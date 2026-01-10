<p align="center">
  <a href="RELEASE/README.md"><img src="https://img.shields.io/badge/Language-English-blue?style=flat-square" alt="English"/></a>
  <a href="RELEASE/README.id.md"><img src="https://img.shields.io/badge/Bahasa-Indonesia-red?style=flat-square" alt="Indonesia"/></a>
</p>

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/geetrpcs-banner.png" width="600" alt="geetRPCS Banner"/>
</p>

<h1 align="center">geetRPCS</h1>

<p align="center">
  <b>Discord Rich Presence Otomatis untuk aplikasi favoritmu!</b><br/>
  <sub>Tampilkan aktivitasmu di Discord secara real-time dengan efisiensi ekstrim 🚀</sub>
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

Pilih metode instalasi yang paling sesuai untukmu:

### 1. Direkomendasikan (Portable + Shortcut) ⭐
Unduh versi portable (standalone) via PowerShell dan otomatis buat shortcut di Desktop.
```ps
irm https://bit.ly/geetrpcs | iex; Install-GeetRPCS -DesktopShortcut
```

### 2. Ringan (Minimal + Shortcut)
Ukuran file lebih kecil, memerlukan [.NET 8.0 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/8.0/runtime).
```ps
irm https://bit.ly/geetrpcs | iex; Install-GeetRPCS -Version "minimal" -DesktopShortcut
```

### 3. Unduh Manual (Zip)
Unduh secara manual melalui **[Halaman Releases](https://github.com/makcrtve/geetRPCS/releases/latest)**.

---

## ✨ Fitur

<table>
<tr>
<td width="50%">

### 🎯 Inti
- 🔍 **Auto Deteksi** - 40+ aplikasi populer
- 🖱️ **Mouse Energy** - Level aktivitas real-time
- 🎨 **Animasi Tray** - Feedback visual [BARU]
- ⌨️ **Hotkey Global** - Pintasan keyboard
- 👀 **Jendela Preview** - Live preview reaktif

</td>
<td width="50%">

### ⚙️ Kontrol
- ⏸️ **Mode Jeda** - Sembunyikan presence sementara
- 🔒 **Mode Privat** - Sensor judul jendela
- 📊 **Statistik** - Tracking + Ekspor
- 🔄 **True Hot Reload** - Edit & terapkan instan
- 🌐 **Multi-Bahasa** - EN / ID

</td>
</tr>
<tr>
<td width="50%">

### 🔧 Utilitas
- 🎯 **Smart Defaults** - Jalan tanpa config.json
- 📉 **Sangat Efisien** - Penggunaan RAM 10-20MB [BARU]
- 🔄 **Auto Update** - Notifikasi versi baru
- 🚀 **Auto Startup** - Validasi lebih kokoh [PENINGKATAN]

</td>
<td width="50%">

### 🎨 Kustomisasi
- 🖼 *Aset Kustom* - Gunakan gambar sendiri
- 📝 *Teks Kustom* - Dukungan placeholders
- 🔘 *Tombol Kustom* - Dengan validasi URL
- 🔗 *Aset Pintar* - Refresh mapping otomatis

</td>
</tr>
</table>

---

## 📉 Engine Efisiensi Ekstrim <sup>BARU</sup>

Versi 1.2.7 memperkenalkan perombakan total pada engine agar aplikasi terasa "lebih ringan dari udara":

| Metrik | Peningkatan |
|:-------|:------------|
| **RAM Usage** | **10 MB - 20 MB** (Turun dari ~80MB) |
| **CPU Usage** | **~0%** (Beralih ke pemantauan berbasis Event) |
| **Footprint** | Pembersihan memori aktif & disposal UI total |

> 💡 **Cara kerja:** Kami menggunakan `SetWinEventHook` untuk hanya "bangun" saat Anda benar-benar berpindah jendela. Tidak ada pengecekan terus-menerus = Tidak ada pemborosan CPU!

---

## 🎨 Animasi Ikon Tray <sup>BARU</sup>

Ikon system tray kini hidup! Saat geetRPCS mendeteksi pergantian aplikasi, ikon akan melakukan animasi **rotasi 360° dengan efek brightness pulse** yang halus.

- **Efek:** Rotasi + Denyut Kecerahan
- **Durasi:** 800ms (12 frame)
- **Easing:** Ease-In-Out Quadratic
- **Kontrol:** Aktifkan/Matikan via Menu Tray

---

## 🖱️ Detektor Energi Mouse

Tampilkan level produktivitasmu secara real-time di Discord! Fitur ini menganalisis aktivitas mouse untuk menentukan "level energi" kamu.

| Level | Emoji | Kondisi |
|:------|:-----:|:--------|
| **Tidur** | 💤 | Tidak ada aktivitas > 30 detik |
| **Santai** | ☕ | Aktivitas rendah (scroll santai) |
| **Normal** | 🎯 | Aktivitas standar (kerja biasa) |
| **Fokus** | 🔥 | Aktivitas tinggi (editing intensif) |
| **Rush** | ⚡ | Aktivitas luar biasa (mode deadline!) |

---

## 🎯 Aplikasi Didukung

<details open>
<summary><b>41 Software • 64+ Nama Proses</b> (klik untuk buka/tutup)</summary>

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

---

## 🖥️ Penggunaan

### ⌨️ Hotkey Global (Pintasan)
| Pintasan | Fungsi |
|----------|--------|
| `CTRL` + `ALT` + `P` | ⏸️ Jeda / Lanjutkan Presence |
| `CTRL` + `ALT` + `V` | 👀 Toggle Jendela Preview |
| `CTRL` + `ALT` + `H` | 🔒 Toggle Mode Privat |
| `CTRL` + `ALT` + `R` | 🔄 Reload Konfigurasi |
| `CTRL` + `ALT` + `S` | 📊 Tampilkan Statistik Hari Ini |

---

## ⚙️ Konfigurasi

### 🎯 Smart Defaults
geetRPCS langsung berfungsi tanpa konfigurasi! `config.json` hanya dibutuhkan jika ingin kustomisasi lanjut (AppID sendiri, tombol, dll).

<details>
<summary><b>📄 config.json</b> - Konfigurasi Utama (Opsional)</summary>

```json
{
  "Discord": {
    "ApplicationId": "APP_ID_DISCORD_KAMU",
    "Details": "Sedang santai...",
    "State": "Siap bekerja",
    "ActiveDetails": "Bekerja di {app_name}",
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
<summary><b>🔗 Syarat URL Tombol</b></summary>

geetRPCS memvalidasi URL secara otomatis. URL yang tidak valid atau label > 32 karakter akan dilewati.
- ✅ `https://github.com`
- ❌ `github.com` (tanpa protokol)
</details>

---

## ❓ FAQ

<details>
<summary><b>Presence tidak muncul di Discord?</b></summary>

1. Pastikan gunakan Discord **Desktop** (bukan web).
2. Settings → Activity Privacy → Aktifkan "Display current activity".
3. Restart geetRPCS dan Discord.
</details>

<details>
<summary><b>Animasi tray tidak jalan?</b></summary>

1. Pastikan "🎨 Animasi Ikon Tray" aktif di menu.
2. Animasi hanya terpicu saat **pindah aplikasi**, bukan ganti judul window.
</details>

<details>
<summary><b>Startup tidak berfungsi?</b></summary>

1. Pindahkan folder geetRPCS ke lokasi permanen (Bukan Temp/Downloads).
2. Aktifkan ulang fitur startup melalui menu tray untuk update registry.
</details>

---

## 🛡️ Keamanan

<p align="center">
  <a href="https://www.virustotal.com/gui/file/a7f78aa1c7b5bf17018ec3c7a0ac523d00394ad86b5da7b502627ca1f961f164/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F71%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
  <a href="https://www.virustotal.com/gui/file/dc535d607e0c43fdbf05ed6be9dc4a21bf9b785996de11e5d64255b7ec4d3735/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F68%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>  
</p>

**Hasil Scan v1.2.7:** 0/71 Deteksi.
> Catatan: Beberapa AV mungkin menandai "Hook" (Hotkey/Mouse) sebagai false positive.

---

## 🔮 Roadmap
- [x] Pemeriksa update otomatis
- [x] Pelacak statistik
- [x] Jendela Preview Reaktif
- [x] Animasi Ikon Tray
- [x] Optimasi Memori Ekstrim
- [x] True Hot Reload
- [ ] Dashboard UI (WPF/WinUI)
- [ ] Pelacakan aktivitas keyboard

---

<p align="center">
  <sub>Dibuat dengan ❤️ oleh <a href="https://github.com/makcrtve">makcrtve</a></sub><br/>
  <sub>geetRPCS v1.2.7 • Lisensi MIT • 2026</sub>
</p>

