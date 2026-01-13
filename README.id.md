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
  <a href="#-mulai-cepat">Mulai Cepat</a> •
  <a href="#-fitur">Fitur</a> •
  <a href="#-aplikasi-didukung">Aplikasi Didukung</a> •
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

Installer interaktif akan memandu kamu:

```
  ╔═══════════════════════════════════════════╗
  ║       geetRPCS Installer / Updater        ║
  ╚═══════════════════════════════════════════╝

Pilih Versi:
  [1] Portable (Direkomendasikan) - Mandiri, tanpa dependensi
  [2] Minimal - Ukuran lebih kecil, memerlukan .NET 8.0 Runtime

Masukkan pilihan [1-2]: _

Buat shortcut Desktop? [Y/n]: _
Buat shortcut Start Menu? [Y/n]: _
```

> 💡 **Update:** Jalankan perintah yang sama untuk update ke versi terbaru. Pengaturanmu akan tetap aman!

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
# Uninstall bersih (hapus semua)
irm https://bit.ly/geetrpcs-del | iex; Uninstall-GeetRPCS -Silent

# Simpan data pengguna (pengaturan, cache)
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
- 🔍 **Deteksi Hybrid** - Berbasis event + polling
- 🛡️ **Single Instance** - Cegah proses duplikat
- 📉 **RAM Ultra Rendah** - Hanya gunakan 5-15MB RAM
- 🎨 **Animasi Tray** - Feedback visual saat ganti aplikasi
- 🛡️ **Ketahanan JSON** - Dukungan komentar di JSON (BARU!)
- 👀 **Preview Pintar** - Preview presence auto-refresh
- 🛠️ **Kelola Aplikasi** - Blacklist aplikasi tertentu

</td>
<td width="50%">

### ⚙️ Kontrol
- ⏸️ **Mode Pause** - Sembunyikan presence sementara
- 🔒 **Mode Private** - Sensor judul window
- 📊 **Statistik** - Pelacakan + Ekspor CSV/JSON
- 🌐 **Multi-Bahasa** - EN / ID

</td>
</tr>
<tr>
<td width="50%">

### 🔧 Utilitas
- 🖱️ **Mouse Energy** - Level aktivitas real-time
- 🔄 **True Hot Reload** - Edit & terapkan instan
- ⚡ **Quick Actions** - Akses cepat ke config
- 🚀 **Auto Startup** - Jalan saat Windows mulai

</td>
<td width="50%">

### 🎨 Kustomisasi
- 🎭 **Teks Jenaka** - Status lucu dinamis (BARU!)
- 🖼️ **Aset Custom** - Pakai gambar sendiri
- 📝 **Teks Custom** - Teks & placeholder custom
- 🔘 **Tombol Custom** - Link ke portfolio
- 🔗 **Validasi URL** - Filter tombol pintar

</td>
</tr>
</table>

---

## 🎨 Animasi Ikon Tray

Ikon system tray kini hidup! Ketika geetRPCS mendeteksi perpindahan aplikasi, ikon melakukan efek **rotasi 360° dengan pulsa brightness** yang mulus.

| Properti | Nilai |
|:---------|:------|
| **Efek** | Rotasi + Pulsa brightness |
| **Durasi** | 800ms (12 frame) |
| **Easing** | Ease-In-Out Quadratic |
| **Toggle** | Menu tray → "🎨 Animasi Ikon Tray" |

> 💡 Animasi halus ini memberikan konfirmasi visual bahwa geetRPCS mendeteksi perpindahan aplikasimu!

---

## 🖱️ Detektor Mouse Energy

<p align="center">
  <b>Tunjukkan level produktivitasmu secara real-time di Discord!</b>
</p>

geetRPCS memiliki **Detektor Mouse Energy** - fitur unik yang menganalisis aktivitas mouse-mu dan menampilkan "level energi" saat ini di Discord presence.

| Level | Emoji | Kondisi |
|:------|:-----:|:----------|
| **Sleeping** | 💤 | Tidak ada aktivitas > 30 detik |
| **Relaxing** | ☕ | Aktivitas rendah (scrolling santai) |
| **Normal** | 🎯 | Aktivitas standar (kerja biasa) |
| **Focused** | 🔥 | Aktivitas tinggi (editing intensif) |
| **Rush** | ⚡ | Aktivitas sangat tinggi (mode deadline!) |

**Contoh tampilan Discord:**
```
Bekerja di FL Studio 2025
Untitled - FL Studio | 🔥 Focused
```

> 💡 **Tip:** Toggle fitur ini on/off via Menu System Tray → "🖱️ Detektor Mouse Energy"

---

## 🎭 Mesin Narasi Jenaka

<p align="center">
  <b>Bawa kepribadian ke status Discord-mu!</b>
</p>

Alih-alih pesan "Working..." yang membosankan, geetRPCS kini menampilkan **teks dinamis dan lucu** yang berganti setiap 60 detik!

**Fitur:**
- 🎲 Pemilihan acak dari teks lucu yang telah dikurasi
- 🔄 Auto-rotasi setiap 60 detik
- 📝 Sepenuhnya dapat dikustomisasi via `witty.json`
- 🎯 Nol dampak performa
- 🔌 Placeholder `{witty_text}` baru

**Contoh Teks:**

| Aplikasi | Teks Jenaka |
|:---------|:------------|
| **FL Studio** | "Bikin lagu yang bakal hits 🔥", "Mana snare-nya? 🥁", "Soundgoodizer di Master 🎚️" |
| **VS Code** | "Compile kode spaghetti 🍝", "Di komputer saya jalan kok 🤷", "Debug 100 error 🐛" |
| **Chrome** | "100 tab terbuka 🔥", "Riset di YouTube 🎥", "Pasti lagi kerja... 👀" |

**Cara Pakai:**
1. Edit `witty.json` untuk menambah teks sendiri
2. Gunakan `{witty_text}` di field `customDetails`
3. Reload dengan `Ctrl+Alt+R`

> 💡 **Tip:** 400+ teks bawaan tersedia untuk 40+ aplikasi!

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

> 💡 **Tip:** Kamu bisa menambah aplikasi sendiri di `apps.json`!

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
| ⏸️ Pause | Toggle presence hidup/mati |
| 🔒 Mode Private | Sensor judul window |
| 🖱️ Mouse Energy | Toggle detektor aktivitas |
| 🎨 Animasi Tray | Toggle animasi ikon |
| 📡 Telemetry | Toggle data penggunaan anonim |
| 👀 Jendela Preview | Preview langsung Discord presence |
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

### 🎯 Pengaturan Terpadu

geetRPCS bekerja **langsung pakai**! Aplikasi sekarang menggunakan `settings.json` terpusat dan cache internal untuk memastikan performa.

**config.json hanya diperlukan jika kamu ingin:**
- Menggunakan Discord Application ID sendiri
- Kustomisasi teks presence
- Menambah tombol custom

> 💡 **Tip:** Buat config.json via Quick Actions → "Edit config.json" (akan auto-dibuat dengan default)

<details>
<summary><b>📄 config.json</b> - Konfigurasi utama (Opsional)</summary>

```json
{
  "Discord": {
    "ApplicationId": "YOUR_DISCORD_APP_ID",
    "Details": "Menganggur...",
    "State": "Siap bekerja",
    "ActiveDetails": "Bekerja di {app_name}",
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
    "customDetails": "Produksi di {app_name}",
    "buttons": [
      { "label": "Portfolio Saya", "url": "https://example.com" }
    ]
  }
]
```

**Menambah aplikasi:** Task Manager → catat nama proses → tambah ke apps.json → Reload All (`Ctrl+Alt+R`)

</details>

<details>
<summary><b>🔗 Persyaratan URL Tombol</b></summary>

geetRPCS validasi URL tombol secara otomatis:

| Format URL | Status |
|:-----------|:------:|
| `https://github.com` | ✅ Valid |
| `http://example.com` | ✅ Valid |
| `github.com` | ❌ Dilewati (tanpa protokol) |
| `ftp://files.com` | ❌ Dilewati (protokol invalid) |
| URL kosong | ❌ Dilewati |

**Batas label tombol:** Maksimal 32 karakter

> Tombol invalid dilewati secara diam-diam - tanpa error, mereka hanya tidak akan muncul di Discord.

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
├── settings.json         # Pengaturan pengguna (auto-kelola)
├── statistics.json       # Data pelacakan (auto-kelola)
├── geetRPCS.log          # File log (auto-dibuat)
├── .telemetry            # Penghitung peluncuran (auto-dibuat)
├── ImageCache/           # Cache gambar preview (auto-dibuat)
└── Languages/            # File bahasa (auto-dibuat)
```

</details>

---

## ❓ FAQ

<details>
<summary><b>Presence tidak muncul di Discord?</b></summary>

1. Pastikan kamu menggunakan Discord **Desktop** (bukan web)
2. Settings → Activity Privacy → Aktifkan "Display current activity"
3. Restart geetRPCS dan Discord
4. Pastikan kamu tidak dalam mode **Pause**

</details>

<details>
<summary><b>Cara update geetRPCS?</b></summary>

Cukup jalankan perintah instalasi yang sama:

```powershell
irm https://bit.ly/geetrpcs | iex
```

Installer akan:
- ✅ Deteksi versi saat ini
- ✅ Download hanya jika ada versi baru
- ✅ Backup pengaturanmu (`apps.json`, `settings.json`, `statistics.json`)
- ✅ Install update
- ✅ Restore pengaturanmu

</details>

<details>
<summary><b>Animasi tray tidak bekerja?</b></summary>

1. Pastikan "🎨 Animasi Ikon Tray" diaktifkan di menu tray
2. Animasi hanya dipicu saat **ganti aplikasi** (bukan perubahan judul window)
3. Cek `geetRPCS.log` untuk pesan TrayAnimator

</details>

<details>
<summary><b>Startup tidak bekerja?</b></summary>

v1.2.7+ meningkatkan validasi startup:
1. Pastikan geetRPCS **tidak** berjalan dari folder temporary
2. Pindahkan aplikasi ke lokasi permanen (mis., `C:\Programs\geetRPCS\`)
3. Aktifkan startup lagi via menu tray
4. Jika kamu memindahkan aplikasi, aktifkan ulang startup untuk update path registry

</details>

<details>
<summary><b>Aplikasi baru tidak terdeteksi setelah edit apps.json?</b></summary>

1. Edit `apps.json` dan simpan
2. Klik kanan tray → Quick Actions → **Reload All** (atau tekan `Ctrl+Alt+R`)
3. Aplikasi baru seharusnya langsung terdeteksi

Jika masih tidak bekerja, periksa:
- Nama proses cocok persis (case-insensitive)
- Sintaks JSON valid
- Aplikasi tidak dinonaktifkan di **Kelola Aplikasi**

</details>

<details>
<summary><b>Mouse Energy tidak update?</b></summary>

1. Pastikan "🖱️ Detektor Mouse Energy" diaktifkan di menu tray
2. Fitur menganalisis aktivitas dari waktu ke waktu - tunggu beberapa detik
3. Beberapa aplikasi fullscreen mungkin mempengaruhi deteksi
4. Cek `geetRPCS.log` untuk error MouseTracker

</details>

<details>
<summary><b>Tombol tidak muncul di Discord?</b></summary>

Periksa bahwa URL-mu:
- Dimulai dengan `http://` atau `https://`
- URL yang valid (bukan hanya nama domain)
- Label 32 karakter atau kurang

**Contoh tombol yang valid:**
```json
{ "label": "Website Saya", "url": "https://example.com" }
```

</details>

<details>
<summary><b>Hotkey tidak bekerja?</b></summary>

Pastikan tidak ada aplikasi lain yang menggunakan shortcut yang sama. Beberapa game fullscreen yang jalan "As Administrator" mungkin memblokir hotkey jika geetRPCS tidak juga dijalankan sebagai Admin.

</details>

<details>
<summary><b>Gambar tidak muncul?</b></summary>

1. Upload gambar di Discord Developer Portal
2. Tunggu beberapa menit (sinkronisasi Discord)
3. Nama key harus cocok **persis** (case sensitive)
4. Jendela Preview → 🔄 Refresh (Auto-refresh diaktifkan di v1.2.8)

</details>

<details>
<summary><b>Troubleshooting</b></summary>

Buka `geetRPCS.log` atau klik kanan tray → **Buka File Log**

| Error | Solusi |
|-------|--------|
| Apps.json tidak ditemukan | Pastikan apps.json ada di folder yang sama |
| Discord tidak terkoneksi | Pastikan Discord Desktop berjalan |
| Presence tidak muncul | Cek mode Pause dan Kelola Aplikasi |
| Gambar preview kosong | Clear Cache → Refresh |
| Mouse hook gagal | Jalankan sebagai Administrator |
| Tombol tidak muncul | Cek format URL (harus dimulai http/https) |
| Startup dari temp ditolak | Pindah aplikasi ke folder permanen |
| Sudah berjalan | v1.2.8 cegah instance duplikat. Cek tray. |

</details>

---

## 🛡️ Keamanan

<p align="center">
  <a href="https://www.virustotal.com/gui/file/641f510931e9280af5e4aca37796b120b4c24514af7d685772868a680492ceff/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F71%20Bersih-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
  <a href="https://www.virustotal.com/gui/file/3ec9263b32939cb1bd3c18fd5415f3450c3a86f5fa6c580034272f00113a5ed6/detection">
    <img src="https://img.shields.io/badge/VirusTotal-0%2F69%20Bersih-brightgreen?style=for-the-badge&logo=virustotal" alt="VirusTotal"/>
  </a>
</p>

<details>
<summary><b>Detail Scan & Info False Positive</b></summary>

**Hasil Scan v1.3.0:**
- ✅ `0/71` | `0/70` deteksi malware (Bersih)
- ✅ Code Signed: Tidak (Self-contained)

**False Positive?** Beberapa antivirus mungkin menandainya karena:
- Executable baru / tidak banyak didistribusikan
- Akses Discord RPC API
- Akses registry (auto-startup)
- **Global Hotkey hooks** (RegisterHotKey API)
- **Mouse hooks** (SetWindowsHookEx API)
- **Manipulasi ikon** (GDI+ untuk animasi tray)

**Solusi:** Whitelist di antivirus atau verifikasi di [VirusTotal](https://www.virustotal.com)

</details>

---

## 🔮 Roadmap

- [x] Pemeriksa auto-update
- [x] Pelacak statistik
- [x] Multi-bahasa (EN/ID)
- [x] Jendela Preview
- [x] Kelola Aplikasi
- [x] Dukungan Global Hotkeys
- [x] Detektor Mouse Energy
- [x] Smart Defaults (config opsional)
- [x] True Hot Reload
- [x] Validasi URL untuk tombol
- [x] Animasi Ikon Tray
- [x] One-command installer/updater
- [x] Single Instance Enforcement
- [x] Optimasi Memori
- [ ] Dukungan lebih banyak software
- [ ] UI Dashboard (WPF/WinUI)

---

## 📞 Tautan

<p align="center">
  <a href="https://github.com/makcrtve/geetRPCS/issues">🐛 Laporkan Bug</a> •
  <a href="https://github.com/makcrtve/geetRPCS/discussions">💬 Diskusi</a> •
  <a href="https://github.com/makcrtve/geetRPCS/releases">📦 Rilis</a> •
  <a href="https://discord.gg/ScTybDUEpH">🎮 Gabung Discord</a>
</p>

---

<p align="center">
  <sub>Dibuat dengan ❤️ oleh <a href="https://github.com/makcrtve">makcrtve</a></sub><br/>
  <sub>geetRPCS v1.3.0 • MIT License • 2026</sub>
</p>
