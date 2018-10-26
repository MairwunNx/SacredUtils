using NHotkey;
using NHotkey.Wpf;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;

// ReSharper disable InconsistentNaming
namespace SacredUtils.resources.bin
{
    public static class ApplicationStartEmulateHotkeys
    {
        private const int WM_KEYUP = 0x0101;

        private static readonly IntPtr hWndSacred = NativeMethods.FindWindow(AppSettings.ApplicationSettings.hWndSacred, null);

        public static void RegisterMainHotkeys()
        {
            HotkeyManager.Current.AddOrReplace("EnableHandling", Key.E, ModifierKeys.Shift | ModifierKeys.Control, EnableHotkeys);
            HotkeyManager.Current.AddOrReplace("DisableHandling", Key.D, ModifierKeys.Shift | ModifierKeys.Control, DisableHotkeys);

            AppLogger.Log.Info("Register global application MainHotkey successfully done!");

            RegisterHotkeys();
        }

        private static void RegisterHotkeys()
        {
            try
            {
                HotkeyManager.Current.AddOrReplace("Q", Key.Q, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game Q hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("W", Key.W, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game W hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("E", Key.E, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game E hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("R", Key.R, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game R hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("T", Key.T, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game T hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("Y", Key.Y, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game Y hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("U", Key.U, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game U hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("I", Key.I, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game I hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("O", Key.O, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game O hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("P", Key.P, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game P hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("A", Key.A, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game A hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("S", Key.S, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game S hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("D", Key.D, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game D hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("F", Key.F, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game F hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("G", Key.G, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game G hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("H", Key.H, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game H hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("J", Key.J, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game J hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("K", Key.K, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game K hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("L", Key.L, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game L hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("Z", Key.Z, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game Z hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("X", Key.X, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game X hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("C", Key.C, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game C hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("V", Key.V, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game V hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("B", Key.B, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game B hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("N", Key.N, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game N hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("M", Key.M, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game M hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("SPACE", Key.Space, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game Space hotkey successfully done!");

                AppLogger.Log.Info("Register all global game hotkeys successfully done!");

                CheckAvailabilityProcess();
            }
            catch (Exception e)
            {
                AppLogger.Log.Error(e.ToString);
            }
        }

        private static void DisableHotkeys(object sender, HotkeyEventArgs e)
        {
            DisableHotkeyHandle();
        }

        private static void EnableHotkeys(object sender, HotkeyEventArgs e)
        {
            RegisterHotkeys();
        }

        private static void HandleHotKeys(object sender, HotkeyEventArgs e)
        {
            try
            {
                if (e.Name == "Q")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyQ, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyQ} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "W")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyW, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyW} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "E")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyE, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyE} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "R")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyR, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyR} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "T")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyT, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyT} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "Y")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyY, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyY} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "U")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyU, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyU} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "I")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyI, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyI} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "O")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyO, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyO} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "P")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyP, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyP} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "A")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyA, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyA} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "S")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyS, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyS} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "D")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyD, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyD} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "F")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyF, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyF} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "G")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyG, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyG} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "H")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyH, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyH} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "J")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyJ, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyJ} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "K")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyK, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyK} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "L")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyL, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyL} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "Z")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyZ, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyZ} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "X")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyX, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyX} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "C")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyC, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyC} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "V")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyV, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyV} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "B")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyB, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyN} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "M")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeyM, out Keys key);

                    switch (key)
                    {
                        case Keys.Space: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, Keys.Space, IntPtr.Zero); break;
                        default: NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero); break;
                    }

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyM} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "SPACE")
                {
                    Enum.TryParse(HotkeySettings.GameHotkeySettings.KeySpace, out Keys key);

                    NativeMethods.PostMessage(hWndSacred, WM_KEYUP, key, IntPtr.Zero);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeySpace} successfully sended to Sacred.exe window");

                     e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }
            }
            catch (Exception exception)
            {
                AppLogger.Log.Error(exception.ToString);
            }
        }

        private static void CheckAvailabilityProcess()
        {
            DispatcherTimer timer = new DispatcherTimer();

            timer.Interval = new TimeSpan(0, 0, AppSettings.ApplicationSettings.DelayCheckingSacredProcess);

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
                HotkeyManager.Current.Remove("Q");
                HotkeyManager.Current.Remove("W");
                HotkeyManager.Current.Remove("E");
                HotkeyManager.Current.Remove("R");
                HotkeyManager.Current.Remove("T");
                HotkeyManager.Current.Remove("Y");
                HotkeyManager.Current.Remove("U");
                HotkeyManager.Current.Remove("I");
                HotkeyManager.Current.Remove("O");
                HotkeyManager.Current.Remove("P");
                HotkeyManager.Current.Remove("A");
                HotkeyManager.Current.Remove("S");
                HotkeyManager.Current.Remove("D");
                HotkeyManager.Current.Remove("F");
                HotkeyManager.Current.Remove("G");
                HotkeyManager.Current.Remove("H");
                HotkeyManager.Current.Remove("J");
                HotkeyManager.Current.Remove("K");
                HotkeyManager.Current.Remove("L");
                HotkeyManager.Current.Remove("Z");
                HotkeyManager.Current.Remove("X");
                HotkeyManager.Current.Remove("C");
                HotkeyManager.Current.Remove("V");
                HotkeyManager.Current.Remove("B");
                HotkeyManager.Current.Remove("N");
                HotkeyManager.Current.Remove("M");
                HotkeyManager.Current.Remove("SPACE");

                AppLogger.Log.Info("Shutting down all global game hotkeys done!");
            }
            catch (Exception e)
            {
                AppLogger.Log.Error(e.ToString);
            }
        }
    }
}
