using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;
using EnumsNET;
using NHotkey;
using NHotkey.Wpf;
using SacredUtils.resources.bin;
using SacredUtils.SourceFiles.utils;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;

// ReSharper disable InconsistentNaming
namespace SacredUtils.SourceFiles.bin
{
    public static class ApplicationStartEmulateHotkeys
    {
        private static readonly IntPtr hWndSacred = NativeMethods.FindWindow(Settings.HWndSacredWindowClassId, null);
        private static readonly string[] registerHotKeyList = File.ReadAllLines("$SacredUtils\\conf\\hk.regr.txt");

        public static void RegisterMainHotkeys()
        {
            HotkeyManager.Current.AddOrReplace("EnableHandling", Key.E, ModifierKeys.Shift | ModifierKeys.Control, EnableHotkeys);
            HotkeyManager.Current.AddOrReplace("DisableHandling", Key.D, ModifierKeys.Shift | ModifierKeys.Control, DisableHotkeys);

            Logger.Log.Info("Register global application MainHotkey successfully done!");
            Thread.Sleep(Settings.HotKeyRegisterGameDelay);
            RegisterHotkeys();
        }

        private static void RegisterHotkeys()
        {
            try
            {
                foreach (string keyName in registerHotKeyList)
                {
                    Enums.TryParse(keyName, out Key registerKey);

                    HotkeyManager.Current.AddOrReplace(keyName, registerKey, ModifierKeys.None, HandleHotKeys);
                    Logger.Log.Info($"Register global game {keyName} hotkey successfully done!");
                }

                Logger.Log.Info("Register all global game hotkeys successfully done!");
                CheckAvailabilityProcess();
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.ToString);
            }
        }

        private static void HandleHotKeys(object sender, HotkeyEventArgs e)
        {
            NativeMethods.SetForegroundWindow(hWndSacred);

            if (Settings.UseSimplifiedHotKeySettings)
            {
                SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get($" = {e.Name}"));

                e.Handled = Settings.HotKeyEventArgsGameHandled;
            }
            else
            {
                PropertyInfo propertyInfo = HotkeySettings.GameHotkeySettings.GetType().GetProperty($"Key{e.Name}");

                if ((string) propertyInfo?.GetValue(HotkeySettings.GameHotkeySettings) == "None")
                {
                    SendKeys.SendWait(""); 
                }
                else
                {
                    SendKeys.SendWait((string)propertyInfo?.GetValue(HotkeySettings.GameHotkeySettings)); 
                }

                e.Handled = Settings.HotKeyEventArgsGameHandled;
            }
        }

        private static void CheckAvailabilityProcess()
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, Settings.DelayCheckingSacredProcess)
            };

            timer.Tick += (s, e) =>
            {
                Process[] pname = Process.GetProcessesByName("Sacred");

                if (pname.Length == 0) { DisableHotkeyHandle(); timer.Stop(); }
            };

            timer.Start();
        }
        
        private static void DisableHotkeyHandle()
        {
            try
            {
                foreach (string keyName in registerHotKeyList)
                {
                    HotkeyManager.Current.Remove(keyName);
                    Logger.Log.Info($"Unregister global game {keyName} hotkey successfully done!");
                }

                Logger.Log.Info("Shutting down all global game hotkeys done!");
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.ToString);
            }
        }

        private static void DisableHotkeys(object sender, HotkeyEventArgs e) => DisableHotkeyHandle();

        private static void EnableHotkeys(object sender, HotkeyEventArgs e) => RegisterHotkeys();
    }
}
