<p align="center">
  <a href="README.en.md"><img src="https://img.shields.io/badge/Language-English-blue?style=flat-square" alt="English"/></a>
  <a href="README.id.md"><img src="https://img.shields.io/badge/Bahasa-Indonesia-red?style=flat-square" alt="Indonesia"/></a>
</p>

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/geetrpcs-banner.png" width="600" alt="geetRPCS Banner"/>
</p>

<h1 align="center">geetRPCS</h1>

<p align="center">
  <b>Automatic Discord Rich Presence untuk aplikasi favorit Anda!</b><br/>
  <sub>Tampilkan aktivitas Anda di Discord secara real-time, tanpa ribet 🚀</sub>
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
  <img src="https://img.shields.io/github/v/release/makcrtve/geetRPCS?style=flat-square&label=Versi&color=success" alt="Download"/>
  <img src="https://img.shields.io/github/downloads/makcrtve/geetRPCS/total?style=flat-square&label=Unduhan&color=blue" alt="Downloads"/>
</p>

<p align="center">
  <a href="#-quick-start">Mulai Cepat</a> •
  <a href="#-features">Fitur</a> •
  <a href="#-supported-apps">Aplikasi yang Didukung</a> •
  <a href="#%EF%B8%8F-configuration">Konfigurasi</a> •
  <a href="#-faq">FAQ</a>
</p>

---

## 🚀 Mulai Cepat

### ⚡ Instalasi Satu Perintah (Direkomendasikan)

Buka **PowerShell** dan jalankan:

```powershell
irm https://bit.ly/geetrpcs | iex
```

Installer interaktif akan memandu Anda:

```
  ╔═══════════════════════════════════════════╗
  ║       geetRPCS Installer / Updater        ║
  ╚═══════════════════════════════════════════╝

Pilih Versi:
  [1] Portable (Direkomendasikan) - Mandiri, tanpa dependensi
  [2] Minimal - Ukuran lebih kecil, butuh .NET 8.0 Runtime

Masukkan pilihan [1-2]: _

Buat shortcut Desktop? [Y/n]: _
Buat shortcut Start Menu? [Y/n]: _
```

> 💡 **Update:** Jalankan perintah yang sama untuk update ke versi terbaru. Pengaturan Anda akan tersimpan!

---

### 🗑️ Hapus Instalasi (Uninstall)

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

# Simpan data user (pengaturan, cache)
irm https://bit.ly/geetrpcs-del | iex; Uninstall-GeetRPCS -Silent -KeepUserData
```

#### Download Manual (Zip)
1. Download file `.zip` terbaru dari **[Releases](https://github.com/makcrtve/geetRPCS/releases/latest)**
2. Ekstrak ke folder pilihan Anda
3. Jalankan `geetRPCS.exe`

</details>

---

<details>
<summary><b>🛠️ Untuk Developer: Build dari Source</b></summary>
<br>

Persyaratan:
- **[.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)**
- Windows OS

### 1. Clone repositori
```powershell
git clone https://github.com/makcrtve/geetRPCS.git
cd geetRPCS
```

### 2. Build project
Buka terminal di dalam folder project dan jalankan:

**Portable (Direkomendasikan):**
```powershell
dotnet publish -c Release -r win-x64 -p:PublishSingleFile=true -p:SelfContained=true --output publish/portable
```

**Minimal (Butuh .NET Runtime):**
```powershell
dotnet publish -c Release -r win-x64 -p:PublishSingleFile=false -p:SelfContained=false --output publish/minimal
```

> **Lokasi Output:** Executable akan berada di dalam folder `publish/` di dalam direktori project.

</details>

---

## ✨ Fitur

<table>
<tr>
<td width="25%" valign="top">

**🎯 Inti**
- Deteksi Hibrida
- Satu Instansi (Single Instance)
- RAM Sangat Rendah (5-30MB)
- Animasi Ikon Tray
- Dukungan Komentar JSON
- Preview Auto-refresh
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
- Menu Cepat Tray
- Ganti App ID via Menu
- Ganti App ID Dinamis

</td>
<td width="25%" valign="top">

**🔧 Utilitas**
- Async I/O Teroptimasi 🚀
- True Hot Reload
- Akses Config Cepat
- Auto Startup
- Logging Event
- Update Checker (UI Kustom)
- Update Database App Otomatis
- Manajemen Cache
- **.gitignore Ready 🆕**

</td>
<td width="25%" valign="top">

**🎨 Kustomisasi**
- Teks Jenaka Dinamis
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

Ikon system tray kini lebih hidup! Saat geetRPCS mendeteksi pergantian aplikasi, ikon akan melakukan **rotasi 360° dengan efek detak**.

| Properti | Nilai |
|:---------|:------|
| **Efek** | Rotasi + Denyut Kecerahan |
| **Durasi** | 800ms (12 frame) |
| **Easing** | Ease-In-Out Quadratic |
| **Toggle** | Menu Tray → "🎨 Tray Icon Animation" |

> 💡 Animasi halus ini memberikan konfirmasi visual bahwa geetRPCS mendeteksi pergantian aplikasi Anda!

---

## 🖱️ Detektor Energi Mouse

<p align="center">
  <b>Tampilkan tingkat produktivitas real-time Anda di Discord!</b>
</p>

geetRPCS memiliki fitur **Detektor Energi Mouse** - fitur unik yang menganalisis aktivitas mouse Anda dan menampilkan "tingkat energi" saat ini di presence Discord.

| Level | Emoji | Kondisi |
|:------|:-----:|:----------|
| **Tertidur** | 💤 | Tidak ada aktivitas > 30 detik |
| **Bersantai** | ☕ | Aktivitas rendah (scrolling santai) |
| **Normal** | 🎯 | Aktivitas standar (bekerja biasa) |
| **Fokus** | 🔥 | Aktivitas tinggi (editing intens) |
| **Rush** | ⚡ | Aktivitas sangat tinggi (mode deadline!) |

**Contoh tampilan di Discord:**
```
Working on FL Studio 2025
Untitled - FL Studio | 🔥 Focused
```

> 💡 **Tip:** Nyalakan/matikan fitur ini via menu System Tray → "🖱️ Mouse Energy Detector"

---

## 🎭 Mesin Narasi Jenaka

<p align="center">
  <b>Bawa kepribadian ke status Discord Anda!</b>
</p>

Daripada pesan "Working..." yang membosankan, geetRPCS kini menampilkan **teks jenaka dinamis** yang berganti setiap 60 detik!

**Fitur:**
- 🎲 Pemilihan acak dari teks lucu yang dikurasi
- 🔄 Berotasi otomatis setiap 60 detik
- 📝 Sepenuhnya dapat dikustomisasi via `witty.json`
- 🎯 Nol biaya performa
- 🔌 Placeholder `{witty_text}` baru

**Contoh Teks:**

| App | Teks Jenaka |
|:----|:------------|
| **FL Studio** | "Producing next heater 🔥", "Where is snare? 🥁", "Soundgoodizer on Master 🎚️" |
| **VS Code** | "Compiling spaghetti code 🍝", "It works on my machine 🤷", "Debugging 100 errors 🐛" |
| **Chrome** | "100 tabs open 🔥", "Researching on YouTube 🎥", "Definitely working... 👀" |

**Cara Menggunakan:**
1. Edit `witty.json` untuk menambahkan teks Anda sendiri
2. Gunakan `{witty_text}` di field `customDetails`
3. Reload dengan `Ctrl+Alt+R`

> 💡 **Tip:** 400+ teks pra-tulis disertakan untuk 40+ aplikasi!

---

## 🎯 Aplikasi yang Didukung

<details open>
<summary><b>50+ Software • 80+ Nama Proses</b> (klik untuk toggle)</summary>

| Kategori | Aplikasi |
|:--------:|----------|
| 🎵 **Produksi Musik** | FL Studio, Ableton Live, Cubase, REAPER, Pro Tools, Studio One, Reason, Cakewalk by BandLab, Bitwig Studio |
| 🎤 **Edit Audio** | Adobe Audition, Audacity |
| 🎬 **Edit Video** | Adobe Premiere Pro, Adobe After Effects, DaVinci Resolve, Wondershare Filmora, Vegas Pro, CapCut |
| 🧊 **3D Modeling & Animasi** | Blender, Autodesk Maya, ZBrush, Substance 3D Painter |
| 🏛️ **CAD & Arsitektur** | SketchUp, AutoCAD |
| 🎨 **Desain Grafis & Foto** | Adobe Photoshop, Adobe Illustrator, Adobe Lightroom, GIMP, Inkscape, Affinity Studio, CorelDRAW, Krita, Clip Studio Paint, Aseprite |
| 💻 **Desain UI/UX** | Figma, Canva |
| 🌐 **Web Browser** | Brave Browser, Google Chrome, Mozilla Firefox, Zen Browser, Microsoft Edge |
| 📊 **Office & Produktivitas** | Microsoft Word, Microsoft Excel, Microsoft PowerPoint, Notion |
| 💬 **Komunikasi** | Telegram, Slack, WhatsApp, Zoom |
| 📈 **Data Science & Analisis** | Orange Data Mining |
| 🔧 **Media Tools** | HandBrake |

</details>

> 💡 **Tip:** Anda bisa menambahkan aplikasi Anda sendiri di `apps.json`!

---

## 🖥️ Penggunaan

### ⌨️ Hotkey Global (Shortcut)
Kontrol geetRPCS langsung dari keyboard, bahkan saat aplikasi diminimize:

| Shortcut | Fungsi |
|----------|----------|
| `Ctrl + Alt + P` | ⏸️ Jeda / Lanjutkan Presence |
| `Ctrl + Alt + V` | 👀 Buka/Tutup Jendela Preview |
| `Ctrl + Alt + H` | 🔒 Nyalakan Mode Privat |
| `Ctrl + Alt + R` | 🔄 Reload Konfigurasi |
| `Ctrl + Alt + S` | 📊 Tampilkan Statistik Hari Ini |

### 🖱️ Menu System Tray
**Klik kanan** ikon tray untuk mengakses menu manual:

| Menu | Fungsi |
|------|----------|
| ⏸️ Pause | Toggle presence nyala/mati |
| 🔒 Private Mode | Sensor judul window |
| 🖱️ Mouse Energy | Toggle detektor aktivitas |
| 🎨 Tray Animation | Toggle animasi ikon |
| 📡 Telemetry | Toggle data penggunaan anonim |
| 👀 Preview Window | Preview live presence Discord |
| 🛠️ Manage Apps | Aktifkan/nonaktifkan aplikasi |
| 🔑 Change App ID | Update Discord App ID default |
| 📊 Statistics | Liha & ekspor statistik |
| ⚡ Quick Actions | Akses folder, edit config |
| 🌐 Language | Ganti bahasa (EN/ID) |

<details>
<summary><b>📸 Screenshots</b></summary>

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/screenshot-1.png" width="280"/>
</p>
<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/screenshot-2.png" width="280"/>
</p>
<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/screenshot-3.png" width="280"/>
</p>
<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/screenshot-4.png" width="280"/>
</p>

</details>

---

## ⚙️ Konfigurasi

### 🎯 Pengaturan Terpusat

geetRPCS bekerja **langsung tanpa konfigurasi**! Aplikasi kini menggunakan `settings.json` terpusat dan cache internal untuk memastikan performa.

**config.json hanya dibutuhkan jika Anda ingin:**
- Menggunakan Discord Application ID Anda sendiri
- Mengubah teks presence
- Menambah tombol kustom

> 💡 **Tip:** Buat `config.json` via Quick Actions → "Edit config.json" (akan dibuat otomatis dengan default) ATAU gunakan menu **"Change App ID"**!

<details>
<summary><b>🔑 Ganti Client ID Dinamis (Baru di v1.3.2)</b></summary>

Anda sekarang bisa menetapkan **Discord App ID yang berbeda untuk aplikasi tertentu** tanpa mengubah config manual setiap saat.

**Cara kerjanya:**
1. Tambahkan field `"clientId"` ke aplikasi tertentu di `apps.json`.
2. Saat geetRPCS mendeteksi aplikasi tersebut, ia akan otomatis berganti ke App ID spesifik itu.
3. Saat Anda berpindah ke aplikasi lain (tanpa ID kustom), ia akan kembali ke ID global/default.

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

**Manfaat:**
- Discord Rich Presence berbeda untuk konteks berbeda (Kerja vs Personal).
- Gunakan aset/ikon aplikasi spesifik per aplikasi.
</details>

<details>
<summary><b>📄 config.json</b> - Konfigurasi Utama (Opsional)</summary>

```json
{
  "Discord": {
    "ApplicationId": "YOUR_DEFAULT_DISCORD_APP_ID",
    "Details": "Idling...",
    "State": "Ready to work",
    "ActiveDetails": "Working on {app_name}",
    "ActiveState": "{window_title}",
    "Assets": {
      "LargeImageKey": "geetrpcs-logo",
      "LargeImageText": "geetRPCS v1.3.3",
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
    "clientId": "OPTIONAL_SPECIFIC_APP_ID",
    "buttons": [
      { "label": "My Portfolio", "url": "https://example.com" }
    ]
  }
]
```

**Menambah aplikasi:** Task Manager → catat nama proses → tambahkan ke `apps.json` → Reload All (`Ctrl+Alt+R`)

> **Catatan:** Jika `"clientId"` tidak diisi, aplikasi menggunakan ID default dari `config.json`.

</details>

<details>
<summary><b>🔗 Persyaratan URL Tombol</b></summary>

geetRPCS memvalidasi URL tombol secara otomatis:

| Format URL | Status |
|:-----------|:------:|
| `https://github.com` | ✅ Valid |
| `http://example.com` | ✅ Valid |
| `github.com` | ❌ Dilewati (tanpa protokol) |
| `ftp://files.com` | ❌ Dilewati (protokol invalid) |
| URL Kosong | ❌ Dilewati |

**Batas label tombol:** Maksimum 32 karakter

> Tombol tidak valid akan dilewati secara diam-diam - tanpa error, hanya tidak muncul di Discord.

</details>

<details>
<summary><b>🎨 Aset Discord</b> - Upload gambar</summary>

1. Buka [Discord Developer Portal](https://discord.com/developers/applications)
2. Pilih aplikasi → **Rich Presence** → **Art Assets**
3. Upload gambar dengan nama yang cocok dengan `largeKey` / `smallKey`

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
├── witty.json            # Teks jenaka (wajib)
├── rpicon.ico            # Ikon (wajib)
├── config.json           # Konfigurasi Discord RPC (opsional)
├── settings.json         # Pengaturan user (dikelola otomatis)
├── statistics.json       # Data pelacakan (dikelola otomatis)
├── geetRPCS.log          # File log (dibuat otomatis)
├── .telemetry            # Penghitung peluncuran (dibuat otomatis)
├── ImageCache/           # Cache gambar preview (dibuat otomatis)
└── Languages/            # File bahasa (dibuat otomatis)
```

</details>

---

## ❓ FAQ (Tanya Jawab)

<details>
<summary><b>Presence tidak muncul di Discord?</b></summary>

1. Pastikan Anda menggunakan Discord **Desktop** (bukan web)
2. Settings → Activity Privacy → Aktifkan "Display current activity"
3. Restart geetRPCS dan Discord
4. Pastikan Anda tidak dalam mode **Pause**

</details>

<details>
<summary><b>Bagaimana cara update geetRPCS?</b></summary>

Cukup jalankan perintah install yang sama:

```powershell
irm https://bit.ly/geetrpcs | iex
```

Installer akan:
- ✅ Mendeteksi versi Anda saat ini
- ✅ Download hanya jika ada versi baru
- ✅ Backup pengaturan Anda (`apps.json`, `settings.json`, `statistics.json`)
- ✅ Install update
- ✅ Restore pengaturan Anda

**Catatan v1.3.3:** Source code kini siap open-source dengan `.gitignore` yang tepat dan formatting profesional!

</details>

<details>
<summary><b>Bagaimana cara menggunakan Discord App ID berbeda untuk aplikasi tertentu?</b></summary>

Anda bisa menimpa App ID global per aplikasi.

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
Ini akan menggunakan `987654321098765432` hanya untuk VS Code.

</details>

<details>
<summary><b>Bagaimana cara kerja Update Otomatis Database Aplikasi?</b></summary>

geetRPCS secara otomatis memeriksa apakah database `apps.json` Anda kadaluarsa saat startup.

- **Jika update ditemukan:** Dialog muncul menanyakan apakah Anda ingin update.
- **Jika Anda klik "Update":** Aplikasi mendownload `apps.json` terbaru dari GitHub dan mengganti yang lokal.
- **Jika Anda klik "Close":** Anda tetap menggunakan versi lokal saat ini.

Ini memastikan Anda selalu memiliki dukungan untuk software terbaru tanpa mendownload file manual.

</details>

<details>
<summary><b>Animasi tray tidak jalan?</b></summary>

1. Pastikan "🎨 Tray Icon Animation" aktif di menu tray
2. Animasi hanya terpicu saat **ganti aplikasi** (bukan ganti judul window)
3. Cek `geetRPCS.log` untuk pesan TrayAnimator

</details>

<details>
<summary><b>Startup tidak bekerja?</b></summary>

v1.2.7+ meningkatkan validasi startup:
1. Pastikan geetRPCS **tidak** dijalankan dari folder sementara (temp)
2. Pindahkan aplikasi ke lokasi permanen (contoh: `C:\Programs\geetRPCS\`)
3. Aktifkan startup lagi via menu tray
4. Jika Anda memindahkan aplikasi, aktifkan ulang startup untuk update path registry

</details>

<details>
<summary><b>Aplikasi baru tidak terdeteksi setelah edit apps.json?</b></summary>

1. Edit `apps.json` dan save
2. Klik kanan tray → Quick Actions → **Reload All** (atau tekan `Ctrl+Alt+R`)
3. Aplikasi baru harusnya terdeteksi langsung

Jika masih tidak bekerja, cek:
- Nama proses cocok persis (tidak case-sensitive)
- Sintaks JSON valid
- Aplikasi tidak dinonaktifkan di **Manage Apps**

</details>

<details>
<summary><b>Mouse Energy tidak update?</b></summary>

1. Pastikan "🖱️ Mouse Energy Detector" aktif di menu tray
2. Fitur ini menganalisis aktivitas seiring waktu - tunggu beberapa detik
3. Beberapa aplikasi fullscreen mungkin mempengaruhi deteksi
4. Cek `geetRPCS.log` untuk error MouseTracker

</details>

<details>
<summary><b>Tombol tidak muncul di Discord?</b></summary>

Cek URL Anda:
- Mulai dengan `http://` atau `https://`
- Adalah URL valid (bukan hanya nama domain)
- Label 32 karakter atau kurang

**Contoh tombol valid:**
```json
{ "label": "Website Saya", "url": "https://example.com" }
```

</details>

<details>
<summary><b>Hotkey tidak bekerja?</b></summary>

Pastikan tidak ada aplikasi lain menggunakan shortcut yang sama. Beberapa game fullscreen yang berjalan "As Administrator" mungkin memblokir hotkey jika geetRPCS tidak dijalankan sebagai Admin juga.

</details>

<details>
<summary><b>Gambar tidak muncul?</b></summary>

1. Upload gambar di Discord Developer Portal
2. Tunggu beberapa menit (sinkronisasi Discord)
3. Nama Key harus cocok **persis** (case sensitive)
4. Preview Window → 🔄 Refresh (Auto-refresh aktif di v1.2.8)

</details>

<details>
<summary><b>Troubleshooting</b></summary>

Buka `geetRPCS.log` atau klik kanan tray → **Open Log File**

| Error | Solusi |
|-------|----------|
| Apps.json not found | Pastikan apps.json ada di folder yang sama |
| Discord not connected | Pastikan Discord Desktop berjalan |
| Presence not showing | Cek mode Pause dan Manage Apps |
| Preview image empty | Hapus Cache → Refresh |
| Mouse hook failed | Jalankan sebagai Administrator |
| Buttons not appearing | Cek format URL (harus mulai dengan http/https) |
| Startup from temp rejected | Pindahkan app ke folder permanen |
| Already running | v1.2.8 mencegah instansi duplikat. Cek tray. |

</details>

---

## 🛡️ Keamanan

<p align="center">
  <a href="https://www.virustotal.com/gui/file-analysis/ZmI0NWJiYmJmMjA2MTIxMDlmNTI2NzIzMTM4YmVmYmY6MTc2ODYyNTE2NQ==/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F71%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
  <a href="https://www.virustotal.com/gui/file-analysis/MDdlNzQ5ZGJmMTZhYzY3ZmI5ZmZiYjM4MzI1MDE1ZjU6MTc2ODYyNTE5Ng==/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F69%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
</p>

<details>
<summary><b>Detail Scan & Info False Positive</b></summary>

**Hasil Scan v1.3.3:**
- ✅ `0/71` | `0/69` deteksi malware (Bersih)
- ✅ Code Signed: Tidak (Self-contained)

**False Positive?** Beberapa AV mungkin menandainya karena:
- Executable baru / tidak didistribusikan secara luas
- Akses API Discord RPC
- Akses Registry (auto-startup)
- **Hook Hotkey Global** (API RegisterHotKey)
- **Hook Mouse** (API SetWindowsHookEx)
- **Manipulasi Ikon** (GDI+ untuk animasi tray)

**Solusi:** Whitelist di antivirus atau verifikasi di [VirusTotal](https://www.virustotal.com)

</details>

---

## 🔮 Roadmap

- [x] Auto-update checker (UI Kustom)
- [x] Statistics tracker (Async I/O)
- [x] Multi-bahasa (EN/ID)
- [x] Preview Window
- [x] App Manager
- [x] Dukungan Hotkey Global
- [x] Detektor Energi Mouse
- [x] Smart Defaults (config opsional)
- [x] True Hot Reload
- [x] Validasi URL untuk tombol
- [x] Animasi Ikon Tray
- [x] Installer/updater satu perintah
- [x] Penegakan Satu Instansi
- [x] Optimisasi Memori
- [x] Ganti App ID dari Menu
- [x] Ganti App ID Dinamis (Per-App)
- [x] Update Database App Otomatis
- [x] **.gitignore & GitHub Ready 🆕**
- [x] **Formatting Kode Profesional 🆕**
- [ ] Dukungan software lebih banyak
- [ ] UI Dashboard (WPF/WinUI)

---

## 📞 Tautan

<p align="center">
  <a href="https://github.com/makcrtve/geetRPCS/issues">🐛 Lapor Bug</a> •
  <a href="https://github.com/makcrtve/geetRPCS/discussions">💬 Diskusi</a> •
  <a href="https://github.com/makcrtve/geetRPCS/releases">📦 Rilis</a> •
  <a href="https://discord.gg/ScTybDUEpH">🎮 Gabung Discord</a>
</p>

---

<p align="center">
  <sub>Dibuat dengan ❤️ oleh <a href="https://github.com/makcrtve">makcrtve</a></sub><br/>
  <sub>geetRPCS v1.3.3 • Apache 2.0 License • 2026</sub>
</p>
