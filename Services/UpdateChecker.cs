/**
 * geetRPCS - Update Checker
 * Handles application and definitions updates from GitHub
 */

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geetRPCS.Services
{
    internal static class UpdateChecker
    {
        // --- Configuration ---
        private const string GITHUB_API_URL = "https://api.github.com/repos/makcrtve/geetRPCS/releases/latest";
        private const string APPS_RAW_URL = "https://raw.githubusercontent.com/makcrtve/geetRPCS/main/apps.json";
        private static string CURRENT_VERSION => System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
        private static readonly string AppFolder = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string AppsPath = Path.Combine(AppFolder, "apps.json");
        private static readonly string LogPath = Path.Combine(AppFolder, "geetRPCS.log");
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
            AddHeaderPanel(dialog, "📦", LanguageManager.Current.UpdateAppsAvailableMessage, null,
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
        public static async Task CheckForUpdates(bool showUpToDateMessage = false)
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
                    return;
                }
                string latestVersion = latestRelease.TagName?.TrimStart('v') ?? "0.0.0";
                Log($"Current version: {CURRENT_VERSION}", "DEBUG");
                Log($"Latest version: {latestVersion}", "DEBUG");
                if (IsNewerVersion(latestVersion, CURRENT_VERSION))
                {
                    Log($"New version available: {latestVersion}", "INFO");
                    ShowEnhancedUpdateDialog(latestRelease);
                }
                else
                {
                    Log("Application is up to date", "INFO");
                    if (showUpToDateMessage)
                        ShowUpToDateDialog();
                }
            }
            catch (Exception ex)
            {
                Log($"Update check failed: {ex.Message}", "ERROR");
                if (showUpToDateMessage)
                    MessageBox.Show($"{LanguageManager.Current.UpdateCheckFailed}\n\n{ex.Message}",
                        LanguageManager.Current.UpdateAvailableTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static async Task<GitHubRelease> FetchLatestRelease()
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
        private static void ShowEnhancedUpdateDialog(GitHubRelease release)
        {
            string latestVersion = release.TagName?.TrimStart('v') ?? "Unknown";
            string releaseNotes = release.Body ?? "No release notes available.";
            string downloadUrl = release.HtmlUrl ?? "https://github.com/makcrtve/geetRPCS/releases";
            DateTime publishedDate = release.PublishedAt;
            using var dialog = CreateBaseDialog(LanguageManager.Current.UpdateAvailableTitle, new Size(550, 650));
            dialog.MaximumSize = new Size(700, 850);
            AddHeaderPanel(dialog, "🎊", LanguageManager.Current.UpdateAvailableMessage, LanguageManager.Current.UpdateSubtitle,
                Color.FromArgb(88, 101, 242), Color.FromArgb(88, 101, 242), Color.FromArgb(115, 125, 255));
            var contentPanel = CreateContentPanel(dialog);
            int yPos = 10;
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
            AddLabel(contentPanel, LanguageManager.Current.UpdateChangelog, new Point(20, yPos), new Font("Segoe UI", 10, FontStyle.Bold), Color.White);
            yPos += 25;
            var changelogBox = new RichTextBox
            {
                Location = new Point(20, yPos),
                Size = new Size(contentPanel.Width - 60, 95),
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
            yPos += 110;
            AddLabel(contentPanel, LanguageManager.Current.UpdateHowTo, new Point(20, yPos), new Font("Segoe UI", 10, FontStyle.Bold), Color.White);
            yPos += 25;
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
                    var thread = new System.Threading.Thread(() => {
                        try { Clipboard.SetText(cmdText); } catch { }
                    });
                    thread.SetApartmentState(System.Threading.ApartmentState.STA);
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
                try { Process.Start(new ProcessStartInfo { FileName = "https://api.github.com/repos/makcrtve/geetRPCS/releases/latest", UseShellExecute = true }); } catch { }
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
            using var dialog = CreateBaseDialog("✅ You're Up to Date!", new Size(450, 280));
            AddHeaderPanel(dialog, "✅", "You're Up to Date!", null,
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
            try
            {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                File.AppendAllText(LogPath, $"[{timestamp}] [UpdateChecker] [{level}] {message}\r\n");
            }
            catch { }
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
            [JsonPropertyName("tag_name")] public string TagName { get; set; }
            [JsonPropertyName("name")] public string Name { get; set; }
            [JsonPropertyName("body")] public string Body { get; set; }
            [JsonPropertyName("html_url")] public string HtmlUrl { get; set; }
            [JsonPropertyName("published_at")] public DateTime PublishedAt { get; set; }
            [JsonPropertyName("prerelease")] public bool Prerelease { get; set; }
        }
        #endregion
    }
}
