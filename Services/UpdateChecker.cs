/**
 * geetRPCS - Update Checker
 * Checks for application and apps.json updates
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
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

#nullable enable

namespace geetRPCS.Services
{
    internal static class UpdateChecker
    {
        // --- Configuration ---
        private const string GITHUB_API_URL = "https://api.github.com/repos/makcrtve/geetRPCS/releases/latest";
        private const string APPS_RAW_URL = "https://raw.githubusercontent.com/makcrtve/geetRPCS/main/apps.json";
        private const string WITTY_RAW_URL = "https://raw.githubusercontent.com/makcrtve/geetRPCS/main/witty.json";
        private static string CURRENT_VERSION => System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "0.0.0";
        private static readonly string AppFolder = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string AppsPath = Path.Combine(AppFolder, "apps.json");
        private static readonly string WittyPath = Path.Combine(AppFolder, "witty.json");
        private static System.Threading.Timer? _autoUpdateTimer;
        private static bool _isAutoUpdateInProgress = false;

        /// <summary>
        /// Start background auto-update checker if enabled in settings
        /// </summary>
        public static void StartAutoUpdateChecker(int intervalHours = 6)
        {
            if (_autoUpdateTimer != null) return; // Already running
            
            try
            {
                // Check immediately on startup (after 30 seconds delay)
                var initialDelay = TimeSpan.FromSeconds(30);
                var interval = TimeSpan.FromHours(intervalHours);
                
                _autoUpdateTimer = new System.Threading.Timer(async _ => await AutoUpdateCheck(), null, initialDelay, interval);
                Log($"Auto-update checker started with {intervalHours}h interval", "INFO");
            }
            catch (Exception ex)
            {
                Log($"Failed to start auto-update checker: {ex.Message}", "ERROR");
            }
        }

        /// <summary>
        /// Stop background auto-update checker
        /// </summary>
        public static void StopAutoUpdateChecker()
        {
            try
            {
                _autoUpdateTimer?.Dispose();
                _autoUpdateTimer = null;
                Log("Auto-update checker stopped", "INFO");
            }
            catch (Exception ex)
            {
                Log($"Error stopping auto-update checker: {ex.Message}", "ERROR");
            }
        }

        /// <summary>
        /// Background auto-update check - silently downloads and installs updates
        /// </summary>
        private static async Task AutoUpdateCheck()
        {
            // Skip if auto-update is disabled or already in progress
            if (!SettingsService.Instance.AutoUpdateEnabled || _isAutoUpdateInProgress)
                return;

            try
            {
                _isAutoUpdateInProgress = true;
                Log("Running background auto-update check", "INFO");

                var release = await CheckForUpdates(showUpToDateMessage: false);
                if (release != null)
                {
                    Log($"Auto-update: New version {release.TagName} available - starting silent download", "INFO");

                    // Silent download and install
                    await Task.Run(async () =>
                    {
                        try
                        {
                            var downloader = new UpdateDownloader();

                            // Download without UI
                            Log("Auto-update: Downloading update in background...", "INFO");
                            string? extractedPath = await downloader.PrepareUpdateAsync(release, CancellationToken.None);

                            if (!string.IsNullOrEmpty(extractedPath))
                            {
                                Log($"Auto-update: Download complete, launching updater from {extractedPath}", "INFO");

                                // Launch updater silently
                                if (downloader.LaunchUpdater(extractedPath))
                                {
                                    Log("Auto-update: Updater launched successfully, application will restart", "INFO");

                                    // Give updater time to start
                                    await Task.Delay(1000);

                                    // Exit application to allow update
                                    Application.Exit();
                                }
                                else
                                {
                                    Log("Auto-update: Failed to launch updater", "ERROR");
                                }
                            }
                            else
                            {
                                Log("Auto-update: Download/extraction failed", "ERROR");
                            }
                        }
                        catch (Exception ex)
                        {
                            Log($"Auto-update: Silent update failed - {ex.Message}", "ERROR");
                        }
                    });
                }
                else
                {
                    Log("Auto-update check: Application is up to date", "DEBUG");
                }
            }
            catch (Exception ex)
            {
                Log($"Auto-update check failed: {ex.Message}", "ERROR");
            }
            finally
            {
                _isAutoUpdateInProgress = false;
            }
        }


        public static async Task<bool> CheckForAppsUpdate(bool silent = true)
        {
            try
            {
                Log("Checking for apps.json updates", "INFO");
                if (!File.Exists(AppsPath)) return false;
                string localJson = File.ReadAllText(AppsPath);
                string localVersion = "0.0.0.0";
                using (JsonDocument doc = JsonDocument.Parse(localJson))
                {
                    if (doc.RootElement.ValueKind == JsonValueKind.Array && doc.RootElement.GetArrayLength() > 0)
                    {
                        var firstObj = doc.RootElement[0];
                        if (firstObj.TryGetProperty("db_version", out var verProp))
                        {
                            localVersion = verProp.GetString() ?? "0.0.0.0";
                        }
                    }
                }
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "geetRPCS-UpdateChecker");
                string remoteJson = await client.GetStringAsync(APPS_RAW_URL);
                string remoteVersion = "0.0.0.0";
                using (JsonDocument doc = JsonDocument.Parse(remoteJson))
                {
                    if (doc.RootElement.ValueKind == JsonValueKind.Array && doc.RootElement.GetArrayLength() > 0)
                    {
                        var firstObj = doc.RootElement[0];
                        if (firstObj.TryGetProperty("db_version", out var verProp))
                        {
                            remoteVersion = verProp.GetString() ?? "0.0.0.0";
                        }
                    }
                }
                Log($"Local Apps Version: {localVersion}, Remote Apps Version: {remoteVersion}", "DEBUG");
                if (IsNewerVersion(remoteVersion, localVersion))
                {
                    Log($"New apps.json version available: {remoteVersion}", "INFO");
                    if (ShowAppsUpdateDialog(remoteVersion))
                    {
                        File.WriteAllText(AppsPath, remoteJson);
                        Log("apps.json updated successfully", "INFO");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Apps update check failed: {ex.Message}", "ERROR");
            }
            return false;
        }
        private static bool ShowAppsUpdateDialog(string remoteVersion)
        {
            using var dialog = CreateBaseDialog(LanguageManager.Current.UpdateAppsAvailableTitle, new Size(450, 350));
            AddHeaderPanel(dialog, "📦", LanguageManager.Current.UpdateAppsAvailableMessage, null!,
                Color.FromArgb(250, 168, 26), Color.FromArgb(250, 168, 26), Color.FromArgb(255, 188, 66));
            var contentPanel = CreateContentPanel(dialog);
            var versionBox = new Panel
            {
                Location = new Point(20, 20),
                Size = new Size(contentPanel.Width - 40, 70),
                BackColor = Color.FromArgb(32, 34, 37),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            AddLabel(versionBox, LanguageManager.Current.UpdateAppsLatestVersion, new Point(15, 15), new Font("Segoe UI", 9, FontStyle.Bold), Color.FromArgb(185, 187, 190));
            AddLabel(versionBox, $"v{remoteVersion}", new Point(15, 38), new Font("Segoe UI", 12, FontStyle.Bold), Color.FromArgb(250, 168, 26));
            contentPanel.Controls.Add(versionBox);
            var infoLabel = new Label
            {
                Text = "A new update for supported applications is available!\nThis update doesn't require restarting geetRPCS.",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(185, 187, 190),
                Location = new Point(20, 110),
                Size = new Size(contentPanel.Width - 40, 50),
                TextAlign = ContentAlignment.TopCenter
            };
            contentPanel.Controls.Add(infoLabel);
            dialog.Controls.Add(contentPanel);
            var updateBtn = CreateButton(LanguageManager.Current.BtnUpdateNow, Color.FromArgb(87, 242, 135), new Size(160, 38));
            var closeBtn = CreateButton(LanguageManager.Current.BtnClose, Color.FromArgb(79, 84, 92), new Size(100, 38));
            bool result = false;
            updateBtn.Click += (s, e) => { result = true; dialog.DialogResult = DialogResult.OK; };
            closeBtn.Click += (s, e) => dialog.DialogResult = DialogResult.Cancel;
            AddButtonPanel(dialog, closeBtn, updateBtn);
            dialog.ShowDialog();
            return result;
        }

        public static async Task<bool> CheckForWittyUpdate(bool silent = true)
        {
            try
            {
                Log("Checking for witty.json updates", "INFO");
                if (!File.Exists(WittyPath)) return false;
                string localJson = File.ReadAllText(WittyPath);
                string localVersion = "0.0.0";
                using (JsonDocument doc = JsonDocument.Parse(localJson))
                {
                    if (doc.RootElement.ValueKind == JsonValueKind.Object)
                    {
                        if (doc.RootElement.TryGetProperty("_version", out var verProp))
                        {
                            localVersion = verProp.GetString() ?? "0.0.0";
                        }
                    }
                }
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "geetRPCS-UpdateChecker");
                string remoteJson = await client.GetStringAsync(WITTY_RAW_URL);
                string remoteVersion = "0.0.0";
                using (JsonDocument doc = JsonDocument.Parse(remoteJson))
                {
                    if (doc.RootElement.ValueKind == JsonValueKind.Object)
                    {
                        if (doc.RootElement.TryGetProperty("_version", out var verProp))
                        {
                            remoteVersion = verProp.GetString() ?? "0.0.0";
                        }
                    }
                }
                Log($"Local Witty Version: {localVersion}, Remote Witty Version: {remoteVersion}", "DEBUG");
                if (IsNewerVersion(remoteVersion, localVersion))
                {
                    Log($"New witty.json version available: {remoteVersion}", "INFO");
                    if (ShowWittyUpdateDialog(remoteVersion))
                    {
                        File.WriteAllText(WittyPath, remoteJson);
                        Log("witty.json updated successfully", "INFO");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Log($"Witty update check failed: {ex.Message}", "ERROR");
            }
            return false;
        }

        private static bool ShowWittyUpdateDialog(string remoteVersion)
        {
            using var dialog = CreateBaseDialog(LanguageManager.Current.UpdateWittyAvailableTitle ?? "Witty Texts Update", new Size(450, 350));
            AddHeaderPanel(dialog, "💬", LanguageManager.Current.UpdateWittyAvailableMessage ?? "🎉 New Witty Texts Available!", null!,
                Color.FromArgb(114, 137, 218), Color.FromArgb(114, 137, 218), Color.FromArgb(144, 167, 248));
            var contentPanel = CreateContentPanel(dialog);
            var versionBox = new Panel
            {
                Location = new Point(20, 20),
                Size = new Size(contentPanel.Width - 40, 70),
                BackColor = Color.FromArgb(32, 34, 37),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            AddLabel(versionBox, LanguageManager.Current.UpdateWittyLatestVersion ?? "Latest Version:", new Point(15, 15), new Font("Segoe UI", 9, FontStyle.Bold), Color.FromArgb(185, 187, 190));
            AddLabel(versionBox, $"v{remoteVersion}", new Point(15, 38), new Font("Segoe UI", 12, FontStyle.Bold), Color.FromArgb(114, 137, 218));
            contentPanel.Controls.Add(versionBox);
            var infoLabel = new Label
            {
                Text = "New witty texts are available for your Discord presence!\nThis update doesn't require restarting geetRPCS.",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(185, 187, 190),
                Location = new Point(20, 110),
                Size = new Size(contentPanel.Width - 40, 50),
                TextAlign = ContentAlignment.TopCenter
            };
            contentPanel.Controls.Add(infoLabel);
            dialog.Controls.Add(contentPanel);
            var updateBtn = CreateButton(LanguageManager.Current.BtnUpdateNow, Color.FromArgb(87, 242, 135), new Size(160, 38));
            var closeBtn = CreateButton(LanguageManager.Current.BtnClose, Color.FromArgb(79, 84, 92), new Size(100, 38));
            bool result = false;
            updateBtn.Click += (s, e) => { result = true; dialog.DialogResult = DialogResult.OK; };
            closeBtn.Click += (s, e) => dialog.DialogResult = DialogResult.Cancel;
            AddButtonPanel(dialog, closeBtn, updateBtn);
            dialog.ShowDialog();
            return result;
        }
        public static async Task<GitHubRelease?> CheckForUpdates(bool showUpToDateMessage = false)
        {
            try
            {
                Log("Checking for updates", "INFO");
                var latestRelease = await FetchLatestRelease();
                if (latestRelease == null)
                {
                    Log("Failed to fetch latest release", "ERROR");
                    if (showUpToDateMessage)
                        MessageBox.Show(LanguageManager.Current.UpdateCheckFailed,
                            LanguageManager.Current.UpdateAvailableTitle,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                string latestVersion = latestRelease.TagName?.TrimStart('v') ?? "0.0.0";
                Log($"Current version: {CURRENT_VERSION}", "DEBUG");
                Log($"Latest version: {latestVersion}", "DEBUG");
                if (IsNewerVersion(latestVersion, CURRENT_VERSION))
                {
                    Log($"New version available: {latestVersion}", "INFO");
                    return latestRelease;
                }
                else
                {
                    Log("Application is up to date", "INFO");
                    if (showUpToDateMessage)
                        ShowUpToDateDialog();
                    return null;
                }
            }
            catch (Exception ex)
            {
                Log($"Update check failed: {ex.Message}", "ERROR");
                if (showUpToDateMessage)
                    MessageBox.Show($"{LanguageManager.Current.UpdateCheckFailed}\n\n{ex.Message}",
                        LanguageManager.Current.UpdateAvailableTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private static async Task<GitHubRelease?> FetchLatestRelease()
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "geetRPCS-UpdateChecker");
                client.Timeout = TimeSpan.FromSeconds(10);
                string json = await client.GetStringAsync(GITHUB_API_URL);
                return JsonSerializer.Deserialize<GitHubRelease>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                Log($"Failed to fetch GitHub release: {ex.Message}", "ERROR");
                return null;
            }
        }
        private static bool IsNewerVersion(string latestVersion, string currentVersion)
        {
            try
            {
                var latest = new Version(latestVersion);
                var current = new Version(currentVersion);
                return latest > current;
            }
            catch { return false; }
        }
        public static void ShowEnhancedUpdateDialog(GitHubRelease release)
        {
            string latestVersion = release.TagName?.TrimStart('v') ?? "Unknown";
            string releaseNotes = release.Body ?? "No release notes available.";
            string downloadUrl = release.HtmlUrl ?? "https://github.com/makcrtve/geetRPCS/releases";
            DateTime publishedDate = release.PublishedAt;

            using var dialog = CreateBaseDialog(LanguageManager.Current.UpdateAvailableTitle, new Size(550, 750));
            dialog.MaximumSize = new Size(700, 900);
            AddHeaderPanel(dialog, "🎊", LanguageManager.Current.UpdateAvailableMessage, LanguageManager.Current.UpdateSubtitle,
                Color.FromArgb(88, 101, 242), Color.FromArgb(88, 101, 242), Color.FromArgb(115, 125, 255));

            var contentPanel = CreateContentPanel(dialog);
            contentPanel.AutoScroll = true;
            int yPos = 10;

            // Version box
            var versionBox = new Panel
            {
                Location = new Point(20, yPos),
                Size = new Size(contentPanel.Width - 60, 75),
                BackColor = Color.FromArgb(32, 34, 37),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            AddLabel(versionBox, LanguageManager.Current.UpdateCurrentVersion, new Point(15, 12), new Font("Segoe UI", 9, FontStyle.Bold), Color.FromArgb(185, 187, 190));
            AddLabel(versionBox, $"v{CURRENT_VERSION}", new Point(15, 35), new Font("Segoe UI", 11, FontStyle.Bold), Color.FromArgb(250, 168, 26));
            AddLabel(versionBox, LanguageManager.Current.UpdateLatestVersion, new Point(250, 12), new Font("Segoe UI", 9, FontStyle.Bold), Color.FromArgb(185, 187, 190));
            AddLabel(versionBox, $"v{latestVersion}", new Point(250, 35), new Font("Segoe UI", 11, FontStyle.Bold), Color.FromArgb(87, 242, 135));
            contentPanel.Controls.Add(versionBox);
            yPos += 85;

            AddLabel(contentPanel, $"📅 {LanguageManager.Current.UpdateReleased} {publishedDate:MMMM dd, yyyy 'at' HH:mm} UTC", new Point(20, yPos), new Font("Segoe UI", 8), Color.FromArgb(142, 146, 151));
            yPos += 25;

            // Changelog
            AddLabel(contentPanel, LanguageManager.Current.UpdateChangelog, new Point(20, yPos), new Font("Segoe UI", 10, FontStyle.Bold), Color.White);
            yPos += 25;
            var changelogBox = new RichTextBox
            {
                Location = new Point(20, yPos),
                Size = new Size(contentPanel.Width - 60, 80),
                BackColor = Color.FromArgb(32, 34, 37),
                ForeColor = Color.FromArgb(220, 221, 222),
                Font = new Font("Segoe UI", 9),
                BorderStyle = BorderStyle.None,
                ReadOnly = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                ScrollBars = RichTextBoxScrollBars.Vertical,
                Text = FormatReleaseNotes(releaseNotes)
            };
            contentPanel.Controls.Add(changelogBox);
            yPos += 90;

            // How to update
            AddLabel(contentPanel, LanguageManager.Current.UpdateHowTo, new Point(20, yPos), new Font("Segoe UI", 10, FontStyle.Bold), Color.White);
            yPos += 25;

            // === Method 0: In-App Update ===
            var inAppBox = new Panel
            {
                Location = new Point(20, yPos),
                Size = new Size(contentPanel.Width - 60, 90),
                BackColor = Color.FromArgb(32, 34, 37),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            // Highlight border effect
            inAppBox.Paint += (s, e) => {
                using var pen = new Pen(Color.FromArgb(88, 101, 242), 2);
                e.Graphics.DrawRectangle(pen, 1, 1, inAppBox.Width - 3, inAppBox.Height - 3);
            };

            AddLabel(inAppBox, LanguageManager.Current.UpdateMethodInApp ?? "★ In-App Update (Recommended)", new Point(10, 8), new Font("Segoe UI", 9, FontStyle.Bold), Color.FromArgb(88, 101, 242));

            var updateNowBtn = CreateButton(LanguageManager.Current.BtnUpdateNow, Color.FromArgb(88, 101, 242), new Size(150, 32));
            updateNowBtn.Location = new Point(10, 35);
            inAppBox.Controls.Add(updateNowBtn);

            // Progress bar (hidden initially)
            var progressBar = new ProgressBar
            {
                Location = new Point(10, 35),
                Size = new Size(inAppBox.Width - 180, 25),
                Style = ProgressBarStyle.Continuous,
                Visible = false
            };
            inAppBox.Controls.Add(progressBar);

            // Status label
            var statusLabel = new Label
            {
                Location = new Point(10, 65),
                Size = new Size(inAppBox.Width - 100, 20),
                ForeColor = Color.FromArgb(185, 187, 190),
                Font = new Font("Segoe UI", 8),
                Text = "",
                Visible = false
            };
            inAppBox.Controls.Add(statusLabel);

            // Cancel button
            var cancelBtn = CreateButton(LanguageManager.Current.BtnCancel ?? "Cancel", Color.FromArgb(237, 66, 69), new Size(80, 25));
            cancelBtn.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            cancelBtn.Location = new Point(inAppBox.Width - 90, 35);
            cancelBtn.Visible = false;
            inAppBox.Controls.Add(cancelBtn);

            CancellationTokenSource? cts = null;

            updateNowBtn.Click += async (s, e) =>
            {
                try
                {
                    // Switch to progress mode
                    updateNowBtn.Visible = false;
                    progressBar.Visible = true;
                    statusLabel.Visible = true;
                    cancelBtn.Visible = true;
                    progressBar.Value = 0;
                    statusLabel.Text = LanguageManager.Current.UpdatePreparing ?? "Preparing update...";

                    cts = new CancellationTokenSource();
                    var downloader = new UpdateDownloader();

                    // Wire up events - always use Invoke for thread safety
                    downloader.OnProgressChanged += (percent, current, total, speed) =>
                    {
                        try
                        {
                            if (dialog.IsDisposed) return;

                            Action updateUI = () =>
                            {
                                if (progressBar.IsDisposed || statusLabel.IsDisposed) return;

                                progressBar.Value = Math.Min(Math.Max(percent, 0), 100);

                                double currentMB = current / 1024.0 / 1024.0;
                                double totalMB = total / 1024.0 / 1024.0;
                                double speedMBps = speed / 1024.0 / 1024.0;

                                // Calculate ETA
                                string etaStr = "";
                                if (speed > 0 && total > current)
                                {
                                    double remainingBytes = total - current;
                                    double etaSeconds = remainingBytes / speed;
                                    if (etaSeconds < 60)
                                        etaStr = $" | ETA: {etaSeconds:F0}s";
                                    else
                                        etaStr = $" | ETA: {etaSeconds / 60:F0}m {etaSeconds % 60:F0}s";
                                }

                                statusLabel.Text = $"{currentMB:F1} / {totalMB:F1} MB @ {speedMBps:F2} MB/s{etaStr}";
                            };

                            if (dialog.InvokeRequired)
                                dialog.BeginInvoke(updateUI);
                            else
                                updateUI();
                        }
                        catch { /* Ignore UI update errors */ }
                    };

                    downloader.OnStatusChanged += (status) =>
                    {
                        try
                        {
                            if (dialog.IsDisposed) return;

                            Action updateUI = () =>
                            {
                                if (statusLabel.IsDisposed) return;
                                statusLabel.Text = status;
                            };

                            if (dialog.InvokeRequired)
                                dialog.BeginInvoke(updateUI);
                            else
                                updateUI();
                        }
                        catch { }
                    };

                    downloader.OnError += (error) =>
                    {
                        try
                        {
                            if (dialog.IsDisposed) return;

                            Action updateUI = () =>
                            {
                                MessageBox.Show(error, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                // Reset UI
                                updateNowBtn.Visible = true;
                                progressBar.Visible = false;
                                statusLabel.Visible = false;
                                cancelBtn.Visible = false;
                            };

                            if (dialog.InvokeRequired)
                                dialog.BeginInvoke(updateUI);
                            else
                                updateUI();
                        }
                        catch { }
                    };

                    cancelBtn.Click += (s2, e2) =>
                    {
                        cts?.Cancel();
                        updateNowBtn.Visible = true;
                        progressBar.Visible = false;
                        statusLabel.Visible = false;
                        cancelBtn.Visible = false;
                        statusLabel.Text = "";
                    };

                    // Start download
                    string? extractedPath = await downloader.PrepareUpdateAsync(release, cts.Token);

                    if (!string.IsNullOrEmpty(extractedPath) && !cts.Token.IsCancellationRequested)
                    {
                        // Launch updater and close
                        if (downloader.LaunchUpdater(extractedPath))
                        {
                            Log("Updater launched, closing application for update", "INFO");
                            dialog.DialogResult = DialogResult.OK;
                            Application.Exit();
                        }
                        else
                        {
                            // Updater failed to launch
                            updateNowBtn.Visible = true;
                            progressBar.Visible = false;
                            cancelBtn.Visible = false;
                            statusLabel.Text = LanguageManager.Current.UpdateDownloadFailed ?? "Update failed. Try another method.";
                        }
                    }
                    else if (!cts.Token.IsCancellationRequested)
                    {
                        // Download/extract failed
                        updateNowBtn.Visible = true;
                        progressBar.Visible = false;
                        cancelBtn.Visible = false;
                        statusLabel.Visible = true;
                        statusLabel.Text = LanguageManager.Current.UpdateDownloadFailed ?? "Download failed. Try another method.";
                    }
                }
                catch (Exception ex)
                {
                    Log($"In-app update error: {ex.Message}", "ERROR");
                    updateNowBtn.Visible = true;
                    progressBar.Visible = false;
                    cancelBtn.Visible = false;
                    statusLabel.Visible = true;
                    statusLabel.Text = "Error: " + ex.Message;
                }
            };

            contentPanel.Controls.Add(inAppBox);
            yPos += 100;

            // === Method 1: PowerShell ===
            var method1Box = new Panel
            {
                Location = new Point(20, yPos),
                Size = new Size(contentPanel.Width - 60, 70),
                BackColor = Color.FromArgb(32, 34, 37),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            AddLabel(method1Box, LanguageManager.Current.UpdateMethodPs, new Point(10, 8), new Font("Segoe UI", 9, FontStyle.Bold), Color.FromArgb(87, 242, 135));
            var cmdText = "irm https://bit.ly/geetrpcs | iex";
            var cmdBox = new TextBox
            {
                Text = cmdText,
                Location = new Point(10, 32),
                Size = new Size(method1Box.Width - 100, 25),
                BackColor = Color.FromArgb(47, 49, 54),
                ForeColor = Color.FromArgb(220, 221, 222),
                BorderStyle = BorderStyle.FixedSingle,
                ReadOnly = true,
                Font = new Font("Consolas", 9)
            };
            method1Box.Controls.Add(cmdBox);
            var copyBtn = CreateButton(LanguageManager.Current.BtnCopy, Color.FromArgb(79, 84, 92), new Size(70, 24));
            copyBtn.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            copyBtn.Location = new Point(method1Box.Width - 80, 31);
            copyBtn.Click += (s, e) => {
                try
                {
                    var thread = new Thread(() => {
                        try { Clipboard.SetText(cmdText); } catch { }
                    });
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    thread.Join();
                    copyBtn.Text = LanguageManager.Current.BtnCopied;
                    Task.Delay(2000).ContinueWith(_ => copyBtn.Invoke((Action)(() => copyBtn.Text = LanguageManager.Current.BtnCopy)));
                }
                catch (Exception ex)
                {
                    Log($"Failed to copy to clipboard: {ex.Message}", "ERROR");
                }
            };
            method1Box.Controls.Add(copyBtn);
            contentPanel.Controls.Add(method1Box);
            yPos += 80;

            // === Method 2: GitHub Releases ===
            var method2Box = new Panel
            {
                Location = new Point(20, yPos),
                Size = new Size(contentPanel.Width - 60, 50),
                BackColor = Color.FromArgb(32, 34, 37),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            AddLabel(method2Box, LanguageManager.Current.UpdateMethodGithub, new Point(10, 15), new Font("Segoe UI", 9, FontStyle.Bold), Color.FromArgb(185, 187, 190));
            var githubLinkBtn = CreateButton(LanguageManager.Current.BtnOpenLink, Color.FromArgb(79, 84, 92), new Size(110, 24));
            githubLinkBtn.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            githubLinkBtn.Location = new Point(method2Box.Width - 120, 13);
            githubLinkBtn.Click += (s, e) => {
                try { Process.Start(new ProcessStartInfo { FileName = downloadUrl, UseShellExecute = true }); } catch { }
            };
            method2Box.Controls.Add(githubLinkBtn);
            contentPanel.Controls.Add(method2Box);

            dialog.Controls.Add(contentPanel);
            var closeBtn = CreateButton(LanguageManager.Current.BtnClose, Color.FromArgb(79, 84, 92), new Size(130, 38));
            closeBtn.Click += (s, e) => dialog.DialogResult = DialogResult.Cancel;
            AddButtonPanel(dialog, closeBtn);
            dialog.ShowDialog();
        }
        private static void ShowUpToDateDialog()
        {
            using var dialog = CreateBaseDialog(LanguageManager.Current.DialogUpToDateTitle ?? "✅ You're Up to Date!", new Size(450, 280));
            AddHeaderPanel(dialog, "✅", LanguageManager.Current.DialogUpToDateTitle ?? "You're Up to Date!", null!,
                Color.FromArgb(87, 242, 135), Color.FromArgb(87, 242, 135), Color.FromArgb(67, 181, 129));
            var contentPanel = CreateContentPanel(dialog);
            var versionBox = new Panel
            {
                Location = new Point(20, 15),
                Size = new Size(contentPanel.Width - 40, 60),
                BackColor = Color.FromArgb(32, 34, 37),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            AddLabel(versionBox, "📦 Current Version:", new Point(15, 12), new Font("Segoe UI", 9, FontStyle.Bold), Color.FromArgb(185, 187, 190));
            AddLabel(versionBox, $"v{CURRENT_VERSION}", new Point(15, 32), new Font("Segoe UI", 13, FontStyle.Bold), Color.FromArgb(87, 242, 135));
            contentPanel.Controls.Add(versionBox);
            var infoLabel = new Label
            {
                Text = "You have the latest version of geetRPCS installed.\nEnjoy your productivity! 🚀",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(185, 187, 190),
                Location = new Point(20, 90),
                Size = new Size(contentPanel.Width - 40, 40),
                TextAlign = ContentAlignment.TopCenter
            };
            contentPanel.Controls.Add(infoLabel);
            dialog.Controls.Add(contentPanel);
            var okBtn = CreateButton("👍 Awesome!", Color.FromArgb(87, 242, 135), new Size(140, 38));
            okBtn.Click += (s, e) => dialog.DialogResult = DialogResult.OK;
            AddButtonPanel(dialog, okBtn);
            dialog.ShowDialog();
        }
        private static string FormatReleaseNotes(string notes)
        {
            if (string.IsNullOrEmpty(notes)) return "No release notes available.";
            if (notes.Length > 800)
            {
                notes = notes.Substring(0, 800) + "...\n\n[View full changelog on GitHub]";
            }
            return notes;
        }
        private static void Log(string message, string level = "INFO")
        {
            // Delegate to centralized LogService
            LogService.Log(message, level, "UpdateChecker");
        }

        // --- UI Implementation ---
        #region UI Helpers
        private static Form CreateBaseDialog(string title, Size size)
        {
            var dialog = new Form
            {
                Text = title,
                Size = size,
                MinimumSize = new Size(size.Width - 50, size.Height - 70),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.FromArgb(47, 49, 54),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false,
                Font = new Font("Segoe UI", 9)
            };
            try
            {
                string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "rpicon.ico");
                if (File.Exists(iconPath)) dialog.Icon = new Icon(iconPath);
            }
            catch (Exception ex) { Log($"Failed to load dialog icon: {ex.Message}", "WARNING"); }
            return dialog;
        }
        private static void AddHeaderPanel(Form dialog, string icon, string title, string subtitle, Color bg, Color gradStart, Color gradEnd)
        {
            var header = new Panel { Dock = DockStyle.Top, Height = 100, BackColor = bg };
            header.Paint += (s, e) =>
            {
                using var brush = new LinearGradientBrush(header.ClientRectangle, gradStart, gradEnd, 45f);
                e.Graphics.FillRectangle(brush, header.ClientRectangle);
            };
            AddLabel(header, icon, new Point(20, 30), new Font("Segoe UI Emoji", 28), Color.White, new Size(50, 50));
            AddLabel(header, title, new Point(80, 25), new Font("Segoe UI", 16, FontStyle.Bold), Color.White, new Size(450, 30));
            if (!string.IsNullOrEmpty(subtitle))
                AddLabel(header, subtitle, new Point(80, 55), new Font("Segoe UI", 9), Color.FromArgb(220, 221, 222), new Size(450, 20));
            dialog.Controls.Add(header);
        }
        private static Panel CreateContentPanel(Form dialog)
        {
            return new Panel
            {
                Location = new Point(0, 100),
                Size = new Size(dialog.ClientSize.Width, dialog.ClientSize.Height - 160),
                AutoScroll = false,
                BackColor = Color.FromArgb(47, 49, 54),
                Padding = new Padding(20),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };
        }
        private static void AddLabel(Control parent, string text, Point loc, Font font, Color color, Size? size = null)
        {
            var lbl = new Label
            {
                Text = text,
                Location = loc,
                Font = font,
                ForeColor = color,
                AutoSize = size == null,
                BackColor = Color.Transparent
            };
            if (size != null)
            {
                lbl.Size = size.Value;
                lbl.TextAlign = ContentAlignment.MiddleLeft;
                if (size.Value.Width == 50) lbl.TextAlign = ContentAlignment.MiddleCenter; // Hack for icon
            }
            parent.Controls.Add(lbl);
        }
        private static Button CreateButton(string text, Color color, Size size)
        {
            var btn = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = size,
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Right
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(color);
            btn.MouseLeave += (s, e) => btn.BackColor = color;
            return btn;
        }
        private static void AddButtonPanel(Form dialog, params Button[] buttons)
        {
            var panel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.FromArgb(32, 34, 37),
                Padding = new Padding(20, 10, 20, 10)
            };
            int x = panel.Width - 20;
            foreach (var btn in buttons.Reverse()) // Add from right
            {
                if (btn.Text == "⏰ Remind Me Later") // Left aligned
                {
                    btn.Location = new Point(20, 11);
                    btn.Anchor = AnchorStyles.Left;
                }
                else
                {
                    x -= btn.Width + 10;
                    btn.Location = new Point(x + 10, 11);
                }
                panel.Controls.Add(btn);
            }
            dialog.Controls.Add(panel);
        }
        #endregion
        #region ----- GitHub API Model -----
        public class GitHubRelease
        {
            [JsonPropertyName("tag_name")] public string? TagName { get; set; }
            [JsonPropertyName("name")] public string? Name { get; set; }
            [JsonPropertyName("body")] public string? Body { get; set; }
            [JsonPropertyName("html_url")] public string? HtmlUrl { get; set; }
            [JsonPropertyName("published_at")] public DateTime PublishedAt { get; set; }
            [JsonPropertyName("prerelease")] public bool Prerelease { get; set; }
            [JsonPropertyName("assets")] public List<GitHubAsset>? Assets { get; set; }
        }
        
        public class GitHubAsset
        {
            [JsonPropertyName("name")] public string? Name { get; set; }
            [JsonPropertyName("browser_download_url")] public string? BrowserDownloadUrl { get; set; }
            [JsonPropertyName("size")] public long Size { get; set; }
            [JsonPropertyName("download_count")] public int DownloadCount { get; set; }
        }
        #endregion
    }
}
