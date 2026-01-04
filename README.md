<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/geetrpcs-banner.png" width="600" alt="geetRPCS Banner"/>
</p>

<h1 align="center">geetRPCS</h1>

<p align="center">
  <b>Discord Rich Presence otomatis untuk aplikasi favoritmu!</b><br/>
  <sub>Tampilkan aktivitasmu di Discord secara real time tanpa ribet 🚀</sub>
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Platform-Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white" alt="Windows"/>
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 8"/>
  <img src="https://img.shields.io/badge/Discord-RPC-5865F2?style=for-the-badge&logo=discord&logoColor=white" alt="Discord"/>
  <img src="https://img.shields.io/badge/License-MIT-green?style=for-the-badge" alt="License"/>
</p>

<p align="center">
  <a href="https://github.com/makcrtve/geetRPCS/releases/latest">
    <img src="https://img.shields.io/github/v/release/makcrtve/geetRPCS?style=flat-square&label=Download&color=success" alt="Download"/>
  </a>
  <img src="https://img.shields.io/github/downloads/makcrtve/geetRPCS/total?style=flat-square&label=Total%20Downloads&color=blue" alt="Downloads"/>
</p>

---

## 📖 Tentang geetRPCS

**geetRPCS** adalah aplikasi Windows yang secara otomatis mendeteksi aplikasi yang sedang kamu gunakan dan menampilkannya sebagai Discord Rich Presence. Cocok untuk content creator, musisi, desainer, dan siapa saja yang ingin memamerkan aktivitas mereka di Discord!

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/preview.gif" width="350" alt="Preview"/>
</p>

---

## ✨ Fitur Utama

| Fitur | Deskripsi |
|:-----:|-----------|
| 🔍 | **Auto Detect** Otomatis mendeteksi 20+ aplikasi populer |
| ⏱️ | **Elapsed Timer** Menampilkan berapa lama kamu menggunakan aplikasi |
| 🔒 | **Private Mode** Sembunyikan judul window dengan satu klik |
| 🔄 | **Hot Reload** Ubah konfigurasi tanpa restart aplikasi |
| 🚀 | **Auto Startup** Opsi untuk berjalan otomatis saat Windows nyala |
| 🎨 | **Kustomisasi Penuh** Atur teks, gambar, dan tombol sesukamu |
| 💾 | **Ringan** Berjalan di system tray, tidak mengganggu aktivitas |

---

## 🎯 Aplikasi yang Didukung

<table>
<tr>
<td align="center" width="20%">

### 🎵 Musik
FL Studio<br/>
Ableton Live<br/>
Adobe Audition

</td>
<td align="center" width="20%">

### 🎬 Video
Adobe Premiere Pro<br/>
Adobe After Effects<br/>
CapCut

</td>
<td align="center" width="20%">

### 🎨 Desain
Adobe Photoshop<br/>
Adobe Illustrator<br/>
Adobe Lightroom<br/>
Affinity

</td>
<td align="center" width="20%">

### 🌐 Browser
Brave<br/>
Chrome<br/>
Firefox<br/>
Zen Browser<br/>
Microsoft Edge

</td>
<td align="center" width="20%">

### 📝 Office
Microsoft Word<br/>
Microsoft Excel<br/>
Microsoft PowerPoint

</td>
</tr>
</table>

<p align="center">
  <i>...dan masih banyak lagi! Kamu juga bisa menambahkan aplikasi sendiri.</i>
</p>

---

## 📥 Instalasi

### Persyaratan Sistem
* Windows 10/11 (64 bit)
* Discord Desktop terinstall
* .NET 8.0 Runtime (sudah termasuk dalam paket)

### Langkah Instalasi

1. **Download** rilis terbaru dari [halaman Releases](https://github.com/makcrtve/geetRPCS/releases/latest)

2. **Ekstrak** file ZIP ke folder pilihan kamu

3. **Jalankan** `geetRPCS.exe`

4. **Selesai!** Ikon geetRPCS akan muncul di system tray

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/tray-icon.png" width="300" alt="Tray Icon"/>
</p>

---

## 🖥️ Cara Penggunaan

### Menu System Tray

Klik kanan pada ikon geetRPCS di system tray untuk mengakses menu:

| Menu | Fungsi |
|------|--------|
| 🔒 **Private Mode** | Aktifkan/nonaktifkan mode privat (sensor judul window) |
| 🔄 **Reload Config** | Muat ulang konfigurasi tanpa restart |
| ⏱️ **Reset All Timers** | Reset semua timer elapsed time |
| 🚀 **Run on Windows startup** | Aktifkan/nonaktifkan auto start |
| ❌ **Exit** | Keluar dari aplikasi |

### Private Mode

Double click ikon tray untuk toggle Private Mode dengan cepat!

Saat **Private Mode aktif**:
* Judul window akan ditampilkan sebagai `********`
* Cocok untuk menyembunyikan project rahasia atau aktivitas pribadi

---

## ⚙️ Konfigurasi

### config.json

File konfigurasi utama untuk mengatur tampilan default presence:

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
      "LargeImageText": "geetRPCS v1.0.0",
      "SmallImageKey": "verified",
      "SmallImageText": "geetRPCS Standby"
    },
    "Buttons": [
      {
        "Label": "GitHub",
        "Url": "https://github.com/makcrtve/geetRPCS"
      }
    ]
  }
}
```

### Placeholder yang Tersedia

| Placeholder | Deskripsi |
|-------------|-----------|
| `{app_name}` | Nama aplikasi (dari apps.json) |
| `{process_name}` | Nama process Windows |
| `{window_title}` | Judul window aktif |

---

### apps.json

File untuk mengatur konfigurasi per aplikasi:

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
      {
        "label": "My Portfolio",
        "url": "https://example.com"
      }
    ]
  }
]
```

### Menambah Aplikasi Baru

1. Buka **Task Manager** dan catat nama process aplikasi yang ingin ditambahkan
2. Tambahkan entry baru di `apps.json`
3. Upload gambar ke Discord Developer Portal (Art Assets)
4. Klik **Reload Config** di menu tray

---

## 🎨 Mengatur Gambar (Assets)

1. Buka [Discord Developer Portal](https://discord.com/developers/applications)
2. Pilih aplikasi kamu
3. Pergi ke **Rich Presence** → **Art Assets**
4. Upload gambar dengan nama yang sesuai dengan `largeKey` dan `smallKey`

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/discord-assets.png" width="500" alt="Discord Assets"/>
</p>

---

## 📸 Screenshot

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/screenshot-1.png" width="280" alt="Screenshot 1"/>
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/screenshot-2.png" width="280" alt="Screenshot 2"/>
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/screenshot-3.png" width="280" alt="Screenshot 3"/>
</p>

---

## ❓ FAQ

<details>
<summary><b>Presence tidak muncul di Discord?</b></summary>

1. Pastikan Discord Desktop terinstall (bukan versi web)
2. Buka Discord Settings → Activity Privacy → Aktifkan "Display current activity"
3. Restart geetRPCS dan Discord

</details>

<details>
<summary><b>Aplikasi tidak terdeteksi?</b></summary>

1. Buka Task Manager dan catat nama process yang benar
2. Tambahkan ke `apps.json` dengan nama process yang tepat
3. Klik Reload Config

</details>

<details>
<summary><b>Gambar tidak muncul?</b></summary>

1. Pastikan gambar sudah diupload di Discord Developer Portal
2. Tunggu beberapa menit (Discord membutuhkan waktu untuk sync)
3. Nama key harus sama persis (case sensitive)

</details>

<details>
<summary><b>Bagaimana cara menghapus dari startup?</b></summary>

Klik kanan ikon tray → Hilangkan centang pada "Run on Windows startup"

</details>

---

## 🔧 Troubleshooting

Jika mengalami masalah, periksa file `geetRPCS.log` di folder yang sama dengan exe untuk melihat error log.

### Error Umum

| Error | Solusi |
|-------|--------|
| `config.json tidak ditemukan` | Pastikan file config.json ada di folder yang sama |
| `apps.json tidak ditemukan` | Pastikan file apps.json ada di folder yang sama |
| Discord tidak terhubung | Pastikan Discord Desktop sedang berjalan |

---

## 📜 Lisensi

[MIT License](https://github.com/makcrtve/geetRPCS/blob/main/LICENSE)

---

## 🙏 Credits

* [DiscordRichPresence](https://github.com/Lachee/discord-rpc-csharp) by Lachee
* Ikon dan aset oleh makcrtve

---

## 📞 Dukungan

Butuh bantuan atau ingin melaporkan bug?

* 📧 Buat [Issue](https://github.com/makcrtve/geetRPCS/issues) di GitHub

---

<p align="center">
  <b>Made with ❤️ and ☕ by makcrtve</b>
  <br/>
  <sub>geetRPCS v1.1.0 • 2026</sub>
</p>
