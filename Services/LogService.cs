/**
 * geetRPCS - Log Service
 * Centralized logging with log levels, rotation, and thread-safety
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
using System.IO;
using System.Runtime.CompilerServices;

#nullable enable

namespace geetRPCS.Services
{
    /// <summary>
    /// Log levels for filtering messages
    /// </summary>
    public enum LogLevel
    {
        DEBUG = 0,
        INFO = 1,
        WARN = 2,
        ERROR = 3
    }

    /// <summary>
    /// Centralized logging service with log rotation and level filtering
    /// </summary>
    internal static class LogService
    {
        private static readonly object _lock = new object();
        private static StreamWriter? _writer;
        private static string _logPath = null!;
        private static LogLevel _minLevel = LogLevel.INFO;
        private static bool _initialized = false;

        // Configuration
        private const long MAX_FILE_SIZE_BYTES = 5 * 1024 * 1024; // 5MB
        private const int MAX_BACKUP_FILES = 3;
        private static readonly string AppFolder = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// Initialize the log service. Must be called once at startup.
        /// </summary>
        public static void Initialize(string? logFileName = null, LogLevel? minLevel = null)
        {
            lock (_lock)
            {
                if (_initialized) return;

                _logPath = Path.Combine(AppFolder, logFileName ?? "geetRPCS.log");
                _minLevel = minLevel ?? ParseLogLevel(GetConfiguredLogLevel());

                try
                {
                    RotateIfNeeded();
                    _writer = new StreamWriter(_logPath, append: true) { AutoFlush = true };
                    _initialized = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[LogService] Failed to initialize: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Set the minimum log level at runtime
        /// </summary>
        public static void SetMinLevel(LogLevel level)
        {
            lock (_lock)
            {
                _minLevel = level;
            }
        }

        /// <summary>
        /// Set the minimum log level from string
        /// </summary>
        public static void SetMinLevel(string levelStr)
        {
            SetMinLevel(ParseLogLevel(levelStr));
        }

        /// <summary>
        /// Log a DEBUG message (verbose, for development)
        /// </summary>
        public static void Debug(string message, [CallerMemberName] string module = "")
            => Write(LogLevel.DEBUG, message, module);

        /// <summary>
        /// Log an INFO message (normal operation)
        /// </summary>
        public static void Info(string message, [CallerMemberName] string module = "")
            => Write(LogLevel.INFO, message, module);

        /// <summary>
        /// Log a WARN message (potential issues)
        /// </summary>
        public static void Warn(string message, [CallerMemberName] string module = "")
            => Write(LogLevel.WARN, message, module);

        /// <summary>
        /// Log an ERROR message (failures)
        /// </summary>
        public static void Error(string message, [CallerMemberName] string module = "")
            => Write(LogLevel.ERROR, message, module);

        /// <summary>
        /// Log with explicit level and module (for backward compatibility)
        /// </summary>
        public static void Log(string message, string level = "INFO", string module = "geetRPCS")
        {
            var logLevel = ParseLogLevel(level);
            Write(logLevel, message, module);
        }

        /// <summary>
        /// Core logging method
        /// </summary>
        private static void Write(LogLevel level, string message, string module)
        {
            // Early exit if below minimum level
            if (level < _minLevel) return;

            try
            {
                lock (_lock)
                {
                    // Auto-initialize if not done
                    if (!_initialized)
                    {
                        Initialize();
                    }

                    // Check if rotation needed
                    RotateIfNeeded();

                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string levelStr = level.ToString();
                    string logLine = $"[{timestamp}] [{module}] [{levelStr}] {message}";

                    _writer?.WriteLine(logLine);

                    // Also write to debug output for development
                    System.Diagnostics.Debug.WriteLine(logLine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LogService] Write failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Rotate log files if current file exceeds max size
        /// </summary>
        private static void RotateIfNeeded()
        {
            try
            {
                if (!File.Exists(_logPath)) return;

                var fileInfo = new FileInfo(_logPath);
                if (fileInfo.Length < MAX_FILE_SIZE_BYTES) return;

                // Close current writer
                _writer?.Close();
                _writer?.Dispose();
                _writer = null;

                // Rotate existing backups (delete oldest)
                string backup3 = $"{_logPath}.3";
                string backup2 = $"{_logPath}.2";
                string backup1 = $"{_logPath}.1";

                if (File.Exists(backup3)) File.Delete(backup3);
                if (File.Exists(backup2)) File.Move(backup2, backup3);
                if (File.Exists(backup1)) File.Move(backup1, backup2);

                // Rotate current to .1
                File.Move(_logPath, backup1);

                // Reopen writer for new file
                _writer = new StreamWriter(_logPath, append: true) { AutoFlush = true };

                Info("Log file rotated due to size limit", "LogService");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LogService] Rotation failed: {ex.Message}");
            }
        }

        /// <summary>
        /// Parse log level string to enum
        /// </summary>
        private static LogLevel ParseLogLevel(string levelStr)
        {
            return levelStr?.ToUpperInvariant() switch
            {
                "DEBUG" => LogLevel.DEBUG,
                "INFO" => LogLevel.INFO,
                "WARN" or "WARNING" => LogLevel.WARN,
                "ERROR" => LogLevel.ERROR,
                _ => LogLevel.INFO
            };
        }

        /// <summary>
        /// Get configured log level from settings
        /// </summary>
        private static string GetConfiguredLogLevel()
        {
            try
            {
                // Try to get from SettingsService if available
                return SettingsService.Instance?.LogLevel ?? "INFO";
            }
            catch
            {
                return "INFO";
            }
        }

        /// <summary>
        /// Cleanup resources on application exit
        /// </summary>
        public static void Shutdown()
        {
            lock (_lock)
            {
                try
                {
                    Info("LogService shutting down", "LogService");
                    _writer?.Flush();
                    _writer?.Close();
                    _writer?.Dispose();
                    _writer = null;
                    _initialized = false;
                }
                catch { }
            }
        }
    }
}
