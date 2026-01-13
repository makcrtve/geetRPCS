<p align="center">
  <a href="README.en.md"><img src="https://img.shields.io/badge/Language-English-blue?style=flat-square" alt="English"/></a>
  <a href="README.id.md"><img src="https://img.shields.io/badge/Bahasa-Indonesia-red?style=flat-square" alt="Indonesia"/></a>
</p>

<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/geetrpcs-banner.png" width="600" alt="geetRPCS Banner"/>
</p>

<h1 align="center">geetRPCS</h1>

<p align="center">
  <b>Discord Rich Presence Otomatis untuk aplikasi favorit Anda!</b><br/>
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
  <img src="https://img.shields.io/github/v/release/makcrtve/geetRPCS?style=flat-square&label=Version&color=success" alt="Download"/>
  <img src="https://img.shields.io/github/downloads/makcrtve/geetRPCS/total?style=flat-square&label=Downloads&color=blue" alt="Downloads"/>
</p>

<p align="center">
  <a href="#-mulai-cepat">Mulai Cepat</a> •
  <a href="#-fitur">Fitur</a> •
  <a href="#-aplikasi-yang-didukung">Aplikasi Didukung</a> •
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

Installer interaktif akan memandu Anda:

```
  ╔═══════════════════════════════════════════╗
  ║       geetRPCS Installer / Updater        ║
  ╚═══════════════════════════════════════════╝

Pilih Versi:
  [1] Portable (Direkomendasikan) - Standalone, tanpa dependensi
  [2] Minimal - Ukuran lebih kecil, memerlukan .NET 8.0 Runtime

Masukkan pilihan [1-2]: _

Buat shortcut Desktop? [Y/n]: _
Buat shortcut Start Menu? [Y/n]: _
```

> 💡 **Update:** Jalankan perintah yang sama untuk update ke versi terbaru. Pengaturan Anda akan tetap tersimpan!

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

# Simpan data pengguna (settings, cache)
irm https://bit.ly/geetrpcs-del | iex; Uninstall-GeetRPCS -Silent -KeepUserData
```

#### Download Manual (Zip)
1. Download `.zip` terbaru dari **[Releases](https://github.com/makcrtve/geetRPCS/releases/latest)**
2. Ekstrak ke folder pilihan Anda
3. Jalankan `geetRPCS.exe`

</details>

---

## ✨ Fitur

<table>
<tr>
<td width="25%" valign="top">

**🎯 Inti**
- Deteksi Hibrida
- Single Instance
- RAM Ultra Rendah (5-20MB)
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

</td>
<td width="25%" valign="top">

**🔧 Utilitas**
- Pelacakan Aktivitas Mouse
- Hot Reload Sesungguhnya
- Akses Konfigurasi Cepat
- Auto Startup
- Event Logging
- Pemeriksa Update
- Manajemen Cache

</td>
<td width="25%" valign="top">

**🎨 Kustomisasi**
- Teks Lucu Dinamis 🆕
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

Ikon system tray kini hidup! Ketika geetRPCS mendeteksi perpindahan aplikasi, ikon melakukan efek **rotasi 360° dengan pulse brightness** yang smooth.

| Properti | Nilai |
|:---------|:------|
| **Efek** | Rotasi + Pulse brightness |
| **Durasi** | 800ms (12 frame) |
| **Easing** | Ease-In-Out Kuadratik |
| **Toggle** | Menu tray → "🎨 Tray Icon Animation" |

> 💡 Animasi halus ini memberikan konfirmasi visual bahwa geetRPCS mendeteksi perpindahan aplikasi Anda!

---

## 🖱️ Detektor Energi Mouse

<p align="center">
  <b>Tampilkan level produktivitas real-time Anda di Discord!</b>
</p>

geetRPCS dilengkapi **Mouse Energy Detector** - fitur unik yang menganalisis aktivitas mouse Anda dan menampilkan "level energi" saat ini di presence Discord.

| Level | Emoji | Kondisi |
|:------|:-----:|:----------|
| **Sleeping** | 💤 | Tidak ada aktivitas > 30 detik |
| **Relaxing** | ☕ | Aktivitas rendah (scrolling santai) |
| **Normal** | 🎯 | Aktivitas standar (kerja biasa) |
| **Focused** | 🔥 | Aktivitas tinggi (editing intensif) |
| **Rush** | ⚡ | Aktivitas sangat tinggi (mode deadline!) |

**Contoh tampilan Discord:**
```
Working on FL Studio 2025
Untitled - FL Studio | 🔥 Focused
```

> 💡 **Tips:** Toggle fitur ini on/off via Menu System Tray → "🖱️ Mouse Energy Detector"

---

## 🎭 Mesin Narasi Lucu

<p align="center">
  <b>Berikan kepribadian pada status Discord Anda!</b>
</p>

Alih-alih pesan "Working..." yang membosankan, geetRPCS kini menampilkan **teks lucu dinamis** yang berputar setiap 60 detik!

**Fitur:**
- 🎲 Pemilihan acak dari teks lucu yang dikurasi
- 🔄 Auto-rotasi setiap 60 detik
- 📝 Sepenuhnya dapat dikustomisasi via `witty.json`
- 🎯 Nol biaya performa
- 🔌 Placeholder baru `{witty_text}`

**Contoh Teks:**

| Aplikasi | Teks Lucu |
|:---------|:----------|
| **FL Studio** | "Produksi lagu hits berikutnya 🔥", "Dimana snare-nya? 🥁", "Soundgoodizer di Master 🎚️" |
| **VS Code** | "Compile kode spaghetti 🍝", "Di laptop saya jalan kok 🤷", "Debug 100 error 🐛" |
| **Chrome** | "100 tab terbuka 🔥", "Riset di YouTube 🎥", "Pasti lagi kerja... 👀" |

**Cara Menggunakan:**
1. Edit `witty.json` untuk menambahkan teks Anda sendiri
2. Gunakan `{witty_text}` di field `customDetails`
3. Reload dengan `Ctrl+Alt+R`

> 💡 **Tips:** 400+ teks pre-written tersedia untuk 40+ aplikasi!

---

## 🎯 Aplikasi yang Didukung

<details open>
<summary><b>42 Software • 65+ Nama Proses</b> (klik untuk toggle)</summary>

| Kategori | Aplikasi |
|:--------:|----------|
| 🎵 **DAW** | FL Studio, Ableton, Cubase, REAPER, Pro Tools, Studio One, Reason, Cakewalk |
| 🎬 **Video** | Premiere Pro, After Effects, DaVinci Resolve, Filmora, Vegas Pro, CapCut |
| 🎨 **Desain** | Photoshop, Illustrator, Lightroom, Figma, Canva, CorelDRAW, GIMP, Inkscape, Affinity |
| 🧊 **3D/CAD** | Blender, Maya, SketchUp, AutoCAD |
| 📡 **Streaming** | OBS Studio, Streamlabs |
| 🌐 **Browser** | Chrome, Brave, Firefox, Edge, Zen |
| 📦 **Lainnya** | Orange Data Mining, Adobe Audition, VLC, MS Office, Telegram, HandBrake |

</details>

> 💡 **Tips:** Anda dapat menambahkan aplikasi sendiri di `apps.json`!

---

## 🖥️ Penggunaan

### ⌨️ Hotkey Global (Shortcut)
Kontrol geetRPCS langsung dari keyboard Anda, bahkan ketika aplikasi diminimalkan:

| Shortcut | Fungsi |
|----------|--------|
| `Ctrl + Alt + P` | ⏸️ Jeda / Lanjutkan Presence |
| `Ctrl + Alt + V` | 👀 Toggle Jendela Preview |
| `Ctrl + Alt + H` | 🔒 Toggle Mode Privat |
| `Ctrl + Alt + R` | 🔄 Reload Config |
| `Ctrl + Alt + S` | 📊 Tampilkan Statistik Hari Ini |

### 🖱️ Menu System Tray
**Klik kanan** ikon tray untuk mengakses menu manual:

| Menu | Fungsi |
|------|--------|
| ⏸️ Pause | Toggle presence on/off |
| 🔒 Private Mode | Sensor judul window |
| 🖱️ Mouse Energy | Toggle detektor aktivitas |
| 🎨 Tray Animation | Toggle animasi ikon |
| 📡 Telemetry | Toggle data penggunaan anonim |
| 👀 Preview Window | Preview langsung presence Discord |
| 🛠️ Manage Apps | Aktifkan/nonaktifkan aplikasi |
| 📊 Statistics | Lihat & ekspor statistik |
| ⚡ Quick Actions | Akses folder, edit config |
| 🌐 Language | Ubah bahasa (EN/ID) |

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

### 🎯 Pengaturan Terpusat

geetRPCS bekerja **langsung pakai**! Aplikasi kini menggunakan `settings.json` terpusat dan cache internal untuk memastikan performa.

**config.json hanya diperlukan jika Anda ingin:**
- Menggunakan Discord Application ID sendiri
- Kustomisasi teks presence
- Menambahkan tombol kustom

> 💡 **Tips:** Buat config.json via Quick Actions → "Edit config.json" (akan auto-create dengan default)

<details>
<summary><b>📄 config.json</b> - Konfigurasi utama (Opsional)</summary>

```json
{
  "Discord": {
    "ApplicationId": "YOUR_DISCORD_APP_ID",
    "Details": "Sedang idle...",
    "State": "Siap bekerja",
    "ActiveDetails": "Bekerja dengan {app_name}",
    "ActiveState": "{window_title}",
    "Assets": {
      "LargeImageKey": "geetrpcs-logo",
      "LargeImageText": "geetRPCS v1.3.0",
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
    "customDetails": "Produksi dengan {app_name}",
    "buttons": [
      { "label": "Portfolio Saya", "url": "https://example.com" }
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
| `github.com` | ❌ Dilewati (tidak ada protokol) |
| `ftp://files.com` | ❌ Dilewati (protokol tidak valid) |
| URL kosong | ❌ Dilewati |

**Batas label tombol:** Maksimal 32 karakter

> Tombol tidak valid akan dilewati secara diam-diam - tidak ada error, hanya tidak muncul di Discord.

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
├── witty.json            # Teks lucu (wajib)
├── rpicon.ico            # Ikon (wajib)
├── config.json           # Konfigurasi Discord RPC (opsional)
├── settings.json         # Pengaturan pengguna (auto-managed)
├── statistics.json       # Data pelacakan (auto-managed)
├── geetRPCS.log          # File log (auto-generated)
├── .telemetry            # Penghitung peluncuran (auto-generated)
├── ImageCache/           # Cache gambar preview (auto-generated)
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
4. Pastikan Anda tidak dalam mode **Pause**

</details>

<details>
<summary><b>Cara update geetRPCS?</b></summary>

Cukup jalankan perintah install yang sama:

```powershell
irm https://bit.ly/geetrpcs | iex
```

Installer akan:
- ✅ Deteksi versi Anda saat ini
- ✅ Download hanya jika versi baru tersedia
- ✅ Backup pengaturan Anda (`apps.json`, `settings.json`, `statistics.json`)
- ✅ Install update
- ✅ Restore pengaturan Anda

</details>

<details>
<summary><b>Animasi tray tidak berfungsi?</b></summary>

1. Pastikan "🎨 Tray Icon Animation" diaktifkan di menu tray
2. Animasi hanya trigger saat **perpindahan aplikasi** (bukan perubahan judul window)
3. Cek `geetRPCS.log` untuk pesan TrayAnimator

</details>

<details>
<summary><b>Startup tidak berfungsi?</b></summary>

v1.2.7+ meningkatkan validasi startup:
1. Pastikan geetRPCS **tidak** berjalan dari folder temporary
2. Pindahkan aplikasi ke lokasi permanen (contoh: `C:\Programs\geetRPCS\`)
3. Aktifkan startup lagi via menu tray
4. Jika Anda memindahkan aplikasi, aktifkan ulang startup untuk update path registry

</details>

<details>
<summary><b>Aplikasi baru tidak terdeteksi setelah edit apps.json?</b></summary>

1. Edit `apps.json` dan simpan
2. Klik kanan tray → Quick Actions → **Reload All** (atau tekan `Ctrl+Alt+R`)
3. Aplikasi baru harus terdeteksi langsung

Jika masih tidak bekerja, cek:
- Nama proses cocok persis (case-insensitive)
- Sintaks JSON valid
- Aplikasi tidak dinonaktifkan di **Manage Apps**

</details>

<details>
<summary><b>Mouse Energy tidak update?</b></summary>

1. Pastikan "🖱️ Mouse Energy Detector" diaktifkan di menu tray
2. Fitur menganalisis aktivitas dari waktu ke waktu - tunggu beberapa detik
3. Beberapa aplikasi fullscreen mungkin mempengaruhi deteksi
4. Cek `geetRPCS.log` untuk error MouseTracker

</details>

<details>
<summary><b>Tombol tidak muncul di Discord?</b></summary>

Pastikan URL Anda:
- Dimulai dengan `http://` atau `https://`
- Adalah URL valid (bukan hanya nama domain)
- Label 32 karakter atau kurang

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
4. Preview Window → 🔄 Refresh (Auto-refresh diaktifkan di v1.2.8)

</details>

<details>
<summary><b>Troubleshooting</b></summary>

Buka `geetRPCS.log` atau klik kanan tray → **Open Log File**

| Error | Solusi |
|-------|--------|
| Apps.json not found | Pastikan apps.json ada di folder yang sama |
| Discord not connected | Pastikan Discord Desktop berjalan |
| Presence not showing | Cek mode Pause dan Manage Apps |
| Preview image empty | Clear Cache → Refresh |
| Mouse hook failed | Jalankan sebagai Administrator |
| Buttons not appearing | Cek format URL (harus dimulai dengan http/https) |
| Startup from temp rejected | Pindahkan aplikasi ke folder permanen |
| Already running | v1.2.8 mencegah instance duplikat. Cek tray. |

</details>

---

## 🛡️ Keamanan

<p align="center">
  <a href="https://www.virustotal.com/gui/file/641f510931e9280af5e4aca37796b120b4c24514af7d685772868a680492ceff/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F71%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
  <a href="https://www.virustotal.com/gui/file/3ec9263b32939cb1bd3c18fd5415f3450c3a86f5fa6c580034272f00113a5ed6/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F69%20Clean-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
</p>

<details>
<summary><b>Detail Scan & Info False Positive</b></summary>

**Hasil Scan v1.3.0:**
- ✅ `0/71` | `0/70` deteksi malware (Clean)
- ✅ Code Signed: Tidak (Self-contained)

**False Positive?** Beberapa AV mungkin menandainya karena:
- Executable baru / tidak banyak didistribusikan
- Akses Discord RPC API
- Akses registry (auto-startup)
- **Hook hotkey global** (RegisterHotKey API)
- **Hook mouse** (SetWindowsHookEx API)
- **Manipulasi ikon** (GDI+ untuk animasi tray)

**Solusi:** Whitelist di antivirus atau verifikasi di [VirusTotal](https://www.virustotal.com)

</details>

---

## 🔮 Roadmap

- [x] Pemeriksa auto-update
- [x] Pelacak statistik
- [x] Multi-bahasa (EN/ID)
- [x] Jendela Preview
- [x] Manajer Aplikasi
- [x] Dukungan Hotkey Global
- [x] Detektor Energi Mouse
- [x] Default Cerdas (config opsional)
- [x] Hot Reload Sesungguhnya
- [x] Validasi URL untuk tombol
- [x] Animasi Ikon Tray
- [x] Installer/updater satu perintah
- [x] Penegakan Single Instance
- [x] Optimasi Memori
- [ ] Dukungan lebih banyak software
- [ ] UI Dashboard (WPF/WinUI)

---

## 📞 Link

<p align="center">
  <a href="https://github.com/makcrtve/geetRPCS/issues">🐛 Laporkan Bug</a> •
  <a href="https://github.com/makcrtve/geetRPCS/discussions">💬 Diskusi</a> •
  <a href="https://github.com/makcrtve/geetRPCS/releases">📦 Releases</a> •
  <a href="https://discord.gg/ScTybDUEpH">🎮 Join Discord</a>
</p>

---

<p align="center">
  <sub>Dibuat dengan ❤️ oleh <a href="https://github.com/makcrtve">makcrtve</a></sub><br/>
  <sub>geetRPCS v1.3.0 • Lisensi MIT • 2026</sub>
</p>
