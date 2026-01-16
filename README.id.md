<p align="center">
  <a href="README.en.md"><img src="https://img.shields.io/badge/Language-English-blue?style=flat-square" alt="English"/></a>
  <a href="README.id.md"><img src="https://img.shields.io/badge/Bahasa-Indonesia-red?style=flat-square" alt="Indonesia"/></a>
</p>

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/geetrpcs-banner.png" width="600" alt="geetRPCS Banner"/>
</p>

<h1 align="center">geetRPCS</h1>

<p align="center">
  <b>Discord Rich Presence otomatis untuk aplikasi favoritmu!</b><br/>
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
  <a href="#-supported-apps">Aplikasi Didukung</a> •
  <a href="#%EF%B8%8F-configuration">Konfigurasi</a> •
  <a href="#-faq">FAQ</a>
</p>

---

## 🚀 Quick Start

### ⚡ Instalasi Satu Perintah (Direkomendasikan)

Buka **PowerShell** dan jalankan:

```powershell
irm https://bit.ly/geetrpcs | iex
```

Installer interaktif akan memandu kamu:

```
  ╔═══════════════════════════════════════════╗
  ║       geetRPCS Installer / Updater        ║
  ╚═══════════════════════════════════════════╝

Select Version:
  [1] Portable (Direkomendasikan) - Mandiri, tanpa dependensi
  [2] Minimal - Ukuran lebih kecil, butuh .NET 8.0 Runtime

Masukkan pilihan [1-2]: _

Buat shortcut Desktop? [Y/n]: _
Buat shortcut Start Menu? [Y/n]: _
```

> 💡 **Info Pembaruan:** Jalankan perintah yang sama untuk update ke versi terbaru. Pengaturanmu akan tetap tersimpan!

---

### 🗑️ Uninstall

```powershell
irm https://bit.ly/geetrpcs-del | iex
```

<details>
<summary><b>Opsi Instalasi Lanjutan</b></summary>

#### Instalasi Senyap (Tanpa Prompt)
```powershell
# Portable + Semua Shortcut
irm https://bit.ly/geetrpcs | iex; Install-GeetRPCS -Silent -DesktopShortcut -StartMenuShortcut

# Minimal + Tanpa Shortcut
irm https://bit.ly/geetrpcs | iex; Install-GeetRPCS -Version "minimal" -Silent
```

#### Uninstall Senyap
```powershell
# Uninstall bersih (hapus semuanya)
irm https://bit.ly/geetrpcs-del | iex; Uninstall-GeetRPCS -Silent

# Jaga data pengguna (settings, cache)
irm https://bit.ly/geetrpcs-del | iex; Uninstall-GeetRPCS -Silent -KeepUserData
```

#### Unduhan Manual (Zip)
1. Download `.zip` terbaru dari **[Releases](https://github.com/makcrtve/geetRPCS/releases/latest)**
2. Ekstrak ke folder yang kamu inginkan
3. Jalankan `geetRPCS.exe`

</details>

---

## ✨ Fitur

<table>
<tr>
<td width="25%" valign="top">

**🎯 Inti**
- Hybrid Detection
- Instansi Tunggal
- RAM Ultra Rendah (5-20MB)
- Animasi Tray
- Dukungan Komentar JSON
- Auto-refresh Preview
- Manajer Blacklist App

</td>
<td width="25%" valign="top">

**⚙️ Kontrol**
- Mode Jeda
- Mode Privat
- Pelacakan Statistik
- Ekspor CSV/JSON
- Multi-Bahasa (EN/ID)
- Hotkey Global
- Menu Cepat Tray
- Ubah App ID lewat Menu
- **Penggantian App ID Dinamis (Per-App) 🆕**

</td>
<td width="25%" valign="top">

**🔧 Utilitas**
- Async I/O Teroptimasi 🚀
- Hot Reload Asli
- Akses Konfigurasi Cepat
- Auto Startup
- Event Logging
- Pengecek Update (UI Kustom)
- **Auto Pembaruan DB Apps 🆕**
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

## 🎨 Animasi Ikon Tray

Ikon tray sistem sekarang jadi hidup! Saat geetRPCS mendeteksi perpindahan aplikasi, ikon akan melakukan efek **rotasi 360° dengan pulsa kecerahan**.

| Properti | Nilai |
|:---------|:------|
| **Efek** | Rotasi + Pulsa Kecerahan |
| **Durasi** | 800ms (12 frame) |
| **Easing** | Ease-In-Out Quadratic |
| **Toggle** | Menu tray → "🎨 Animasi Ikon Tray" |

> 💡 Animasi halus ini memberikan konfirmasi visual bahwa geetRPCS mendeteksi perpindahan aplikasimu!

---

## 🖱️ Detektor Energi Mouse

<p align="center">
  <b>Tampilkan tingkat produktivitas real-time-mu di Discord!</b>
</p>

geetRPCS memiliki fitur **Detektor Energi Mouse** - fitur unik yang menganalisa aktivitas mouse-mu dan menampilkan tingkat "energi" saat ini di Discord presence.

| Level | Emoji | Kondisi |
|:------|:-----:|:----------|
| **Tidur** | 💤 | Tidak ada aktivitas selama > 30 detik |
| **Santai** | ☕ | Aktivitas rendah (scrolling santai) |
| **Normal** | 🎯 | Aktivitas standar (kerja reguler) |
| **Fokus** | 🔥 | Aktivitas tinggi (editing intensif) |
| **Rush** | ⚡ | Aktivitas sangat tinggi (deadline mode!) |

**Contoh tampilan Discord:**
```
Working on FL Studio 2025
Untitled - FL Studio | 🔥 Fokus
```

> 💡 **Tips:** Aktifkan fitur ini lewat menu System Tray → "🖱️ Detektor Energi Mouse"

---

## 🎭 Mesin Narasi Witty

<p align="center">
  <b>Berikan kepribadian pada status Discord-mu!</b>
</p>

Alih-alih pesan membosankan "Working...", geetRPCS sekarang menampilkan **teks humor yang dinamis** yang berganti setiap 60 detik!

**Fitur:**
- 🎲 Pilihan acak dari teks lucu kurasi
- 🔄 Berganti otomatis setiap 60 detik
- 📝 Bisa dikustomisasi penuh lewat `witty.json`
- 🎯 Nol biaya performa
- 🔌 Placeholder baru `{witty_text}`

**Contoh Teks:**

| Aplikasi | Teks Witty |
|:----|:------------|
| **FL Studio** | "Producing next heater 🔥", "Snare kemana? 🥁", "Soundgoodizer on Master 🎚️" |
| **VS Code** | "Compiling spaghetti code 🍝", "Works on my machine 🤷", "Debugging 100 errors 🐛" |
| **Chrome** | "100 tabs open 🔥", "Research di YouTube 🎥", "Definitely working... 👀" |

**Cara Pakai:**
1. Edit `witty.json` untuk tambah teks sendiri
2. Pakai `{witty_text}` di kolom `customDetails`
3. Reload dengan `Ctrl+Alt+R`

> 💡 **Tips:** 400+ teks bawaan disertakan untuk 40+ aplikasi!

---

## 🎯 Aplikasi Didukung

<details open>
<summary><b>42 Software • 65+ Nama Proses</b> (klik untuk toggle)</summary>

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

> 💡 **Tips:** Kamu bisa tambah aplikasi sendiri di `apps.json`!

---

## 🖥️ Penggunaan

### ⌨️ Hotkey Global (Pintasan)
Kontrol geetRPCS langsung dari keyboard, bahkan saat aplikasi diminimalkan:

| Pintasan | Fungsi |
|----------|----------|
| `Ctrl + Alt + P` | ⏸️ Jeda / Lanjutkan Presence |
| `Ctrl + Alt + V` | 👀 Toggle Jendela Preview |
| `Ctrl + Alt + H` | 🔒 Toggle Mode Privat |
| `Ctrl + Alt + R` | 🔄 Reload Config |
| `Ctrl + Alt + S` | 📊 Tampilkan Statistik Hari Ini |

### 🖱️ Menu Tray Sistem
**Klik kanan** ikon tray untuk mengakses menu manual:

| Menu | Fungsi |
|------|----------|
| ⏸️ Jeda | Hidupkan/matikan presence |
| 🔒 Mode Privat | Sensor judul jendela |
| 🖱️ Energi Mouse | Aktifkan detektor aktivitas |
| 🎨 Animasi Tray | Aktifkan animasi ikon |
| 📡 Telemetri | Aktifkan data pengguna anonim |
| 👀 Jendela Preview | Preview langsung presence Discord |
| 🛠️ Kelola Aplikasi | Hidupkan/matikan aplikasi |
| 🔑 Ubah App ID | Update ID App Discord default |
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

### 🎯 Pengaturan Terpadu

geetRPCS jalan **langsung saat diinstal**! Aplikasi ini sekarang menggunakan `settings.json` terpusat dan cache internal untuk memastikan performa.

**config.json hanya dibutuhkan jika kamu ingin:**
- Menggunakan Discord Application ID sendiri
- Mengkustomisasi teks presence
- Menambahkan tombol kustom

> 💡 **Tips:** Buat `config.json` lewat Quick Actions → "Edit config.json" (akan auto-create dengan default) ATAU gunakan menu item **"Ubah App ID"**!

<details>
<summary><b>🔑 Penggantian Client ID Dinamis (Baru di v1.3.2)</b></summary>

Kamu sekarang bisa menetapkan **App ID Discord yang berbeda untuk aplikasi tertentu** tanpa harus mengubah config manual setiap kali.

**Cara kerjanya:**
1. Tambahkan kolom `"clientId"` ke aplikasi tertentu di `apps.json`.
2. Saat geetRPCS mendeteksi aplikasi tersebut, ia akan otomatis pindah ke App ID spesifik itu.
3. Saat kamu pindah ke aplikasi lain (tanpa ID kustom), ia akan kembali ke ID global/default.

**Contoh:**
```json
[
  {
    "process": "chrome",
    "appName": "Google Chrome",
    "clientId": "111111111111111111", 
    ...
  },
  {
    "process": "FL64",
    "appName": "FL Studio",
    "clientId": "222222222222222222", 
    ...
  }
]
```

**Keuntungan:**
- Preset Rich Presence berbeda untuk konteks berbeda (Kerja vs Personal).
- Pakai aset/ikon khusus per aplikasi.
</details>

<details>
<summary><b>📄 config.json</b> - Konfigurasi utama (Opsional)</summary>

```json
{
  "Discord": {
    "ApplicationId": "ID_APP_DISCORD_DEFAULT_ANDA",
    "Details": "Idling...",
    "State": "Siap kerja",
    "ActiveDetails": "Kerja di {app_name}",
    "ActiveState": "{window_title}",
    "Assets": {
      "LargeImageKey": "geetrpcs-logo",
      "LargeImageText": "geetRPCS v1.3.2",
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
    "clientId": "ID_APP_SPESIFIK_OPSIONAL",
    "buttons": [
      { "label": "Portfolio Saya", "url": "https://contoh.com" }
    ]
  }
]
```

**Menambah aplikasi:** Task Manager → catat nama proses → tambah ke `apps.json` → Reload All (`Ctrl+Alt+R`)

> **Catatan:** Jika `"clientId"` dihapus, aplikasi akan pakai ID default dari `config.json`.

</details>

<details>
<summary><b>🔗 Persyaratan URL Tombol</b></summary>

geetRPCS memvalidasi URL tombol secara otomatis:

| Format URL | Status |
|:-----------|:------:|
| `https://github.com` | ✅ Valid |
| `http://contoh.com` | ✅ Valid |
| `github.com` | ❌ Dilewati (tidak ada protokol) |
| `ftp://files.com` | ❌ Dilewati (protokol tidak valid) |
| URL Kosong | ❌ Dilewati |

**Limit label tombol:** Maksimal 32 karakter

> Tombol yang tidak valid akan dilewati secara diam-diam - tidak ada error, hanya saja tidak akan muncul di Discord.

</details>

<details>
<summary><b>🎨 Aset Discord</b> - Upload gambar</summary>

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
📁 %LOCALAPPDATA%\geetRPCS\
├── geetRPCS.exe          # Aplikasi utama
├── apps.json             # Daftar aplikasi (dibutuhkan)
├── witty.json            # Teks witty (dibutuhkan)
├── rpicon.ico            # Ikon (dibutuhkan)
├── config.json           # Konfigurasi Discord RPC (opsional)
├── settings.json         # Pengaturan user (auto-manage, async)
├── statistics.json       # Data tracking (auto-manage, async)
├── geetRPCS.log          # File log (auto-generate)
├── .telemetry            # Counter launch (auto-generate)
├── ImageCache/           # Cache Gambar Preview (auto-generate)
└── Languages/            # File bahasa (auto-generate)
```

</details>

---

## ❓ FAQ

<details>
<summary><b>Presence tidak muncul di Discord?</b></summary>

1. Pastikan kamu menggunakan Discord **Desktop** (bukan web)
2. Settings → Activity Privacy → Enable "Display current activity"
3. Restart geetRPCS dan Discord
4. Pastikan kamu tidak dalam mode **Pause** (Jeda)

</details>

<details>
<summary><b>Cara update geetRPCS?</b></summary>

Cukup jalankan perintah instal yang sama:

```powershell
irm https://bit.ly/geetrpcs | iex
```

Installer akan:
- ✅ Deteksi versi saat ini
- ✅ Download hanya jika ada versi baru tersedia
- ✅ Backup pengaturanmu (`apps.json`, `settings.json`, `statistics.json`)
- ✅ Install update
- ✅ Restore pengaturanmu

**Catatan v1.3.2:** Pengecek update sekarang punya dialog kustom cantik sesuai tema Discord!

</details>

<details>
<summary><b>Cara menggunakan App ID Discord berbeda untuk aplikasi spesifik?</b></summary>

Di **v1.3.2**, kamu bisa menimpa App ID global per aplikasi.

1. Buka `apps.json`.
2. Tambahkan `"clientId": "ID_APP_SPESIFIK_ANDA"` ke entri aplikasi yang diinginkan.
3. Reload konfigurasi (`Ctrl+Alt+R`).

Contoh:
```json
{
  "process": "VSCode",
  "appName": "VS Code",
  "clientId": "987654321098765432", 
  ...
}
```
Ini akan pakai `987654321098765432` hanya untuk VS Code.

</details>

<details>
<summary><b>Bagaimana cara kerja Pembaruan Database Aplikasi Otomatis?</b></summary>

Sejak **v1.3.2**, geetRPCS otomatis mengecek apakah database `apps.json`-mu sudah kadaluarsa saat startup.

- **Jika ada update:** Sebuah dialog akan muncul menanyakan apakah kamu ingin update.
- **Jika kamu klik "Update":** Aplikasi akan download `apps.json` terbaru dari GitHub dan mengganti yang lokal.
- **Jika kamu klik "Tutup":** Kamu tetap pakai versi lokalmu saat ini.

Ini memastikan kamu selalu punya dukungan untuk software terbaru tanpa perlu download manual file.

</details>

<details>
<summary><b>Animasi tray tidak jalan?</b></summary>

1. Pastikan "🎨 Animasi Ikon Tray" diaktifkan di menu tray
2. Animasi hanya triggered saat **pindah aplikasi** (bukan perubahan judul jendela)
3. Cek `geetRPCS.log` untuk pesan TrayAnimator

</details>

<details>
<summary><b>Startup tidak jalan?</b></summary>

v1.2.7+ meningkatkan validasi startup:
1. Pastikan geetRPCS **tidak** berjalan dari folder sementara (temp)
2. Pindahkan aplikasi ke lokasi permanen (misalnya, `C:\Programs\geetRPCS\`)
3. Aktifkan startup lagi lewat menu tray
4. Jika kamu memindahkan aplikasi, aktifkan ulang startup untuk update path registry

</details>

<details>
<summary><b>Aplikasi baru tidak terdeteksi setelah edit apps.json?</b></summary>

1. Edit `apps.json` dan simpan
2. Klik kanan tray → Quick Actions → **Reload All** (atau tekan `Ctrl+Alt+R`)
3. Aplikasi baru harusnya langsung terdeteksi

Jika masih tidak jalan, cek:
- Nama proses cocok persis (tidak case-sensitive)
- Sintaks JSON valid
- Aplikasi tidak dinonaktifkan di **Kelola Aplikasi**

</details>

<details>
<summary><b>Energi Mouse tidak update?</b></summary>

1. Pastikan "🖱️ Detektor Energi Mouse" diaktifkan di menu tray
2. Fitur ini menganalisa aktivitas seiring waktu - tunggu beberapa detik
3. Beberapa aplikasi fullscreen mungkin mempengaruhi deteksi
4. Cek `geetRPCS.log` untuk error MouseTracker

</details>

<details>
<summary><b>Tombol tidak muncul di Discord?</b></summary>

Cek bahwa URL-mu:
- Dimulai dengan `http://` atau `https://`
- Adalah URL valid (bukan cuma nama domain)
- Labelnya 32 karakter atau kurang

**Contoh tombol yang valid:**
```json
{ "label": "Website Saya", "url": "https://contoh.com" }
```

</details>

<details>
<summary><b>Hotkey tidak jalan?</b></summary>

Pastikan tidak ada aplikasi lain yang pakai pintasan yang sama. Beberapa game fullscreen yang jalan "As Administrator" mungkin memblokir hotkey jika geetRPCS tidak juga dijalankan sebagai Admin.

</details>

<details>
<summary><b>Gambar tidak muncul?</b></summary>

1. Upload gambar di Discord Developer Portal
2. Tunggu beberapa menit (Discord sync)
3. Nama key harus cocok **persis** (case sensitive)
4. Jendela Preview → 🔄 Refresh (Auto-refresh aktif di v1.2.8)

</details>

<details>
<summary><b>Troubleshooting</b></summary>

Buka `geetRPCS.log` atau klik kanan tray → **Open Log File**

| Error | Solusi |
|-------|----------|
| Apps.json tidak ditemukan | Pastikan apps.json ada di folder yang sama |
| Discord tidak terhubung | Pastikan Discord Desktop sedang berjalan |
| Presence tidak muncul | Cek mode Pause dan Kelola Aplikasi |
| Gambar preview kosong | Clear Cache → Refresh |
| Mouse hook gagal | Jalankan sebagai Administrator |
| Tombol tidak muncul | Cek format URL (harus mulai dengan http/https) |
| Startup dari temp ditolak | Pindahkan app ke folder permanen |
| Sudah berjalan | v1.2.8 mencegah instansi ganda. Cek tray. |

</details>

---

## 🛡️ Keamanan

<p align="center">
  <a href="https://www.virustotal.com/gui/file/36128aa46bd9505c3543f7ad2a9f9bbc51222b86fbd913d817f7b2bf056ab3dd/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F71%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
  <a href="https://www.virustotal.com/gui/file-analysis/OTU0ZGQzZjA1YzczNWNiNTNmYTgzZjhlM2ExZDZhNWY6MTc2ODQ5NTkwMQ==/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F69%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
</p>

<details>
<summary><b>Detail Scan & Info Positif Palsu</b></summary>

**Hasil Scan v1.3.2:**
- ✅ `0/71` | `0/70` deteksi malware (Bersih)
- ✅ Code Signed: No (Self-contained)

**Positif Palsu?** Beberapa AV mungkin menandainya karena:
- Executable baru / belum tersebar luas
- Akses API Discord RPC
- Akses Registry (auto-startup)
- **Global Hotkey hooks** (API RegisterHotKey)
- **Mouse hooks** (API SetWindowsHookEx)
- **Manipulasi Ikon** (GDI+ untuk animasi tray)

**Solusi:** Whitelist di antivirus atau verifikasi di [VirusTotal](https://www.virustotal.com)

</details>

---

## 🔮 Roadmap

- [x] Pengecek update otomatis (UI Kustom)
- [x] Tracker statistik (Async I/O)
- [x] Multi-bahasa (EN/ID)
- [x] Jendela Preview
- [x] Manajer App
- [x] Dukungan Hotkey Global
- [x] Detektor Energi Mouse
- [x] Default Cerdas (config opsional)
- [x] True Hot Reload
- [x] Validasi URL untuk tombol
- [x] Animasi Ikon Tray
- [x] Installer/updater satu perintah
- [x] Penegakan Instansi Tunggal
- [x] Optimasi Memori
- [x] Ubah App ID dari Menu
- [x] **Penggantian App ID Dinamis (Per-App) 🆕**
- [x] **Auto Pembaruan Database Apps 🆕**
- [ ] Dukungan software lebih banyak
- [ ] Dashboard UI (WPF/WinUI)

---

## 📞 Links

<p align="center">
  <a href="https://github.com/makcrtve/geetRPCS/issues">🐛 Lapor Bug</a> •
  <a href="https://github.com/makcrtve/geetRPCS/discussions">💬 Diskusi</a> •
  <a href="https://github.com/makcrtve/geetRPCS/releases">📦 Rilis</a> •
  <a href="https://discord.gg/ScTybDUEpH">🎮 Gabung Discord</a>
</p>

---

<p align="center">
  <sub>Dibuat dengan ❤️ oleh <a href="https://github.com/makcrtve">makcrtve</a></sub><br/>
  <sub>geetRPCS v1.3.2 • MIT License • 2026</sub>
</p>
