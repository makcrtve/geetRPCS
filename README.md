<p align="center">
  <img src="https://raw.githubusercontent.com/makcrtve/geetRPCS/main/assets/geetrpcs-logo-512.png" width="128" alt="geetRPCS logo" />
</p>

<h1 align="center">geetRPCS</h1>
<p align="center">
  <i>Tiny tray-app that pushes your coding vibe straight to Discord 🎧</i><br/>
  <sub>Windows • .NET 8 • No console window • Live reload • Open-source</sub>
</p>

<p align="center">
  <a href="https://github.com/makcrtve/geetRPCS/releases/latest">
    <img alt="GitHub release (latest by date)" src="https://img.shields.io/github/v/release/makcrtve/geetRPCS?style=flat-square">
  </a>
  <a href="https://github.com/makcrtve/geetRPCS/actions">
    <img alt="GitHub Workflow Status" src="https://img.shields.io/github/actions/workflow/status/makcrtve/geetRPCS/build.yml?style=flat-square">
  </a>
  <img alt="License" src="https://img.shields.io/github/license/makcrtve/geetRPCS?style=flat-square">
</p>

---

## ✨ Fitur utama
- 🚀 Mulai bersama Windows (opsional) – tidak muncul di taskbar, cukup di tray
- 📝 Rich presence lengkap: details, state, 2 tombol, large & small image
- 🔄 Reload config tanpa restart; edit `config.json` → klik “Reload Config” di tray
- 🎯 Single executable (self-contained publish support)
- 🪶 C# murni + Windows Forms, tidak perlu runtime tambahan

## 🪟 Cara pakai
1. Download `geetRPCS.zip` dari [rilis terbaru](https://github.com/makcrtve/geetRPCS/releases/latest)
2. Ekstrak ke folder mana pun
3. Edit `config.json` (lihat bagian [Konfigurasi](#konfigurasi))
4. Jalankan `geetRPCS.exe` – ikon tray akan muncul
5. Buka Discord → lihat statusmu berubah!

## ⚙️ Konfigurasi
File `config.json` wajib ada di folder yang sama dengan exe. Contoh minimal:

```json
{
  "Discord": {
    "ApplicationId": "1433700335863726183",
    "Details": "Coding pakai geetRPCS",
    "State": "Visual Studio Code",
    "Assets": {
      "LargeImageKey": "geetrpcs-logo",
      "LargeImageText": "geetRPCS v1.0.0",
      "SmallImageKey": "verified",
      "SmallImageText": "Coding Time!"
    },
    "Buttons": [
      {
        "Label": "YouTube",
        "Url": "https://youtu.be/dQw4w9WgXcQ"
      }
    ]
  }
}
```

| Kunci | Keterangan |
|-------|------------|
| `ApplicationId` | ID aplikasi Discord mu (buat di [discord.com/developers/applications](https://discord.com/developers/applications)) |
| `Details` | Baris pertama presence |
| `State` | Baris kedua presence |
| `Assets` | Gambar large/small beserta tooltip-nya |
| `Buttons` | Maks. 2 tombol (opsional) |

Setelah mengubah file, klik kanan ikon tray → **Reload Config**.

## 🛠️ Build dari source
```bash
git clone https://github.com/makcrtve/geetRPCS.git
cd geetRPCS
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```
Executable siap pakai ada di `bin/Release/net8.0-windows/win-x64/publish/`

## 🧩 Dependensi
- .NET 8 (target `net8.0-windows`)
- [DiscordRichPresence](https://www.nuget.org/packages/DiscordRichPresence) 1.6.1.70
- System.Text.Json 8.0.5

## 📄 Lisensi
[MIT](LICENSE) – bebas dipakai, diperjualbelikan, ataupun di-embed ke project lain.

## 🙋‍♂️ Kontribusi
Pull-request & issue sangat welcome!  
Baca [CONTRIBUTING.md](CONTRIBUTING.md) sebelum memulai.

---

<div align="center">
  <b>Made with ☕ by makcrtve</b>
</div>
