<p align="center">
  <a href="README.md"><img src="https://img.shields.io/badge/Language-English-blue?style=flat-square" alt="English"/></a>
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

Cara termudah instalasi geetRPCS adalah via **PowerShell**. Pilih metode yang pas buat kamu:

### 1. Rekomendasi (Portable + Shortcut) ⭐
Mengunduh versi portable (mandiri) dan otomatis membuat shortcut di Desktop untuk akses mudah.
```ps
irm https://raw.githubusercontent.com/makcrtve/geetRPCS/main/install.ps1 | iex; Install-GeetRPCS -DesktopShortcut
```

### 2. Ringan (Minimal + Shortcut)
Ukuran file lebih kecil, tapi membutuhkan [.NET 8.0 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/8.0/runtime) terinstall. Termasuk shortcut Desktop.
```ps
irm https://raw.githubusercontent.com/makcrtve/geetRPCS/main/install.ps1 | iex; Install-GeetRPCS -Version "minimal" -DesktopShortcut
```

### 3. Standar (Hanya Portable)
Mengunduh versi portable via PowerShell tanpa membuat shortcut apapun.
```ps
irm https://raw.githubusercontent.com/makcrtve/geetRPCS/main/install.ps1 | iex; Install-GeetRPCS
```

### 4. Download Manual (Zip)
Jika kamu tidak ingin menggunakan command line, kamu bisa unduh manual:
1. Download file `.zip` terbaru dari **[Halaman Rilis](https://github.com/makcrtve/geetRPCS/releases/latest)**.
2. **Ekstrak** file zip ke folder pilihanmu.
3. **Jalankan** `geetRPCS.exe`.

---

## ✨ Fitur

<table>
<tr>
<td width="50%">

### 🎯 Inti
- 🔍 **Deteksi Otomatis** - 40+ aplikasi populer
- 🖱️ **Energi Mouse** - Level aktivitas real-time
- ⌨️ **Hotkey Global** - Jalan pintas keyboard
- 👀 **Jendela Preview** - Pratinjau presence langsung
- 🛠️ **Manajer Aplikasi** - Blacklist aplikasi

</td>
<td width="50%">

### ⚙️ Kontrol
- ⏸️ **Mode Jeda** - Sembunyikan status sementara
- 🔒 **Mode Privat** - Sensor judul jendela
- 📊 **Statistik** - Pelacakan + Ekspor CSV/JSON
- 🌐 **Multi-Bahasa** - EN / ID

</td>
</tr>
<tr>
<td width="50%">

### 🔧 Utilitas
- 🎯 **Default Cerdas** - Jalan tanpa config.json
- 🔄 **True Hot Reload** - Edit & terapkan instan [BARU]
- ⚡ **Aksi Cepat** - Akses cepat ke config/folder
- 🚀 **Auto Startup** - Jalan saat Windows nyala

</td>
<td width="50%">

### 🎨 Kustomisasi
- 🖼️ **Aset Kustom** - Pakai gambar sendiri
- 📝 **Teks Kustom** - Teks & placeholder bebas
- 🔘 **Tombol Kustom** - Link ke portofolio
- 🔗 **Validasi URL** - Filter tombol pintar [BARU]

</td>
</tr>
</table>

---

## 🔄 True Hot Reload (Baru di v1.2.6)

<p align="center">
  <b>Edit apps.json → Klik Reload → Perubahan langsung aktif!</b>
</p>

v1.2.6 memperkenalkan **True Hot Reload** - akhirnya, mengedit `apps.json` dan menekan "Reload All" benar-benar berfungsi tanpa perlu restart aplikasi!

| Sebelum v1.2.6 | Sesudah v1.2.6 |
|:--------------|:-------------|
| Edit apps.json → Reload → ❌ Masih pakai cache lama | Edit apps.json → Reload → ✅ Aplikasi baru terdeteksi! |
| Harus restart agar berubah | Tidak perlu restart |
| Aset gambar nyangkut di config lama | Aset langsung diperbarui |

**Apa yang dimuat ulang:**
- ✅ Aplikasi baru yang ditambahkan ke `apps.json`
- ✅ Perubahan nama aplikasi dan detail kustom
- ✅ Update icon/aset gambar
- ✅ Perubahan tombol dan URL

> 💡 **Tips:** Tekan `CTRL + ALT + R` untuk reload cepat setelah edit config!

---

## 🖱️ Detektor Energi Mouse

<p align="center">
  <b>Tunjukkan tingkat produktivitasmu di Discord!</b>
</p>

geetRPCS memiliki fitur unik **Mouse Energy Detector** yang menganalisis pergerakan mouse dan menampilkan "level energi" kamu saat ini di Discord presence.

| Level | Emoji | Kondisi |
|:------|:-----:|:----------|
| **Sleeping** | 💤 | Tidak ada aktivitas > 30 detik |
| **Relaxing** | ☕ | Aktivitas rendah (scrolling santai) |
| **Normal** | 🎯 | Aktivitas standar (kerja biasa) |
| **Focused** | 🔥 | Aktivitas tinggi (editing intens) |
| **Rush** | ⚡ | Aktivitas sangat tinggi (mode deadline!) |

**Contoh tampilan Discord:**
```
Working on FL Studio 2025
Untitled - FL Studio | 🔥 Focused
```

> 💡 **Tips:** Fitur ini bisa dimatikan lewat menu System Tray → "🖱️ Mouse Energy Detector"

---

## 🎯 Aplikasi yang Didukung

<details open>
<summary><b>41 Software • 64+ Nama Proses</b> (klik untuk lihat)</summary>

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

> 💡 **Tips:** Kamu bisa menambahkan aplikasimu sendiri di `apps.json`!

---

## 🖥️ Cara Penggunaan

### ⌨️ Hotkey Global (Jalan Pintas)
Kontrol geetRPCS langsung dari keyboard, bahkan saat aplikasi diminimize:

| Shortcut | Fungsi |
|----------|----------|
| `CTRL` + `ALT` + `P` | ⏸️ Pause / Resume Presence |
| `CTRL` + `ALT` + `V` | 👀 Buka Jendela Preview |
| `CTRL` + `ALT` + `H` | 🔒 Toggle Mode Privat |
| `CTRL` + `ALT` + `R` | 🔄 Reload Config |
| `CTRL` + `ALT` + `S` | 📊 Lihat Statistik Hari Ini |

### 🖱️ Menu System Tray
**Klik kanan** icon di tray (pojok kanan bawah taskbar) untuk membuka menu:

| Menu | Fungsi |
|------|----------|
| ⏸️ Pause | Nyalakan/matikan presence |
| 🔒 Private Mode | Sensor judul jendela (window title) |
| 🖱️ Mouse Energy | Nyalakan detektor aktivitas |
| 📡 Telemetry | Nyalakan data penggunaan anonim |
| 👀 Preview Window | Pratinjau tampilan Discord |
| 🛠️ Manage Apps | Atur (enable/disable) aplikasi |
| 📊 Statistics | Lihat & ekspor statistik |
| ⚡ Quick Actions | Buka folder / edit config |
| 🌐 Language | Ganti bahasa (EN/ID) |

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

## ⚙️ Konfigurasi

### 🎯 Default Cerdas

geetRPCS bisa berjalan **langsung (out of the box)** tanpa perlu file `config.json`! Aplikasi akan menggunakan pengaturan default yang optimal secara otomatis.

**config.json hanya dibutuhkan jika kamu ingin:**
- Menggunakan Application ID Discord milikmu sendiri
- Mengubah teks presence default
- Menambahkan tombol kustom global

> 💡 **Tips:** Buat config.json via Quick Actions → "Edit config.json" (akan dibuatkan otomatis)

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
      { "label": "My Portfolio", "url": "https://example.com" }
    ]
  }
]
```

**Cara tambah aplikasi:** Cek Task Manager → catat nama proses (tanpa .exe) → tambah ke apps.json → Reload All (`CTRL+ALT+R`)

</details>

<details>
<summary><b>🔗 Persyaratan URL Tombol</b> (Baru di v1.2.6)</summary>

v1.2.6 menambahkan validasi pintar untuk tombol Discord:

| Format URL | Status |
|:-----------|:------:|
| `https://github.com` | ✅ Valid |
| `http://example.com` | ✅ Valid |
| `github.com` | ❌ Dilewati (tidak ada protokol) |
| `ftp://files.com` | ❌ Dilewati (protokol salah) |
| URL Kosong | ❌ Dilewati |

**Batas label tombol:** Maksimal 32 karakter.

> Tombol yang tidak valid akan dilewati secara diam-diam (tidak muncul error, tapi tombolnya hilang di Discord).

</details>

<details>
<summary><b>🎨 Aset Discord</b> - Upload Gambar</summary>

1. Buka [Discord Developer Portal](https://discord.com/developers/applications)
2. Pilih aplikasi → **Rich Presence** → **Art Assets**
3. Upload gambar dengan nama yang sama persis dengan `largeKey` / `smallKey`

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/discord-assets.png" width="500"/>
</p>

</details>

<details>
<summary><b>📁 Struktur File</b></summary>

```
geetRPCS/
├── geetRPCS.exe          # Aplikasi Utama (v1.2.6)
├── apps.json             # Daftar Aplikasi (wajib)
├── rpicon.ico            # Icon (wajib)
├── config.json           # Konfigurasi RPC (opsional)
├── settings.json         # Pengaturan (dibuat otomatis)
├── statistics.json       # Data tracking (dibuat otomatis)
├── geetRPCS.log          # File Log (dibuat otomatis)
├── .telemetry            # Counter peluncuran (dibuat otomatis)
├── ImageCache/           # Cache gambar (dibuat otomatis)
└── Languages/            # File bahasa (dibuat otomatis)
```

</details>

---

## ❓ FAQ

<details>
<summary><b>Presence tidak muncul di Discord?</b></summary>

1. Pastikan kamu pakai Discord **Desktop** (bukan web)
2. Settings (Discord) → Activity Privacy → Nyalakan "Display current activity"
3. Restart geetRPCS dan Discord
4. Pastikan kamu tidak sedang dalam mode **Pause**

</details>

<details>
<summary><b>Aplikasi baru tidak terdeteksi setelah edit apps.json?</b></summary>

**Di v1.2.6, ini harusnya otomatis!**

1. Edit `apps.json` dan simpan (save)
2. Klik kanan tray → Quick Actions → **Reload All** (atau tekan `CTRL+ALT+R`)
3. Aplikasi baru akan langsung terdeteksi

Jika masih gagal, cek:
- Nama proses (process name) harus sama persis (case-insensitive)
- Syntax JSON harus valid (tidak ada koma berlebih)
- Aplikasi tidak dimatikan (disabled) di menu **Manage Apps**

</details>

<details>
<summary><b>Mouse Energy tidak berubah?</b></summary>

1. Pastikan "🖱️ Mouse Energy Detector" nyala di menu tray
2. Fitur ini menganalisa dalam selang waktu tertentu - tunggu beberapa detik
3. Beberapa aplikasi fullscreen mungkin mempengaruhi deteksi
4. Cek `geetRPCS.log` jika ada error MouseTracker

</details>

<details>
<summary><b>Tombol tidak muncul di Discord?</b></summary>

v1.2.6 memvalidasi URL tombol. Pastikan URL kamu:
- Dimulai dengan `http://` atau `https://`
- Adalah URL yang valid (bukan sekadar nama domain)
- Label maksimal 32 karakter

**Contoh tombol valid:**
```json
{ "label": "Web Saya", "url": "https://example.com" }
```

**Contoh tombol tidak valid (akan di-skip):**
```json
{ "label": "Web Saya", "url": "example.com" }
```

</details>

<details>
<summary><b>Hotkey tidak berfungsi?</b></summary>

Pastikan tidak ada aplikasi lain yang memakai shortcut yang sama. Beberapa game fullscreen yang berjalan "Run as Administrator" mungkin memblokir hotkey jika geetRPCS tidak dijalankan sebagai Admin juga.

</details>

<details>
<summary><b>Gambar (Aset) tidak muncul?</b></summary>

1. Upload gambar di Discord Developer Portal
2. Tunggu beberapa menit (Discord butuh waktu sync)
3. Nama Key harus sama **persis** (besar/kecil huruf berpengaruh di API Discord tertentu)
4. Jendela Preview → 🔄 Refresh

</details>

<details>
<summary><b>Data apa yang diambil Telemetry?</b></summary>

Telemetry anonim (opsional) mengumpulkan:
- Username Discord (untuk menghitung jumlah user unik)
- Versi Aplikasi
- Durasi sesi
- Jumlah aplikasi yang digunakan

**Tidak ada data pribadi, nama file, atau judul window yang diambil.**
Kamu bisa mematikannya kapan saja lewat menu tray.

</details>

<details>
<summary><b>Troubleshooting</b></summary>

Buka `geetRPCS.log` atau klik kanan tray → **Open Log File**

| Masalah | Solusi |
|-------|----------|
| Apps.json not found | Pastikan apps.json ada di folder yang sama |
| Discord not connected | Pastikan Discord Desktop menyala |
| Presence not showing | Cek mode Pause dan Manage Apps |
| Preview image empty | Hapus Cache (Clear Cache) → Refresh |
| Mouse hook failed | Jalankan sebagai Administrator |
| Buttons not appearing | Cek format URL (harus pakai http/https) |

</details>

---

## 🛡️ Keamanan

<p align="center">
  <a href="https://www.virustotal.com/gui/file/d512a338ca3bca11bbcabd8073831694929202aaad62d39a94851483c8989e1c/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F65%20Aman-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
  <a href="https://www.virustotal.com/gui/file/72c03212682d9f228cf5bb4960e3aafa5a6359e8f00f10c0a960c600ac53baaa/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F69%20Aman-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
</p>

<details>
<summary><b>Detail Scan & Info Positif Palsu</b></summary>

**Hasil Scan v1.2.6:**
- ✅ **0/65** deteksi malware (Bersih)
- ✅ Code Signed: Tidak (Self-contained)

**Positif Palsu (False Positive)?** Beberapa Antivirus mungkin curiga karena:
- Executable baru / belum dikenal luas
- Akses API Discord RPC
- Akses Registry (untuk auto-startup)
- **Hook Hotkey Global** (API RegisterHotKey)
- **Hook Mouse** (API SetWindowsHookEx)

**Solusi:** Masukkan ke whitelist antivirus atau verifikasi sendiri di [VirusTotal](https://www.virustotal.com)

</details>

---

## 🔮 Roadmap

- [x] Auto-update checker
- [x] Pelacak statistik (Statistics)
- [x] Multi-bahasa (EN/ID)
- [x] Jendela Preview
- [x] Manajer Aplikasi
- [x] Dukungan Hotkey Global
- [x] Detektor Energi Mouse
- [x] Default Cerdas (config opsional)
- [x] True Hot Reload
- [x] Validasi URL Tombol
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
  <sub>geetRPCS v1.2.6 • MIT License • 2026</sub>
</p>
