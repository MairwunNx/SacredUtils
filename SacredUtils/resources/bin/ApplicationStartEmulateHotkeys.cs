using NHotkey;
using NHotkey.Wpf;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;
using static SacredUtils.AppLogger;

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

            Log.Info("Register global application MainHotkey successfully done!");

            Thread.Sleep(AppSettings.ApplicationSettings.HotKeyRegisterDelay);

            RegisterHotkeys();
        }

        private static void RegisterHotkeys()
        {
            try
            {
                HotkeyManager.Current.AddOrReplace("Q", Key.Q, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game Q hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("W", Key.W, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game W hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("E", Key.E, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game E hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("R", Key.R, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game R hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("T", Key.T, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game T hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("Y", Key.Y, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game Y hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("U", Key.U, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game U hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("I", Key.I, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game I hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("O", Key.O, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game O hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("P", Key.P, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game P hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("A", Key.A, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game A hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("S", Key.S, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game S hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("D", Key.D, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game D hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("F", Key.F, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game F hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("G", Key.G, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game G hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("H", Key.H, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game H hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("J", Key.J, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game J hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("K", Key.K, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game K hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("L", Key.L, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game L hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("Z", Key.Z, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game Z hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("X", Key.X, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game X hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("C", Key.C, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game C hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("V", Key.V, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game V hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("B", Key.B, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game B hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("N", Key.N, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game N hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("M", Key.M, ModifierKeys.None, HandleHotKeys);
                Log.Info("Register global game M hotkey successfully done!");

                Log.Info("Register all global game hotkeys successfully done!");

                CheckAvailabilityProcess();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString);
            }
        }

        private static void HandleHotKeys(object sender, HotkeyEventArgs e)
        {
            if (AppSettings.ApplicationSettings.UseSimplifiedHotKeySettings)
            {
                switch (e.Name)
                {
                    case "Q": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = Q")); break;
                    case "W": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = W")); break;
                    case "E": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = E")); break;
                    case "R": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = R")); break;
                    case "T": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = T")); break;
                    case "Y": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = Y")); break;
                    case "U": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = U")); break;
                    case "I": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = I")); break;
                    case "O": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = O")); break;
                    case "P": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = P")); break;
                    case "A": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = A")); break;
                    case "S": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = S")); break;
                    case "D": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = D")); break;
                    case "F": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = F")); break;
                    case "G": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = G")); break;
                    case "H": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = H")); break;
                    case "J": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = J")); break;
                    case "K": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = K")); break;
                    case "L": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = L")); break;
                    case "Z": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = Z")); break;
                    case "X": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = X")); break;
                    case "C": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = C")); break;
                    case "V": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = V")); break;
                    case "B": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = B")); break;
                    case "N": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = N")); break;
                    case "M": SendKeys.SendWait(ApplicationHotKeyGetSystemKeyValue.Get(" = M")); break;
                }

                e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
            }
            else
            {
                try
                {
                    NativeMethods.SetForegroundWindow(hWndSacred);

                    if (e.Name == "Q")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyQ == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyQ);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyQ} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "W")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyW == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyW);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyW} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "E")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyE == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyE);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyE} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "R")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyR == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyR);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyR} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "T")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyT == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyT);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyT} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "Y")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyY == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyY);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyY} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "U")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyU == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyU);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyU} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "I")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyI == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyI);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyI} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "O")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyO == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyO);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyO} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "P")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyP == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyP);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyP} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "A")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyA == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyA);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyA} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "S")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyS == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyS);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyS} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "D")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyD == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyD);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyD} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "F")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyF);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyF} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "G")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyG == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyG);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyG} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "H")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyH == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyH);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyH} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "J")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyJ == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyJ);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyJ} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "K")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyK == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyK);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyK} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "L")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyL == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyL);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyL} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "Z")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyZ == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyZ);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyZ} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "X")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyX == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyX);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyX} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "C")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyC == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyC);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyC} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "V")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyV == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyV);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyV} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "B")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyB == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyB);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyN} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }

                    if (e.Name == "M")
                    {
                        SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyM == "None" ? "" : HotkeySettings.GameHotkeySettings.KeyM);

                        Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyM} successfully sended to Sacred.exe window");

                        e.Handled = AppSettings.ApplicationSettings.HotKeyEventArgsHandled;
                    }
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString);
                }
            }
        }

        private static void CheckAvailabilityProcess()
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, AppSettings.ApplicationSettings.DelayCheckingSacredProcess)
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

                Log.Info("Shutting down all global game hotkeys done!");
            }
            catch (Exception e)
            {
                Log.Error(e.ToString);
            }
        }

        private static void DisableHotkeys(object sender, HotkeyEventArgs e) => DisableHotkeyHandle();

        private static void EnableHotkeys(object sender, HotkeyEventArgs e) => RegisterHotkeys();
    }
}
