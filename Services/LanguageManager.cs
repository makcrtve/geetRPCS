/**
 * geetRPCS - Language Manager
 * Manages application-wide language and localization
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using geetRPCS.Models;

namespace geetRPCS.Services
{
    internal static class LanguageManager
    {
        private static readonly string AppFolder = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string LanguagesFolder = Path.Combine(AppFolder, "Languages");
        private static readonly string SettingsPath = Path.Combine(AppFolder, "settings.json");

        private static Language _currentLanguage;
        private static string _currentLanguageCode = "en";
        public static Language Current => _currentLanguage ?? LoadLanguage("en");
        static LanguageManager()
        {
            EnsureLanguagesFolder();
            LoadSettings();
        }
        private static void EnsureLanguagesFolder()
        {
            try
            {
                if (!Directory.Exists(LanguagesFolder))
                {
                    Directory.CreateDirectory(LanguagesFolder);
                    Log($"Created folder: {LanguagesFolder}", "INFO");
                }
                CreateDefaultLanguageFiles();
            }
            catch (Exception ex)
            {
                Log($"Failed to create folder: {ex.Message}", "ERROR");
            }
        }
        private static void CreateDefaultLanguageFiles()
        {
            string enPath = Path.Combine(LanguagesFolder, "en.json");
            if (!File.Exists(enPath))
            {
                var english = Language.CreateEnglish();
                SaveLanguageFile(english, enPath);
            }
            string idPath = Path.Combine(LanguagesFolder, "id.json");
            if (!File.Exists(idPath))
            {
                var indonesian = Language.CreateIndonesian();
                SaveLanguageFile(indonesian, idPath);
            }
        }
        private static void SaveLanguageFile(Language language, string path)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                string json = JsonSerializer.Serialize(language, options);
                File.WriteAllText(path, json);
                Log($"Saved language file: {Path.GetFileName(path)}", "INFO");
            }
            catch (Exception ex)
            {
                Log($"Failed to save language file: {ex.Message}", "ERROR");
            }
        }
        private static void LoadSettings()
        {
            try
            {
                _currentLanguageCode = SettingsService.Instance.Language ?? "en";
                _currentLanguage = LoadLanguage(_currentLanguageCode);
                Log($"Ready with language: {_currentLanguageCode}", "INFO");
            }
            catch (Exception ex)
            {
                Log($"Failed to load settings: {ex.Message}", "ERROR");
                _currentLanguage = Language.CreateEnglish();
            }
        }
        public static async Task SetLanguageAsync(string languageCode)
        {
            try
            {
                var newLanguage = LoadLanguage(languageCode);
                if (newLanguage != null)
                {
                    _currentLanguage = newLanguage;
                    _currentLanguageCode = languageCode;
                    SettingsService.Instance.Language = languageCode;
                    await SettingsService.SaveAsync();
                    Log($"Language changed to: {languageCode}", "INFO");
                }
            }
            catch (Exception ex)
            {
                Log($"Failed to change language: {ex.Message}", "ERROR");
            }
        }
        public static string GetCurrentLanguageCode()
        {
            return _currentLanguageCode;
        }
        private static Language LoadLanguage(string languageCode)
        {
            try
            {
                string path = Path.Combine(LanguagesFolder, $"{languageCode}.json");
                if (!File.Exists(path))
                {
                    Log($"Language file not found: {Path.GetFileName(path)} - using English", "WARNING");
                    return Language.CreateEnglish();
                }
                string json = File.ReadAllText(path);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var language = JsonSerializer.Deserialize<Language>(json, options);
                Log($"Loaded language: {languageCode}", "INFO");
                return language ?? Language.CreateEnglish();
            }
            catch (Exception ex)
            {
                Log($"Failed to load language {languageCode}: {ex.Message}", "ERROR");
                return Language.CreateEnglish();
            }
        }
        public static List<LanguageInfo> GetAvailableLanguages()
        {
            var languages = new List<LanguageInfo>
            {
                new LanguageInfo { Code = "en", Name = "English" },
                new LanguageInfo { Code = "id", Name = "Bahasa Indonesia" }
            };
            return languages;
        }
        private static void Log(string message, string level = "INFO")
        {
            // Delegate to centralized LogService
            LogService.Log(message, level, "LanguageManager");
        }
        // --- Models ---
        public class LanguageInfo
        {
            public string Code { get; set; }
            public string Name { get; set; }
        }
    }
}
