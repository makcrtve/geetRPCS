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
  <a href="#-aplikasi-didukung">Aplikasi Didukung</a> •
  <a href="#%EF%B8%8F-konfigurasi">Konfigurasi</a> •
  <a href="#-faq">FAQ</a>
</p>

---

## 🚀 Mulai Cepat

Pilih metode instalasi yang sesuai:

### 1. Direkomendasikan (Portable + Shortcut) ⭐
Unduh versi portable (standalone) via PowerShell dan otomatis membuat shortcut Desktop.
```ps
irm https://raw.githubusercontent.com/makcrtve/geetRPCS/main/install.ps1 | iex; Install-GeetRPCS -DesktopShortcut
```

### 2. Ringan (Minimal + Shortcut)
Ukuran file lebih kecil, tapi memerlukan [.NET 8.0 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/8.0/runtime). Termasuk shortcut Desktop.
```ps
irm https://raw.githubusercontent.com/makcrtve/geetRPCS/main/install.ps1 | iex; Install-GeetRPCS -Version "minimal" -DesktopShortcut
```

### 3. Standar (Portable Saja)
Unduh versi portable via PowerShell tanpa membuat shortcut.
```ps
irm https://raw.githubusercontent.com/makcrtve/geetRPCS/main/install.ps1 | iex; Install-GeetRPCS
```

### 4. Unduh Manual (Zip)
Jika tidak ingin menggunakan command line:
1. Unduh file `.zip` terbaru dari **[Halaman Releases](https://github.com/makcrtve/geetRPCS/releases/latest)**.
2. **Ekstrak** file zip ke folder pilihanmu.
3. **Jalankan** `geetRPCS.exe`.

---

## ✨ Fitur

<table>
<tr>
<td width="50%">

### 🎯 Inti
- 🔍 **Auto Deteksi** - 40+ aplikasi populer
- 🖱️ **Mouse Energy** - Level aktivitas real-time
- 🎨 **Animasi Tray** - Feedback visual saat ganti app [BARU]
- ⌨️ **Hotkey Global** - Pintasan keyboard
- 👀 **Jendela Preview** - Preview presence langsung
- 🛠️ **Manajer App** - Blacklist aplikasi

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
- 🎯 **Smart Defaults** - Jalan tanpa config.json
- 🔄 **True Hot Reload** - Edit & terapkan langsung
- ⚡ **Aksi Cepat** - Akses cepat ke config
- 🚀 **Auto Startup** - Jalan saat Windows start [DIPERBAIKI]

</td>
<td width="50%">

### 🎨 Kustomisasi
- 🖼️ **Aset Kustom** - Gunakan gambar sendiri
- 📝 **Teks Kustom** - Teks & placeholder kustom
- 🔘 **Tombol Kustom** - Link ke portfolio
- 🔗 **Validasi URL** - Filter tombol pintar

</td>
</tr>
</table>

---

## 🎨 Animasi Ikon Tray <sup>BARU</sup>

Ikon system tray kini hidup! Saat geetRPCS mendeteksi pergantian aplikasi, ikon akan melakukan animasi **rotasi 360° dengan efek brightness pulse** yang smooth.

| Properti | Nilai |
|:---------|:------|
| **Efek** | Rotasi + Brightness pulse |
| **Durasi** | 800ms (12 frame) |
| **Easing** | Ease-In-Out Quadratic |
| **Toggle** | Menu tray → "🎨 Animasi Ikon Tray" |

> 💡 Animasi halus ini memberikan konfirmasi visual bahwa geetRPCS mendeteksi pergantian aplikasimu!

---

## 🖱️ Detektor Energi Mouse

<p align="center">
  <b>Tunjukkan level produktivitasmu secara real-time di Discord!</b>
</p>

geetRPCS memiliki fitur **Detektor Energi Mouse** - fitur unik yang menganalisis aktivitas mouse dan menampilkan "level energi" kamu di Discord presence.

| Level | Emoji | Kondisi |
|:------|:-----:|:--------|
| **Tidur** | 💤 | Tidak ada aktivitas > 30 detik |
| **Santai** | ☕ | Aktivitas rendah (scroll santai) |
| **Normal** | 🎯 | Aktivitas standar (kerja biasa) |
| **Fokus** | 🔥 | Aktivitas tinggi (editing intensif) |
| **Rush** | ⚡ | Aktivitas sangat tinggi (mode deadline!) |

**Contoh tampilan Discord:**
```
Working on FL Studio 2025
Untitled - FL Studio | 🔥 Fokus
```

> 💡 **Tip:** Aktifkan/nonaktifkan fitur ini via menu System Tray → "🖱️ Detektor Energi Mouse"

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

### ⌨️ Hotkey Global (Pintasan)
Kontrol geetRPCS langsung dari keyboard, bahkan saat aplikasi diminimalkan:

| Pintasan | Fungsi |
|----------|--------|
| `CTRL` + `ALT` + `P` | ⏸️ Jeda / Lanjutkan Presence |
| `CTRL` + `ALT` + `V` | 👀 Toggle Jendela Preview |
| `CTRL` + `ALT` + `H` | 🔒 Toggle Mode Privat |
| `CTRL` + `ALT` + `R` | 🔄 Reload Config |
| `CTRL` + `ALT` + `S` | 📊 Tampilkan Statistik Hari Ini |

### 🖱️ Menu System Tray
**Klik kanan** ikon tray untuk mengakses menu:

| Menu | Fungsi |
|------|--------|
| ⏸️ Jeda | Toggle presence on/off |
| 🔒 Mode Privat | Sensor judul window |
| 🖱️ Mouse Energy | Toggle detektor aktivitas |
| 🎨 Animasi Tray | Toggle animasi ikon [BARU] |
| 📡 Telemetri | Toggle data penggunaan anonim |
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

### 🎯 Smart Defaults

geetRPCS langsung berfungsi **tanpa** memerlukan file `config.json`! Aplikasi menggunakan pengaturan default yang sudah dioptimalkan.

**config.json hanya diperlukan jika ingin:**
- Menggunakan Application ID Discord sendiri
- Kustomisasi teks presence
- Menambahkan tombol kustom

> 💡 **Tip:** Buat config.json via Aksi Cepat → "Edit config.json" (akan dibuat otomatis dengan default)

<details>
<summary><b>📄 config.json</b> - Konfigurasi utama (Opsional)</summary>

```json
{
  "Discord": {
    "ApplicationId": "APPLICATION_ID_DISCORD_KAMU",
    "Details": "Menganggur...",
    "State": "Siap bekerja",
    "ActiveDetails": "Bekerja di {app_name}",
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
    "customDetails": "Produksi di {app_name}",
    "buttons": [
      { "label": "Portfolio Saya", "url": "https://example.com" }
    ]
  }
]
```

**Menambah app:** Task Manager → catat nama proses → tambahkan ke apps.json → Reload Semua (`CTRL+ALT+R`)

</details>

<details>
<summary><b>🔗 Syarat URL Tombol</b></summary>

geetRPCS memvalidasi URL tombol secara otomatis:

| Format URL | Status |
|:-----------|:------:|
| `https://github.com` | ✅ Valid |
| `http://example.com` | ✅ Valid |
| `github.com` | ❌ Dilewati (tanpa protokol) |
| `ftp://files.com` | ❌ Dilewati (protokol tidak valid) |
| URL kosong | ❌ Dilewati |

**Batas label tombol:** Maksimal 32 karakter

> Tombol tidak valid akan dilewati tanpa error - hanya tidak muncul di Discord.

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
├── geetRPCS.exe          # Aplikasi utama (v1.2.7)
├── apps.json             # Daftar aplikasi (wajib)
├── rpicon.ico            # Ikon (wajib)
├── config.json           # Konfigurasi Discord RPC (opsional)
├── settings.json         # Pengaturan (otomatis)
├── statistics.json       # Data tracking (otomatis)
├── geetRPCS.log          # File log (otomatis)
├── .telemetry            # Penghitung launch (otomatis)
├── ImageCache/           # Cache gambar (otomatis)
└── Languages/            # File bahasa (otomatis)
```

</details>

---

## ❓ FAQ

<details>
<summary><b>Presence tidak muncul di Discord?</b></summary>

1. Pastikan menggunakan Discord **Desktop** (bukan web)
2. Settings → Activity Privacy → Aktifkan "Display current activity"
3. Restart geetRPCS dan Discord
4. Pastikan tidak dalam mode **Jeda**

</details>

<details>
<summary><b>Animasi tray tidak berfungsi?</b></summary>

1. Pastikan "🎨 Animasi Ikon Tray" diaktifkan di menu tray
2. Animasi hanya terpicu saat **ganti aplikasi** (bukan perubahan judul window)
3. Cek `geetRPCS.log` untuk pesan TrayAnimator

</details>

<details>
<summary><b>Startup tidak berfungsi?</b></summary>

v1.2.7 memperbaiki validasi startup:
1. Pastikan geetRPCS **tidak** dijalankan dari folder temporary
2. Pindahkan aplikasi ke lokasi permanen (contoh: `C:\Programs\geetRPCS\`)
3. Aktifkan startup lagi via menu tray
4. Jika memindahkan aplikasi, aktifkan ulang startup untuk update path registry

</details>

<details>
<summary><b>Aplikasi baru tidak terdeteksi setelah edit apps.json?</b></summary>

1. Edit `apps.json` dan simpan
2. Klik kanan tray → Aksi Cepat → **Reload Semua** (atau tekan `CTRL+ALT+R`)
3. Aplikasi baru seharusnya langsung terdeteksi

Jika masih tidak berfungsi, periksa:
- Nama proses cocok persis (case-insensitive)
- Sintaks JSON valid
- Aplikasi tidak dinonaktifkan di **Kelola Aplikasi**

</details>

<details>
<summary><b>Mouse Energy tidak update?</b></summary>

1. Pastikan "🖱️ Detektor Energi Mouse" diaktifkan di menu tray
2. Fitur ini menganalisis aktivitas seiring waktu - tunggu beberapa detik
3. Beberapa aplikasi fullscreen mungkin mempengaruhi deteksi
4. Cek `geetRPCS.log` untuk error MouseTracker

</details>

<details>
<summary><b>Tombol tidak muncul di Discord?</b></summary>

Pastikan URL-mu:
- Diawali dengan `http://` atau `https://`
- URL valid (bukan hanya nama domain)
- Label maksimal 32 karakter

**Contoh tombol valid:**
```json
{ "label": "Website Saya", "url": "https://example.com" }
```

</details>

<details>
<summary><b>Hotkey tidak berfungsi?</b></summary>

Pastikan tidak ada aplikasi lain yang menggunakan shortcut yang sama. Beberapa game fullscreen yang berjalan "As Administrator" mungkin memblokir hotkey jika geetRPCS tidak juga dijalankan sebagai Admin.

</details>

<details>
<summary><b>Gambar tidak muncul?</b></summary>

1. Upload gambar di Discord Developer Portal
2. Tunggu beberapa menit (sinkronisasi Discord)
3. Nama key harus cocok **persis** (case sensitive)
4. Jendela Preview → 🔄 Refresh

</details>

<details>
<summary><b>Troubleshooting</b></summary>

Buka `geetRPCS.log` atau klik kanan tray → **Buka File Log**

| Error | Solusi |
|-------|--------|
| Apps.json tidak ditemukan | Pastikan apps.json ada di folder yang sama |
| Discord tidak terhubung | Pastikan Discord Desktop berjalan |
| Presence tidak muncul | Cek mode Jeda dan Kelola Aplikasi |
| Gambar preview kosong | Clear Cache → Refresh |
| Mouse hook gagal | Jalankan sebagai Administrator |
| Tombol tidak muncul | Cek format URL (harus diawali http/https) |
| Startup dari temp ditolak | Pindahkan app ke folder permanen |

</details>

---

## 🛡️ Keamanan

<p align="center">
  <a href="https://www.virustotal.com/gui/file/4e54e168c20bc02bc718bcda8155477bc92d195da18ce176d772777895f32bb0/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F71%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
  <a href="https://www.virustotal.com/gui/file/d2254ed3d046c9877ef764e4200521b01a6c5fc2b15fb9cf3065039d9787bc32/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F70%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>  
</p>

<details>
<summary><b>Detail Scan & Info False Positive</b></summary>

**Hasil Scan v1.2.7:**
- ✅ **0/72** deteksi malware (Bersih)
- ✅ Code Signed: Tidak (Self-contained)

**False Positive?** Beberapa AV mungkin menandai karena:
- Executable baru / belum banyak didistribusikan
- Akses Discord RPC API
- Akses Registry (auto-startup)
- **Hook Hotkey Global** (RegisterHotKey API)
- **Hook Mouse** (SetWindowsHookEx API)
- **Manipulasi Ikon** (GDI+ untuk animasi tray)

**Solusi:** Whitelist di antivirus atau verifikasi di [VirusTotal](https://www.virustotal.com)

</details>

---

## 🔮 Roadmap

- [x] Pemeriksa update otomatis
- [x] Pelacak statistik
- [x] Multi-bahasa (EN/ID)
- [x] Jendela Preview
- [x] Manajer Aplikasi
- [x] Dukungan Hotkey Global
- [x] Detektor Energi Mouse
- [x] Smart Defaults (config opsional)
- [x] True Hot Reload
- [x] Validasi URL untuk tombol
- [x] Animasi Ikon Tray
- [ ] Dukungan software lebih banyak
- [ ] Dashboard UI (WPF/WinUI)
- [ ] Pelacakan aktivitas keyboard

---

## 📞 Tautan

<p align="center">
  <a href="https://github.com/makcrtve/geetRPCS/issues">🐛 Laporkan Bug</a> •
  <a href="https://github.com/makcrtve/geetRPCS/discussions">💬 Diskusi</a> •
  <a href="https://github.com/makcrtve/geetRPCS/releases">📦 Releases</a>
</p>

---

<p align="center">
  <sub>Dibuat dengan ❤️ oleh <a href="https://github.com/makcrtve">makcrtve</a></sub><br/>
  <sub>geetRPCS v1.2.7 • Lisensi MIT • 2026</sub>
</p>

