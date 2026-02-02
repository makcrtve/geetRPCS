# geetRPCS Architecture Overview

Dokumen ini menjelaskan struktur arsitektur tingkat tinggi dari **geetRPCS** (Discord Rich Presence Custom Switcher). Tujuan dari dokumen ini adalah untuk membantu pengembang memahami bagaimana aplikasi bekerja, bagaimana data mengalir, dan bagaimana komponen-komponen utamanya saling berinteraksi.

## High-Level Architecture

geetRPCS beroperasi sebagai aplikasi **System Tray** yang berjalan di background. Inti dari aplikasi ini adalah loop utama di `Program.cs` yang mengorkestrasi deteksi aplikasi, manajemen state, dan komunikasi ke Discord RPC.

```mermaid
graph TD
    User((User))

    subgraph Core [Core Application]
        Program[Program.cs<br/>(Main Loop / Controller)]
        Stats[AppStatistics<br/>(Usage Tracking)]
    end

    subgraph Inputs [Input & Detection]
        Watcher[TaskbarWatcher<br/>(Window Detection)]
        Input[GlobalHotkey / MouseTracker<br/>(User Input)]
    end

    subgraph Data [Data & Configuration]
        ConfigMan[AppConfigManager<br/>(apps.json)]
        Narrative[NarrativeService<br/>(witty.json)]
        Settings[SettingsService<br/>(Registry/Config)]
    end

    subgraph Output [Outputs]
        RPC[DiscordRpcClient<br/>(Discord IPC)]
        Tray[TrayIcon / Animator<br/>(UI Feedback)]
        Telemetry[TelemetryService<br/>(Analytics)]
    end

    %% Flows
    User --> |Interacts/Configures| Tray
    User --> |Active Window| Watcher
    User --> |Hotkeys| Input

    Watcher --> |Report Process| Program
    Input --> |Pause/Resume/Energy| Program

    Program --> |Query Config| ConfigMan
    Program --> |Get Texts| Narrative
    Program --> |Load/Save| Settings
    Program --> |Track Usage| Stats

    Program --> |Update Presence| RPC
    Program --> |Animate Icon| Tray
    Program --> |Send Reports| Telemetry
```

## Komponen Utama

### 1. Core Controller (`Program.cs`)

File ini adalah "otak" dari aplikasi. Berbeda dengan aplikasi .NET modern yang mungkin menggunakan Dependency Injection container yang kompleks, geetRPCS didesain _straightforward_ dengan `Program.cs` sebagai pusat kendali.

- **Tanggung Jawab:**
  - Menginisialisasi semua service (`DiscordRPC`, `TaskbarWatcher`, dll).
  - Menangani _Single Instance Mutex_.
  - Mengelola _State_ global (`currentApp`, `isPaused`, `privateMode`).
  - Menangani event dari Tray Icon dan Hotkeys.
  - Melakukan update ke Discord RPC berdasarkan input dari `TaskbarWatcher`.

### 2. Services

Service-service ini menangani logika spesifik untuk menjaga `Program.cs` tetap bersih (meskipun saat ini `Program.cs` masih melakukan orkestrasi berat).

| Service                    | Deskripsi                                                                                                                                   |
| :------------------------- | :------------------------------------------------------------------------------------------------------------------------------------------ |
| **`TaskbarWatcher`**       | Memantau perubahan window aktif dan event taskbar menggunakan UI Automation / WinAPI hooks. Memberitahu `Program.cs` saat aplikasi berubah. |
| **`AppConfigManager`**     | Memuat dan me-manage database aplikasi yang didukung dari `apps.json`.                                                                      |
| **`NarrativeService`**     | ("Witty Service") Menangani rotasi teks status lucu/unik dari `witty.json` agar status tidak monoton.                                       |
| **`TelemetryService`**     | Mengirimkan data penggunaan anonim (aplikasi yang dideteksi, durasi) untuk analisa pengembangan.                                            |
| **`UpdateChecker`**        | Memeriksa update aplikasi dan update database (`apps.json`/`witty.json`) dari GitHub.                                                       |
| **`MouseActivityTracker`** | (Experimental) Menghitung "energi" gerakan mouse untuk fitur status dinamis.                                                                |

### 3. Data Persistence

- **`config.json`**: Konfigurasi dasar RPC (Client ID default) dan teks default saat idle.
- **`apps.json`**: Database besar mapping Process Name -> Discord App ID & Assets. File ini sering diupdate.
- **`witty.json`**: Kumpulan kalimat acak untuk status Discord.
- **`Registry / UserSettings`**: Disimpan via `SettingsService` untuk preferensi user (seperti `AutoStart`, `TrayAnimation`).
- **`AppStatistics`**: Menyimpan data penggunaan lokal (berapa lama user menggunakan app X) untuk fitur "Today's Stats".

### 4. User Interface (UI)

Karena berbasis System Tray, UI-nya minimalis:

- **`ContextMenu`**: Menu klik kanan pada tray icon (Pause, Manage Apps, dll).
- **`PresencePreviewForm`**: Form untuk melihat preview realtime tampilan Rich Presence.
- **`ManageAppsForm`**: Interface untuk mendisable deteksi aplikasi tertentu.

## Alur Data (Data Flow)

1. **Deteksi**: `TaskbarWatcher` mendeteksi user berpindah window ke "Visual Studio Code".
2. **Lookup**: `Program.cs` menerima nama process (`Code.exe`), lalu bertanya ke `AppConfigManager`: "Apakah `Code.exe` ada di database?"
3. **Penyusunan**:
   - Jika ada, ambil App ID kustom (jika ada) dan aset gambar.
   - Ambil teks status dari `NarrativeService` (jika mode Witty aktif).
   - Format string (ganti `{filename}`, `{project}`) menggunakan helper di `Placeholders`.
4. **Eksekusi**:
   - Jika App ID berubah, `DiscordRpcClient` di-restart dengan ID baru.
   - Panggil `rpc.SetPresence()` dengan data yang sudah disusun.
   - Trigger animasi tray via `TrayIconAnimator`.

## Struktur Folder Source

```text
geetRPCS/
├── Program.cs           # Main Entry Point
├── Models/              # Data Structures (json mapping objects)
├── Services/            # Logic Providers (Network, File I/O, System Hooks)
├── UI/                  # Windows Forms (Preview, Settings)
├── Utils/               # Helpers (GlobalHotkeys, MemoryHelper)
├── Languages/           # Localization Files (.json)
└── assets/              # Icons and Images
```
