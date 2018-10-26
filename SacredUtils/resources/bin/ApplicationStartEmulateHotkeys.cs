using NHotkey;
using NHotkey.Wpf;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;

// ReSharper disable InconsistentNaming
namespace SacredUtils.resources.bin
{
    public static class ApplicationStartEmulateHotkeys
    {
        private static readonly IntPtr hWndSacred = NativeMethods.FindWindow(AppSettings.ApplicationSettings.hWndSacred, null);

        public static void RegisterMainHotkeys()
        {
            HotkeyManager.Current.AddOrReplace("EnableHandling", Key.E, ModifierKeys.Shift | ModifierKeys.Control, EnableHotkeys);
            HotkeyManager.Current.AddOrReplace("DisableHandling", Key.D, ModifierKeys.Shift | ModifierKeys.Control, DisableHotkeys);

            AppLogger.Log.Info("Register global application MainHotkey successfully done!");

            Thread.Sleep(1000);

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
                NativeMethods.SetForegroundWindow(hWndSacred);

                if (e.Name == "Q")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyQ == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyQ);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyQ} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "W")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyW == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyW);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyW} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "E")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyE == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyE);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyE} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "R")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyR == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyR);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyR} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "T")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyT == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyT);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyT} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "Y")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyY == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyY);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyY} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "U")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyU == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyU);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyU} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "I")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyI == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyI);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyI} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "O")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyO == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyO);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyO} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "P")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyP == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyP);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyP} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "A")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyA == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyA);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyA} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "S")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyS == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyS);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyS} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "D")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyD == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyD);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyD} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "F")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyF);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyF} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "G")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyG == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyG);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyG} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "H")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyH == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyH);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyH} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "J")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyJ == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyJ);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyJ} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "K")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyK == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyK);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyK} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "L")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyL == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyL);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyL} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "Z")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyZ == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyZ);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyZ} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "X")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyX == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyX);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyX} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "C")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyC == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyC);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyC} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "V")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyV == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyV);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyV} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "B")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyB == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyB);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyN} successfully sended to Sacred.exe window");

                    e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                }

                if (e.Name == "M")
                {
                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyM == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyM);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyM} successfully sended to Sacred.exe window");

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

                AppLogger.Log.Info("Shutting down all global game hotkeys done!");
            }
            catch (Exception e)
            {
                AppLogger.Log.Error(e.ToString);
            }
        }
    }
}
