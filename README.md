<p align="center">
  <a href="README.md"><img src="https://img.shields.io/badge/Language-English-blue?style=flat-square" alt="English"/></a>
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
  <img src="https://img.shields.io/badge/Windows-0078D6?style=flat-square&logo=windows&logoColor=white" alt="Windows"/>
  <img src="https://img.shields.io/badge/.NET_8.0-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt=".NET 8"/>
  <img src="https://img.shields.io/badge/Discord_RPC-5865F2?style=flat-square&logo=discord&logoColor=white" alt="Discord"/>
  <a href="https://github.com/makcrtve/geetRPCS/releases/latest">
    <img src="https://img.shields.io/github/v/release/makcrtve/geetRPCS?style=flat-square&label=Download&color=success" alt="Download"/>
  </a>
  <img src="https://img.shields.io/github/downloads/makcrtve/geetRPCS/total?style=flat-square&color=blue" alt="Downloads"/>
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

```bash
1. Download  →  github.com/makcrtve/geetRPCS/releases/latest
2. Extract   →  to your preferred folder
3. Run       →  geetRPCS.exe
4. Done!     →  Icon appears in the system tray 🎉
```

> **Requirements:** Windows 10/11 • Discord Desktop • [.NET 8.0 Runtime](https://dotnet.microsoft.com/download/dotnet/8.0)

---

## ✨ Features

<table>
<tr>
<td width="50%">

### 🎯 Core
- 🔍 **Auto Detect** - 40+ popular applications
- ⌨️ **Global Hotkeys** - Keyboard shortcuts [NEW]
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
- 🔄 **Auto Update** - New version notifications
- ⚡ **Quick Actions** - Fast access to configs
- 🚀 **Auto Startup** - Run when Windows starts

</td>
<td width="50%">

### 🎨 Customization
- 🖼️ **Custom Assets** - Use your own images
- 📝 **Custom Text** - Custom texts & placeholders
- 🔘 **Custom Buttons** - Link to portfolio

</td>
</tr>
</table>

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
|----------|--------|
| `CTRL` + `ALT` + `P` | ⏸️ Pause / Resume Presence |
| `CTRL` + `ALT` + `V` | 👀 Toggle Preview Window |
| `CTRL` + `ALT` + `H` | 🔒 Toggle Private Mode |
| `CTRL` + `ALT` + `R` | 🔄 Reload Config |
| `CTRL` + `ALT` + `S` | 📊 Show Today's Stats |

### 🖱️ System Tray Menu
**Right-click** the tray icon to access the manual menu:

| Menu | Function |
|------|--------|
| ⏸️ Pause | Toggle presence on/off |
| 🔒 Private Mode | Censor window titles |
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

<details>
<summary><b>📄 config.json</b> - Main configuration</summary>

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
      "LargeImageText": "geetRPCS v1.2.4",
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

**Adding an app:** Task Manager → note process name → add to apps.json → Reload All

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
├── geetRPCS.exe          # Main application (v1.2.4)
├── config.json           # Discord RPC Configuration
├── apps.json             # Application list
├── geetrpcs.ico          # Icon
├── settings.json         # Settings (auto)
├── statistics.json       # Tracking data (auto)
├── geetRPCS.log          # Log file (auto)
├── ImageCache/           # Image cache (auto)
└── Languages/            # Language files (auto)
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
<summary><b>Hotkeys not working?</b></summary>

Ensure no other application is using the same shortcuts. Some fullscreen games running "As Administrator" might block hotkeys if geetRPCS is not also run as Admin.

</details>

<details>
<summary><b>Application not detected?</b></summary>

1. Open Task Manager → note the correct process name
2. Add it to `apps.json`
3. Quick Actions → Reload All (CTRL+ALT+R)
4. Ensure it is not disabled in **Manage Apps**

</details>

<details>
<summary><b>Images not showing?</b></summary>

1. Upload images in Discord Developer Portal
2. Wait a few minutes (Discord sync)
3. Key names must match **exactly** (case sensitive)
4. Preview Window → 🔄 Refresh

</details>

<details>
<summary><b>Troubleshooting</b></summary>

Open `geetRPCS.log` or right-click tray → **Open Log File**

| Error | Solution |
|-------|--------|
| Config not found | Ensure files are in the same folder |
| Discord not connected | Ensure Discord Desktop is running |
| Presence not showing | Check Pause mode and Manage Apps |
| Preview image empty | Clear Cache → Refresh |

</details>

---

## 🛡️ Security

<p align="center">
  <a href="https://www.virustotal.com/gui/file/726971ceebe6af4d14aa069852ad76ea31d58b52878104283513b0974a354a76">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F73%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
</p>

<details>
<summary><b>Scan Details & False Positive Info</b></summary>

**Scan Result v1.2.4:**
- ✅ **0/73** malware detections (Clean)
- ✅ Code Signed: No (Self-contained)

**False Positive?** Some AVs might flag it because:
- New executable / not widely distributed
- Discord RPC API access
- Registry access (auto-startup)
- **Global Hotkey hooks** (new feature v1.2.4)

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
- [ ] More software support
- [ ] UI Dashboard (WPF/WinUI)

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
  <sub>geetRPCS v1.2.4 • MIT License • 2026</sub>
</p>
