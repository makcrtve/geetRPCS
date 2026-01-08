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
    <img src="https://img.shields.io/badge/using-C%23-00bb88.svg?style=flat-square&logo=discord&logoColor=white" alt="using C#"/>
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
  <a href="#-mulai-cepat">Mulai Cepat</a> •
  <a href="#-fitur">Fitur</a> •
  <a href="#-aplikasi-yang-didukung">Aplikasi</a> •
  <a href="#%EF%B8%8F-konfigurasi">Konfigurasi</a> •
  <a href="#-faq">FAQ</a>
</p>

---

## 🚀 Mulai Cepat

```md
1. Download  →  github.com/makcrtve/geetRPCS/releases/latest
2. Ekstrak   →  ke folder pilihanmu
3. Jalankan  →  geetRPCS.exe
4. Selesai   →  Ikon muncul di system tray
```

> **Persyaratan:** Windows 10/11 • Discord Desktop • [.NET 8.0 Runtime](https://dotnet.microsoft.com/download/dotnet/8.0)

---

## ✨ Fitur

<table>
<tr>
<td width="50%">

### 🎯 Inti
- 🔍 **Deteksi Otomatis** - 40+ aplikasi populer
- 🖱️ **Energi Mouse** - Level aktivitas real-time
- ⌨️ **Hotkey Global** - Pintasan keyboard
- 👀 **Jendela Preview** - Preview presence langsung
- 🛠️ **Manajer Aplikasi** - Blacklist aplikasi

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
- 🎯 **Smart Defaults** - Berjalan tanpa config.json
- 🔄 **Hot Reload Sejati** - Edit & terapkan instan [BARU]
- ⚡ **Aksi Cepat** - Akses cepat ke config
- 🚀 **Auto Startup** - Jalan saat Windows mulai

</td>
<td width="50%">

### 🎨 Kustomisasi
- 🖼️ **Asset Kustom** - Gunakan gambar sendiri
- 📝 **Teks Kustom** - Teks & placeholder kustom
- 🔘 **Tombol Kustom** - Link ke portofolio
- 🔗 **Validasi URL** - Filter tombol pintar [BARU]

</td>
</tr>
</table>

---

## 🔄 Hot Reload Sejati (Baru di v1.2.6)

<p align="center">
  <b>Edit apps.json → Klik Reload → Perubahan langsung diterapkan!</b>
</p>

v1.2.6 memperkenalkan **Hot Reload Sejati** - akhirnya, mengedit `apps.json` dan mengklik "Muat Ulang Semua" benar-benar berfungsi tanpa perlu restart aplikasi!

| Sebelum v1.2.6 | Setelah v1.2.6 |
|:---------------|:---------------|
| Edit apps.json → Reload → ❌ Cache lama dipakai | Edit apps.json → Reload → ✅ Aplikasi baru terdeteksi! |
| Perlu restart untuk perubahan | Tidak perlu restart |
| Asset tetap di config lama | Asset langsung diperbarui |

**Yang di-reload:**
- ✅ Aplikasi baru yang ditambahkan ke `apps.json`
- ✅ Perubahan nama aplikasi dan custom details
- ✅ Update ikon/asset
- ✅ Modifikasi tombol dan URL

> 💡 **Tips:** Gunakan `CTRL + ALT + R` untuk reload cepat setelah mengedit config!

---

## 🖱️ Detektor Energi Mouse

<p align="center">
  <b>Tampilkan level produktivitas real-time di Discord!</b>
</p>

geetRPCS memiliki fitur **Detektor Energi Mouse** - fitur unik yang menganalisis aktivitas mouse dan menampilkan "level energi" saat ini di Discord presence.

| Level | Emoji | Kondisi |
|:------|:-----:|:--------|
| **Tidur** | 💤 | Tidak ada aktivitas > 30 detik |
| **Santai** | ☕ | Aktivitas rendah (scroll santai) |
| **Normal** | 🎯 | Aktivitas standar (kerja biasa) |
| **Fokus** | 🔥 | Aktivitas tinggi (editing intensif) |
| **Rush** | ⚡ | Aktivitas sangat tinggi (mode deadline!) |

**Contoh tampilan Discord:**
```
Bekerja di FL Studio 2025
Untitled - FL Studio | 🔥 Fokus
```

> 💡 **Tips:** Toggle fitur ini on/off via menu System Tray → "🖱️ Detektor Energi Mouse"

---

## 🎯 Aplikasi yang Didukung

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

> 💡 **Tips:** Kamu bisa menambahkan aplikasi sendiri di `apps.json`!

---

## 🖥️ Penggunaan

### ⌨️ Hotkey Global (Pintasan)
Kontrol geetRPCS langsung dari keyboard, bahkan saat aplikasi minimize:

| Pintasan | Fungsi |
|----------|--------|
| `CTRL` + `ALT` + `P` | ⏸️ Jeda / Lanjutkan Presence |
| `CTRL` + `ALT` + `V` | 👀 Toggle Jendela Preview |
| `CTRL` + `ALT` + `H` | 🔒 Toggle Mode Privat |
| `CTRL` + `ALT` + `R` | 🔄 Muat Ulang Config |
| `CTRL` + `ALT` + `S` | 📊 Tampilkan Statistik Hari Ini |

### 🖱️ Menu System Tray
**Klik kanan** ikon tray untuk mengakses menu manual:

| Menu | Fungsi |
|------|--------|
| ⏸️ Jeda | Toggle presence on/off |
| 🔒 Mode Privat | Sensor judul window |
| 🖱️ Energi Mouse | Toggle detektor aktivitas |
| 📡 Telemetri | Toggle data penggunaan anonim |
| 👀 Jendela Preview | Preview langsung Discord presence |
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

geetRPCS berjalan **langsung** tanpa memerlukan file `config.json`! Aplikasi menggunakan pengaturan default yang sudah dioptimalkan secara otomatis.

**config.json hanya diperlukan jika ingin:**
- Menggunakan Discord Application ID sendiri
- Kustomisasi teks presence
- Menambahkan tombol kustom

> 💡 **Tips:** Buat config.json via Aksi Cepat → "Edit config.json" (akan auto-create dengan default)

<details>
<summary><b>📄 config.json</b> - Konfigurasi utama (Opsional)</summary>

```json
{
  "Discord": {
    "ApplicationId": "ID_APLIKASI_DISCORD_KAMU",
    "Details": "Menganggur...",
    "State": "Siap bekerja",
    "ActiveDetails": "Bekerja di {app_name}",
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
      { "label": "Portofolio Saya", "url": "https://example.com" }
    ]
  }
]
```

**Menambahkan aplikasi:** Task Manager → catat nama proses → tambahkan ke apps.json → Muat Ulang Semua (`CTRL+ALT+R`)

</details>

<details>
<summary><b>🔗 Persyaratan URL Tombol</b> (Baru di v1.2.6)</summary>

v1.2.6 menambahkan validasi URL pintar untuk tombol Discord:

| Format URL | Status |
|:-----------|:------:|
| `https://github.com` | ✅ Valid |
| `http://example.com` | ✅ Valid |
| `github.com` | ❌ Dilewati (tanpa protokol) |
| `ftp://files.com` | ❌ Dilewati (protokol tidak valid) |
| URL Kosong | ❌ Dilewati |

**Batas label tombol:** Maksimal 32 karakter

> Tombol yang tidak valid akan dilewati secara diam-diam - tidak ada error, hanya tidak akan muncul di Discord.

</details>

<details>
<summary><b>🎨 Discord Assets</b> - Upload gambar</summary>

1. Buka [Discord Developer Portal](https://discord.com/developers/applications)
2. Pilih aplikasi → **Rich Presence** → **Art Assets**
3. Upload gambar dengan nama yang sesuai `largeKey` / `smallKey`

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/discord-assets.png" width="500"/>
</p>

</details>

<details>
<summary><b>📁 Struktur File</b></summary>

```
geetRPCS/
├── geetRPCS.exe          # Aplikasi utama (v1.2.6)
├── apps.json             # Daftar aplikasi (wajib)
├── rpicon.ico            # Ikon (wajib)
├── config.json           # Konfigurasi Discord RPC (opsional)
├── settings.json         # Pengaturan (auto-generated)
├── statistics.json       # Data tracking (auto-generated)
├── geetRPCS.log          # File log (auto-generated)
├── .telemetry            # Penghitung peluncuran (auto-generated)
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
4. Pastikan tidak dalam mode **Jeda**

</details>

<details>
<summary><b>Aplikasi baru tidak terdeteksi setelah edit apps.json?</b></summary>

**Di v1.2.6, ini seharusnya langsung berfungsi!**

1. Edit `apps.json` dan simpan
2. Klik kanan tray → Aksi Cepat → **Muat Ulang Semua** (atau tekan `CTRL+ALT+R`)
3. Aplikasi baru seharusnya langsung terdeteksi

Jika masih tidak berfungsi, periksa:
- Nama proses cocok persis (case-insensitive)
- Sintaks JSON valid
- Aplikasi tidak dinonaktifkan di **Kelola Aplikasi**

</details>

<details>
<summary><b>Energi Mouse tidak update?</b></summary>

1. Pastikan "🖱️ Detektor Energi Mouse" aktif di menu tray
2. Fitur ini menganalisis aktivitas dari waktu ke waktu - tunggu beberapa detik
3. Beberapa aplikasi fullscreen mungkin mempengaruhi deteksi
4. Periksa `geetRPCS.log` untuk error MouseTracker

</details>

<details>
<summary><b>Tombol tidak muncul di Discord?</b></summary>

v1.2.6 memvalidasi URL tombol. Pastikan URL:
- Dimulai dengan `http://` atau `https://`
- URL yang valid (bukan hanya nama domain)
- Label maksimal 32 karakter

**Contoh tombol yang valid:**
```json
{ "label": "Website Saya", "url": "https://example.com" }
```

**Contoh tombol tidak valid (akan dilewati):**
```json
{ "label": "Website Saya", "url": "example.com" }
```

</details>

<details>
<summary><b>Hotkey tidak berfungsi?</b></summary>

Pastikan tidak ada aplikasi lain yang menggunakan pintasan yang sama. Beberapa game fullscreen yang berjalan "As Administrator" mungkin memblokir hotkey jika geetRPCS tidak juga dijalankan sebagai Admin.

</details>

<details>
<summary><b>Gambar tidak muncul?</b></summary>

1. Upload gambar di Discord Developer Portal
2. Tunggu beberapa menit (sinkronisasi Discord)
3. Nama key harus cocok **persis** (case sensitive)
4. Jendela Preview → 🔄 Refresh

</details>

<details>
<summary><b>Data apa yang dikumpulkan Telemetri?</b></summary>

Telemetri anonim (opt-in) mengumpulkan:
- Username Discord (untuk jumlah pengguna unik)
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
| Discord tidak terkoneksi | Pastikan Discord Desktop berjalan |
| Presence tidak muncul | Periksa mode Jeda dan Kelola Aplikasi |
| Gambar preview kosong | Clear Cache → Refresh |
| Mouse hook gagal | Jalankan sebagai Administrator |
| Tombol tidak muncul | Periksa format URL (harus dimulai http/https) |

</details>

---

## 🛡️ Keamanan

<p align="center">
  <a href="https://www.virustotal.com/gui/file/6e1607c50d4bab6d24840b3cf88f07cead687e71d0e976fd55c4da6955f10cf9/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F62%20Bersih-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
</p>

<details>
<summary><b>Detail Scan & Info False Positive</b></summary>

**Hasil Scan v1.2.6:**
- ✅ **0/62** deteksi malware (Bersih)
- ✅ Code Signed: Tidak (Self-contained)

**False Positive?** Beberapa AV mungkin menandainya karena:
- Executable baru / tidak banyak didistribusikan
- Akses API Discord RPC
- Akses Registry (auto-startup)
- **Hook Hotkey Global** (API RegisterHotKey)
- **Hook Mouse** (API SetWindowsHookEx)

**Solusi:** Whitelist di antivirus atau verifikasi di [VirusTotal](https://www.virustotal.com)

</details>

---

## 🔮 Roadmap

- [x] Pemeriksa auto-update
- [x] Tracker statistik
- [x] Multi-bahasa (EN/ID)
- [x] Jendela Preview
- [x] Manajer Aplikasi
- [x] Dukungan Hotkey Global
- [x] Detektor Energi Mouse
- [x] Smart Defaults (config opsional)
- [x] Hot Reload Sejati
- [x] Validasi URL untuk tombol
- [ ] Dukungan software lebih banyak
- [ ] Dashboard UI (WPF/WinUI)
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
  <sub>geetRPCS v1.2.6 • Lisensi MIT • 2026</sub>
</p>

