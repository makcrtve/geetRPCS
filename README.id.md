<p align="center">
  <a href="README.en.md"><img src="https://img.shields.io/badge/Language-English-blue?style=flat-square" alt="English"/></a>
  <a href="README.id.md"><img src="https://img.shields.io/badge/Bahasa-Indonesia-red?style=flat-square" alt="Indonesia"/></a>
</p>

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/geetrpcs-banner.png" width="600" alt="geetRPCS Banner"/>
</p>

<h1 align="center">geetRPCS</h1>

<p align="center">
  <b>Discord Rich Presence Otomatis untuk aplikasi favorit kamu!</b><br/>
  <sub>Tampilkan aktivitasmu di Discord secara real-time, tanpa ribet 🚀</sub>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Windows-0078D6?style=flat-square&logo=windows&logoColor=white" alt="Windows"/>
  <img src="https://img.shields.io/badge/.NET_8.0-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt=".NET 8"/>
  <img src="https://img.shields.io/badge/Discord_RPC-5865F2?style=flat-square&logo=discord&logoColor=white" alt="Discord"/>
  <a href="https://github.com/makcrtve/geetRPCS/releases/latest">
    <img src="https://img.shields.io/github/v/release/makcrtve/geetRPCS?style=flat-square&label=Versi&color=success" alt="Download"/>
  </a>
  <img src="https://img.shields.io/github/downloads/makcrtve/geetRPCS/total?style=flat-square&label=Unduhan&color=blue" alt="Downloads"/>
</p>

<p align="center">
  <a href="#-mulai-cepat">Mulai Cepat</a> •
  <a href="#-fitur">Fitur</a> •
  <a href="#-aplikasi-didukung">Aplikasi Didukung</a> •
  <a href="#%EF%B8%8F-konfigurasi">Konfigurasi</a> •
  <a href="#-faq">FAQ</a>
</p>

---

## 🚀 Mulai Cepat

```md
1. Download  →  github.com/makcrtve/geetRPCS/releases/latest
2. Ekstrak   →  ke folder pilihanmu
3. Jalankan  →  geetRPCS.exe
4. Selesai   →  Icon muncul di system tray
```

> **Persyaratan:** Windows 10/11 • Discord Desktop • [.NET 8.0 Runtime](https://dotnet.microsoft.com/download/dotnet/8.0)

---

## ✨ Fitur

<table>
<tr>
<td width="50%">

### 🎯 Inti
- 🔍 **Auto Deteksi** - 40+ aplikasi populer
- 🖱️ **Mouse Energy** - Level aktivitas real-time [BARU]
- ⌨️ **Global Hotkeys** - Shortcut keyboard
- 👀 **Preview Window** - Preview presence langsung
- 🛠️ **App Manager** - Blacklist aplikasi

</td>
<td width="50%">

### ⚙️ Kontrol
- ⏸️ **Mode Pause** - Sembunyikan presence sementara
- 🔒 **Mode Privat** - Sensor judul window
- 📊 **Statistik** - Tracking + Ekspor CSV/JSON
- 🌐 **Multi-Bahasa** - EN / ID

</td>
</tr>
<tr>
<td width="50%">

### 🔧 Utilitas
- 🎯 **Smart Defaults** - Jalan tanpa config.json [BARU]
- 🔄 **Auto Update** - Notifikasi versi baru
- ⚡ **Quick Actions** - Akses cepat ke config
- 🚀 **Auto Startup** - Jalan saat Windows start

</td>
<td width="50%">

### 🎨 Kustomisasi
- 🖼️ **Custom Assets** - Gunakan gambar sendiri
- 📝 **Custom Text** - Teks & placeholder custom
- 🔘 **Custom Buttons** - Link ke portfolio

</td>
</tr>
</table>

---

## 🖱️ Mouse Energy Detector

<p align="center">
  <b>Tunjukkan level produktivitasmu secara real-time di Discord!</b>
</p>

geetRPCS v1.2.5 memperkenalkan **Mouse Energy Detector** - fitur unik yang menganalisis aktivitas mouse dan menampilkan "level energi" kamu saat ini di Discord presence.

| Level | Emoji | Kondisi |
|:------|:-----:|:--------|
| **Sleeping** | 💤 | Tidak ada aktivitas > 30 detik |
| **Relaxing** | ☕ | Aktivitas rendah (scrolling santai) |
| **Normal** | 🎯 | Aktivitas standar (kerja biasa) |
| **Focused** | 🔥 | Aktivitas tinggi (editing intensif) |
| **Rush** | ⚡ | Aktivitas sangat tinggi (mode deadline!) |

**Contoh tampilan di Discord:**
```
Working on FL Studio 2025
Untitled - FL Studio | 🔥 Fokus
```

> 💡 **Tip:** Toggle fitur ini on/off via menu System Tray → "🖱️ Detektor Energi Mouse"

---

## 🎯 Aplikasi Didukung

<details open>
<summary><b>41 Software • 64+ Nama Proses</b> (klik untuk toggle)</summary>

| Kategori | Aplikasi |
|:--------:|----------|
| 🎵 **DAW** | FL Studio, Ableton, Cubase, REAPER, Pro Tools, Studio One, Reason, Cakewalk |
| 🎬 **Video** | Premiere Pro, After Effects, DaVinci Resolve, Filmora, Vegas Pro, CapCut |
| 🎨 **Desain** | Photoshop, Illustrator, Lightroom, Figma, Canva, CorelDRAW, GIMP, Inkscape, Affinity |
| 🧊 **3D/CAD** | Blender, Maya, SketchUp, AutoCAD |
| 📡 **Stream** | OBS Studio, Streamlabs |
| 🌐 **Browser** | Chrome, Brave, Firefox, Edge, Zen |
| 📦 **Lainnya** | Adobe Audition, VLC, MS Office, Telegram, HandBrake |

</details>

> 💡 **Tip:** Kamu bisa menambahkan aplikasi sendiri di `apps.json`!

---

## 🖥️ Penggunaan

### ⌨️ Global Hotkeys (Shortcut)
Kontrol geetRPCS langsung dari keyboard, bahkan saat aplikasi di-minimize:

| Shortcut | Fungsi |
|----------|--------|
| `CTRL` + `ALT` + `P` | ⏸️ Pause / Resume Presence |
| `CTRL` + `ALT` + `V` | 👀 Toggle Preview Window |
| `CTRL` + `ALT` + `H` | 🔒 Toggle Mode Privat |
| `CTRL` + `ALT` + `R` | 🔄 Reload Config |
| `CTRL` + `ALT` + `S` | 📊 Tampilkan Statistik Hari Ini |

### 🖱️ Menu System Tray
**Klik kanan** icon tray untuk akses menu manual:

| Menu | Fungsi |
|------|--------|
| ⏸️ Jeda | Toggle presence on/off |
| 🔒 Mode Privat | Sensor judul window |
| 🖱️ Energi Mouse | Toggle detektor aktivitas [BARU] |
| 📡 Telemetry | Toggle data penggunaan anonim [BARU] |
| 👀 Jendela Preview | Preview Discord presence langsung |
| 🛠️ Kelola Aplikasi | Aktifkan/nonaktifkan aplikasi |
| 📊 Statistik | Lihat & ekspor statistik |
| ⚡ Aksi Cepat | Akses folder, edit config |
| 🌐 Bahasa | Ganti bahasa (EN/ID) |

<details>
<summary><b>📸 Screenshot</b></summary>

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

## ⚙️ Konfigurasi

### 🎯 Smart Defaults (Baru di v1.2.5)

geetRPCS sekarang bisa langsung jalan **tanpa** file `config.json`! Aplikasi menggunakan pengaturan default yang sudah optimal secara otomatis.

**config.json hanya diperlukan jika kamu ingin:**
- Menggunakan Discord Application ID sendiri
- Kustomisasi teks presence
- Menambahkan tombol custom

> 💡 **Tip:** Buat config.json via Quick Actions → "Edit config.json" (akan auto-create dengan default)

<details>
<summary><b>📄 config.json</b> - Konfigurasi utama (Opsional)</summary>

```json
{
  "Discord": {
    "ApplicationId": "YOUR_DISCORD_APP_ID",
    "Details": "Menganggur...",
    "State": "Siap bekerja",
    "ActiveDetails": "Bekerja di {app_name}",
    "ActiveState": "{window_title}",
    "Assets": {
      "LargeImageKey": "geetrpcs-logo",
      "LargeImageText": "geetRPCS v1.2.5",
      "SmallImageKey": "verified",
      "SmallImageText": "geetRPCS Standby"
    },
    "Buttons": [
      { "Label": "GitHub", "Url": "https://github.com/makcrtve/geetRPCS" }
    ]
  }
}
```

**Placeholder:** `{app_name}` • `{process_name}` • `{window_title}`

</details>

<details>
<summary><b>📄 apps.json</b> - Daftar aplikasi</summary>

```json
[
  {
    "process": "FL64",
    "appName": "FL Studio 2025",
    "largeKey": "flstudio",
    "largeText": "FL Studio 2025",
    "smallKey": "geetrpcs-logo",
    "smallText": "geetRPCS",
    "customDetails": "Producing di {app_name}",
    "buttons": [
      { "label": "Portfolio Saya", "url": "https://example.com" }
    ]
  }
]
```

**Menambahkan aplikasi:** Task Manager → catat nama proses → tambahkan ke apps.json → Reload All

</details>

<details>
<summary><b>🎨 Discord Assets</b> - Upload gambar</summary>

1. Buka [Discord Developer Portal](https://discord.com/developers/applications)
2. Pilih aplikasi → **Rich Presence** → **Art Assets**
3. Upload gambar dengan nama sesuai `largeKey` / `smallKey`

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/discord-assets.png" width="500"/>
</p>

</details>

<details>
<summary><b>📁 Struktur File</b></summary>

```
geetRPCS/
├── geetRPCS.exe          # Aplikasi utama (v1.2.5)
├── apps.json             # Daftar aplikasi (wajib)
├── rpicon.ico            # Icon (wajib)
├── config.json           # Konfigurasi Discord RPC (opsional)
├── settings.json         # Pengaturan (auto-generated)
├── statistics.json       # Data tracking (auto-generated)
├── geetRPCS.log          # File log (auto-generated)
├── .telemetry            # Penghitung launch (auto-generated)
├── ImageCache/           # Cache gambar (auto-generated)
└── Languages/            # File bahasa (auto-generated)
```

</details>

---

## ❓ FAQ

<details>
<summary><b>Presence tidak muncul di Discord?</b></summary>

1. Pastikan menggunakan Discord **Desktop** (bukan web)
2. Settings → Activity Privacy → Aktifkan "Display current activity"
3. Restart geetRPCS dan Discord
4. Pastikan tidak dalam mode **Pause**

</details>

<details>
<summary><b>Mouse Energy tidak update?</b></summary>

1. Pastikan "🖱️ Detektor Energi Mouse" aktif di menu tray
2. Fitur ini menganalisis aktivitas dari waktu ke waktu - tunggu beberapa detik
3. Beberapa aplikasi fullscreen mungkin mempengaruhi deteksi
4. Cek `geetRPCS.log` untuk error MouseTracker

</details>

<details>
<summary><b>Hotkeys tidak berfungsi?</b></summary>

Pastikan tidak ada aplikasi lain yang menggunakan shortcut yang sama. Beberapa game fullscreen yang berjalan sebagai "Administrator" mungkin memblokir hotkey jika geetRPCS tidak juga dijalankan sebagai Admin.

</details>

<details>
<summary><b>Aplikasi tidak terdeteksi?</b></summary>

1. Buka Task Manager → catat nama proses yang benar
2. Tambahkan ke `apps.json`
3. Quick Actions → Reload All (CTRL+ALT+R)
4. Pastikan tidak dinonaktifkan di **Kelola Aplikasi**

</details>

<details>
<summary><b>Gambar tidak muncul?</b></summary>

1. Upload gambar di Discord Developer Portal
2. Tunggu beberapa menit (sinkronisasi Discord)
3. Nama key harus sama **persis** (case sensitive)
4. Preview Window → 🔄 Refresh

</details>

<details>
<summary><b>Data apa yang dikumpulkan Telemetry?</b></summary>

Telemetry anonim (opt-in) mengumpulkan:
- Username Discord (untuk menghitung pengguna unik)
- Versi aplikasi
- Durasi sesi
- Jumlah aplikasi yang digunakan

**Tidak ada data pribadi, nama file, atau judul window yang dikumpulkan.**
Kamu bisa menonaktifkannya kapan saja via menu tray.

</details>

<details>
<summary><b>Troubleshooting</b></summary>

Buka `geetRPCS.log` atau klik kanan tray → **Buka File Log**

| Error | Solusi |
|-------|--------|
| Apps.json tidak ditemukan | Pastikan apps.json ada di folder yang sama |
| Discord tidak terhubung | Pastikan Discord Desktop berjalan |
| Presence tidak muncul | Cek mode Pause dan Kelola Aplikasi |
| Preview gambar kosong | Clear Cache → Refresh |
| Mouse hook gagal | Jalankan sebagai Administrator |

</details>

---

## 🛡️ Keamanan

<p align="center">
  <a href="https://www.virustotal.com/gui/file/7066e6feab9c601859c58ba9d8429bf234342d150cd01d80808d6fb5a4a419e0/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F73%20Bersih-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
</p>

<details>
<summary><b>Detail Scan & Info False Positive</b></summary>

**Hasil Scan v1.2.5:**
- ✅ **0/73** deteksi malware (Bersih)
- ✅ Code Signed: Tidak (Self-contained)

**False Positive?** Beberapa AV mungkin menandai karena:
- Executable baru / belum banyak didistribusikan
- Akses API Discord RPC
- Akses Registry (auto-startup)
- **Global Hotkey hooks** (RegisterHotKey API)
- **Mouse hooks** (SetWindowsHookEx API) [BARU]

**Solusi:** Whitelist di antivirus atau verifikasi di [VirusTotal](https://www.virustotal.com)

</details>

---

## 🔮 Roadmap

- [x] Auto-update checker
- [x] Statistics tracker
- [x] Multi-bahasa (EN/ID)
- [x] Preview Window
- [x] App Manager
- [x] Support Global Hotkeys
- [x] Mouse Energy Detector
- [x] Smart Defaults (config opsional)
- [ ] Dukungan software lebih banyak
- [ ] UI Dashboard (WPF/WinUI)
- [ ] Tracking aktivitas keyboard

---

## 📞 Tautan

<p align="center">
  <a href="https://github.com/makcrtve/geetRPCS/issues">🐛 Laporkan Bug</a> •
  <a href="https://github.com/makcrtve/geetRPCS/discussions">💬 Diskusi</a> •
  <a href="https://github.com/makcrtve/geetRPCS/releases">📦 Rilis</a>
</p>

---

<p align="center">
  <sub>Dibuat dengan ❤️ oleh <a href="https://github.com/makcrtve">makcrtve</a></sub><br/>
  <sub>geetRPCS v1.2.5 • MIT License • 2026</sub>
</p>
