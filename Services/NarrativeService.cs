/**
 * geetRPCS - Narrative Service
 * Manages dynamic text responses for the RPC
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using geetRPCS.Models;

namespace geetRPCS.Services
{
    public static class NarrativeService
    {
        // --- Models ---
        private class CacheEntry
        {
            public string Text { get; set; }
            public DateTime LastUpdated { get; set; }
        }
        private static readonly Dictionary<string, CacheEntry> _sessionTexts = new Dictionary<string, CacheEntry>(StringComparer.OrdinalIgnoreCase);
        private static Dictionary<string, List<string>> _wittyTexts;
        private static readonly Random _random = new Random();
        private static readonly object _lock = new object();
        private static readonly TimeSpan _rotationInterval = TimeSpan.FromSeconds(60);
        private static readonly string WittyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "witty.json");
        static NarrativeService()
        {
            LoadWittyTexts();
        }
        private static void LoadWittyTexts()
        {
            try
            {
                if (File.Exists(WittyPath))
                {
                    System.Diagnostics.Debug.WriteLine($"[NarrativeService] Loading witty.json from: {WittyPath}");
                    string json = File.ReadAllText(WittyPath);
                    var loaded = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    _wittyTexts = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
                    if (loaded != null)
                    {
                        foreach (var kvp in loaded)
                        {
                            if (kvp.Value.ValueKind == JsonValueKind.Array)
                            {
                                try
                                {
                                    var texts = kvp.Value.Deserialize<List<string>>();
                                    if (texts != null)
                                    {
                                        _wittyTexts[kvp.Key] = texts;
                                    }
                                }
                                catch
                                {
                                    System.Diagnostics.Debug.WriteLine($"[NarrativeService] Skipping entry '{kvp.Key}' - not a valid string array");
                                }
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine($"[NarrativeService] Skipping non-array entry: '{kvp.Key}'");
                            }
                        }
                        System.Diagnostics.Debug.WriteLine($"[NarrativeService] Loaded {_wittyTexts.Count} process entries from witty.json");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"[NarrativeService] Failed to deserialize witty.json");
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[NarrativeService] witty.json not found at: {WittyPath}");
                    _wittyTexts = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[NarrativeService] Error loading witty.json: {ex.Message}");
                _wittyTexts = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            }
        }
        public static void Reload()
        {
            lock (_lock)
            {
                LoadWittyTexts();
                _sessionTexts.Clear();
            }
        }
        public static string GetForApp(string processName)
        {
            if (string.IsNullOrEmpty(processName)) return "";
            lock (_lock)
            {
                System.Diagnostics.Debug.WriteLine($"[NarrativeService] Looking for witty text for process: '{processName}'");
                System.Diagnostics.Debug.WriteLine($"[NarrativeService] Dictionary has {_wittyTexts.Count} entries");
                if (_sessionTexts.TryGetValue(processName, out var entry))
                {
                    if (DateTime.Now - entry.LastUpdated < _rotationInterval)
                    {
                        System.Diagnostics.Debug.WriteLine($"[NarrativeService] Returning cached text: '{entry.Text}'");
                        return entry.Text;
                    }
                }
                string selectedText;
                if (_wittyTexts.TryGetValue(processName, out var texts) && texts != null && texts.Count > 0)
                {
                    System.Diagnostics.Debug.WriteLine($"[NarrativeService] Found {texts.Count} witty texts for '{processName}'");
                    if (texts.Count > 1 && entry != null)
                    {
                         string newText;
                         int retry = 0;
                         do
                         {
                             newText = texts[_random.Next(texts.Count)];
                             retry++;
                         } while (newText == entry.Text && retry < 5);
                         selectedText = newText;
                    }
                    else
                    {
                        selectedText = texts[_random.Next(texts.Count)];
                    }
                    System.Diagnostics.Debug.WriteLine($"[NarrativeService] Selected: '{selectedText}'");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[NarrativeService] No witty texts found for '{processName}', checking AppConfig...");
                    var app = AppConfigManager.Apps.Find(a => a.Process.Equals(processName, StringComparison.OrdinalIgnoreCase));
                    if (app != null && app.WittyTexts != null && app.WittyTexts.Count > 0)
                    {
                        System.Diagnostics.Debug.WriteLine($"[NarrativeService] Found {app.WittyTexts.Count} texts in AppConfig");
                        if (app.WittyTexts.Count > 1 && entry != null)
                        {
                             string newText;
                             int retry = 0;
                             do
                             {
                                 newText = app.WittyTexts[_random.Next(app.WittyTexts.Count)];
                                 retry++;
                             } while (newText == entry.Text && retry < 5);
                             selectedText = newText;
                        }
                        else
                        {
                            selectedText = app.WittyTexts[_random.Next(app.WittyTexts.Count)];
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"[NarrativeService] Using fallback text");
                        selectedText = "Working hard... 🔨";
                    }
                }
                _sessionTexts[processName] = new CacheEntry { Text = selectedText, LastUpdated = DateTime.Now };
                return selectedText;
            }
        }
        public static bool ShouldRotate(string processName)
        {
             lock (_lock)
             {
                 if (_sessionTexts.TryGetValue(processName, out var entry))
                 {
                     return (DateTime.Now - entry.LastUpdated) >= _rotationInterval;
                 }
                 return true; // No entry means we need one
             }
        }
        public static void ResetForApp(string processName)
        {
            lock (_lock)
            {
                if (_sessionTexts.ContainsKey(processName))
                    _sessionTexts.Remove(processName);
            }
        }
        public static void ResetAll()
        {
            lock (_lock)
            {
                _sessionTexts.Clear();
            }
        }
    }
}
