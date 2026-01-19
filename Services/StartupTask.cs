/**
 * geetRPCS - Startup Service
 * Manages application startup and registration
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
using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.Versioning;
using System.Windows.Forms;
namespace geetRPCS.Services
{
    [SupportedOSPlatform("windows")]
    internal static class StartupTask
    {
        private const string REG_KEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private const string APP_NAME = "geetRPCS";
        public static void Enable(bool on = true)
        {
            try
            {
                using var key = Registry.CurrentUser.OpenSubKey(REG_KEY, true);
                if (on)
                {
                    string exePath = Application.ExecutablePath;
                    if (!IsValidExecutablePath(exePath, out string errorMessage))
                    {
                        throw new InvalidOperationException(errorMessage);
                    }
                    string normalizedPath = Path.GetFullPath(exePath);
                    try
                    {
                        var logMethod = typeof(Program).GetMethod("Log",
                            System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
                        logMethod?.Invoke(null, new object[] {
                            $"Enabling startup with path: {normalizedPath}",
                            "INFO",
                            "StartupTask"
                        });
                    }
                    catch { /* Logging is optional */ }
                    key?.SetValue(APP_NAME, $"\"{normalizedPath}\"");
                }
                else
                {
                    key?.DeleteValue(APP_NAME, false);
                    try
                    {
                        var logMethod = typeof(Program).GetMethod("Log",
                            System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
                        logMethod?.Invoke(null, new object[] {
                            "Disabled startup",
                            "INFO",
                            "StartupTask"
                        });
                    }
                    catch { /* Logging is optional */ }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengubah startup:\n{ex.Message}", "geetRPCS",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw; // Re-throw to let caller handle if needed
            }
        }
        public static bool IsEnabled()
        {
            using var key = Registry.CurrentUser.OpenSubKey(REG_KEY);
            return key?.GetValue(APP_NAME) != null;
        }
        private static bool IsValidExecutablePath(string path, out string errorMessage)
        {
            errorMessage = null;
            if (string.IsNullOrWhiteSpace(path))
            {
                errorMessage = "Path executable tidak valid (kosong).";
                return false;
            }
            if (!File.Exists(path))
            {
                errorMessage = $"File executable tidak ditemukan:\n{path}";
                return false;
            }
            if (!Path.IsPathRooted(path))
            {
                errorMessage = "Path executable harus absolute path.";
                return false;
            }
            string tempPath = Path.GetTempPath();
            string normalizedPath = Path.GetFullPath(path);
            string normalizedTemp = Path.GetFullPath(tempPath);
            if (normalizedPath.StartsWith(normalizedTemp, StringComparison.OrdinalIgnoreCase))
            {
                errorMessage = "Tidak dapat mengaktifkan startup dari folder temporary.\n" +
                              "Silakan pindahkan aplikasi ke lokasi permanent terlebih dahulu.";
                return false;
            }
            return true;
        }
    }
}
