using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using NHotkey;
using NHotkey.Wpf;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;

// ReSharper disable InconsistentNaming
#pragma warning disable 414
namespace SacredUtils.resources.bin
{
    public static class ForceSacredGameDisableWinKey
    {
        private static DispatcherTimer _timer = new DispatcherTimer();
        private static KeyboardHookListener m_KeyboardHookManager;
        private static bool m_leftwin;
        private static bool m_rightwin;

        public static void RegisterKeys()
        {
            if (AppSettings.ApplicationSettings.AutoRegisterHotKeyForWinKey)
            {
                HotkeyManager.Current.AddOrReplace("DisableWinKey", Key.U, ModifierKeys.Control, Disable);
                HotkeyManager.Current.AddOrReplace("EnableWinKey", Key.I, ModifierKeys.Control, Enable);
            }

            m_KeyboardHookManager = new KeyboardHookListener(new GlobalHooker());
            m_KeyboardHookManager.KeyDown += hookManager_keyDown;
        }

        private static void hookManager_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LWin) e.Handled = true;
            if (e.KeyCode == Keys.RWin) e.Handled = true;
            if (e.KeyCode == Keys.LWin) m_leftwin = true;
            if (e.KeyCode == Keys.RWin) m_rightwin = true;
        }

        private static void Enable(object sender, HotkeyEventArgs e) => Enable(true);

        private static void Disable(object sender, HotkeyEventArgs e) => Disable();

        public static void Disable() { m_KeyboardHookManager.Enabled = true; CheckAvailabilityProcess(); }

        private static void Enable(bool force)
        {
            if (force)
            {
                m_KeyboardHookManager.Enabled = false;
            }
            else
            {
                m_KeyboardHookManager.Enabled = false;
                m_KeyboardHookManager.Dispose();
            }
        }

        private static void CheckAvailabilityProcess()
        {
            _timer.Interval = new TimeSpan(0, 0, AppSettings.ApplicationSettings.DelayCheckingSacredProcess);

            _timer.Tick += (s, e) =>
            {
                Process[] pname = Process.GetProcessesByName("Sacred");

                if (pname.Length == 0) { Enable(false); _timer.Stop(); }
            };

            _timer.Start();
        }
    }
}
