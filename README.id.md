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

### ⚡ Instalasi Satu Perintah (Rekomendasi)

Buka **PowerShell** dan jalankan:

```powershell
irm https://bit.ly/geetrpcs | iex
```

Installer interaktif akan memandumu:

```
  ╔═══════════════════════════════════════════╗
  ║       geetRPCS Installer / Updater        ║
  ╚═══════════════════════════════════════════╝

Select Version:
  [1] Portable (Recommended) - Standalone, no dependencies
  [2] Minimal - Smaller size, requires .NET 8.0 Runtime

Enter choice [1-2]: _

Create Desktop shortcut? [Y/n]: _
Create Start Menu shortcut? [Y/n]: _
```

> 💡 **Update:** Jalankan perintah yang sama untuk update ke versi terbaru. Pengaturanmu akan dipertahankan!

---

### 🗑️ Uninstall

```powershell
irm https://bit.ly/geetrpcs-del | iex
```

<details>
<summary><b>Opsi Instalasi Lanjutan</b></summary>

#### Silent Install (Tanpa Prompt)
```powershell
# Portable + Semua Shortcut
irm https://bit.ly/geetrpcs | iex; Install-GeetRPCS -Silent -DesktopShortcut -StartMenuShortcut

# Minimal + Tanpa Shortcut
irm https://bit.ly/geetrpcs | iex; Install-GeetRPCS -Version "minimal" -Silent
```

#### Silent Uninstall
```powershell
# Uninstall bersih (hapus semua)
irm https://bit.ly/geetrpcs-del | iex; Uninstall-GeetRPCS -Silent

# Simpan data pengguna (pengaturan, cache)
irm https://bit.ly/geetrpcs-del | iex; Uninstall-GeetRPCS -Silent -KeepUserData
```

#### Download Manual (Zip)
1. Download file `.zip` terbaru dari **[Releases](https://github.com/makcrtve/geetRPCS/releases/latest)**
2. Ekstrak ke folder pilihanmu
3. Jalankan `geetRPCS.exe`

</details>

---

## ✨ Fitur

<table>
<tr>
<td width="50%">

### 🎯 Inti
- 🔍 **Deteksi Otomatis** - 40+ aplikasi populer
- 🖱️ **Mouse Energy** - Level aktivitas real-time
- 🎨 **Animasi Tray** - Feedback visual saat ganti app
- ⌨️ **Hotkey Global** - Shortcut keyboard
- 👀 **Jendela Preview** - Preview presence langsung
- 🛠️ **Manajer Aplikasi** - Blacklist aplikasi

</td>
<td width="50%">

### ⚙️ Kontrol
- ⏸️ **Mode Pause** - Sembunyikan presence sementara
- 🔒 **Mode Private** - Sensor judul jendela
- 📊 **Statistik** - Tracking + Ekspor CSV/JSON
- 🌐 **Multi-Bahasa** - EN / ID

</td>
</tr>
<tr>
<td width="50%">

### 🔧 Utilitas
- 🎯 **Smart Defaults** - Berjalan tanpa config.json
- 🔄 **True Hot Reload** - Edit & terapkan langsung
- ⚡ **Quick Actions** - Akses cepat ke konfigurasi
- 🚀 **Auto Startup** - Jalan saat Windows mulai

</td>
<td width="50%">

### 🎨 Kustomisasi
- 🖼️ **Custom Assets** - Gunakan gambar sendiri
- 📝 **Custom Text** - Teks & placeholder kustom
- 🔘 **Custom Buttons** - Link ke portofolio
- 🔗 **Validasi URL** - Filter tombol otomatis

</td>
</tr>
</table>

---

## 🎨 Animasi Ikon Tray

Ikon system tray sekarang hidup! Saat geetRPCS mendeteksi pergantian aplikasi, ikon melakukan **rotasi 360° dengan efek pulse brightness** yang halus.

| Properti | Nilai |
|:---------|:------|
| **Efek** | Rotasi + Pulse brightness |
| **Durasi** | 800ms (12 frame) |
| **Easing** | Ease-In-Out Quadratic |
| **Toggle** | Menu tray → "🎨 Tray Icon Animation" |

> 💡 Animasi halus ini memberikan konfirmasi visual bahwa geetRPCS mendeteksi pergantian aplikasimu!

---

## 🖱️ Detektor Mouse Energy

<p align="center">
  <b>Tunjukkan level produktivitasmu secara real-time di Discord!</b>
</p>

geetRPCS memiliki fitur **Mouse Energy Detector** - fitur unik yang menganalisis aktivitas mouse dan menampilkan "level energi" kamu saat ini di Discord presence.

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
Untitled - FL Studio | 🔥 Focused
```

> 💡 **Tips:** Aktifkan/nonaktifkan fitur ini via menu System Tray → "🖱️ Mouse Energy Detector"

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

> 💡 **Tips:** Kamu bisa menambahkan aplikasi sendiri di `apps.json`!

---

## 🖥️ Penggunaan

### ⌨️ Hotkey Global (Shortcut)
Kontrol geetRPCS langsung dari keyboard, bahkan saat aplikasi diminimize:

| Shortcut | Fungsi |
|----------|--------|
| `Ctrl + Alt + P` | ⏸️ Pause / Resume Presence |
| `Ctrl + Alt + V` | 👀 Toggle Jendela Preview |
| `Ctrl + Alt + H` | 🔒 Toggle Mode Private |
| `Ctrl + Alt + R` | 🔄 Reload Config |
| `Ctrl + Alt + S` | 📊 Tampilkan Statistik Hari Ini |

### 🖱️ Menu System Tray
**Klik kanan** ikon tray untuk mengakses menu manual:

| Menu | Fungsi |
|------|--------|
| ⏸️ Pause | Toggle presence on/off |
| 🔒 Mode Private | Sensor judul jendela |
| 🖱️ Mouse Energy | Toggle detektor aktivitas |
| 🎨 Animasi Tray | Toggle animasi ikon |
| 📡 Telemetri | Toggle data penggunaan anonim |
| 👀 Jendela Preview | Preview presence Discord langsung |
| 🛠️ Kelola Aplikasi | Aktifkan/nonaktifkan aplikasi |
| 📊 Statistik | Lihat & ekspor statistik |
| ⚡ Quick Actions | Akses folder, edit config |
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

**config.json hanya diperlukan jika kamu ingin:**
- Menggunakan Discord Application ID sendiri
- Kustomisasi teks presence
- Menambahkan tombol kustom

> 💡 **Tips:** Buat config.json via Quick Actions → "Edit config.json" (akan otomatis dibuat dengan defaults)

<details>
<summary><b>📄 config.json</b> - Konfigurasi utama (Opsional)</summary>

```json
{
  "Discord": {
    "ApplicationId": "DISCORD_APP_ID_KAMU",
    "Details": "Sedang santai...",
    "State": "Siap bekerja",
    "ActiveDetails": "Mengerjakan {app_name}",
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
      { "label": "Portofolio Saya", "url": "https://example.com" }
    ]
  }
]
```

**Menambah aplikasi:** Task Manager → catat nama proses → tambahkan ke apps.json → Reload All (`Ctrl+Alt+R`)

</details>

<details>
<summary><b>🔗 Persyaratan URL Tombol</b></summary>

geetRPCS memvalidasi URL tombol secara otomatis:

| Format URL | Status |
|:-----------|:------:|
| `https://github.com` | ✅ Valid |
| `http://example.com` | ✅ Valid |
| `github.com` | ❌ Dilewati (tanpa protokol) |
| `ftp://files.com` | ❌ Dilewati (protokol tidak valid) |
| URL kosong | ❌ Dilewati |

**Batas label tombol:** Maksimal 32 karakter

> Tombol tidak valid akan dilewati secara diam-diam - tidak ada error, hanya tidak akan muncul di Discord.

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
📁 %LOCALAPPDATA%\geetRPCS\
├── geetRPCS.exe          # Aplikasi utama
├── apps.json             # Daftar aplikasi (wajib)
├── rpicon.ico            # Ikon (wajib)
├── config.json           # Konfigurasi Discord RPC (opsional)
├── settings.json         # Pengaturan (otomatis dibuat)
├── .version              # Info versi (otomatis dibuat)
├── statistics.json       # Data tracking (otomatis dibuat)
├── geetRPCS.log          # File log (otomatis dibuat)
├── .telemetry            # Penghitung peluncuran (otomatis dibuat)
├── ImageCache/           # Cache gambar (otomatis dibuat)
└── Languages/            # File bahasa (otomatis dibuat)
```

</details>

---

## ❓ FAQ

<details>
<summary><b>Presence tidak muncul di Discord?</b></summary>

1. Pastikan kamu menggunakan Discord **Desktop** (bukan web)
2. Pengaturan → Privasi Aktivitas → Aktifkan "Tampilkan aktivitas saat ini"
3. Restart geetRPCS dan Discord
4. Pastikan kamu tidak dalam mode **Pause**

</details>

<details>
<summary><b>Bagaimana cara update geetRPCS?</b></summary>

Cukup jalankan perintah install yang sama:

```powershell
irm https://bit.ly/geetrpcs | iex
```

Installer akan:
- ✅ Mendeteksi versi terpasang
- ✅ Download hanya jika ada versi baru
- ✅ Backup pengaturanmu (`apps.json`, `settings.json`)
- ✅ Install update
- ✅ Restore pengaturanmu

</details>

<details>
<summary><b>Animasi tray tidak berfungsi?</b></summary>

1. Pastikan "🎨 Tray Icon Animation" diaktifkan di menu tray
2. Animasi hanya terpicu saat **ganti aplikasi** (bukan perubahan judul jendela)
3. Periksa `geetRPCS.log` untuk pesan TrayAnimator

</details>

<details>
<summary><b>Startup tidak berfungsi?</b></summary>

v1.2.7 meningkatkan validasi startup:
1. Pastikan geetRPCS **tidak** berjalan dari folder sementara
2. Pindahkan aplikasi ke lokasi permanen (contoh: `C:\Programs\geetRPCS\`)
3. Aktifkan startup lagi via menu tray
4. Jika kamu memindahkan aplikasi, aktifkan ulang startup untuk memperbarui path registry

</details>

<details>
<summary><b>Aplikasi baru tidak terdeteksi setelah edit apps.json?</b></summary>

1. Edit `apps.json` dan simpan
2. Klik kanan tray → Quick Actions → **Reload All** (atau tekan `Ctrl+Alt+R`)
3. Aplikasi baru seharusnya langsung terdeteksi

Jika masih tidak berfungsi, periksa:
- Nama proses cocok persis (tidak case-sensitive)
- Sintaks JSON valid
- Aplikasi tidak dinonaktifkan di **Kelola Aplikasi**

</details>

<details>
<summary><b>Mouse Energy tidak update?</b></summary>

1. Pastikan "🖱️ Mouse Energy Detector" diaktifkan di menu tray
2. Fitur ini menganalisis aktivitas dari waktu ke waktu - tunggu beberapa detik
3. Beberapa aplikasi fullscreen mungkin mempengaruhi deteksi
4. Periksa `geetRPCS.log` untuk error MouseTracker

</details>

<details>
<summary><b>Tombol tidak muncul di Discord?</b></summary>

Periksa bahwa URL-mu:
- Dimulai dengan `http://` atau `https://`
- URL yang valid (bukan hanya nama domain)
- Label maksimal 32 karakter

**Contoh tombol yang valid:**
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
| Apps.json not found | Pastikan apps.json ada di folder yang sama |
| Discord not connected | Pastikan Discord Desktop berjalan |
| Presence not showing | Periksa mode Pause dan Kelola Aplikasi |
| Preview image empty | Bersihkan Cache → Refresh |
| Mouse hook failed | Jalankan sebagai Administrator |
| Buttons not appearing | Periksa format URL (harus dimulai dengan http/https) |
| Startup from temp rejected | Pindahkan aplikasi ke folder permanen |

</details>

---

## 🛡️ Keamanan

<p align="center">
  <a href="https://www.virustotal.com/gui/file/4e54e168c20bc02bc718bcda8155477bc92d195da18ce176d772777895f32bb0/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F71%20Bersih-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
  <a href="https://www.virustotal.com/gui/file/d2254ed3d046c9877ef764e4200521b01a6c5fc2b15fb9cf3065039d9787bc32/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F70%20Bersih-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>  
</p>

<details>
<summary><b>Detail Scan & Info False Positive</b></summary>

**Hasil Scan v1.2.7:**
- ✅ **0/72** deteksi malware (Bersih)
- ✅ Code Signed: Tidak (Self-contained)

**False Positive?** Beberapa antivirus mungkin menandainya karena:
- Executable baru / belum tersebar luas
- Akses Discord RPC API
- Akses registry (auto-startup)
- **Hook Hotkey Global** (RegisterHotKey API)
- **Hook Mouse** (SetWindowsHookEx API)
- **Manipulasi ikon** (GDI+ untuk animasi tray)

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
- [x] Detektor Mouse Energy
- [x] Smart Defaults (config opsional)
- [x] True Hot Reload
- [x] Validasi URL untuk tombol
- [x] Animasi Ikon Tray
- [x] Installer/updater satu perintah
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
  <sub>geetRPCS v1.2.7 • Lisensi MIT • 2025</sub>
</p>
