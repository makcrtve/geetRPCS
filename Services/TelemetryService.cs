/**
 * geetRPCS - Telemetry Service
 * Handles anonymous telemetry reports
 */
/*
 * Copyright (c) 2026 makcrtve
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 */

using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace geetRPCS.Services
{
    public static class TelemetryService
    {
        private const string TELEMETRY_URL = "https://geet-rpcs-tel.vercel.app/api/telemetry";
        private static string APP_VERSION => System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
        private const ulong DEVELOPER_ID = 626250175857426452;
        private static readonly string AppFolder = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string TelemetryPath = Path.Combine(AppFolder, ".telemetry");

        private static readonly HttpClient _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
        private static string _cachedUsername, _cachedUserId;
        private static bool _isEnabled => SettingsService.Instance.TelemetryEnabled;

        // --- Public Methods ---
        #region Public Methods
        public static async Task ReportStartupAsync(string username, ulong userId)
        {
            if (!_isEnabled)
            {
                Log("Telemetry disabled, skipping", "INFO");
                return;
            }
            if (string.IsNullOrEmpty(TELEMETRY_URL))
            {
                Log("Webhook URL not configured", "WARNING");
                return;
            }
            _cachedUsername = username;
            _cachedUserId = userId.ToString();
            try
            {
                bool isFirstLaunch = !File.Exists(TelemetryPath);
                int launchCount = GetLaunchCount();
                SaveLaunchCount(launchCount + 1);
                string languageCode = "en";
                try { languageCode = LanguageManager.GetCurrentLanguageCode() ?? "en"; } catch (Exception ex) { Log($"Language detection failed: {ex.Message}", "WARNING"); }
                Log($"Sending telemetry: User={username}, ID={userId}, Version={APP_VERSION}, Lang={languageCode}", "INFO");
                var payload = new
                {
                    content = userId != DEVELOPER_ID ? $"🔔 **New Usage Detected!** <@{DEVELOPER_ID}>" : null,
                    embeds = new[]
                    {
                        new
                        {
                            title = "📊 geetRPCS User Report",
                            color = isFirstLaunch ? 5763719 : 3447003,
                            fields = new[]
                            {
                                new { name = "👤 User", value = $"`{username ?? "Unknown"}`", inline = true },
                                new { name = "🆔 User ID", value = $"`{userId}`", inline = true },
                                new { name = "💻 Version", value = $"`{APP_VERSION}`", inline = true },
                                new { name = "🌍 Language", value = $"`{languageCode}`", inline = true },
                                new { name = "🔢 Launch #", value = $"`{launchCount + 1}`", inline = true },
                                new { name = "⏱️ Session", value = isFirstLaunch ? "🆕 First Launch!" : "🔄 Returning User", inline = true }
                            },
                            footer = new { text = $"Started at {DateTime.Now:yyyy-MM-dd HH:mm:ss} (Local Time)" },
                            timestamp = DateTime.UtcNow.ToString("o")
                        }
                    }
                };
                var json = JsonSerializer.Serialize(payload);
                Log($"Payload: {json}", "DEBUG");
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(TELEMETRY_URL, content).ConfigureAwait(false);
                string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    Log($"Telemetry sent successfully! Status: {response.StatusCode}", "INFO");
                }
                else
                {
                    string errorMsg = $"Telemetry failed: {response.StatusCode}";
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                        errorMsg += " (Vercel URL mungkin salah atau API belum di-deploy)";
                    Log($"{errorMsg} - {responseBody}", "ERROR");
                }
            }
            catch (HttpRequestException ex) { Log($"Telemetry HTTP error: {ex.Message}", "ERROR"); }
            catch (TaskCanceledException) { Log("Telemetry timeout", "ERROR"); }
            catch (Exception ex) { Log($"Telemetry error: {ex.Message}\n{ex.StackTrace}", "ERROR"); }
        }
        public static async Task ReportShutdownAsync(TimeSpan sessionDuration, int appsTracked)
        {
            if (!_isEnabled || string.IsNullOrEmpty(TELEMETRY_URL)) return;
            if (string.IsNullOrEmpty(_cachedUsername)) return;
            if (!string.IsNullOrEmpty(_cachedUserId) && ulong.TryParse(_cachedUserId, out ulong userId) && userId == DEVELOPER_ID)
            {
                Log($"Shutdown telemetry skipped for developer (User ID: {userId})", "INFO");
                return;
            }
            try
            {
                var payload = new
                {
                    embeds = new[]
                    {
                        new
                        {
                            title = "👋 geetRPCS Session Ended",
                            color = 15158332,
                            fields = new[]
                            {
                                new { name = "👤 User", value = $"`{_cachedUsername ?? "Unknown"}`", inline = true },
                                new { name = "🆔 User ID", value = $"`{_cachedUserId ?? "Unknown"}`", inline = true },
                                new { name = "⏱️ Duration", value = $"`{FormatDuration(sessionDuration)}`", inline = true },
                                new { name = "📱 Apps Used", value = $"`{appsTracked}`", inline = true }
                            },
                            footer = new { text = $"Ended at {DateTime.Now:yyyy-MM-dd HH:mm:ss} (Local Time)" }
                        }
                    }
                };
                var json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                await _httpClient.PostAsync(TELEMETRY_URL, content).ConfigureAwait(false);
                Log("Shutdown telemetry sent", "INFO");
            }
            catch (Exception ex) { Log($"Shutdown telemetry error: {ex.Message}", "ERROR"); }
        }
        public static async Task SetEnabledAsync(bool enabled)
        {
            SettingsService.Instance.TelemetryEnabled = enabled;
            await SettingsService.SaveAsync().ConfigureAwait(false);
            Log($"Telemetry enabled: {enabled}", "INFO");
        }
        public static bool IsEnabled() => SettingsService.Instance.TelemetryEnabled;
        #endregion

        // --- Helpers ---
        #region Helpers
        private static int GetLaunchCount()
        {
            try
            {
                if (File.Exists(TelemetryPath))
                {
                    string content = File.ReadAllText(TelemetryPath);
                    if (int.TryParse(content.Trim(), out int count)) return count;
                }
            }
            catch (Exception ex) { Log($"Failed to read launch count: {ex.Message}", "WARNING"); }
            return 0;
        }
        private static void SaveLaunchCount(int count)
        {
            try { File.WriteAllText(TelemetryPath, count.ToString()); } catch (Exception ex) { Log($"Failed to save launch count: {ex.Message}", "ERROR"); }
        }
        private static string FormatDuration(TimeSpan time)
        {
            if (time.TotalHours >= 1) return $"{(int)time.TotalHours}h {time.Minutes}m";
            else if (time.TotalMinutes >= 1) return $"{(int)time.TotalMinutes}m {time.Seconds}s";
            else return $"{(int)time.TotalSeconds}s";
        }
        private static void Log(string message, string level = "INFO")
        {
            // Delegate to centralized LogService
            LogService.Log(message, level, "Telemetry");
            // Also write to telemetry.log for backward compatibility
            try
            {
                string telemetryLog = Path.Combine(AppFolder, "telemetry.log");
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                File.AppendAllText(telemetryLog, $"[{timestamp}] [Telemetry] [{level}] {message}" + Environment.NewLine);
            }
            catch { }
        }
        #endregion
    }
}
