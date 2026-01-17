/**
 * geetRPCS - Mouse Activity Tracker
 * Uses low-level hooks to analyze user interaction energy
 */

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace geetRPCS.Services
{
    public class MouseActivityTracker : IDisposable
    {
        // --- Definitions ---
        #region Constants & Enums
        private const double HIGH_ENERGY_VELOCITY = 600;
        private const double MEDIUM_ENERGY_VELOCITY = 150;
        private const double LOW_ENERGY_VELOCITY = 40;
        private const int IDLE_TIMEOUT_SECONDS = 30;
        private const int HIGH_CLICKS_PER_MINUTE = 50;
        private const int MEDIUM_CLICKS_PER_MINUTE = 15;
        public enum EnergyLevel { Sleeping, Relaxing, Normal, Focused, Rush }
        #endregion
        #region ----- Fields -----
        private static readonly string LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "geetRPCS.log");
        private IntPtr _mouseHookHandle = IntPtr.Zero;
        private LowLevelMouseProc _mouseProc;
        private bool _isHookInstalled, _isRunning, _isEnabled = true;
        private Point _lastMousePosition;
        private DateTime _lastMoveTime, _lastClickTime, _lastAnalysisTime;
        private double _accumulatedDistance, _averageVelocity;
        private int _clicksPerMinute;
        private System.Collections.Generic.Queue<DateTime> _recentClicks = new System.Collections.Generic.Queue<DateTime>();
        private readonly object _lockData = new object();
        private Thread _analysisThread;
        private EnergyLevel _currentEnergy = EnergyLevel.Normal;
        public event Action<EnergyLevel, double, int> OnEnergyChanged;
        #endregion

        // --- Low Level Interaction ---
        #region Win32 API
        private const int WH_MOUSE_LL = 14;
        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_MBUTTONDOWN = 0x0207;
        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        [StructLayout(LayoutKind.Sequential)]
        private struct POINT { public int x, y; }
        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData, flags, time;
            public IntPtr dwExtraInfo;
        }
        #endregion
        #region ----- Constructor -----
        public MouseActivityTracker()
        {
            _lastMousePosition = Point.Empty;
            _lastMoveTime = _lastClickTime = _lastAnalysisTime = DateTime.UtcNow;
            _recentClicks.Clear();
            _accumulatedDistance = _averageVelocity = 0;
            _clicksPerMinute = 0;
        }
        #endregion
        #region ----- Public Methods -----
        public void Start()
        {
            if (_isRunning) return;
            try
            {
                _isRunning = true;
                InstallHook();
                StartAnalysisThread();
                Log("Mouse Activity Tracker started", "INFO");
            }
            catch (Exception ex)
            {
                Log($"Failed to start Mouse Activity Tracker: {ex.Message}", "ERROR");
                _isRunning = false;
            }
        }
        public void Stop()
        {
            _isRunning = false;
            UninstallHook();
            Log("Mouse Activity Tracker stopped", "INFO");
        }
        public void SetEnabled(bool enabled)
        {
            _isEnabled = enabled;
            if (!enabled) _currentEnergy = EnergyLevel.Normal;
            Log($"Mouse Activity Tracker enabled: {enabled}", "INFO");
        }
        public EnergyLevel GetCurrentEnergy()
        {
            if (!_isEnabled) return EnergyLevel.Normal;
            lock (_lockData) { return _currentEnergy; }
        }
        public string GetEnergyEmoji() => GetCurrentEnergy() switch
        {
            EnergyLevel.Sleeping => "💤",
            EnergyLevel.Relaxing => "☕",
            EnergyLevel.Normal => "🎯",
            EnergyLevel.Focused => "🔥",
            EnergyLevel.Rush => "⚡",
            _ => "🎯"
        };
        public string GetEnergyText() => GetCurrentEnergy() switch
        {
            EnergyLevel.Sleeping => LanguageManager.Current.EnergySleeping ?? "Zzz...",
            EnergyLevel.Relaxing => LanguageManager.Current.EnergyRelaxing ?? "Relaxing",
            EnergyLevel.Normal => LanguageManager.Current.EnergyNormal ?? "Working",
            EnergyLevel.Focused => LanguageManager.Current.EnergyFocused ?? "Focused",
            EnergyLevel.Rush => LanguageManager.Current.EnergyRush ?? "Rush Mode!",
            _ => "Working"
        };
        public string GetEnergyStateText()
        {
            if (!_isEnabled) return null;
            return $"{GetEnergyEmoji()} {GetEnergyText()}";
        }
        public (double velocity, int clicksPerMinute, EnergyLevel energy) GetStats()
        {
            lock (_lockData) { return (_averageVelocity, _clicksPerMinute, _currentEnergy); }
        }
        #endregion
        #region ----- Hook Management -----
        private void InstallHook()
        {
            if (_isHookInstalled) return;
            _mouseProc = MouseHookCallback;
            using (var process = Process.GetCurrentProcess())
            using (var module = process.MainModule)
            {
                _mouseHookHandle = SetWindowsHookEx(WH_MOUSE_LL, _mouseProc,
                    GetModuleHandle(module.ModuleName), 0);
            }
            if (_mouseHookHandle == IntPtr.Zero)
            {
                int error = Marshal.GetLastWin32Error();
                Log($"Failed to install mouse hook. Error code: {error}", "ERROR");
            }
            else
            {
                _isHookInstalled = true;
                Log("Mouse hook installed successfully", "INFO");
            }
        }
        private void UninstallHook()
        {
            if (!_isHookInstalled || _mouseHookHandle == IntPtr.Zero) return;
            UnhookWindowsHookEx(_mouseHookHandle);
            _mouseHookHandle = IntPtr.Zero;
            _isHookInstalled = false;
            Log("Mouse hook uninstalled", "INFO");
        }
        private IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && _isEnabled)
            {
                try
                {
                    int message = wParam.ToInt32();
                    var hookStruct = Marshal.PtrToStructure<MSLLHOOKSTRUCT>(lParam);
                    if (message == WM_MOUSEMOVE)
                        ProcessMouseMove(new Point(hookStruct.pt.x, hookStruct.pt.y));
                    else if (message == WM_LBUTTONDOWN || message == WM_RBUTTONDOWN || message == WM_MBUTTONDOWN)
                        ProcessMouseClick();
                }
                catch { }
            }
            return CallNextHookEx(_mouseHookHandle, nCode, wParam, lParam);
        }
        #endregion
        #region ----- Data Processing -----
        private void ProcessMouseMove(Point currentPosition)
        {
            lock (_lockData)
            {
                if (_lastMousePosition != Point.Empty)
                {
                    double dx = currentPosition.X - _lastMousePosition.X;
                    double dy = currentPosition.Y - _lastMousePosition.Y;
                    double distance = Math.Sqrt(dx * dx + dy * dy);
                    _accumulatedDistance += distance;
                }
                _lastMousePosition = currentPosition;
                _lastMoveTime = DateTime.UtcNow;
            }
        }
        private void ProcessMouseClick()
        {
            lock (_lockData)
            {
                _recentClicks.Enqueue(DateTime.UtcNow);
                _lastClickTime = DateTime.UtcNow;
            }
        }
        private void StartAnalysisThread()
        {
            _analysisThread = new Thread(AnalysisLoop) { IsBackground = true, Name = "MouseActivityAnalyzer" };
            _analysisThread.Start();
        }
        private void AnalysisLoop()
        {
            const int BUFFER_SIZE = 10;
            double[] velocityBuffer = new double[BUFFER_SIZE];
            int bufferIndex = 0;
            while (_isRunning)
            {
                try
                {
                    Thread.Sleep(500);
                    if (!_isEnabled) continue;
                    EnergyLevel newEnergy;
                    double avgVelocity;
                    int cpm;
                    lock (_lockData)
                    {
                        DateTime now = DateTime.UtcNow;
                        double elapsed = (now - _lastAnalysisTime).TotalSeconds;
                        if (elapsed < 0.1) elapsed = 0.5; // Fallback
                        _lastAnalysisTime = now;
                        double currentVelocity = _accumulatedDistance / elapsed;
                        _accumulatedDistance = 0;
                        velocityBuffer[bufferIndex] = currentVelocity;
                        bufferIndex = (bufferIndex + 1) % BUFFER_SIZE;
                        double sum = 0;
                        for (int i = 0; i < BUFFER_SIZE; i++) sum += velocityBuffer[i];
                        avgVelocity = sum / BUFFER_SIZE;
                        _averageVelocity = avgVelocity;
                        CleanupOldClicks();
                        _clicksPerMinute = _recentClicks.Count;
                        cpm = _clicksPerMinute;
                        TimeSpan timeSinceLastMove = now - _lastMoveTime;
                        TimeSpan timeSinceLastClick = now - _lastClickTime;
                        if (timeSinceLastMove.TotalSeconds > IDLE_TIMEOUT_SECONDS &&
                            timeSinceLastClick.TotalSeconds > IDLE_TIMEOUT_SECONDS)
                            newEnergy = EnergyLevel.Sleeping;
                        else
                            newEnergy = CalculateEnergyLevel(avgVelocity, cpm);
                        if (newEnergy != _currentEnergy)
                        {
                            _currentEnergy = newEnergy;
                            Log($"Energy level changed to: {newEnergy} (Velocity: {avgVelocity:F0} px/s, CPM: {cpm})", "INFO");
                            OnEnergyChanged?.Invoke(newEnergy, avgVelocity, cpm);
                        }
                    }
                }
                catch (Exception ex) { Log($"Analysis loop error: {ex.Message}", "ERROR"); }
            }
        }
        private EnergyLevel CalculateEnergyLevel(double velocity, int clicksPerMinute)
        {
            int velocityScore = velocity >= HIGH_ENERGY_VELOCITY ? 4 :
                               velocity >= MEDIUM_ENERGY_VELOCITY ? 2 :
                               velocity >= LOW_ENERGY_VELOCITY ? 1 : 0;
            int clickScore = clicksPerMinute >= HIGH_CLICKS_PER_MINUTE ? 4 :
                            clicksPerMinute >= MEDIUM_CLICKS_PER_MINUTE ? 2 :
                            clicksPerMinute > 0 ? 1 : 0;
            int totalScore = velocityScore + clickScore;
            return totalScore switch
            {
                >= 6 => EnergyLevel.Rush,
                >= 4 => EnergyLevel.Focused,
                >= 2 => EnergyLevel.Normal,
                _ => EnergyLevel.Relaxing
            };
        }
        #endregion
        #region ----- Helpers -----
        private void CleanupOldClicks()
        {
            DateTime cutoff = DateTime.UtcNow.AddSeconds(-60);
            while (_recentClicks.Count > 0 && _recentClicks.Peek() < cutoff)
            {
                _recentClicks.Dequeue();
            }
        }
        private static void Log(string message, string level = "INFO")
        {
            try
            {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                File.AppendAllText(LogPath, $"[{timestamp}] [MouseTracker] [{level}] {message}\r\n");
            }
            catch { }
        }
        #endregion
        #region ----- Dispose -----
        public void Dispose()
        {
            Stop();
            _analysisThread = null;
        }
        #endregion
    }
}
