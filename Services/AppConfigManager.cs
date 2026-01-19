/**
 * geetRPCS - Config Manager
 * Manages loading and saving of app configurations
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
using System.Linq;
using geetRPCS.Models;

namespace geetRPCS.Services
{
    internal static class AppConfigManager
    {
        private static List<AppConfig> _apps;
        private static HashSet<string> _processNames;
        private static readonly object _lock = new object();
        private static readonly string AppsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "apps.json");
        // --- Shared Data ---
        public static List<AppConfig> Apps
        {
            get
            {
                lock (_lock)
                {
                    if (_apps == null) Reload();
                    return _apps;
                }
            }
        }
        public static HashSet<string> ProcessNames
        {
            get
            {
                lock (_lock)
                {
                    if (_processNames == null) Reload();
                    return _processNames;
                }
            }
        }
        public static void Reload()
        {
            lock (_lock)
            {
                try
                {
                    var allApps = AppConfig.Load(AppsPath) ?? new List<AppConfig>();
                    _apps = allApps.Where(a => !string.IsNullOrEmpty(a.Process)).ToList();
                    _processNames = new HashSet<string>(_apps.Select(a => a.Process), StringComparer.OrdinalIgnoreCase);
                }
                catch
                {
                    _apps = new List<AppConfig>();
                    _processNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                }
            }
        }
    }
}
