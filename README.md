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
  <img src="https://img.shields.io/badge/Discord_RPC-5865F2?style=flat-square&logo=discord&logoColor=white" alt="Discord"/>
  <a href="https://github.com/Lachee/discord-rpc-csharp">
    <img src="https://img.shields.io/badge/using-C%23-00bb88.svg?style=flat-square&logo=csharp&logoColor=white" alt="using C#"/>
  </a>
  <img src="https://img.shields.io/badge/Windows-0078D6?style=flat-square&logo=windows&logoColor=white" alt="Windows"/>
  <img src="https://img.shields.io/badge/.NET_8.0-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt=".NET 8"/>
  <a href="https://discord.gg/ScTybDUEpH">
    <img src="https://img.shields.io/badge/Join_Discord-5865F2?style=flat-square&logo=discord&logoColor=white" alt="Join Discord"/>
  </a>
  <br/>
  <img src="https://img.shields.io/github/v/release/makcrtve/geetRPCS?style=flat-square&label=Version&color=success" alt="Download"/>
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

### ⚡ One-Command Install (Recommended)

Open **PowerShell** and run:

```powershell
irm https://bit.ly/geetrpcs | iex
```

The interactive installer will guide you through:

```
  ╔═══════════════════════════════════════════╗
  ║       geetRPCS Installer / Updater        ║
  ╚═══════════════════════════════════════════╝

Select Version:
  [1] Portable (Recommended) - Standalone, no dependencies
  [2] Minimal - Smaller size, requires .NET 8.0 Runtime

Enter choice [1-2]: _

Create Desktop shortcut? [Y/n]: _
Create Start Menu shortcut? [Y/n]: _
```

> 💡 **Update:** Run the same command to update to the latest version. Your settings will be preserved!

---

### 🗑️ Uninstall

```powershell
irm https://bit.ly/geetrpcs-del | iex
```

<details>
<summary><b>Advanced Installation Options</b></summary>

#### Silent Install (No Prompts)
```powershell
# Portable + All Shortcuts
irm https://bit.ly/geetrpcs | iex; Install-GeetRPCS -Silent -DesktopShortcut -StartMenuShortcut

# Minimal + No Shortcuts
irm https://bit.ly/geetrpcs | iex; Install-GeetRPCS -Version "minimal" -Silent
```

#### Silent Uninstall
```powershell
# Clean uninstall (remove everything)
irm https://bit.ly/geetrpcs-del | iex; Uninstall-GeetRPCS -Silent

# Keep user data (settings, cache)
irm https://bit.ly/geetrpcs-del | iex; Uninstall-GeetRPCS -Silent -KeepUserData
```

#### Manual Download (Zip)
1. Download the latest `.zip` from **[Releases](https://github.com/makcrtve/geetRPCS/releases/latest)**
2. Extract to your preferred folder
3. Run `geetRPCS.exe`

</details>

---

## ✨ Features

<table>
<tr>
<td width="25%" valign="top">

**🎯 Core**
- Hybrid Detection
- Single Instance
- Ultra Low RAM (5-20MB)
- Tray Animation
- JSON Comments Support
- Auto-refresh Preview
- App Blacklist Manager

</td>
<td width="25%" valign="top">

**⚙️ Control**
- Pause Mode
- Private Mode
- Statistics Tracking
- CSV/JSON Export
- Multi-Language (EN/ID)
- Global Hotkeys
- Tray Quick Menu
- Change App ID via Menu 🆕

</td>
<td width="25%" valign="top">

**🔧 Utility**
- Optimized Async I/O 🚀
- True Hot Reload
- Quick Config Access
- Auto Startup
- Event Logging
- Update Checker (Custom UI) 🆕
- Cache Management

</td>
<td width="25%" valign="top">

**🎨 Customization**
- Dynamic Witty Texts
- Custom Discord Assets
- Text Placeholders
- Custom Buttons
- URL Validation
- Per-App Settings
- Flexible Presence Format

</td>
</tr>
</table>

---

## 🎨 Tray Icon Animation

The system tray icon now comes alive! When geetRPCS detects an app switch, the icon performs a smooth **360° rotation with brightness pulse** effect.

| Property | Value |
|:---------|:------|
| **Effect** | Rotation + Brightness pulse |
| **Duration** | 800ms (12 frames) |
| **Easing** | Ease-In-Out Quadratic |
| **Toggle** | Tray menu → "🎨 Tray Icon Animation" |

> 💡 This subtle animation provides visual confirmation that geetRPCS detected your app switch!

---

## 🖱️ Mouse Energy Detector

<p align="center">
  <b>Show your real-time productivity level on Discord!</b>
</p>

geetRPCS features the **Mouse Energy Detector** - a unique feature that analyzes your mouse activity and displays your current "energy level" on Discord presence.

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

## 🎭 Witty Narrative Engine

<p align="center">
  <b>Bring personality to your Discord status!</b>
</p>

Instead of boring "Working..." messages, geetRPCS now displays **dynamic, humorous texts** that rotate every 60 seconds!

**Features:**
- 🎲 Random selection from curated funny texts
- 🔄 Auto-rotates every 60 seconds
- 📝 Fully customizable via `witty.json`
- 🎯 Zero performance cost
- 🔌 New `{witty_text}` placeholder

**Example Texts:**

| App | Witty Texts |
|:----|:------------|
| **FL Studio** | "Producing the next heater 🔥", "Where is the snare? 🥁", "Soundgoodizer on Master 🎚️" |
| **VS Code** | "Compiling spaghetti code 🍝", "It works on my machine 🤷", "Debugging 100 errors 🐛" |
| **Chrome** | "100 tabs open 🔥", "Researching on YouTube 🎥", "Definitely working... 👀" |

**How to Use:**
1. Edit `witty.json` to add your own texts
2. Use `{witty_text}` in `customDetails` field
3. Reload with `Ctrl+Alt+R`

> 💡 **Tip:** 400+ pre-written texts included for 40+ applications!

---

## 🎯 Supported Apps

<details open>
<summary><b>42 Software • 65+ Process Names</b> (click to toggle)</summary>

| Category | Applications |
|:--------:|----------|
| 🎵 **DAW** | FL Studio, Ableton, Cubase, REAPER, Pro Tools, Studio One, Reason, Cakewalk |
| 🎬 **Video** | Premiere Pro, After Effects, DaVinci Resolve, Filmora, Vegas Pro, CapCut |
| 🎨 **Design** | Photoshop, Illustrator, Lightroom, Figma, Canva, CorelDRAW, GIMP, Inkscape, Affinity |
| 🧊 **3D/CAD** | Blender, Maya, SketchUp, AutoCAD |
| 📡 **Stream** | OBS Studio, Streamlabs |
| 🌐 **Browser** | Chrome, Brave, Firefox, Edge, Zen |
| 📦 **Others** | Orange Data Mining, Adobe Audition, VLC, MS Office, Telegram, HandBrake |

</details>

> 💡 **Tip:** You can add your own applications in `apps.json`!

---

## 🖥️ Usage

### ⌨️ Global Hotkeys (Shortcuts)
Control geetRPCS directly from your keyboard, even when the app is minimized:

| Shortcut | Function |
|----------|----------|
| `Ctrl + Alt + P` | ⏸️ Pause / Resume Presence |
| `Ctrl + Alt + V` | 👀 Toggle Preview Window |
| `Ctrl + Alt + H` | 🔒 Toggle Private Mode |
| `Ctrl + Alt + R` | 🔄 Reload Config |
| `Ctrl + Alt + S` | 📊 Show Today's Stats |

### 🖱️ System Tray Menu
**Right-click** the tray icon to access the manual menu:

| Menu | Function |
|------|----------|
| ⏸️ Pause | Toggle presence on/off |
| 🔒 Private Mode | Censor window titles |
| 🖱️ Mouse Energy | Toggle activity detector |
| 🎨 Tray Animation | Toggle icon animation |
| 📡 Telemetry | Toggle anonymous usage data |
| 👀 Preview Window | Live preview Discord presence |
| 🛠️ Manage Apps | Enable/disable applications |
| 🔑 Change App ID | Update Discord App ID instantly 🆕 |
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

### 🎯 Unified Settings

geetRPCS works **out of the box**! The application now uses a centralized `settings.json` and internal caches to ensure performance.

**config.json is only needed if you want to:**
- Use your own Discord Application ID
- Customize presence text
- Add custom buttons

> 💡 **Tip:** Create config.json via Quick Actions → "Edit config.json" (will auto-create with defaults) OR use the new **"Change App ID"** menu item!

<details>
<summary><b>🔑 New: Change App ID from Tray</b></summary>

Starting v1.3.1, you no longer need to edit `config.json` manually to change your Discord Application ID.

1. Right-click tray icon
2. Select **"🔑 Change App ID"**
3. Enter your new Application ID
4. Click OK

The app will automatically update `config.json` and reload the Discord connection.
</details>

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
      "LargeImageText": "geetRPCS v1.3.1",
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

**Adding an app:** Task Manager → note process name → add to apps.json → Reload All (`Ctrl+Alt+R`)

</details>

<details>
<summary><b>🔗 Button URL Requirements</b></summary>

geetRPCS validates button URLs automatically:

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
📁 %LOCALAPPDATA%\geetRPCS\
├── geetRPCS.exe          # Main application
├── apps.json             # Application list (required)
├── witty.json            # Witty texts (required)
├── rpicon.ico            # Icon (required)
├── config.json           # Discord RPC Configuration (optional)
├── settings.json         # User settings (auto-managed, async)
├── statistics.json       # Tracking data (auto-managed, async)
├── geetRPCS.log          # Log file (auto-generated)
├── .telemetry            # Launch counter (auto-generated)
├── ImageCache/           # Preview Image cache (auto-generated)
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
<summary><b>How to update geetRPCS?</b></summary>

Simply run the same install command:

```powershell
irm https://bit.ly/geetrpcs | iex
```

The installer will:
- ✅ Detect your current version
- ✅ Download only if a new version is available
- ✅ Backup your settings (`apps.json`, `settings.json`, `statistics.json`)
- ✅ Install the update
- ✅ Restore your settings

**v1.3.1 Note:** The update checker now features a beautiful custom dialog matching Discord's theme!

</details>

<details>
<summary><b>Tray animation not working?</b></summary>

1. Ensure "🎨 Tray Icon Animation" is enabled in the tray menu
2. Animation only triggers on **app switch** (not window title changes)
3. Check `geetRPCS.log` for TrayAnimator messages

</details>

<details>
<summary><b>Startup not working?</b></summary>

v1.2.7+ improved startup validation:
1. Make sure geetRPCS is **not** running from a temporary folder
2. Move the application to a permanent location (e.g., `C:\Programs\geetRPCS\`)
3. Enable startup again via the tray menu
4. If you moved the app, re-enable startup to update the registry path

</details>

<details>
<summary><b>New app not detected after editing apps.json?</b></summary>

1. Edit `apps.json` and save
2. Right-click tray → Quick Actions → **Reload All** (or press `Ctrl+Alt+R`)
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

Check that your URLs:
- Start with `http://` or `https://`
- Are valid URLs (not just domain names)
- Labels are 32 characters or less

**Example of a valid button:**
```json
{ "label": "My Website", "url": "https://example.com" }
```

</details>

<details>
<summary><b>Hotkeys not working?</b></summary>

Ensure no other application is using the same shortcuts. Some fullscreen games running "As Administrator" might block hotkeys if geetRPCS is not also run as Admin.

</details>

<details>
<summary><b>Images not showing?</b></summary>

1. Upload images in the Discord Developer Portal
2. Wait a few minutes (Discord sync)
3. Key names must match **exactly** (case sensitive)
4. Preview Window → 🔄 Refresh (Auto-refresh enabled in v1.2.8)

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
| Startup from temp rejected | Move app to a permanent folder |
| Already running | v1.2.8 prevents duplicate instances. Check tray. |

</details>

---

## 🛡️ Security

<p align="center">
  <a href="https://www.virustotal.com/gui/file/36128aa46bd9505c3543f7ad2a9f9bbc51222b86fbd913d817f7b2bf056ab3dd/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F71%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
  <a href="https://www.virustotal.com/gui/file/a241c2b9cf59588b5f15be46072a54c224c1b94f5fb47d3a392ac65acb67a7c6/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F69%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
</p>

<details>
<summary><b>Scan Details & False Positive Info</b></summary>

**Scan Result v1.3.1:**
- ✅ `0/71` | `0/70` malware detections (Clean)
- ✅ Code Signed: No (Self-contained)

**False Positive?** Some AVs might flag it because:
- New executable / not widely distributed
- Discord RPC API access
- Registry access (auto-startup)
- **Global Hotkey hooks** (RegisterHotKey API)
- **Mouse hooks** (SetWindowsHookEx API)
- **Icon manipulation** (GDI+ for tray animation)

**Solution:** Whitelist in antivirus or verify on [VirusTotal](https://www.virustotal.com)

</details>

---

## 🔮 Roadmap

- [x] Auto-update checker (Custom UI)
- [x] Statistics tracker (Async I/O)
- [x] Multi-language (EN/ID)
- [x] Preview Window
- [x] App Manager
- [x] Global Hotkeys support
- [x] Mouse Energy Detector
- [x] Smart Defaults (optional config)
- [x] True Hot Reload
- [x] URL Validation for buttons
- [x] Tray Icon Animation
- [x] One-command installer/updater
- [x] Single Instance Enforcement
- [x] Memory Optimization
- [x] Change App ID from Menu 🆕
- [ ] More software support
- [ ] UI Dashboard (WPF/WinUI)

---

## 📞 Links

<p align="center">
  <a href="https://github.com/makcrtve/geetRPCS/issues">🐛 Report Bug</a> •
  <a href="https://github.com/makcrtve/geetRPCS/discussions">💬 Discussions</a> •
  <a href="https://github.com/makcrtve/geetRPCS/releases">📦 Releases</a> •
  <a href="https://discord.gg/ScTybDUEpH">🎮 Join Discord</a>
</p>

---

<p align="center">
  <sub>Made with ❤️ by <a href="https://github.com/makcrtve">makcrtve</a></sub><br/>
  <sub>geetRPCS v1.3.1 • MIT License • 2026</sub>
</p>
