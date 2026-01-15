<p align="center">
  <a href="README.en.md"><img src="https://img.shields.io/badge/Language-English-blue?style=flat-square" alt="English"/></a>
  <a href="README.id.md"><img src="https://img.shields.io/badge/Bahasa-Indonesia-red?style=flat-square" alt="Indonesia"/></a>
</p>

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/geetrpcs-banner.png" width="600" alt="geetRPCS Banner"/>
</p>

<h1 align="center">geetRPCS</h1>

<p align="center">
  <b>Discord Rich Presence Otomatis untuk aplikasi favoritmu!</b><br/>
  <sub>Tampilkan aktivitasmu di Discord secara real-time, tanpa ribet 🚀</sub>
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
  <a href="#-features">Fitur</a> •
  <a href="#-aplikasi-yang-didukung">Aplikasi yang Didukung</a> •
  <a href="#%EF%B8%8F-konfigurasi">Konfigurasi</a> •
  <a href="#-faq">FAQ</a>
</p>

---

## 🚀 Quick Start

### ⚡ Instalasi Satu Perintah (Disarankan)

Buka **PowerShell** dan jalankan:

```powershell
irm https://bit.ly/geetrpcs | iex
```

Instaler interaktif akan memandu kamu melalui:

```
  ╔═══════════════════════════════════════════╗
  ║       geetRPCS Installer / Updater        ║
  ╚═══════════════════════════════════════════╝

Pilih Versi:
  [1] Portable (Disarankan) - Mandiri, tanpa dependensi
  [2] Minimal - Ukuran lebih kecil, butuh .NET 8.0 Runtime

Masukkan pilihan [1-2]: _

Buat shortcut Desktop? [Y/n]: _
Buat shortcut Start Menu? [Y/n]: _
```

> 💡 **Update:** Jalankan perintah yang sama untuk update ke versi terbaru. Pengaturanmu akan tersimpan!

---

### 🗑️ Uninstalasi

```powershell
irm https://bit.ly/geetrpcs-del | iex
```

<details>
<summary><b>Opsi Instalasi Lanjutan</b></summary>

#### Instalasi Diam (Tanpa Prompt)
```powershell
# Portable + Semua Shortcut
irm https://bit.ly/geetrpcs | iex; Install-GeetRPCS -Silent -DesktopShortcut -StartMenuShortcut

# Minimal + Tanpa Shortcut
irm https://bit.ly/geetrpcs | iex; Install-GeetRPCS -Version "minimal" -Silent
```

#### Uninstalasi Diam
```powershell
# Uninstal bersih (hapus semua)
irm https://bit.ly/geetrpcs-del | iex; Uninstall-GeetRPCS -Silent

# Pertahankan data pengguna (settings, cache)
irm https://bit.ly/geetrpcs-del | iex; Uninstall-GeetRPCS -Silent -KeepUserData
```

#### Unduh Manual (Zip)
1. Unduh `.zip` terbaru dari **[Releases](https://github.com/makcrtve/geetRPCS/releases/latest)**
2. Ekstrak ke folder yang kamu inginkan
3. Jalankan `geetRPCS.exe`

</details>

---

## ✨ Fitur

<table>
<tr>
<td width="25%" valign="top">

**🎯 Inti**
- Deteksi Hybrid
- Single Instance
- RAM Ultra Rendah (5-20MB)
- Animasi Tray
- Dukungan Komentar JSON
- Auto-refresh Preview
- Manajer Blacklist Aplikasi

</td>
<td width="25%" valign="top">

**⚙️ Kontrol**
- Mode Jeda
- Mode Privat
- Pelacakan Statistik
- Ekspor CSV/JSON
- Multi-Bahasa (EN/ID)
- Hotkey Global
- Menu Quick Tray
- Ganti App ID dari Menu 🆕

</td>
<td width="25%" valign="top">

**🔧 Utilitas**
- I/O Async Dioptimalkan 🚀
- True Hot Reload
- Akses Cepat Config
- Auto Startup
- Log Kejadian
- Pengecek Update (UI Kustom) 🆕
- Manajemen Cache

</td>
<td width="25%" valign="top">

**🎨 Kustomisasi**
- Teks Witty Dinamis
- Aset Discord Kustom
- Placeholder Teks
- Tombol Kustom
- Validasi URL
- Pengaturan Per-Aplikasi
- Format Presence Fleksibel

</td>
</tr>
</table>

---

## 🎨 Animasi Tray Icon

Ikon tray sistem sekarang hidup! Ketika geetRPCS mendeteksi perpindahan aplikasi, ikon melakukan animasi **rotasi 360° dengan denyut kecerahan** yang halus.

| Properti | Nilai |
|:---------|:------|
| **Efek** | Rotasi + Denyut kecerahan |
| **Durasi** | 800ms (12 frame) |
| **Easing** | Ease-In-Out Quadratic |
| **Toggle** | Menu tray → "🎨 Tray Icon Animation" |

> 💡 Animasi halus ini memberikan konfirmasi visual bahwa geetRPCS mendeteksi pergantian aplikasimu!

---

## 🖱️ Detektor Energi Mouse

<p align="center">
  <b>Tampilkan level produktivitas real-timemu di Discord!</b>
</p>

geetRPCS memiliki fitur **Detektor Energi Mouse** - fitur unik yang menganalisis aktivitas mousemu dan menampilkan level "energi" kamu saat ini di Discord presence.

| Level | Emoji | Kondisi |
|:------|:-----:|:----------|
| **Sleeping** | 💤 | Tidak ada aktivitas > 30 detik |
| **Relaxing** | ☕ | Aktivitas rendah (scroll santai) |
| **Normal** | 🎯 | Aktivitas standar (kerja biasa) |
| **Focused** | 🔥 | Aktivitas tinggi (editing intensif) |
| **Rush** | ⚡ | Aktivitas sangat tinggi (mode tenggat waktu!) |

**Contoh tampilan Discord:**
```
Working on FL Studio 2025
Untitled - FL Studio | 🔥 Focused
```

> 💡 **Tips:** Aktifkan/nonaktifkan fitur ini melalui menu System Tray → "🖱️ Mouse Energy Detector"

---

## 🎭 Mesin Narasi Witty

<p align="center">
  <b>Bawa kepribadian pada status Discordmu!</b>
</p>

Alih-alih pesan "Working..." yang membosankan, geetRPCS sekarang menampilkan **teks dinamis dan humor** yang berputar setiap 60 detik!

**Fitur:**
- 🎲 Pilihan acak dari teks lucu yang dikurasi
- 🔄 Berputar otomatis setiap 60 detik
- 📝 Sepenuhnya bisa dikustomisasi lewat `witty.json`
- 🎯 Nol biaya performa
- 🔌 Placeholder `{witty_text}` baru

**Contoh Teks:**

| Aplikasi | Teks Witty |
|:----|:------------|
| **FL Studio** | "Producing next heater 🔥", "Where is the snare? 🥁", "Soundgoodizer on Master 🎚️" |
| **VS Code** | "Compiling spaghetti code 🍝", "It works on my machine 🤷", "Debugging 100 errors 🐛" |
| **Chrome** | "100 tabs open 🔥", "Researching on YouTube 🎥", "Definitely working... 👀" |

**Cara Pakai:**
1. Edit `witty.json` untuk menambahkan teks kamu sendiri
2. Gunakan `{witty_text}` di kolom `customDetails`
3. Reload dengan `Ctrl+Alt+R`

> 💡 **Tips:** 400+ teks pra-tulis disertakan untuk 40+ aplikasi!

---

## 🎯 Aplikasi yang Didukung

<details open>
<summary><b>42 Software • 65+ Nama Proses</b> (klik untuk beralih)</summary>

| Kategori | Aplikasi |
|:--------:|----------|
| 🎵 **DAW** | FL Studio, Ableton, Cubase, REAPER, Pro Tools, Studio One, Reason, Cakewalk |
| 🎬 **Video** | Premiere Pro, After Effects, DaVinci Resolve, Filmora, Vegas Pro, CapCut |
| 🎨 **Desain** | Photoshop, Illustrator, Lightroom, Figma, Canva, CorelDRAW, GIMP, Inkscape, Affinity |
| 🧊 **3D/CAD** | Blender, Maya, SketchUp, AutoCAD |
| 📡 **Stream** | OBS Studio, Streamlabs |
| 🌐 **Browser** | Chrome, Brave, Firefox, Edge, Zen |
| 📦 **Lainnya** | Orange Data Mining, Adobe Audition, VLC, MS Office, Telegram, HandBrake |

</details>

> 💡 **Tips:** Kamu bisa menambahkan aplikasimu sendiri di `apps.json`!

---

## 🖥️ Penggunaan

### ⌨️ Hotkey Global (Shortcut)
Kontrol geetRPCS langsung dari keyboardmu, bahkan saat aplikasi diminimalkan:

| Shortcut | Fungsi |
|----------|----------|
| `Ctrl + Alt + P` | ⏸️ Jeda / Lanjutkan Presence |
| `Ctrl + Alt + V` | 👀 Toggle Jendela Preview |
| `Ctrl + Alt + H` | 🔒 Toggle Mode Privat |
| `Ctrl + Alt + R` | 🔄 Reload Config |
| `Ctrl + Alt + S` | 📊 Tampilkan Statistik Hari Ini |

### 🖱️ Menu System Tray
**Klik kanan** pada ikon tray untuk mengakses menu manual:

| Menu | Fungsi |
|------|----------|
| ⏸️ Pause | Nyalakan/matikan presence |
| 🔒 Private Mode | Sensor judul jendela |
| 🖱️ Mouse Energy | Toggle detektor aktivitas |
| 🎨 Tray Animation | Toggle animasi ikon |
| 📡 Telemetry | Toggle data penggunaan anonim |
| 👀 Preview Window | Preview live Discord presence |
| 🛠️ Manage Apps | Aktifkan/nonaktifkan aplikasi |
| 🔑 Change App ID | Update App ID Discord secara instan 🆕 |
| 📊 Statistics | Lihat & ekspor statistik |
| ⚡ Quick Actions | Akses folder, edit config |
| 🌐 Language | Ubah bahasa (EN/ID) |

<details>
<summary><b>📸 Tangkapan Layar</b></summary>

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

### 🎯 Pengaturan Terpadu

geetRPCS bekerja **langsung jalan**! Aplikasi sekarang menggunakan `settings.json` terpusat dan cache internal untuk memastikan performa.

**config.json hanya dibutuhkan jika kamu ingin:**
- Menggunakan Application ID Discord kamu sendiri
- Mengkustomisasi teks presence
- Menambahkan tombol kustom

> 💡 **Tips:** Buat config.json lewat Quick Actions → "Edit config.json" (akan otomatis dibuat dengan default) ATAU gunakan item menu **"🔑 Change App ID"** yang baru!

<details>
<summary><b>🔑 Baru: Ganti App ID dari Tray</b></summary>

Mulai v1.3.1, kamu tidak perlu mengedit `config.json` secara manual untuk mengubah Application ID Discord.

1. Klik kanan ikon tray
2. Pilih **"🔑 Change App ID"**
3. Masukkan Application ID barumu
4. Klik OK

Aplikasi akan otomatis mengupdate `config.json` dan reload koneksi Discord.
</details>

<details>
<summary><b>📄 config.json</b> - Konfigurasi Utama (Opsional)</summary>

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
    "customDetails": "Producing on {app_name}",
    "buttons": [
      { "label": "Portfolio Saya", "url": "https://example.com" }
    ]
  }
]
```

**Menambahkan aplikasi:** Task Manager → catat nama proses → tambahkan ke apps.json → Reload All (`Ctrl+Alt+R`)

</details>

<details>
<summary><b>🔗 Persyaratan URL Tombol</b></summary>

geetRPCS memvalidasi URL tombol secara otomatis:

| Format URL | Status |
|:-----------|:------:|
| `https://github.com` | ✅ Valid |
| `http://example.com` | ✅ Valid |
| `github.com` | ❌ Dilewati (tidak ada protokol) |
| `ftp://files.com` | ❌ Dilewati (protokol tidak valid) |
| URL Kosong | ❌ Dilewati |

**Batas label tombol:** Maksimal 32 karakter

> Tombol yang tidak valid akan dilewati secara diam-diam - tidak ada error, mereka hanya tidak akan muncul di Discord.

</details>

<details>
<summary><b>🎨 Aset Discord</b> - Unggah gambar</summary>

1. Buka [Discord Developer Portal](https://discord.com/developers/applications)
2. Pilih aplikasi → **Rich Presence** → **Art Assets**
3. Unggah gambar dengan nama yang sesuai dengan `largeKey` / `smallKey`

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/discord-assets.png" width="500"/>
</p>

</details>

<details>
<summary><b>📁 Struktur File</b></summary>

```
📁 %LOCALAPPDATA%\geetRPCS\
├── geetRPCS.exe          # Aplikasi utama
├── apps.json             # Daftar aplikasi (dibutuhkan)
├── witty.json            # Teks witty (dibutuhkan)
├── rpicon.ico            # Ikon (dibutuhkan)
├── config.json           # Konfigurasi Discord RPC (opsional)
├── settings.json         # Pengaturan pengguna (kelola otomatis, async)
├── statistics.json       # Data pelacakan (kelola otomatis, async)
├── geetRPCS.log          # File log (digenerate otomatis)
├── .telemetry            # Penghitung peluncuran (digenerate otomatis)
├── ImageCache/           # Cache gambar Preview (digenerate otomatis)
└── Languages/            # File bahasa (digenerate otomatis)
```

</details>

---

## ❓ FAQ

<details>
<summary><b>Presence tidak muncul di Discord?</b></summary>

1. Pastikan kamu menggunakan Discord **Desktop** (bukan web)
2. Settings → Activity Privacy → Aktifkan "Display current activity"
3. Restart geetRPCS dan Discord
4. Pastikan kamu tidak dalam mode **Pause**

</details>

<details>
<summary><b>Cara update geetRPCS?</b></summary>

Cukup jalankan perintah instalasi yang sama:

```powershell
irm https://bit.ly/geetrpcs | iex
```

Instaler akan:
- ✅ Mendeteksi versi saat ini
- ✅ Mengunduh hanya jika versi baru tersedia
- ✅ Membackup pengaturanmu (`apps.json`, `settings.json`, `statistics.json`)
- ✅ Menginstall update
- ✅ Mengembalikan pengaturanmu

**Catatan v1.3.1:** Pengecek update sekarang memiliki dialog kustom yang cantik dengan tema Discord!

</details>

<details>
<summary><b>Animasi tray tidak jalan?</b></summary>

1. Pastikan "🎨 Tray Icon Animation" diaktifkan di menu tray
2. Animasi hanya terpicu pada **perpindahan aplikasi** (bukan perubahan judul jendela)
3. Cek `geetRPCS.log` untuk pesan TrayAnimator

</details>

<details>
<summary><b>Startup tidak jalan?</b></summary>

v1.2.7+ meningkatkan validasi startup:
1. Pastikan geetRPCS **TIDAK** berjalan dari folder temporary
2. Pindahkan aplikasi ke lokasi permanen (misalnya `C:\Programs\geetRPCS\`)
3. Aktifkan startup lagi lewat menu tray
4. Jika kamu memindahkan aplikasi, aktifkan lagi startup untuk update path registry

</details>

<details>
<summary><b>Aplikasi baru tidak terdeteksi setelah edit apps.json?</b></summary>

1. Edit `apps.json` dan simpan
2. Klik kanan tray → Quick Actions → **Reload All** (atau tekan `Ctrl+Alt+R`)
3. Aplikasi baru seharusnya terdeteksi segera

Jika masih tidak jalan, cek:
- Nama proses cocok persis (case-insensitive)
- Sintaks JSON valid
- Aplikasi tidak didisable di **Manage Apps**

</details>

<details>
<summary><b>Mouse Energy tidak update?</b></summary>

1. Pastikan "🖱️ Mouse Energy Detector" diaktifkan di menu tray
2. Fitur ini menganalisis aktivitas seiring waktu - tunggu beberapa detik
3. Beberapa aplikasi fullscreen mungkin mempengaruhi deteksi
4. Cek `geetRPCS.log` untuk error MouseTracker

</details>

<details>
<summary><b>Tombol tidak muncul di Discord?</b></summary>

Cek apakah URL kamu:
- Diawali dengan `http://` atau `https://`
- Adalah URL yang valid (bukan cuma nama domain)
- Labelnya 32 karakter atau kurang

**Contoh tombol valid:**
```json
{ "label": "Website Saya", "url": "https://example.com" }
```

</details>

<details>
<summary><b>Hotkey tidak jalan?</b></summary>

Pastikan tidak ada aplikasi lain yang menggunakan shortcut yang sama. Beberapa game fullscreen yang berjalan "As Administrator" mungkin memblokir hotkey jika geetRPCS tidak juga dijalankan sebagai Admin.

</details>

<details>
<summary><b>Gambar tidak muncul?</b></summary>

1. Unggah gambar di Discord Developer Portal
2. Tunggu beberapa menit (sinkronisasi Discord)
3. Nama kunci harus cocok **persis** (case sensitive)
4. Jendela Preview → 🔄 Refresh (Auto-refresh aktif di v1.2.8)

</details>

<details>
<summary><b>Pemecahan Masalah</b></summary>

Buka `geetRPCS.log` atau klik kanan tray → **Open Log File**

| Error | Solusi |
|-------|----------|
| Apps.json not found | Pastikan apps.json ada di folder yang sama |
| Discord not connected | Pastikan Discord Desktop berjalan |
| Presence not showing | Cek mode Pause dan Manage Apps |
| Preview image empty | Clear Cache → Refresh |
| Mouse hook failed | Jalankan sebagai Administrator |
| Buttons not appearing | Cek format URL (harus diawali http/https) |
| Startup from temp rejected | Pindahkan aplikasi ke folder permanen |
| Already running | v1.2.8 mencegah instance ganda. Cek tray. |

</details>

---

## 🛡️ Keamanan

<p align="center">
  <a href="https://www.virustotal.com/gui/file/36128aa46bd9505c3543f7ad2a9f9bbc51222b86fbd913d817f7b2bf056ab3dd/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F71%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
  <a href="https://www.virustotal.com/gui/file/a241c2b9cf59588b5f15be46072a54c224c1b94f5fb47d3a392ac65acb67a7c6/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F69%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
</p>

<details>
<summary><b>Detail Scan & Info False Positive</b></summary>

**Hasil Scan v1.3.1:**
- ✅ `0/71` | `0/70` deteksi malware (Clean)
- ✅ Code Signed: Tidak (Self-contained)

**False Positive?** Beberapa AV mungkin menandainya karena:
- Executable baru / belum tersebar luas
- Akses Discord RPC API
- Akses Registry (auto-startup)
- **Global Hotkey hooks** (RegisterHotKey API)
- **Mouse hooks** (SetWindowsHookEx API)
- **Manipulasi Icon** (GDI+ untuk animasi tray)

**Solusi:** Masukkan ke daftar putih (whitelist) di antivirus atau verifikasi di [VirusTotal](https://www.virustotal.com)

</details>

---

## 🔮 Peta Jalan (Roadmap)

- [x] Pengecek auto-update (UI Kustom)
- [x] Pelacak statistik (I/O Async)
- [x] Multi-bahasa (EN/ID)
- [x] Jendela Preview
- [x] Manajer Aplikasi
- [x] Dukungan Hotkey Global
- [x] Detektor Energi Mouse
- [x] Smart Defaults (config opsional)
- [x] True Hot Reload
- [x] Validasi URL untuk tombol
- [x] Animasi Tray Icon
- [x] Instaler/updater satu perintah
- [x] Paksakan Single Instance
- [x] Optimasi Memori
- [x] Ganti App ID dari Menu 🆕
- [ ] Dukungan software lainnya
- [ ] Dashboard UI (WPF/WinUI)

---

## 📞 Link

<p align="center">
  <a href="https://github.com/makcrtve/geetRPCS/issues">🐛 Lapor Bug</a> •
  <a href="https://github.com/makcrtve/geetRPCS/discussions">💬 Diskusi</a> •
  <a href="https://github.com/makcrtve/geetRPCS/releases">📦 Rilis</a> •
  <a href="https://discord.gg/ScTybDUEpH">🎮 Gabung Discord</a>
</p>

---

<p align="center">
  <sub>Dibuat dengan ❤️ oleh <a href="https://github.com/makcrtve">makcrtve</a></sub><br/>
  <sub>geetRPCS v1.3.1 • MIT License • 2026</sub>
</p>
