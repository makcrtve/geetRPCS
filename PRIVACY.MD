<h1 align="center">🔒 Privacy Policy</h1>
<p align="center">
  <b>geetRPCS - Discord Rich Presence Client</b><br/>
  <sub>Last updated: 7 January 2026</sub>
</p>

---

## 📋 Summary

**geetRPCS** respects user privacy. This document explains how our application handles user data and information.

> **TL;DR:** geetRPCS collects **anonymous** usage data **optionally** (can be disabled). All configuration data and statistics remain on your local computer.

---

## 🔍 Data Accessed

geetRPCS accesses the following information:

| Data | Purpose | Stored? | Sent to Server? |
|------|---------|:-------:|:---------------:|
| Application process name | Detect running applications | ❌ No | ❌ No |
| Active window title | Display on Discord presence | ❌ No | ❌ No* |
| Mouse activity | Detect work energy level | ❌ No | ❌ No |
| Local configuration | Store user preferences | ✅ Local | ❌ No |
| Usage statistics | Track app usage time | ✅ Local | ❌ No |
| Activity log | Debugging and troubleshooting | ✅ Local | ❌ No |

> *Window title is sent to Discord API to display as Rich Presence, in accordance with user consent.

---

## 📡 Telemetry (Optional)

### What is Telemetry?

Starting v1.2.5, geetRPCS provides an **optional telemetry** feature to help with application development and user support. This feature is **enabled by default** but can be **disabled anytime**.

### Data Collected (If Enabled):

| Data | Purpose | Example |
|------|---------|---------|
| Discord username | Count unique users & support | `makcrtve` |
| Discord User ID | Unique identification & support | `123456789` |
| App version | Version adoption statistics | `1.2.5` |
| Language | Language usage statistics | `id` or `en` |
| Launch count | Usage statistics | `15` |
| Session duration | Average usage | `2h 30m` |
| Apps used count | Feature statistics | `5` |

### Why Collect Discord Username & User ID?

We understand this may raise questions. Here's our transparent explanation:

**Purpose:**
- 📊 **Count unique users** - Differentiate between "100 launches by 1 person" vs "100 launches by 50 people"
- 🔄 **Track retention** - Know how many users return to use the app
- 🛠️ **Provide support** - If you report an issue, we can check if your session data shows any anomalies

**What we CANNOT do with this data:**
| Action | Possible? |
|--------|:---------:|
| Access your Discord account | ❌ No |
| Send you DMs or mentions | ❌ No |
| See your Discord servers | ❌ No |
| See your Discord activity | ❌ No |
| Correlate with other personal data | ❌ No |

**Important facts:**
- Discord User ID is **public information** - anyone can see it via Discord's Developer Mode
- We don't generate hidden tracking IDs that would be more "creepy"
- Data is only sent to our Discord Webhook for simple analytics
- **Can be disabled anytime** - app works 100% normally without it

> 💡 **Analogy:** This is like a restaurant noting "Customer #12345 visited today" - they know a visitor came, but don't know who you are, where you live, or what you do after eating.

### What is NOT Collected:

- ❌ File or project names
- ❌ Window titles / screen content
- ❌ Geographic location
- ❌ System information (RAM, CPU, etc.)
- ❌ Browsing activity
- ❌ Other personal data

### How to Disable Telemetry:

1. Right-click geetRPCS tray icon
2. Click "📡 Send Anonymous Usage Data" to uncheck
3. Telemetry stops immediately

> **Note:** Telemetry data is sent to a Discord Webhook managed by the developer for development analysis and user support. No data is sold or shared with third parties.

---

## 🖱️ Mouse Energy Detector

### About This Feature:

Mouse Energy Detector uses a **low-level mouse hook** to detect mouse activity and display an "energy level" on Discord.

### Data Processed:

| Data | Stored? | Sent? |
|------|:-------:|:-----:|
| Mouse position | ❌ No (memory only) | ❌ No |
| Movement speed | ❌ No (memory only) | ❌ No |
| Click count | ❌ No (memory only) | ❌ No |
| Energy level | ❌ No | ✅ To Discord |

> *Only the energy level text (e.g., "🔥 Focused") is sent to Discord as part of the presence.

### How to Disable:

1. Right-click geetRPCS tray icon
2. Click "🖱️ Mouse Energy Detector" to uncheck

---

## 📁 Files Created

geetRPCS creates the following files in the installation folder:

```
📁 geetRPCS Folder/
├── 📄 config.json       → Discord configuration (optional, created manually)
├── 📄 apps.json         → Application list (required)
├── 📄 settings.json     → User settings (auto-created)
├── 📄 statistics.json   → Local usage statistics (auto-created)
├── 📄 geetRPCS.log      → Activity log (auto-created)
├── 📄 .telemetry        → Launch counter for telemetry (auto-created)
├── 🖼️ rpicon.ico        → Application icon (required)
├── 📁 ImageCache/       → Discord image cache (auto-created)
└── 📁 Languages/        → Language files (auto-created)
```

### About Log Files

The `geetRPCS.log` file contains:
- ✅ Application start/stop times
- ✅ Detected application names
- ✅ Error and Discord connection status
- ✅ Mouse Energy status (if enabled)
- ✅ Telemetry status (success/failure)
- ❌ Does **NOT** contain sensitive data
- ❌ Does **NOT** contain window titles or file names

You can delete the log file anytime without affecting application functionality.

---

## 🌐 Network Connections

geetRPCS connects to:

| Service | Purpose | Data Sent |
|---------|---------|-----------|
| Discord RPC (local) | Display Rich Presence | Status, details, configured images |
| Discord API | Fetch image assets | Application ID |
| GitHub API | Check for updates | No user data |
| Discord Webhook* | Telemetry (optional) | Anonymous data (see Telemetry section) |

> *Only if telemetry is enabled

### What We Do NOT Do:

- ❌ **Do not** sell data to third parties
- ❌ **Do not** track browsing activity
- ❌ **Do not** access personal files
- ❌ **Do not** read document contents
- ❌ **Do not** record keystrokes

---

## 🔒 Private Mode

geetRPCS provides a **Private Mode** feature for additional privacy protection:

### When Private Mode is ACTIVE:
- ✅ Window titles are censored to `********`
- ✅ File/project names are hidden from Discord
- ✅ Suitable for streaming or screen sharing

### How to Enable:
1. Right-click → select "🔒 Private Mode", or
2. Press `CTRL + ALT + H`

---

## 🗂️ Data Storage

### Local Data

All configuration data is stored **locally** on your computer:

| Location | Contents |
|----------|----------|
| Installation folder | config.json, apps.json, settings.json, statistics.json, log |
| Windows Registry* | Executable path (if auto-startup is enabled) |

> *Only if you enable "Run on Windows startup"

### Registry Entry

If auto-startup is enabled, geetRPCS creates an entry at:
```
HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
```

Key: `geetRPCS`
Value: Path to executable

You can remove this entry anytime through the tray menu.

---

## 🛡️ Security

### Our Security Practices:

- ✅ Telemetry is optional and can be disabled
- ✅ No sensitive data is collected
- ✅ Code runs entirely locally
- ✅ Does not require administrator rights (except for mouse hook in some cases)
- ✅ Does not modify system files

### Rekommendasi Keamanan:

1. Download only from [official GitHub](https://github.com/makcrtve/geetRPCS/releases)
2. Verify file hash if available
3. Do not run third-party modified versions
4. Disable telemetry if uncomfortable

---

## 👤 User Rights

You have full rights over your data:

| Right | How |
|-------|-----|
| **View data** | Open config.json, settings.json, statistics.json, geetRPCS.log files |
| **Edit data** | Edit configuration files with a text editor |
| **Delete data** | Delete geetRPCS folder |
| **Disable telemetry** | Tray menu → uncheck "📡 Send Anonymous Usage Data" |
| **Disable mouse tracking** | Tray menu → uncheck "🖱️ Mouse Energy Detector" |
| **Disable logging** | Delete geetRPCS.log file (will be recreated) |
| **Remove from startup** | Tray menu → uncheck "Run on Windows startup" |

---

## 🔄 Policy Updates

This privacy policy may be updated at any time. Significant changes will be announced through:

- 📋 Release notes on GitHub
- 📄 Updates to PRIVACY.md file

The "Last updated" date at the top of this document indicates the latest revision.

---

## 📞 Contact

If you have questions about this privacy policy:

- 📧 Create an [Issue](https://github.com/makcrtve/geetRPCS/issues) on GitHub

---

## 📜 Consent

By using geetRPCS, you agree to:

1. ✅ Data configured in config.json will be displayed on Discord
2. ✅ Application window titles may be displayed on Discord (unless Private Mode is active)
3. ✅ Mouse energy level may be displayed on Discord (if feature is active)
4. ✅ Log files are created for debugging purposes
5. ✅ Anonymous data may be sent for telemetry (if feature is active)

If you do not agree, you can:
- Not use this application
- Enable Private Mode to hide window titles
- Disable Mouse Energy Detector
- Disable Telemetry
- Delete log files periodically

---

<div align="center">

## 🎯 Our Commitment

**"Your privacy is our priority."**

geetRPCS is designed with a **privacy-first** principle.
The data we collect is optional, transparent, and used solely to improve the app and provide support.

</div>

---

<p align="center">
  <b>geetRPCS v1.2.5</b><br/>
  <sub>© 2026 makcrtve - All Rights Reserved</sub>
</p>
