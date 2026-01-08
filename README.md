<p align="center">
  <a href="README.en.md"><img src="https://img.shields.io/badge/Language-English-blue?style=flat-square" alt="English"/></a>
  <a href="README.id.md"><img src="https://img.shields.io/badge/Bahasa-Indonesia-red?style=flat-square" alt="Indonesia"/></a>
</p>

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/geetrpcs-banner.png" width="600" alt="geetRPCS Banner"/>
</p>

<h1 align="center">geetRPCS</h1>

<p align="center">
  <b>Automatic Discord Rich Presence for your favorite apps!</b><br/>
  <sub>Display your activity on Discord in real-time, hassle-free 🚀</sub>
</p>

<p align="center">
  <a href="https://github.com/Lachee/discord-rpc-csharp">
    <img src="https://img.shields.io/badge/using-C%23-00bb88.svg?style=flat-square&logo=csharp&logoColor=white" alt="using C#"/>
  </a>
  <img src="https://img.shields.io/badge/Windows-0078D6?style=flat-square&logo=windows&logoColor=white" alt="Windows"/>
  <img src="https://img.shields.io/badge/.NET_8.0-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt=".NET 8"/>
  <img src="https://img.shields.io/badge/Discord_RPC-5865F2?style=flat-square&logo=discord&logoColor=white" alt="Discord"/>
  <a href="https://github.com/makcrtve/geetRPCS/releases/latest">
    <img src="https://img.shields.io/github/v/release/makcrtve/geetRPCS?style=flat-square&label=Version&color=success" alt="Download"/>
  </a>
  <img src="https://img.shields.io/github/downloads/makcrtve/geetRPCS/total?style=flat-square&label=Downloads&color=blue" alt="Downloads"/>
</p>

<p align="center">
  <a href="#-quick-start">Quick Start</a> •
  <a href="#-features">Features</a> •
  <a href="#-supported-apps">Supported Apps</a> •
  <a href="#%EF%B8%8F-configuration">Configuration</a> •
  <a href="#-faq">FAQ</a>
</p>

---

## 🚀 Quick Start

1. **Download** the latest release from [Releases Page](https://github.com/makcrtve/geetRPCS/releases/latest).
   - **Portable Version** (Recommended): `geetRPCS-v1.2.6-portable.zip` - No installation required.
   - **Minimal Version**: `geetRPCS-v1.2.6-minimal.zip` - Requires [.NET 8.0 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/8.0/runtime).
2. **Extract** the zip file to your preferred folder.
3. **Run** `geetRPCS.exe`.
4. **Done!** The icon will appear in your system tray.

> **Requirements:** Windows 10/11 • Discord Desktop • [.NET 8.0 Runtime](https://dotnet.microsoft.com/download/dotnet/8.0/runtime) (for Minimal version)

---

## ✨ Features

<table>
<tr>
<td width="50%">

### 🎯 Core
- 🔍 **Auto Detect** - 40+ popular applications
- 🖱️ **Mouse Energy** - Real-time activity level
- ⌨️ **Global Hotkeys** - Keyboard shortcuts
- 👀 **Preview Window** - Live presence preview
- 🛠️ **App Manager** - Blacklist applications

</td>
<td width="50%">

### ⚙️ Control
- ⏸️ **Pause Mode** - Temporarily hide presence
- 🔒 **Private Mode** - Censor window titles
- 📊 **Statistics** - Tracking + Export CSV/JSON
- 🌐 **Multi-Language** - EN / ID

</td>
</tr>
<tr>
<td width="50%">

### 🔧 Utility
- 🎯 **Smart Defaults** - Works without config.json
- 🔄 **True Hot Reload** - Edit & apply instantly [NEW]
- ⚡ **Quick Actions** - Fast access to configs
- 🚀 **Auto Startup** - Run when Windows starts

</td>
<td width="50%">

### 🎨 Customization
- 🖼️ **Custom Assets** - Use your own images
- 📝 **Custom Text** - Custom texts & placeholders
- 🔘 **Custom Buttons** - Link to portfolio
- 🔗 **URL Validation** - Smart button filtering [NEW]

</td>
</tr>
</table>

---

## 🔄 True Hot Reload (New in v1.2.6)

<p align="center">
  <b>Edit apps.json → Click Reload → Changes apply immediately!</b>
</p>

v1.2.6 introduces **True Hot Reload** - finally, editing `apps.json` and clicking "Reload All" actually works without needing to restart the application!

| Before v1.2.6 | After v1.2.6 |
|:--------------|:-------------|
| Edit apps.json → Reload → ❌ Old cache used | Edit apps.json → Reload → ✅ New apps detected! |
| Need to restart for changes | No restart required |
| Assets stuck on old config | Assets refresh immediately |

**What gets reloaded:**
- ✅ New applications added to `apps.json`
- ✅ Changed app names and custom details
- ✅ Updated icons/assets
- ✅ Modified buttons and URLs

> 💡 **Tip:** Use `CTRL + ALT + R` to quickly reload after editing configs!

---

## 🖱️ Mouse Energy Detector

<p align="center">
  <b>Show your real-time productivity level on Discord!</b>
</p>

geetRPCS features **Mouse Energy Detector** - a unique feature that analyzes your mouse activity and displays your current "energy level" on Discord presence.

| Level | Emoji | Condition |
|:------|:-----:|:----------|
| **Sleeping** | 💤 | No activity for > 30 seconds |
| **Relaxing** | ☕ | Low activity (casual scrolling) |
| **Normal** | 🎯 | Standard activity (regular work) |
| **Focused** | 🔥 | High activity (intensive editing) |
| **Rush** | ⚡ | Very high activity (deadline mode!) |

**Example Discord display:**
```
Working on FL Studio 2025
Untitled - FL Studio | 🔥 Focused
```

> 💡 **Tip:** Toggle this feature on/off via System Tray menu → "🖱️ Mouse Energy Detector"

---

## 🎯 Supported Apps

<details open>
<summary><b>41 Software • 64+ Process Names</b> (click to toggle)</summary>

| Category | Applications |
|:--------:|----------|
| 🎵 **DAW** | FL Studio, Ableton, Cubase, REAPER, Pro Tools, Studio One, Reason, Cakewalk |
| 🎬 **Video** | Premiere Pro, After Effects, DaVinci Resolve, Filmora, Vegas Pro, CapCut |
| 🎨 **Design** | Photoshop, Illustrator, Lightroom, Figma, Canva, CorelDRAW, GIMP, Inkscape, Affinity |
| 🧊 **3D/CAD** | Blender, Maya, SketchUp, AutoCAD |
| 📡 **Stream** | OBS Studio, Streamlabs |
| 🌐 **Browser** | Chrome, Brave, Firefox, Edge, Zen |
| 📦 **Others** | Adobe Audition, VLC, MS Office, Telegram, HandBrake |

</details>

> 💡 **Tip:** You can add your own applications in `apps.json`!

---

## 🖥️ Usage

### ⌨️ Global Hotkeys (Shortcuts)
Control geetRPCS directly from your keyboard, even when the app is minimized:

| Shortcut | Function |
|----------|----------|
| `CTRL` + `ALT` + `P` | ⏸️ Pause / Resume Presence |
| `CTRL` + `ALT` + `V` | 👀 Toggle Preview Window |
| `CTRL` + `ALT` + `H` | 🔒 Toggle Private Mode |
| `CTRL` + `ALT` + `R` | 🔄 Reload Config |
| `CTRL` + `ALT` + `S` | 📊 Show Today's Stats |

### 🖱️ System Tray Menu
**Right-click** the tray icon to access the manual menu:

| Menu | Function |
|------|----------|
| ⏸️ Pause | Toggle presence on/off |
| 🔒 Private Mode | Censor window titles |
| 🖱️ Mouse Energy | Toggle activity detector |
| 📡 Telemetry | Toggle anonymous usage data |
| 👀 Preview Window | Live preview Discord presence |
| 🛠️ Manage Apps | Enable/disable applications |
| 📊 Statistics | View & export statistics |
| ⚡ Quick Actions | Access folder, edit config |
| 🌐 Language | Change language (EN/ID) |

<details>
<summary><b>📸 Screenshots</b></summary>

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/screenshot-1.png" width="280"/>
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/screenshot-2.png" width="280"/>
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/screenshot-3.png" width="280"/>
</p>
<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/screenshot-4.png" width="280"/>
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/screenshot-5.png" width="280"/>
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/screenshot-6.png" width="280"/>
</p>

</details>

---

## ⚙️ Configuration

### 🎯 Smart Defaults

geetRPCS works **out of the box** without requiring a `config.json` file! The application uses optimized default settings automatically.

**config.json is only needed if you want to:**
- Use your own Discord Application ID
- Customize presence text
- Add custom buttons

> 💡 **Tip:** Create config.json via Quick Actions → "Edit config.json" (will auto-create with defaults)

<details>
<summary><b>📄 config.json</b> - Main configuration (Optional)</summary>

```json
{
  "Discord": {
    "ApplicationId": "YOUR_DISCORD_APP_ID",
    "Details": "Idling...",
    "State": "Ready to work",
    "ActiveDetails": "Working on {app_name}",
    "ActiveState": "{window_title}",
    "Assets": {
      "LargeImageKey": "geetrpcs-logo",
      "LargeImageText": "geetRPCS v1.2.6",
      "SmallImageKey": "verified",
      "SmallImageText": "geetRPCS Standby"
    },
    "Buttons": [
      { "Label": "GitHub", "Url": "https://github.com/makcrtve/geetRPCS" }
    ]
  }
}
```

**Placeholders:** `{app_name}` • `{process_name}` • `{window_title}`

</details>

<details>
<summary><b>📄 apps.json</b> - Application list</summary>

```json
[
  {
    "process": "FL64",
    "appName": "FL Studio 2025",
    "largeKey": "flstudio",
    "largeText": "FL Studio 2025",
    "smallKey": "geetrpcs-logo",
    "smallText": "geetRPCS",
    "customDetails": "Producing on {app_name}",
    "buttons": [
      { "label": "My Portfolio", "url": "https://example.com" }
    ]
  }
]
```

**Adding an app:** Task Manager → note process name → add to apps.json → Reload All (`CTRL+ALT+R`)

</details>

<details>
<summary><b>🔗 Button URL Requirements</b> (New in v1.2.6)</summary>

v1.2.6 adds smart URL validation for Discord buttons:

| URL Format | Status |
|:-----------|:------:|
| `https://github.com` | ✅ Valid |
| `http://example.com` | ✅ Valid |
| `github.com` | ❌ Skipped (no protocol) |
| `ftp://files.com` | ❌ Skipped (invalid protocol) |
| Empty URL | ❌ Skipped |

**Button label limit:** Maximum 32 characters

> Invalid buttons are silently skipped - no errors, they just won't appear on Discord.

</details>

<details>
<summary><b>🎨 Discord Assets</b> - Upload images</summary>

1. Open [Discord Developer Portal](https://discord.com/developers/applications)
2. Select application → **Rich Presence** → **Art Assets**
3. Upload images with names matching `largeKey` / `smallKey`

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/discord-assets.png" width="500"/>
</p>

</details>

<details>
<summary><b>📁 File Structure</b></summary>

```
geetRPCS/
├── geetRPCS.exe          # Main application (v1.2.6)
├── apps.json             # Application list (required)
├── rpicon.ico            # Icon (required)
├── config.json           # Discord RPC Configuration (optional)
├── settings.json         # Settings (auto-generated)
├── statistics.json       # Tracking data (auto-generated)
├── geetRPCS.log          # Log file (auto-generated)
├── .telemetry            # Launch counter (auto-generated)
├── ImageCache/           # Image cache (auto-generated)
└── Languages/            # Language files (auto-generated)
```

</details>

---

## ❓ FAQ

<details>
<summary><b>Presence not showing on Discord?</b></summary>

1. Ensure you are using Discord **Desktop** (not web)
2. Settings → Activity Privacy → Enable "Display current activity"
3. Restart geetRPCS and Discord
4. Make sure you are not in **Pause** mode

</details>

<details>
<summary><b>New app not detected after editing apps.json?</b></summary>

**In v1.2.6, this should work automatically!**

1. Edit `apps.json` and save
2. Right-click tray → Quick Actions → **Reload All** (or press `CTRL+ALT+R`)
3. New apps should be detected immediately

If still not working, check:
- Process name matches exactly (case-insensitive)
- JSON syntax is valid
- App is not disabled in **Manage Apps**

</details>

<details>
<summary><b>Mouse Energy not updating?</b></summary>

1. Ensure "🖱️ Mouse Energy Detector" is enabled in the tray menu
2. The feature analyzes activity over time - wait a few seconds
3. Some fullscreen applications might affect detection
4. Check `geetRPCS.log` for any MouseTracker errors

</details>

<details>
<summary><b>Buttons not appearing on Discord?</b></summary>

v1.2.6 validates button URLs. Check that your URLs:
- Start with `http://` or `https://`
- Are valid URLs (not just domain names)
- Labels are 32 characters or less

**Example of valid button:**
```json
{ "label": "My Website", "url": "https://example.com" }
```

**Example of invalid button (will be skipped):**
```json
{ "label": "My Website", "url": "example.com" }
```

</details>

<details>
<summary><b>Hotkeys not working?</b></summary>

Ensure no other application is using the same shortcuts. Some fullscreen games running "As Administrator" might block hotkeys if geetRPCS is not also run as Admin.

</details>

<details>
<summary><b>Images not showing?</b></summary>

1. Upload images in Discord Developer Portal
2. Wait a few minutes (Discord sync)
3. Key names must match **exactly** (case sensitive)
4. Preview Window → 🔄 Refresh

</details>

<details>
<summary><b>What data does Telemetry collect?</b></summary>

Anonymous telemetry (opt-in) collects:
- Discord username (for unique user count)
- App version
- Session duration
- Number of apps used

**No personal data, file names, or window titles are collected.**
You can disable it anytime via the tray menu.

</details>

<details>
<summary><b>Troubleshooting</b></summary>

Open `geetRPCS.log` or right-click tray → **Open Log File**

| Error | Solution |
|-------|----------|
| Apps.json not found | Ensure apps.json is in the same folder |
| Discord not connected | Ensure Discord Desktop is running |
| Presence not showing | Check Pause mode and Manage Apps |
| Preview image empty | Clear Cache → Refresh |
| Mouse hook failed | Run as Administrator |
| Buttons not appearing | Check URL format (must start with http/https) |

</details>

---

## 🛡️ Security

<p align="center">
  <a href="https://www.virustotal.com/gui/file/d512a338ca3bca11bbcabd8073831694929202aaad62d39a94851483c8989e1c/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F65%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
  <a href="https://www.virustotal.com/gui/file/72c03212682d9f228cf5bb4960e3aafa5a6359e8f00f10c0a960c600ac53baaa/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F69%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
</p>

<details>
<summary><b>Scan Details & False Positive Info</b></summary>

**Scan Result v1.2.6:**
- ✅ **0/65** malware detections (Clean)
- ✅ Code Signed: No (Self-contained)

**False Positive?** Some AVs might flag it because:
- New executable / not widely distributed
- Discord RPC API access
- Registry access (auto-startup)
- **Global Hotkey hooks** (RegisterHotKey API)
- **Mouse hooks** (SetWindowsHookEx API)

**Solution:** Whitelist in antivirus or verify on [VirusTotal](https://www.virustotal.com)

</details>

---

## 🔮 Roadmap

- [x] Auto-update checker
- [x] Statistics tracker
- [x] Multi-language (EN/ID)
- [x] Preview Window
- [x] App Manager
- [x] Global Hotkeys support
- [x] Mouse Energy Detector
- [x] Smart Defaults (optional config)
- [x] True Hot Reload
- [x] URL Validation for buttons
- [ ] More software support
- [ ] UI Dashboard (WPF/WinUI)
- [ ] Keyboard activity tracking

---

## 📞 Links

<p align="center">
  <a href="https://github.com/makcrtve/geetRPCS/issues">🐛 Report Bug</a> •
  <a href="https://github.com/makcrtve/geetRPCS/discussions">💬 Discussions</a> •
  <a href="https://github.com/makcrtve/geetRPCS/releases">📦 Releases</a>
</p>

---

<p align="center">
  <sub>Made with ❤️ by <a href="https://github.com/makcrtve">makcrtve</a></sub><br/>
  <sub>geetRPCS v1.2.6 • MIT License • 2026</sub>
</p>
