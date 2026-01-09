<p align="center">
  <a href="RELEASE/README.en.md"><img src="https://img.shields.io/badge/Language-English-blue?style=flat-square" alt="English"/></a>
  <a href="RELEASE/README.id.md"><img src="https://img.shields.io/badge/Bahasa-Indonesia-red?style=flat-square" alt="Indonesia"/></a>
</p>

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/geetrpcs-banner.png" width="600" alt="geetRPCS Banner"/>
</p>

<h1 align="center">geetRPCS</h1>

<p align="center">
  <b>Automatic Discord Rich Presence for your favorite apps!</b><br/>
  <sub>Display your activity on Discord in real-time with extreme efficiency 🚀</sub>
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

Choose the installation method that suits you best:

### 1. Recommended (Portable + Shortcut) ⭐
Downloads the portable version (standalone) via PowerShell and automatically creates a Desktop shortcut for easy access.
```ps
irm https://raw.githubusercontent.com/makcrtve/geetRPCS/main/install.ps1 | iex; Install-GeetRPCS -DesktopShortcut
```

### 2. Lightweight (Minimal + Shortcut)
Smaller file size, but requires [.NET 8.0 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/8.0/runtime) installed. Includes Desktop shortcut.
```ps
irm https://raw.githubusercontent.com/makcrtve/geetRPCS/main/install.ps1 | iex; Install-GeetRPCS -Version "minimal" -DesktopShortcut
```

### 3. Standard (Portable Only)
Downloads the portable version via PowerShell without creating any shortcuts.
```ps
irm https://raw.githubusercontent.com/makcrtve/geetRPCS/main/install.ps1 | iex; Install-GeetRPCS
```

### 4. Manual Download (Zip)
Download and install manually from the **[Releases Page](https://github.com/makcrtve/geetRPCS/releases/latest)**.

---

## ✨ Features

<table>
<tr>
<td width="50%">

### 🎯 Core
- 🔍 **Auto Detect** - 40+ popular applications
- 🖱️ **Mouse Energy** - Real-time activity level
- 🎨 **Tray Animation** - Visual feedback [NEW]
- ⌨️ **Global Hotkeys** - Keyboard shortcuts
- 👀 **Preview Window** - Reactive live preview

</td>
<td width="50%">

### ⚙️ Control
- ⏸️ **Pause Mode** - Temporarily hide presence
- 🔒 **Private Mode** - Censor window titles
- 📊 **Statistics** - Tracking + Export
- ⚡ **True Hot Reload** - Edit & apply instantly
- 🌐 **Multi-Language** - EN / ID

</td>
</tr>
<tr>
<td width="50%">

### 🔧 Utility
- 🎯 **Smart Defaults** - Works without config.json
- � **Ultra Efficient** - 10-20MB RAM usage [NEW]
- 🔄 **Auto Update** - Version notifications
- 🚀 **Auto Startup** - Robust validation [IMPROVED]

</td>
<td width="50%">

### 🎨 Customization
- 🖼️ **Custom Assets** - Use your own images
- 📝 **Custom Text** - Placeholders supported
- 🔘 **Custom Buttons** - With URL validation
- 🔗 **Smart Assets** - Auto-refresh mapping

</td>
</tr>
</table>

---

## 📉 Extreme Efficiency Engine <sup>NEW</sup>

Version 1.2.7 introduces a complete engine overhaul focusing on being "lighter than air":

| Metric | Improvement |
|:-------|:------------|
| **RAM Usage** | **10 MB - 20 MB** (Reduced from ~80MB) |
| **CPU Usage** | **~0%** (Switched from polling to Event-Based monitoring) |
| **Footprint** | Active memory trimming & full UI disposal on close |

> 💡 **How it works:** We use `SetWinEventHook` to only wake up when you actually switch windows. No constant polling = No CPU waste!

---

## 🎨 Tray Icon Animation <sup>NEW</sup>

The system tray icon now comes alive! When geetRPCS detects an app switch, the icon performs a smooth **360° rotation with brightness pulse** effect.

- **Effect:** Rotation + Brightness pulse
- **Duration:** 800ms (12 frames)
- **Easing:** Ease-In-Out Quadratic
- **Control:** Enable/Disable via Tray Menu

---

## 🖱️ Mouse Energy Detector

<p align="center">
  <b>Show your real-time productivity level on Discord!</b>
</p>

Analyzes mouse activity/velocity to display your "energy level" on Discord presence.

| Level | Emoji | Condition |
|:------|:-----:|:----------|
| **Sleeping** | 💤 | No activity for > 30 seconds |
| **Relaxing** | ☕ | Low activity (casual scrolling) |
| **Normal** | 🎯 | Standard activity (regular work) |
| **Focused** | 🔥 | High activity (intensive editing) |
| **Rush** | ⚡ | Very high activity (deadline mode!) |

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

---

## 🖥️ Usage

### ⌨️ Global Hotkeys (Shortcuts)
| Shortcut | Function |
|----------|----------|
| `CTRL` + `ALT` + `P` | ⏸️ Pause / Resume Presence |
| `CTRL` + `ALT` + `V` | 👀 Toggle Preview Window |
| `CTRL` + `ALT` + `H` | 🔒 Toggle Private Mode |
| `CTRL` + `ALT` + `R` | 🔄 Reload Config |
| `CTRL` + `ALT` + `S` | 📊 Show Today's Stats |

---

## ⚙️ Configuration

### 🎯 Smart Defaults
geetRPCS works **out of the box**! `config.json` is only needed for advanced customization (Custom AppIDs, buttons, etc.).

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
      "LargeImageText": "geetRPCS v1.2.7",
      "SmallImageKey": "verified",
      "SmallImageText": "geetRPCS Standby"
    }
  }
}
```
</details>

<details>
<summary><b>🔗 Button URL Requirements</b></summary>

geetRPCS validates button URLs automatically. Invalid URLs or labels > 32 characters will be skipped.
- ✅ `https://github.com`
- ❌ `github.com` (missing protocol)
</details>

---

## ❓ FAQ

<details>
<summary><b>Presence not showing on Discord?</b></summary>

1. Ensure you are using Discord **Desktop** (not web)
2. Settings → Activity Privacy → Enable "Display current activity"
3. Restart geetRPCS and Discord
</details>

<details>
<summary><b>Tray animation not working?</b></summary>

1. Ensure "🎨 Tray Icon Animation" is enabled in tray menu.
2. It triggers only on **app switch**, not window title changes.
</details>

<details>
<summary><b>Startup not working?</b></summary>

1. Move geetRPCS to a permanent folder (not Downloads/Temp).
2. Enable startup via tray menu to update registries.
</details>

---

## 🛡️ Security

<p align="center">
  <a href="https://www.virustotal.com/gui/file/a7f78aa1c7b5bf17018ec3c7a0ac523d00394ad86b5da7b502627ca1f961f164/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F71%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
  <a href="https://www.virustotal.com/gui/file/dc535d607e0c43fdbf05ed6be9dc4a21bf9b785996de11e5d64255b7ec4d3735/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F68%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>  
</p>

**Scan Result v1.2.7:** 0/71 Detections.
> Note: Some AVs may flag "Hooks" (Mouse/Hotkeys) as false positives.

---

## 🔮 Roadmap
- [x] Auto-update checker
- [x] Statistics tracker
- [x] Reactive Preview Window
- [x] Tray Icon Animation
- [x] Extreme Memory Optimization
- [x] True Hot Reload
- [ ] UI Dashboard (WPF/WinUI)
- [ ] Keyboard activity tracking

---

<p align="center">
  <sub>Made with ❤️ by <a href="https://github.com/makcrtve">makcrtve</a></sub><br/>
  <sub>geetRPCS v1.2.7 • MIT License • 2026</sub>
</p>
