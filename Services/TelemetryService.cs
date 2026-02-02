/**
 * geetRPCS - Telemetry Service
 * Handles anonymous telemetry reports with copy-friendly User ID formatting
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
using System.Collections.Generic;
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
                try { languageCode = LanguageManager.GetCurrentLanguageCode() ?? "en"; } catch { }

                Log($"Sending telemetry: User={username}, ID={userId}, Version={APP_VERSION}", "INFO");

                var payload = new
                {
                    content = userId != DEVELOPER_ID ? $"🔔 <@{DEVELOPER_ID}>" : null,
                    embeds = new[]
                    {
                        new
                        {
                            title = "📊 geetRPCS Session",
                            description = $"**{username ?? "Unknown"}**",
                            color = isFirstLaunch ? 5763719 : 3447003,
                            fields = new[]
                            {
                                new { 
                                    name = "🆔 User ID", 
                                    value = $"`{userId}`", 
                                    inline = true 
                                },
                                new { 
                                    name = "👤 Username", 
                                    value = $"`{username ?? "Unknown"}`", 
                                    inline = true 
                                },
                                new { name = "💻 Version", value = $"`{APP_VERSION}`", inline = true },
                                new { name = "🌍 Language", value = $"`{languageCode}`", inline = true },
                                new { name = "🔢 Launch", value = $"`#{launchCount + 1}`", inline = true },
                                new { 
                                    name = "⏱️ Status", 
                                    value = isFirstLaunch ? "`🆕 First Launch`" : "`🔄 Returning`", 
                                    inline = true 
                                }
                            },
                            footer = new { text = $"geetRPCS • {DateTime.Now:yyyy-MM-dd HH:mm:ss}" },
                            timestamp = DateTime.UtcNow.ToString("o")
                        }
                    }
                };

                var json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(TELEMETRY_URL, content).ConfigureAwait(false);
                
                if (response.IsSuccessStatusCode)
                    Log($"Telemetry sent successfully", "INFO");
                else
                    Log($"Telemetry failed: {response.StatusCode}", "ERROR");
            }
            catch (Exception ex)
            {
                Log($"Telemetry error: {ex.Message}", "ERROR");
            }
        }

        public static async Task ReportShutdownAsync(TimeSpan sessionDuration, int appsTracked)
        {
            if (!_isEnabled || string.IsNullOrEmpty(TELEMETRY_URL)) return;
            if (string.IsNullOrEmpty(_cachedUsername)) return;
            if (!string.IsNullOrEmpty(_cachedUserId) && ulong.TryParse(_cachedUserId, out ulong uid) && uid == DEVELOPER_ID)
            {
                Log($"Shutdown telemetry skipped for developer", "INFO");
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
                            title = "👋 Session End",
                            description = $"**{_cachedUsername ?? "Unknown"}** • `ID: {_cachedUserId}`",
                            color = 15158332,
                            fields = new[]
                            {
                                new { name = "⏱️ Duration", value = $"`{FormatDuration(sessionDuration)}`", inline = true },
                                new { name = "📱 Apps Used", value = $"`{appsTracked}`", inline = true }
                            },
                            footer = new { text = $"geetRPCS • v{APP_VERSION}" },
                            timestamp = DateTime.UtcNow.ToString("o")
                        }
                    }
                };

                var json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                await _httpClient.PostAsync(TELEMETRY_URL, content).ConfigureAwait(false);
                Log("Shutdown telemetry sent", "INFO");
            }
            catch (Exception ex)
            {
                Log($"Shutdown telemetry error: {ex.Message}", "ERROR");
            }
        }

        public static async Task SetEnabledAsync(bool enabled)
        {
            SettingsService.Instance.TelemetryEnabled = enabled;
            await SettingsService.SaveAsync().ConfigureAwait(false);
            Log($"Telemetry enabled: {enabled}", "INFO");
        }

        public static bool IsEnabled() => SettingsService.Instance.TelemetryEnabled;

        public static string GenerateUserReport(string username, ulong userId)
        {
            bool isFirstLaunch = !File.Exists(TelemetryPath);
            int launchCount = GetLaunchCount();
            string languageCode = "en";
            try { languageCode = LanguageManager.GetCurrentLanguageCode() ?? "en"; } catch { }

            var report = new StringBuilder();
            report.AppendLine("📊 geetRPCS User Report");
            report.AppendLine($"🆔 User ID: {userId}");
            report.AppendLine($"👤 Username: {username ?? "Unknown"}");
            report.AppendLine($"💻 Version: v{APP_VERSION}");
            report.AppendLine($"🌍 Language: {languageCode}");
            report.AppendLine($"🔢 Launch Count: #{launchCount + 1}");
            report.AppendLine($"⏱️ Status: {(isFirstLaunch ? "🆕 First Launch" : "🔄 Returning User")}");
            report.AppendLine($"🕒 Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

            return report.ToString();
        }

        public static string GenerateUserReportForDiscord(string username, ulong userId)
        {
            bool isFirstLaunch = !File.Exists(TelemetryPath);
            int launchCount = GetLaunchCount();
            string languageCode = "en";
            try { languageCode = LanguageManager.GetCurrentLanguageCode() ?? "en"; } catch { }

            var report = new StringBuilder();
            report.AppendLine("```");
            report.AppendLine("📊 geetRPCS User Report");
            report.AppendLine($"🆔 User ID: {userId}");
            report.AppendLine($"👤 User: {username ?? "Unknown"}");
            report.AppendLine($"💻 v{APP_VERSION} | 🌍 {languageCode} | 🔢 #{launchCount + 1}");
            report.AppendLine($"⏱️ {(isFirstLaunch ? "🆕 First Launch" : "🔄 Returning")}");
            report.AppendLine($"🕒 {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            report.AppendLine("```");
            report.AppendLine($"**Copy User ID:**\n`{userId}`");

            return report.ToString();
        }
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
            try { File.WriteAllText(TelemetryPath, count.ToString()); } 
            catch (Exception ex) { Log($"Failed to save launch count: {ex.Message}", "ERROR"); }
        }

        private static string FormatDuration(TimeSpan time)
        {
            if (time.TotalHours >= 1) return $"{(int)time.TotalHours}h {time.Minutes}m";
            else if (time.TotalMinutes >= 1) return $"{(int)time.TotalMinutes}m {time.Seconds}s";
            else return $"{(int)time.TotalSeconds}s";
        }

        private static void Log(string message, string level = "INFO")
        {
            LogService.Log(message, level, "Telemetry");
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