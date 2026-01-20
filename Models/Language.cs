/**
 * geetRPCS - Localization
 * Language localization models for geetRPCS
 */
/*
 * Copyright (c) 2026 makcrtve
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 */

using System.Text.Json.Serialization;
namespace geetRPCS.Models
{
    internal class Language
    {
        [JsonPropertyName("menu_pause")]
        public string MenuPause { get; set; }
        [JsonPropertyName("menu_resume")]
        public string MenuResume { get; set; }
        [JsonPropertyName("menu_private_mode")]
        public string MenuPrivateMode { get; set; }
        [JsonPropertyName("menu_reload_config")]
        public string MenuReloadConfig { get; set; }
        [JsonPropertyName("menu_reset_timers")]
        public string MenuResetTimers { get; set; }
        [JsonPropertyName("menu_startup")]
        public string MenuStartup { get; set; }
        [JsonPropertyName("menu_quick_actions")]
        public string MenuQuickActions { get; set; }
        [JsonPropertyName("menu_open_folder")]
        public string MenuOpenFolder { get; set; }
        [JsonPropertyName("menu_edit_config")]
        public string MenuEditConfig { get; set; }
        [JsonPropertyName("menu_edit_apps")]
        public string MenuEditApps { get; set; }
        [JsonPropertyName("menu_reload_all")]
        public string MenuReloadAll { get; set; }
        [JsonPropertyName("menu_clear_timers")]
        public string MenuClearTimers { get; set; }
        [JsonPropertyName("menu_statistics")]
        public string MenuStatistics { get; set; }
        [JsonPropertyName("menu_today")]
        public string MenuToday { get; set; }
        [JsonPropertyName("menu_this_week")]
        public string MenuThisWeek { get; set; }
        [JsonPropertyName("menu_this_month")]
        public string MenuThisMonth { get; set; }
        [JsonPropertyName("menu_all_time")]
        public string MenuAllTime { get; set; }
        [JsonPropertyName("menu_export_csv")]
        public string MenuExportCSV { get; set; }
        [JsonPropertyName("menu_export_json")]
        public string MenuExportJSON { get; set; }
        [JsonPropertyName("menu_reset_stats")]
        public string MenuResetStats { get; set; }
        [JsonPropertyName("menu_language")]
        public string MenuLanguage { get; set; }
        [JsonPropertyName("menu_check_updates")]
        public string MenuCheckUpdates { get; set; }
        [JsonPropertyName("menu_open_log")]
        public string MenuOpenLog { get; set; }
        [JsonPropertyName("menu_exit")]
        public string MenuExit { get; set; }
        [JsonPropertyName("menu_manage_apps")]
        public string MenuManageApps { get; set; }
        [JsonPropertyName("menu_preview_window")]
        public string MenuPreviewWindow { get; set; }
        [JsonPropertyName("filter_enabled")]
        public string FilterEnabled { get; set; }
        [JsonPropertyName("filter_disabled")]
        public string FilterDisabled { get; set; }
        [JsonPropertyName("manage_apps_title")]
        public string ManageAppsTitle { get; set; }
        [JsonPropertyName("manage_apps_search")]
        public string ManageAppsSearch { get; set; }
        [JsonPropertyName("manage_apps_found")]
        public string ManageAppsFound { get; set; }
        [JsonPropertyName("label_details")]
        public string LabelDetails { get; set; }
        [JsonPropertyName("label_state")]
        public string LabelState { get; set; }
        [JsonPropertyName("msg_presence_paused")]
        public string MsgPresencePaused { get; set; }
        [JsonPropertyName("msg_presence_resumed")]
        public string MsgPresenceResumed { get; set; }
        [JsonPropertyName("msg_private_mode_on")]
        public string MsgPrivateModeOn { get; set; }
        [JsonPropertyName("msg_private_mode_off")]
        public string MsgPrivateModeOff { get; set; }
        [JsonPropertyName("msg_config_reloaded")]
        public string MsgConfigReloaded { get; set; }
        [JsonPropertyName("msg_stats_reset")]
        public string MsgStatsReset { get; set; }
        [JsonPropertyName("msg_timers_reset")]
        public string MsgTimersReset { get; set; }
        [JsonPropertyName("msg_reload_tip")]
        public string MsgReloadTip { get; set; }
        [JsonPropertyName("msg_language_changed")]
        public string MsgLanguageChanged { get; set; }
        [JsonPropertyName("dialog_reload_title")]
        public string DialogReloadTitle { get; set; }
        [JsonPropertyName("dialog_reload_message")]
        public string DialogReloadMessage { get; set; }
        [JsonPropertyName("dialog_reset_timers_title")]
        public string DialogResetTimersTitle { get; set; }
        [JsonPropertyName("dialog_reset_timers_message")]
        public string DialogResetTimersMessage { get; set; }
        [JsonPropertyName("dialog_reset_stats_title")]
        public string DialogResetStatsTitle { get; set; }
        [JsonPropertyName("dialog_reset_stats_message")]
        public string DialogResetStatsMessage { get; set; }
        [JsonPropertyName("dialog_file_not_found")]
        public string DialogFileNotFound { get; set; }
        [JsonPropertyName("dialog_open_with_notepad")]
        public string DialogOpenWithNotepad { get; set; }
        [JsonPropertyName("dialog_log_not_created")]
        public string DialogLogNotCreated { get; set; }
        [JsonPropertyName("btn_save")]
        public string BtnSave { get; set; }
        [JsonPropertyName("menu_change_app_id")]
        public string MenuChangeAppId { get; set; }
        [JsonPropertyName("dialog_change_app_id_title")]
        public string DialogChangeAppIdTitle { get; set; }
        [JsonPropertyName("dialog_change_app_id_message")]
        public string DialogChangeAppIdMessage { get; set; }
        [JsonPropertyName("msg_app_id_changed")]
        public string MsgAppIdChanged { get; set; }
        [JsonPropertyName("link_tutorial")]
        public string LinkTutorial { get; set; }
        [JsonPropertyName("url_tutorial")]
        public string UrlTutorial { get; set; }
        [JsonPropertyName("link_download_assets")]
        public string LinkDownloadAssets { get; set; }
        [JsonPropertyName("error_save_config")]
        public string ErrorSaveConfig { get; set; }
        [JsonPropertyName("stats_no_data_today")]
        public string StatsNoDataToday { get; set; }
        [JsonPropertyName("stats_no_data_week")]
        public string StatsNoDataWeek { get; set; }
        [JsonPropertyName("stats_no_data_month")]
        public string StatsNoDataMonth { get; set; }
        [JsonPropertyName("stats_no_data")]
        public string StatsNoData { get; set; }
        [JsonPropertyName("stats_today_title")]
        public string StatsTodayTitle { get; set; }
        [JsonPropertyName("stats_week_title")]
        public string StatsWeekTitle { get; set; }
        [JsonPropertyName("stats_month_title")]
        public string StatsMonthTitle { get; set; }
        [JsonPropertyName("stats_all_time_title")]
        public string StatsAllTimeTitle { get; set; }
        [JsonPropertyName("stats_week_of")]
        public string StatsWeekOf { get; set; }
        [JsonPropertyName("stats_tracking_since")]
        public string StatsTrackingSince { get; set; }
        [JsonPropertyName("stats_total")]
        public string StatsTotal { get; set; }
        [JsonPropertyName("stats_total_tracked")]
        public string StatsTotalTracked { get; set; }
        [JsonPropertyName("stats_total_apps")]
        public string StatsTotalApps { get; set; }
        [JsonPropertyName("stats_export_success")]
        public string StatsExportSuccess { get; set; }
        [JsonPropertyName("stats_export_failed")]
        public string StatsExportFailed { get; set; }
        [JsonPropertyName("stats_open_folder")]
        public string StatsOpenFolder { get; set; }
        [JsonPropertyName("update_checking")]
        public string UpdateChecking { get; set; }
        [JsonPropertyName("update_available_title")]
        public string UpdateAvailableTitle { get; set; }
        [JsonPropertyName("update_available_message")]
        public string UpdateAvailableMessage { get; set; }
        [JsonPropertyName("update_latest_version")]
        public string UpdateLatestVersion { get; set; }
        [JsonPropertyName("update_current_version")]
        public string UpdateCurrentVersion { get; set; }
        [JsonPropertyName("update_changelog")]
        public string UpdateChangelog { get; set; }
        [JsonPropertyName("update_download_now")]
        public string UpdateDownloadNow { get; set; }
        [JsonPropertyName("update_up_to_date")]
        public string UpdateUpToDate { get; set; }
        [JsonPropertyName("update_check_failed")]
        public string UpdateCheckFailed { get; set; }
        [JsonPropertyName("update_subtitle")]
        public string UpdateSubtitle { get; set; }
        [JsonPropertyName("update_released")]
        public string UpdateReleased { get; set; }
        [JsonPropertyName("update_apps_available_title")]
        public string UpdateAppsAvailableTitle { get; set; }
        [JsonPropertyName("update_apps_available_message")]
        public string UpdateAppsAvailableMessage { get; set; }
        [JsonPropertyName("update_apps_latest_version")]
        public string UpdateAppsLatestVersion { get; set; }
        [JsonPropertyName("btn_update_now")]
        public string BtnUpdateNow { get; set; }
        [JsonPropertyName("msg_apps_updated")]
        public string MsgAppsUpdated { get; set; }
        [JsonPropertyName("update_witty_available_title")]
        public string UpdateWittyAvailableTitle { get; set; }
        [JsonPropertyName("update_witty_available_message")]
        public string UpdateWittyAvailableMessage { get; set; }
        [JsonPropertyName("update_witty_latest_version")]
        public string UpdateWittyLatestVersion { get; set; }
        [JsonPropertyName("msg_witty_updated")]
        public string MsgWittyUpdated { get; set; }
        [JsonPropertyName("update_how_to")]
        public string UpdateHowTo { get; set; }
        [JsonPropertyName("update_method_inapp")]
        public string UpdateMethodInApp { get; set; }
        [JsonPropertyName("update_method_ps")]
        public string UpdateMethodPs { get; set; }
        [JsonPropertyName("update_method_github")]
        public string UpdateMethodGithub { get; set; }
        [JsonPropertyName("update_downloading")]
        public string UpdateDownloading { get; set; }
        [JsonPropertyName("update_extracting")]
        public string UpdateExtracting { get; set; }
        [JsonPropertyName("update_preparing")]
        public string UpdatePreparing { get; set; }
        [JsonPropertyName("update_ready_restart")]
        public string UpdateReadyRestart { get; set; }
        [JsonPropertyName("update_download_failed")]
        public string UpdateDownloadFailed { get; set; }
        [JsonPropertyName("btn_copy")]
        public string BtnCopy { get; set; }
        [JsonPropertyName("btn_copied")]
        public string BtnCopied { get; set; }
        [JsonPropertyName("btn_open_link")]
        public string BtnOpenLink { get; set; }
        [JsonPropertyName("btn_close")]
        public string BtnClose { get; set; }
        [JsonPropertyName("btn_cancel")]
        public string BtnCancel { get; set; }
        [JsonPropertyName("error_missing_files")]
        public string ErrorMissingFiles { get; set; }
        [JsonPropertyName("error_files_location")]
        public string ErrorFilesLocation { get; set; }
        [JsonPropertyName("error_discord_connection")]
        public string ErrorDiscordConnection { get; set; }
        [JsonPropertyName("error_config_invalid")]
        public string ErrorConfigInvalid { get; set; }
        [JsonPropertyName("error_reload_failed")]
        public string ErrorReloadFailed { get; set; }
        [JsonPropertyName("error_startup_toggle")]
        public string ErrorStartupToggle { get; set; }
        [JsonPropertyName("error_open_folder")]
        public string ErrorOpenFolder { get; set; }
        [JsonPropertyName("error_open_file")]
        public string ErrorOpenFile { get; set; }
        [JsonPropertyName("error_export")]
        public string ErrorExport { get; set; }
        [JsonPropertyName("error_already_running")]
        public string ErrorAlreadyRunning { get; set; }
        [JsonPropertyName("media_playing")]
        public string MediaPlaying { get; set; }
        [JsonPropertyName("media_paused")]
        public string MediaPaused { get; set; }
        [JsonPropertyName("app_name")]
        public string AppName { get; set; }
        [JsonPropertyName("tray_paused")]
        public string TrayPaused { get; set; }
        [JsonPropertyName("tray_private")]
        public string TrayPrivate { get; set; }
        [JsonPropertyName("working")]
        public string Working { get; set; }
        [JsonPropertyName("idling")]
        public string Idling { get; set; }
        [JsonPropertyName("ready")]
        public string Ready { get; set; }
        [JsonPropertyName("energy_sleeping")]
        public string EnergySleeping { get; set; }
        [JsonPropertyName("energy_relaxing")]
        public string EnergyRelaxing { get; set; }
        [JsonPropertyName("energy_normal")]
        public string EnergyNormal { get; set; }
        [JsonPropertyName("energy_focused")]
        public string EnergyFocused { get; set; }
        [JsonPropertyName("energy_rush")]
        public string EnergyRush { get; set; }
        [JsonPropertyName("menu_mouse_energy")]
        public string MenuMouseEnergy { get; set; }
        [JsonPropertyName("msg_mouse_energy_on")]
        public string MsgMouseEnergyOn { get; set; }
        [JsonPropertyName("msg_mouse_energy_off")]
        public string MsgMouseEnergyOff { get; set; }
        [JsonPropertyName("menu_telemetry")]
        public string MenuTelemetry { get; set; }
        [JsonPropertyName("msg_telemetry_on")]
        public string MsgTelemetryOn { get; set; }
        [JsonPropertyName("msg_telemetry_off")]
        public string MsgTelemetryOff { get; set; }
        [JsonPropertyName("menu_tray_animation")]
        public string MenuTrayAnimation { get; set; }
        [JsonPropertyName("msg_tray_animation_on")]
        public string MsgTrayAnimationOn { get; set; }
        [JsonPropertyName("msg_tray_animation_off")]
        public string MsgTrayAnimationOff { get; set; }
        public static Language CreateEnglish()
        {
            return new Language
            {
                MenuPause = "⏸️ Pause",
                MenuResume = "▶️ Resume",
                MenuPrivateMode = "🔒 Private Mode",
                MenuReloadConfig = "🔄 Reload Config",
                MenuResetTimers = "⏱️ Reset All Timers",
                MenuStartup = "🚀 Run on Windows startup",
                MenuQuickActions = "⚡ Quick Actions",
                MenuOpenFolder = "📁 Open App Folder",
                MenuEditConfig = "⚙️ Edit config.json",
                MenuEditApps = "📝 Edit apps.json",
                MenuReloadAll = "🔄 Reload All",
                MenuClearTimers = "🗑️ Clear All Timers",
                MenuStatistics = "📊 Statistics",
                MenuToday = "📅 Today's Usage",
                MenuThisWeek = "📆 This Week",
                MenuThisMonth = "📊 This Month",
                MenuAllTime = "🏆 All Time Stats",
                MenuExportCSV = "💾 Export to CSV",
                MenuExportJSON = "📄 Export to JSON",
                MenuResetStats = "🗑️ Reset All Stats",
                MenuLanguage = "🌐 Language",
                MenuCheckUpdates = "🔄 Check for Updates",
                MenuOpenLog = "📄 Open Log File",
                MenuExit = "❌ Exit",
                MenuManageApps = "🛠️ Manage Apps",
                MenuPreviewWindow = "👀 Preview Window",
                FilterEnabled = "Enabled",
                FilterDisabled = "Disabled",
                MenuTelemetry = "📡 Send Anonymous Usage Data",
                MsgTelemetryOn = "Usage data will be sent to help improve the app",
                MsgTelemetryOff = "Usage data will not be sent",
                ManageAppsTitle = "MANAGE APPLICATIONS",
                ManageAppsSearch = "Search applications...",
                ManageAppsFound = "{0} apps found",
                LabelDetails = "Details",
                LabelState = "State",
                MenuChangeAppId = "🆔 Change Application ID...",
                DialogChangeAppIdTitle = "Change Application ID",
                DialogChangeAppIdMessage = "Enter your Client ID (Application ID) from the Discord Developer Portal.\n\nWARNING: Changing the ID will remove all images unless you upload the exact same assets to your portal.",
                MsgAppIdChanged = "Application ID changed successfully!\n\nPlease restart the application if the status does not update.",
                ErrorSaveConfig = "Failed to save configuration.",
                LinkTutorial = "📖 Read Tutorial",
                UrlTutorial = "https://github.com/makcrtve/geetRPCS/blob/main/docs/en/CUSTOM_APP_ID.en.md",
                LinkDownloadAssets = "⬇️ Download Asset Pack (Required)",
                BtnSave = "Save",
                MsgPresencePaused = "Rich Presence paused. Discord won't show any activity.",
                MsgPresenceResumed = "Rich Presence resumed!",
                MsgPrivateModeOn = "Private Mode ON - Window titles are censored",
                MsgPrivateModeOff = "Private Mode OFF - Window titles are visible",
                MsgConfigReloaded = "Config reloaded successfully!",
                MsgStatsReset = "Statistics reset successfully!",
                MsgTimersReset = "All timers have been reset!",
                MsgReloadTip = "Tip: Click 'Reload All' after editing!",
                MsgLanguageChanged = "Language changed! Some parts will update on next restart.",
                DialogReloadTitle = "geetRPCS - Reload All",
                DialogReloadMessage = "Reload all configurations?\n\n• config.json\n• apps.json\n• Discord RPC\n\nPresence will be reset temporarily.",
                DialogResetTimersTitle = "geetRPCS - Clear Timers",
                DialogResetTimersMessage = "Reset all app timers?\n\nElapsed time will be reset to 0.",
                DialogResetStatsTitle = "geetRPCS - Reset Statistics",
                DialogResetStatsMessage = "Reset all statistics?\n\nAll tracking data will be permanently deleted!\nThis action cannot be undone.",
                DialogFileNotFound = "File not found!",
                DialogOpenWithNotepad = "Failed to open with default editor.\n\nOpen with Notepad?",
                DialogLogNotCreated = "Log file has not been created yet.",
                StatsNoDataToday = "No data for today.",
                StatsNoDataWeek = "No data for this week.",
                StatsNoDataMonth = "No data for this month.",
                StatsNoData = "No statistics data available.",
                StatsTodayTitle = "TODAY'S USAGE",
                StatsWeekTitle = "THIS WEEK'S USAGE",
                StatsMonthTitle = "THIS MONTH'S USAGE",
                StatsAllTimeTitle = "ALL TIME STATISTICS",
                StatsWeekOf = "Week of",
                StatsTrackingSince = "Tracking since:",
                StatsTotal = "Total:",
                StatsTotalTracked = "Total Tracked:",
                StatsTotalApps = "Total Apps:",
                StatsExportSuccess = "Statistics exported successfully!\n\nFile:",
                StatsExportFailed = "Failed to export statistics.",
                StatsOpenFolder = "Open folder?",
                UpdateChecking = "Checking for updates...",
                UpdateAvailableTitle = "geetRPCS - Update Available",
                UpdateAvailableMessage = "🎉 New Update Available!",
                UpdateLatestVersion = "Latest Version:",
                UpdateCurrentVersion = "Current Version:",
                UpdateChangelog = "📝 Changelog:",
                UpdateDownloadNow = "Download update now?",
                UpdateUpToDate = "✅ You're using the latest version!\n\nCurrent version:",
                UpdateCheckFailed = "Cannot check for updates.\nMake sure internet connection is active.",
                UpdateSubtitle = "A newer version of geetRPCS is ready to download",
                UpdateReleased = "Released:",
                UpdateAppsAvailableTitle = "App Database Update",
                UpdateAppsAvailableMessage = "🎉 New Applications Supported!",
                UpdateAppsLatestVersion = "Latest Database:",
                BtnUpdateNow = "🚀 Update Now",
                MsgAppsUpdated = "Applications database updated!",
                UpdateWittyAvailableTitle = "Witty Texts Update",
                UpdateWittyAvailableMessage = "🎉 New Witty Texts Available!",
                UpdateWittyLatestVersion = "Latest Version:",
                MsgWittyUpdated = "Witty texts database updated!",
                UpdateHowTo = "🛠️ How to Update:",
                UpdateMethodInApp = "★ In-App Update (Recommended)",
                UpdateMethodPs = "1. Via PowerShell",
                UpdateMethodGithub = "2. Via GitHub Releases",
                UpdateDownloading = "Downloading update...",
                UpdateExtracting = "Extracting files...",
                UpdatePreparing = "Preparing update...",
                UpdateReadyRestart = "Update ready! geetRPCS will restart.",
                UpdateDownloadFailed = "Download failed. Please try another method.",
                BtnCopy = "📋 Copy",
                BtnCopied = "✅ Copied",
                BtnOpenLink = "🌐 Open Link",
                BtnClose = "Close",
                BtnCancel = "Cancel",
                ErrorMissingFiles = "The following files are missing:\n\n",
                ErrorFilesLocation = "\n\nMake sure these files exist in:\n",
                ErrorDiscordConnection = "Failed to connect to Discord:\n\n{0}\n\nMake sure Discord is running.",
                ErrorConfigInvalid = "Invalid config.json format:\n\n{0}\n\nMake sure JSON format is correct.",
                ErrorReloadFailed = "Reload failed:",
                ErrorStartupToggle = "Failed to change startup setting:\n",
                ErrorOpenFolder = "Failed to open folder:\n\n",
                ErrorOpenFile = "Failed to open file:\n\n",
                ErrorExport = "Failed to export statistics:\n\n",
                ErrorAlreadyRunning = "geetRPCS is already running!",
                MediaPlaying = "▶️ Playing",
                MediaPaused = "⏸️ Paused",
                AppName = "geetRPCS",
                TrayPaused = " (Paused)",
                TrayPrivate = " (Private)",
                Working = "Working...",
                Idling = "Idling...",
                Ready = "Ready to work",
                EnergySleeping = "Zzz...",
                EnergyRelaxing = "Relaxing",
                EnergyNormal = "Working",
                EnergyFocused = "Focused",
                EnergyRush = "Rush Mode!",
                MenuMouseEnergy = "🖱️ Mouse Energy Detector",
                MsgMouseEnergyOn = "Mouse Energy Detector ON - Status will reflect your activity",
                MsgMouseEnergyOff = "Mouse Energy Detector OFF",
                MenuTrayAnimation = "🎨 Tray Icon Animation",
                MsgTrayAnimationOn = "Tray animation enabled - icon will pulse on app switch",
                MsgTrayAnimationOff = "Tray animation disabled"
            };
        }
        public static Language CreateIndonesian()
        {
            return new Language
            {
                MenuPause = "⏸️ Jeda",
                MenuResume = "▶️ Lanjutkan",
                MenuPrivateMode = "🔒 Mode Privat",
                MenuReloadConfig = "🔄 Muat Ulang Konfigurasi",
                MenuResetTimers = "⏱️ Reset Semua Timer",
                MenuStartup = "🚀 Jalankan saat Windows startup",
                MenuQuickActions = "⚡ Aksi Cepat",
                MenuOpenFolder = "📁 Buka Folder Aplikasi",
                MenuEditConfig = "⚙️ Edit config.json",
                MenuEditApps = "📝 Edit apps.json",
                MenuReloadAll = "🔄 Muat Ulang Semua",
                MenuClearTimers = "🗑️ Hapus Semua Timer",
                MenuStatistics = "📊 Statistik",
                MenuToday = "📅 Penggunaan Hari Ini",
                MenuThisWeek = "📆 Minggu Ini",
                MenuThisMonth = "📊 Bulan Ini",
                MenuAllTime = "🏆 Statistik Keseluruhan",
                MenuExportCSV = "💾 Ekspor ke CSV",
                MenuExportJSON = "📄 Ekspor ke JSON",
                MenuResetStats = "🗑️ Reset Semua Statistik",
                MenuLanguage = "🌐 Bahasa",
                MenuCheckUpdates = "🔄 Periksa Pembaruan",
                MenuOpenLog = "📄 Buka File Log",
                MenuExit = "❌ Keluar",
                MenuManageApps = "🛠️ Kelola Aplikasi",
                MenuPreviewWindow = "👀 Jendela Preview",
                FilterEnabled = "Aktif",
                FilterDisabled = "Nonaktif",
                MenuTelemetry = "📡 Kirim Data Penggunaan Anonim",
                MsgTelemetryOn = "Data penggunaan akan dikirim untuk membantu pengembangan",
                MsgTelemetryOff = "Data penggunaan tidak akan dikirim",
                ManageAppsTitle = "KELOLA APLIKASI",
                ManageAppsSearch = "Cari aplikasi...",
                ManageAppsFound = "{0} aplikasi ditemukan",
                LabelDetails = "Detail",
                LabelState = "Status",
                MenuChangeAppId = "🆔 Ganti Application ID...",
                DialogChangeAppIdTitle = "Ganti Application ID",
                DialogChangeAppIdMessage = "Masukkan Client ID (Application ID) dari Discord Developer Portal Anda.\n\nPERINGATAN: Mengganti ID akan menghilangkan gambar kecuali Anda mengupload aset yang sama di portal Anda.",
                MsgAppIdChanged = "Application ID berhasil diubah!\n\nSilakan restart aplikasi jika status tidak berubah.",
                ErrorSaveConfig = "Gagal menyimpan konfigurasi.",
                LinkTutorial = "📖 Baca Tutorial",
                UrlTutorial = "https://github.com/makcrtve/geetRPCS/blob/main/docs/id/CUSTOM_APP_ID.id.md",
                LinkDownloadAssets = "⬇️ Download Asset Pack (Wajib)",
                BtnSave = "Simpan",
                MsgPresencePaused = "Rich Presence dijeda. Discord tidak menampilkan aktivitas.",
                MsgPresenceResumed = "Rich Presence dilanjutkan!",
                MsgPrivateModeOn = "Mode Privat AKTIF - Judul window disensor",
                MsgPrivateModeOff = "Mode Privat NONAKTIF - Judul window terlihat",
                MsgConfigReloaded = "Konfigurasi berhasil dimuat ulang!",
                MsgStatsReset = "Statistik berhasil direset!",
                MsgTimersReset = "Semua timer telah direset!",
                MsgReloadTip = "Tip: Klik 'Muat Ulang Semua' setelah mengedit!",
                MsgLanguageChanged = "Bahasa diubah! Beberapa bagian akan diperbarui saat restart.",
                DialogReloadTitle = "geetRPCS - Muat Ulang Semua",
                DialogReloadMessage = "Muat ulang semua konfigurasi?\n\n• config.json\n• apps.json\n• Discord RPC\n\nPresence akan direset sementara.",
                DialogResetTimersTitle = "geetRPCS - Hapus Timer",
                DialogResetTimersMessage = "Reset semua app timer?\n\nWaktu yang sudah berjalan akan direset ke 0.",
                DialogResetStatsTitle = "geetRPCS - Reset Statistik",
                DialogResetStatsMessage = "Reset semua statistik?\n\nSemua data tracking akan dihapus permanen!\nAksi ini tidak bisa dibatalkan.",
                DialogFileNotFound = "File tidak ditemukan!",
                DialogOpenWithNotepad = "Gagal membuka dengan editor default.\n\nBuka dengan Notepad?",
                DialogLogNotCreated = "File log belum dibuat.",
                StatsNoDataToday = "Belum ada data untuk hari ini.",
                StatsNoDataWeek = "Belum ada data untuk minggu ini.",
                StatsNoDataMonth = "Belum ada data untuk bulan ini.",
                StatsNoData = "Belum ada data statistik.",
                StatsTodayTitle = "PENGGUNAAN HARI INI",
                StatsWeekTitle = "PENGGUNAAN MINGGU INI",
                StatsMonthTitle = "PENGGUNAAN BULAN INI",
                StatsAllTimeTitle = "STATISTIK KESELURUHAN",
                StatsWeekOf = "Minggu tanggal",
                StatsTrackingSince = "Tracking sejak:",
                StatsTotal = "Total:",
                StatsTotalTracked = "Total Tracking:",
                StatsTotalApps = "Total Aplikasi:",
                StatsExportSuccess = "Statistik berhasil diekspor!\n\nFile:",
                StatsExportFailed = "Gagal mengekspor statistik.",
                StatsOpenFolder = "Buka folder?",
                UpdateChecking = "Memeriksa pembaruan...",
                UpdateAvailableTitle = "geetRPCS - Pembaruan Tersedia",
                UpdateAvailableMessage = "🎉 Pembaruan Baru Tersedia!",
                UpdateLatestVersion = "Versi Terbaru:",
                UpdateCurrentVersion = "Versi Saat Ini:",
                UpdateChangelog = "📝 Catatan Rilis:",
                UpdateDownloadNow = "Download pembaruan sekarang?",
                UpdateUpToDate = "✅ Kamu sudah menggunakan versi terbaru!\n\nVersi saat ini:",
                UpdateCheckFailed = "Tidak dapat memeriksa pembaruan.\nPastikan koneksi internet aktif.",
                UpdateSubtitle = "Versi terbaru geetRPCS sudah siap untuk diunduh",
                UpdateReleased = "Dirilis:",
                UpdateAppsAvailableTitle = "Pembaruan Basis Data Aplikasi",
                UpdateAppsAvailableMessage = "🎉 Dukungan Aplikasi Baru Tersedia!",
                UpdateAppsLatestVersion = "Basis Data Terbaru:",
                BtnUpdateNow = "🚀 Perbarui Sekarang",
                MsgAppsUpdated = "Basis data aplikasi berhasil diperbarui!",
                UpdateWittyAvailableTitle = "Pembaruan Teks Witty",
                UpdateWittyAvailableMessage = "🎉 Teks Witty Baru Tersedia!",
                UpdateWittyLatestVersion = "Versi Terbaru:",
                MsgWittyUpdated = "Basis data teks witty berhasil diperbarui!",
                UpdateHowTo = "🛠️ Cara Update:",
                UpdateMethodInApp = "★ Update Dalam Aplikasi (Direkomendasikan)",
                UpdateMethodPs = "1. Via PowerShell",
                UpdateMethodGithub = "2. Via GitHub Releases",
                UpdateDownloading = "Mengunduh pembaruan...",
                UpdateExtracting = "Mengekstrak file...",
                UpdatePreparing = "Menyiapkan pembaruan...",
                UpdateReadyRestart = "Pembaruan siap! geetRPCS akan restart.",
                UpdateDownloadFailed = "Unduhan gagal. Silakan coba metode lain.",
                BtnCopy = "📋 Salin",
                BtnCopied = "✅ Tersalin",
                BtnOpenLink = "🌐 Buka Link",
                BtnClose = "Tutup",
                BtnCancel = "Batal",
                ErrorMissingFiles = "File berikut tidak ditemukan:\n\n",
                ErrorFilesLocation = "\n\nPastikan file-file tersebut ada di:\n",
                ErrorDiscordConnection = "Gagal terhubung ke Discord:\n\n{0}\n\nPastikan Discord sedang berjalan.",
                ErrorConfigInvalid = "Format config.json tidak valid:\n\n{0}\n\nPastikan format JSON benar.",
                ErrorReloadFailed = "Reload gagal:",
                ErrorStartupToggle = "Gagal mengubah pengaturan startup:\n",
                ErrorOpenFolder = "Gagal membuka folder:\n\n",
                ErrorOpenFile = "Gagal membuka file:\n\n",
                ErrorExport = "Gagal mengekspor statistik:\n\n",
                ErrorAlreadyRunning = "geetRPCS sudah berjalan!",
                MediaPlaying = "▶️ Memutar",
                MediaPaused = "⏸️ Dijeda",
                AppName = "geetRPCS",
                TrayPaused = " (Dijeda)",
                TrayPrivate = " (Privat)",
                Working = "Bekerja...",
                Idling = "Menganggur...",
                Ready = "Siap bekerja",
                EnergySleeping = "Zzz...",
                EnergyRelaxing = "Santai",
                EnergyNormal = "Bekerja",
                EnergyFocused = "Fokus",
                EnergyRush = "Mode Deadline!",
                MenuMouseEnergy = "🖱️ Detektor Energi Mouse",
                MsgMouseEnergyOn = "Detektor Energi Mouse AKTIF - Status akan mencerminkan aktivitas Anda",
                MsgMouseEnergyOff = "Detektor Energi Mouse NONAKTIF",
                MenuTrayAnimation = "🎨 Animasi Ikon Tray",
                MsgTrayAnimationOn = "Animasi tray aktif - ikon akan beranimasi saat ganti aplikasi",
                MsgTrayAnimationOff = "Animasi tray nonaktif"
            };
        }
    }
}
