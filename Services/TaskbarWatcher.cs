using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
namespace geetRPCS.Services
{
    internal static class TaskbarWatcher
    {
        public delegate void AppChanged(string processName, string details, string state, IntPtr hWnd);
        private static AppChanged _callback;
        private static string _lastFound, _lastTitle;
        private static readonly object _lock = new object();
        private static IntPtr _hookHandle;
        private static WinEventDelegate _eventDelegate;
        private static Thread _backgroundPollThread;
        private const uint EVENT_SYSTEM_FOREGROUND = 0x0003;
        private const uint WINEVENT_OUTOFCONTEXT = 0;
        private delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
        public static void Reload()
        {
            AppConfigManager.Reload();
            lock (_lock)
            {
                _lastFound = null;
                _lastTitle = null;
            }
            CheckCurrentApp();
        }
        public static void Start(AppChanged callback)
        {
            _callback = callback;
            _eventDelegate = new WinEventDelegate(WinEventProc);
            _hookHandle = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, _eventDelegate, 0, 0, WINEVENT_OUTOFCONTEXT);
            _backgroundPollThread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        CheckCurrentApp();
                    }
                    catch
                    {
                    }
                    Thread.Sleep(1000);
                }
            }) { IsBackground = true, Name = "TaskbarWatcherFallback" };
            _backgroundPollThread.Start();
            CheckCurrentApp();
        }
        private static void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            if (eventType == EVENT_SYSTEM_FOREGROUND)
            {
                CheckCurrentApp();
            }
        }
        private static void CheckCurrentApp()
        {
            var (proc, hwnd, title) = GetCurrentApp();
            lock (_lock)
            {
                if (proc == _lastFound && title == _lastTitle)
                    return;
                _lastFound = proc;
                _lastTitle = title;
            }
            _callback?.Invoke(proc ?? "config", null, title, hwnd);
        }
        private static (string processName, IntPtr hWnd, string title) GetCurrentApp()
        {
            var apps = AppConfigManager.Apps;
            var targetProcessNames = AppConfigManager.ProcessNames;
            string lastFound;
            lock (_lock) { lastFound = _lastFound; }
            IntPtr foregroundHwnd = GetForegroundWindow();
            if (foregroundHwnd != IntPtr.Zero)
            {
                GetWindowThreadProcessId(foregroundHwnd, out uint pid);
                if (pid != 0)
                {
                    try
                    {
                        using var p = Process.GetProcessById((int)pid);
                        string procName = p.ProcessName;
                        if (targetProcessNames.Contains(procName))
                        {
                            string title = GetWindowTitle(foregroundHwnd);
                            if (!string.IsNullOrEmpty(title) && title.Length > 2)
                            {
                                var matchingConfigs = apps.Where(a => a.Process != null && a.Process.Equals(procName, StringComparison.OrdinalIgnoreCase)).ToList();
                                var titleMatch = matchingConfigs.FirstOrDefault(a =>
                                    !string.IsNullOrEmpty(a.WindowTitle) &&
                                    title.IndexOf(a.WindowTitle, StringComparison.OrdinalIgnoreCase) >= 0);
                                if (titleMatch != null) return (procName, foregroundHwnd, title);
                                var defaultMatch = matchingConfigs.FirstOrDefault(a => string.IsNullOrEmpty(a.WindowTitle));
                                if (defaultMatch != null) return (procName, foregroundHwnd, title);
                            }
                        }
                    }
                    catch { }
                }
            }
            if (!string.IsNullOrEmpty(lastFound))
            {
               var processes = Process.GetProcessesByName(lastFound);
               foreach (var p in processes)
               {
                   using (p)
                   {
                       if (CheckProcessWindow(p, lastFound, apps, out var result))
                           return result;
                   }
               }
            }
            foreach (var targetProc in targetProcessNames)
            {
                if (string.Equals(targetProc, lastFound, StringComparison.OrdinalIgnoreCase)) continue;
                var processes = Process.GetProcessesByName(targetProc);
                foreach (var p in processes)
                {
                    using (p)
                    {
                        if (CheckProcessWindow(p, targetProc, apps, out var result))
                            return result;
                    }
                }
            }
            return (null, IntPtr.Zero, null);
        }
        private static bool CheckProcessWindow(Process process, string processName, List<geetRPCS.Models.AppConfig> apps, out (string, IntPtr, string) result)
        {
            result = (null, IntPtr.Zero, null);
            try
            {
                if (process.HasExited) return false;
                IntPtr hwnd = process.MainWindowHandle;
                if (hwnd == IntPtr.Zero) return false;
                string title = GetWindowTitle(hwnd);
                if (string.IsNullOrEmpty(title) || title.Length <= 2) return false;
                var matchingConfigs = apps.Where(a => a.Process != null && a.Process.Equals(processName, StringComparison.OrdinalIgnoreCase)).ToList();
                if (matchingConfigs.Any())
                {
                    result = (processName, hwnd, title);
                    return true;
                }
            }
            catch { }
            return false;
        }
        private static string GetWindowTitle(IntPtr hWnd)
        {
            if (hWnd == IntPtr.Zero) return "";
            int len = GetWindowTextLengthW(hWnd);
            if (len <= 0) return "";
            var sb = new StringBuilder(len + 1);
            GetWindowTextW(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }
        #region ----- Win32 -----
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowTextLengthW(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetWindowTextW(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll")]
        private static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);
        [DllImport("user32.dll")]
        private static extern bool UnhookWinEvent(IntPtr hWinEventHook);
        #endregion
    }
}
