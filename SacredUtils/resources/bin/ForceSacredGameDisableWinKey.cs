using Microsoft.Win32;
using NHotkey;
using NHotkey.Wpf;
using System;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Threading;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class ForceSacredGameDisableWinKey
    {
        private static DispatcherTimer _timer = new DispatcherTimer();

        public static void RegisterKeys()
        {
            if (AppSettings.ApplicationSettings.AutoRegisterHotKeyForWinKey)
            {
                HotkeyManager.Current.AddOrReplace("DisableWinKey", Key.U, ModifierKeys.Control, Disable);
                HotkeyManager.Current.AddOrReplace("EnableWinKey", Key.I, ModifierKeys.Control, Enable);
            }
        }

        private static void Enable(object sender, HotkeyEventArgs e) => Enable();

        private static void Disable(object sender, HotkeyEventArgs e) => Disable();

        public static void Disable()
        {
            RegistryKey key = null;
            RegistryKey key1 = null;
            RegistryKey key2 = null;
            RegistryKey key3 = null;

            byte[] binary = 
            {
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x03,
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x5B,
                0xE0,
                0x00,
                0x00,
                0x5C,
                0xE0,
                0x00,
                0x00,
                0x00,
                0x00
            };

            try
            {
                key = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\Keyboard Layout", true);
                key1 = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\Keyboard Layouts", true);
                key2 = Registry.LocalMachine.OpenSubKey("System\\Keyboard Layout", true);

                key.SetValue("Scancode Map", binary, RegistryValueKind.Binary);
                key1.SetValue("Scancode Map", binary, RegistryValueKind.Binary);
                key2.SetValue("Scancode Map", binary, RegistryValueKind.Binary);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString);
            }
            finally
            {
                key.Close();

                CheckAvailabilityProcess();
            }
        }

        private static void Enable()
        {
            RegistryKey key = null;
            RegistryKey key1 = null;
            RegistryKey key2 = null;

            try
            {
                key = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\Keyboard Layout", true);
                key1 = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\Keyboard Layouts", true);
                key2 = Registry.LocalMachine.OpenSubKey("System\\Keyboard Layout", true);

                key.DeleteValue("Scancode Map", true);
                key1.DeleteValue("Scancode Map", true);
                key2.DeleteValue("Scancode Map", true);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString);
            }
            finally
            {
                key.Close();
            }
        }

        private static void CheckAvailabilityProcess()
        {
            _timer.Interval = new TimeSpan(0, 0, AppSettings.ApplicationSettings.DelayCheckingSacredProcess);

            _timer.Tick += (s, e) =>
            {
                Process[] pname = Process.GetProcessesByName("Sacred");

                if (pname.Length == 0) { Enable(); _timer.Stop(); }
            };

            _timer.Start();
        }
    }
}
