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
  <a href="https://github.com/Lachee/discord-rpc-csharp">
    <img src="https://img.shields.io/badge/using-C%23-00bb88.svg?style=flat-square&logo=csharp&logoColor=white" alt="using C#"/>
  </a>
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
  <a href="#-aplikasi-yang-didukung">Aplikasi</a> •
  <a href="#%EF%B8%8F-konfigurasi">Konfigurasi</a> •
  <a href="#-faq">FAQ</a>
</p>

---

## 🚀 Mulai Cepat

### ⚡ Instalasi Satu Perintah (Direkomendasikan)

Buka **PowerShell** dan jalankan:

```powershell
irm https://bit.ly/geetrpcs | iex
```

Installer interaktif akan memandumu:

```
  ╔═══════════════════════════════════════════╗
  ║       geetRPCS Installer / Updater        ║
  ╚═══════════════════════════════════════════╝

Pilih Versi:
  [1] Portable (Direkomendasikan) - Standalone, tanpa dependensi
  [2] Minimal - Ukuran lebih kecil, butuh .NET 8.0 Runtime

Masukkan pilihan [1-2]: _

Buat shortcut Desktop? [Y/n]: _
Buat shortcut Start Menu? [Y/n]: _
```

> 💡 **Update:** Jalankan perintah yang sama untuk memperbarui ke versi terbaru. Pengaturanmu akan tersimpan aman!

---

### 🗑️ Uninstall

```powershell
irm https://bit.ly/geetrpcs-del | iex
```

<details>
<summary><b>Opsi Instalasi Lanjutan</b></summary>

#### Silent Install (Tanpa Dialog)
```powershell
# Portable + Semua Shortcut
irm https://bit.ly/geetrpcs | iex; Install-GeetRPCS -Silent -DesktopShortcut -StartMenuShortcut

# Minimal + Tanpa Shortcut
irm https://bit.ly/geetrpcs | iex; Install-GeetRPCS -Version "minimal" -Silent
```

#### Silent Uninstall
```powershell
# Hapus bersih (termasuk pengaturan)
irm https://bit.ly/geetrpcs-del | iex; Uninstall-GeetRPCS -Silent

# Simpan data user (pengaturan, cache)
irm https://bit.ly/geetrpcs-del | iex; Uninstall-GeetRPCS -Silent -KeepUserData
```

#### Download Manual (Zip)
1. Download `.zip` terbaru dari **[Releases](https://github.com/makcrtve/geetRPCS/releases/latest)**
2. Ekstrak ke folder pilihanmu
3. Jalankan `geetRPCS.exe`

</details>

---

## ✨ Fitur

<table>
<tr>
<td width="50%">

### 🎯 Inti
- 🔍 **Deteksi Hybrid** - Event-based + Polling
- 🛡️ **Single Instance** - Mencegah duplikat proses
- 📉 **Hemat RAM Ekstrem** - Hanya 5-15MB RAM
- 🎨 **Animasi Tray** - Efek visual saat ganti aplikasi
- 👀 **Smart Preview** - Preview presence auto-refresh
- 🛠️ **Manajer Aplikasi** - Blacklist aplikasi tertentu

</td>
<td width="50%">

### ⚙️ Kontrol
- ⏸️ **Mode Jeda** - Sembunyikan presence sementara
- 🔒 **Mode Privat** - Sensor judul window
- 📊 **Statistik** - Tracking + Ekspor CSV/JSON
- 🌐 **Multi-Bahasa** - EN / ID

</td>
</tr>
<tr>
<td width="50%">

### 🔧 Utilitas
- 🖱️ **Energi Mouse** - Level aktivitas real-time
- 🔄 **Hot Reload Nyata** - Edit & terapkan instan
- ⚡ **Aksi Cepat** - Akses cepat ke config
- 🚀 **Otomatis Startup** - Jalan saat Windows mulai

</td>
<td width="50%">

### 🎨 Kustomisasi
- 🖼️ **Aset Kustom** - Pakai gambar sendiri
- 📝 **Teks Kustom** - Teks & placeholder bebas
- 🔘 **Tombol Kustom** - Link ke portofolio
- 🔗 **Validasi URL** - Filter tombol cerdas

</td>
</tr>
</table>

---

## 🎨 Animasi Ikon Tray

Ikon system tray kini lebih hidup! Saat geetRPCS mendeteksi perpindahan aplikasi, ikon akan melakukan efek **rotasi 360° dengan denyut kecerahan** yang halus.

| Properti | Nilai |
|:---------|:------|
| **Efek** | Rotasi + Denyut Kecerahan |
| **Durasi** | 800ms (12 frame) |
| **Easing** | Ease-In-Out Quadratic |
| **Toggle** | Menu Tray → "🎨 Animasi Ikon Tray" |

> 💡 Animasi halus ini memberikan konfirmasi visual bahwa geetRPCS telah mendeteksi perpindahan aplikasimu!

---

## 🖱️ Detektor Energi Mouse

<p align="center">
  <b>Tunjukkan tingkat produktivitasmu secara real-time di Discord!</b>
</p>

geetRPCS memiliki fitur **Mouse Energy Detector** - fitur unik yang menganalisis aktivitas mouse dan menampilkan "tingkat energi" kamu saat ini di Discord presence.

| Level | Emoji | Kondisi |
|:------|:-----:|:----------|
| **Tidur** | 💤 | Tidak ada aktivitas > 30 detik |
| **Santai** | ☕ | Aktivitas rendah (scrolling santai) |
| **Normal** | 🎯 | Aktivitas standar (kerja biasa) |
| **Fokus** | 🔥 | Aktivitas tinggi (editing intensif) |
| **Buru-buru** | ⚡ | Aktivitas sangat tinggi (mode deadline!) |

**Contoh tampilan di Discord:**
```
Working on FL Studio 2025
Untitled - FL Studio | 🔥 Fokus
```

> 💡 **Tip:** Aktifkan/matikan fitur ini via menu System Tray → "🖱️ Detektor Energi Mouse"

---

## 🎯 Aplikasi yang Didukung

<details open>
<summary><b>42 Software • 65+ Nama Proses</b> (klik untuk lihat)</summary>

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

> 💡 **Tip:** Kamu bisa menambahkan aplikasimu sendiri di `apps.json`!

---

## 🖥️ Cara Penggunaan

### ⌨️ Global Hotkeys (Shortcut)
Kontrol geetRPCS langsung dari keyboard, bahkan saat aplikasi diminimize:

| Shortcut | Fungsi |
|----------|----------|
| `Ctrl + Alt + P` | ⏸️ Jeda / Lanjutkan Presence |
| `Ctrl + Alt + V` | 👀 Buka/Tutup Jendela Preview |
| `Ctrl + Alt + H` | 🔒 Toggle Mode Privat |
| `Ctrl + Alt + R` | 🔄 Muat Ulang Config |
| `Ctrl + Alt + S` | 📊 Lihat Statistik Hari Ini |

### 🖱️ Menu System Tray
**Klik kanan** ikon tray untuk mengakses menu manual:

| Menu | Fungsi |
|------|----------|
| ⏸️ Jeda | Nyalakan/matikan presence |
| 🔒 Mode Privat | Sensor judul window |
| 🖱️ Energi Mouse | Toggle detektor aktivitas |
| 🎨 Animasi Tray | Toggle animasi ikon |
| 📡 Telemetri | Toggle data penggunaan anonim |
| 👀 Jendela Preview | Preview live tampilan Discord |
| 🛠️ Kelola Aplikasi | Aktifkan/nonaktifkan aplikasi |
| 📊 Statistik | Lihat & ekspor statistik |
| ⚡ Aksi Cepat | Buka folder, edit config |
| 🌐 Bahasa | Ubah bahasa (EN/ID) |

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

### 🎯 Pengaturan Terpadu (Unified Settings)

geetRPCS langsung bekerja **tanpa ribet**! Aplikasi kini menggunakan `settings.json` terpusat dan cache internal untuk performa maksimal.

**config.json hanya dibutuhkan jika kamu ingin:**
- Menggunakan Discord Application ID milikmu sendiri
- Mengubah teks presence default
- Menambah tombol kustom (buttons)

> 💡 **Tip:** Buat config.json via Aksi Cepat → "Edit config.json" (akan dibuat otomatis dengan default)

<details>
<summary><b>📄 config.json</b> - Konfigurasi Utama (Opsional)</summary>

```json
{
  "Discord": {
    "ApplicationId": "ID_APLIKASI_DISCORD_KAMU",
    "Details": "Idling...",
    "State": "Ready to work",
    "ActiveDetails": "Working on {app_name}",
    "ActiveState": "{window_title}",
    "Assets": {
      "LargeImageKey": "geetrpcs-logo",
      "LargeImageText": "geetRPCS v1.2.7",
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
<summary><b>📄 apps.json</b> - Daftar Aplikasi</summary>

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
      { "label": "Portofolio Saya", "url": "https://example.com" }
    ]
  }
]
```

**Menambah aplikasi:** Buka Task Manager → catat nama proses → tambah ke apps.json → Muat Ulang Semua (`Ctrl+Alt+R`)

</details>

<details>
<summary><b>🔗 Syarat URL Tombol</b></summary>

geetRPCS memvalidasi URL tombol secara otomatis:

| Format URL | Status |
|:-----------|:------:|
| `https://github.com` | ✅ Valid |
| `http://example.com` | ✅ Valid |
| `github.com` | ❌ Diabaikan (tanpa protokol) |
| `ftp://files.com` | ❌ Diabaikan (protokol salah) |
| URL Kosong | ❌ Diabaikan |

**Batas label tombol:** Maksimum 32 karakter

> Tombol yang tidak valid akan diabaikan secara diam-diam - tidak ada error, tombol hanya tidak akan muncul di Discord.

</details>

<details>
<summary><b>🎨 Aset Discord</b> - Upload gambar</summary>

1. Buka [Discord Developer Portal](https://discord.com/developers/applications)
2. Pilih aplikasi → **Rich Presence** → **Art Assets**
3. Upload gambar dengan nama yang sesuai dengan `largeKey` / `smallKey`

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/discord-assets.png" width="500"/>
</p>

</details>

<details>
<summary><b>📁 Struktur File</b></summary>

```
📁 %LOCALAPPDATA%\geetRPCS\
├── geetRPCS.exe          # Aplikasi utama
├── apps.json             # Daftar aplikasi (wajib)
├── rpicon.ico            # Ikon (wajib)
├── config.json           # Konfigurasi Discord RPC (opsional)
├── settings.json         # Pengaturan user (otomatis)
├── statistics.json       # Data tracking (otomatis)
├── geetRPCS.log          # File log (otomatis)
├── .telemetry            # Penghitung launch (otomatis)
├── ImageCache/           # Cache gambar preview (otomatis)
└── Languages/            # File bahasa (otomatis)
```

</details>

---

## ❓ FAQ

<details>
<summary><b>Presence tidak muncul di Discord?</b></summary>

1. Pastikan kamu menggunakan Discord **Desktop** (bukan web)
2. Settings → Activity Privacy → Aktifkan "Display current activity"
3. Restart geetRPCS dan Discord
4. Pastikan kamu tidak sedang dalam mode **Jeda (Pause)**

</details>

<details>
<summary><b>Bagaimana cara update geetRPCS?</b></summary>

Cukup jalankan perintah instalasi yang sama:

```powershell
irm https://bit.ly/geetrpcs | iex
```

Installer akan:
- ✅ Mendeteksi versi saat ini
- ✅ Download hanya jika ada versi baru
- ✅ Backup pengaturanmu (`apps.json`, `settings.json`, `statistics.json`)
- ✅ Install update
- ✅ Restore pengaturanmu

</details>

<details>
<summary><b>Animasi tray tidak jalan?</b></summary>

1. Pastikan "🎨 Animasi Ikon Tray" aktif di menu tray
2. Animasi hanya memicu saat **ganti aplikasi** (bukan saat judul window berubah)
3. Cek `geetRPCS.log` untuk pesan TrayAnimator

</details>

<details>
<summary><b>Startup tidak berfungsi?</b></summary>

v1.2.7+ meningkatkan validasi startup:
1. Pastikan geetRPCS **tidak** dijalankan dari folder temporary (seperti folder download zip langsung)
2. Pindahkan aplikasi ke folder permanen (contoh: `C:\Programs\geetRPCS\`)
3. Aktifkan ulang startup via menu tray
4. Jika kamu memindahkan lokasi aplikasi, matikan dan nyalakan lagi startup untuk memperbarui registry

</details>

<details>
<summary><b>Aplikasi baru tidak terdeteksi setelah edit apps.json?</b></summary>

1. Edit `apps.json` dan simpan
2. Klik kanan tray → Aksi Cepat → **Muat Ulang Semua** (atau tekan `Ctrl+Alt+R`)
3. Aplikasi baru harusnya langsung terdeteksi

Jika masih tidak bisa, cek:
- Nama proses cocok persis (case-insensitive)
- Format JSON valid
- Aplikasi tidak dimatikan di menu **Kelola Aplikasi**

</details>

<details>
<summary><b>Energi Mouse tidak berubah?</b></summary>

1. Pastikan "🖱️ Detektor Energi Mouse" aktif di menu tray
2. Fitur ini menganalisis aktivitas seiring waktu - tunggu beberapa detik
3. Beberapa aplikasi fullscreen mungkin mempengaruhi deteksi hook
4. Cek `geetRPCS.log` untuk error MouseTracker

</details>

<details>
<summary><b>Tombol tidak muncul di Discord?</b></summary>

Cek URL kamu:
- Harus diawali `http://` atau `https://`
- Harus URL valid (bukan cuma nama domain)
- Label maksimal 32 karakter

**Contoh tombol valid:**
```json
{ "label": "Website Saya", "url": "https://example.com" }
```

</details>

<details>
<summary><b>Hotkeys tidak berfungsi?</b></summary>

Pastikan tidak ada aplikasi lain yang menggunakan shortcut yang sama. Beberapa game fullscreen yang berjalan "As Administrator" mungkin memblokir hotkey jika geetRPCS tidak dijalankan sebagai Admin juga.

</details>

<details>
<summary><b>Gambar tidak muncul?</b></summary>

1. Upload gambar di Discord Developer Portal
2. Tunggu beberapa menit (sinkronisasi Discord)
3. Nama Key harus cocok **persis** (case sensitive)
4. Jendela Preview → 🔄 Refresh (Auto-refresh sudah aktif di v1.2.8)

</details>

<details>
<summary><b>Pemecahan Masalah</b></summary>

Buka `geetRPCS.log` atau klik kanan tray → **Buka File Log**

| Masalah | Solusi |
|-------|----------|
| Apps.json not found | Pastikan apps.json ada di folder yang sama |
| Discord not connected | Pastikan Discord Desktop berjalan |
| Presence not showing | Cek mode Jeda dan Kelola Aplikasi |
| Preview image empty | Hapus Cache → Refresh |
| Mouse hook failed | Jalankan sebagai Administrator |
| Buttons not appearing | Cek format URL (harus http/https) |
| Startup from temp rejected | Pindahkan aplikasi ke folder permanen |
| Already running | v1.2.8 mencegah duplikat instance. Cek tray. |

</details>

---

## 🛡️ Keamanan

<p align="center">
  <a href="https://www.virustotal.com/gui/file/09b073de3ed8bc48eb79e6a5c621ed943f30db0737cf0397302da6bc53d759f8/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F71%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
  <a href="https://www.virustotal.com/gui/file/1e9dd509fdef735ef62ffb128ca871f07c10a2d15058a3531061117b6b4900d6/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F69%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>  
</p>

<details>
<summary><b>Detail Scan & Info False Positive</b></summary>

**Hasil Scan v1.2.8:**
- ✅ **0/71** deteksi malware (Clean)
- ✅ Code Signed: Tidak (Self-contained)

**False Positive?** Beberapa Antivirus mungkin menandainya karena:
- Executable baru / belum banyak didistribusikan
- Akses API Discord RPC
- Akses Registry (untuk auto-startup)
- **Hook Global Hotkey** (API RegisterHotKey)
- **Hook Mouse** (API SetWindowsHookEx)
- **Manipulasi Ikon** (GDI+ untuk animasi tray)

**Solusi:** Whitelist di antivirus atau verifikasi sendiri di [VirusTotal](https://www.virustotal.com)

</details>

---

## 🔮 Roadmap

- [x] Auto-update checker
- [x] Pelacak statistik
- [x] Multi-bahasa (EN/ID)
- [x] Jendela Preview
- [x] Manajer Aplikasi
- [x] Dukungan Global Hotkeys
- [x] Detektor Energi Mouse
- [x] Smart Defaults (config opsional)
- [x] True Hot Reload
- [x] Validasi URL untuk tombol
- [x] Animasi Ikon Tray
- [x] Installer/updater satu perintah
- [x] Single Instance Enforcement
- [x] Optimasi Memori
- [ ] Dukungan software lebih banyak
- [ ] Dashboard UI (WPF/WinUI)
- [ ] Pelacakan aktivitas keyboard

---

## 📞 Tautan

<p align="center">
  <a href="https://github.com/makcrtve/geetRPCS/issues">🐛 Lapor Bug</a> •
  <a href="https://github.com/makcrtve/geetRPCS/discussions">💬 Diskusi</a> •
  <a href="https://github.com/makcrtve/geetRPCS/releases">📦 Rilis</a>
</p>

---

<p align="center">
  <sub>Dibuat dengan ❤️ oleh <a href="https://github.com/makcrtve">makcrtve</a></sub><br/>
  <sub>geetRPCS v1.2.8 • MIT License • 2026</sub>
</p>
