using NHotkey;
using NHotkey.Wpf;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;

namespace SacredUtils.resources.bin
{
    public static class ApplicationStartEmulateHotkeys
    {
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("USER32.DLL")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void RegisterMainHotkeys()
        {
            HotkeyManager.Current.AddOrReplace("EnableHandling", Key.E, ModifierKeys.Shift | ModifierKeys.Control, EnableHotkeys);
            HotkeyManager.Current.AddOrReplace("DisableHandling", Key.D, ModifierKeys.Shift | ModifierKeys.Control, DisableHotkeys);

            AppLogger.Log.Info("Register global application MainHotkey successfully done!");

            RegisterHotkeys();
        }

        public static void RegisterHotkeys()
        {
            try
            {
                HotkeyManager.Current.AddOrReplace("F1", Key.F1, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game F1 hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("F2", Key.F2, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game F2 hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("F3", Key.F3, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game F3 hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("F4", Key.F4, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game F4 hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("F5", Key.F5, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game F5 hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("F6", Key.F6, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game F6 hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("F7", Key.F7, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game F7 hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("F8", Key.F8, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game F8 hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("F9", Key.F9, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game F9 hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("F10", Key.F10, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game F10 hotkey successfully done!");
                HotkeyManager.Current.AddOrReplace("F11", Key.F11, ModifierKeys.None, HandleHotKeys);
                AppLogger.Log.Info("Register global game F11 hotkey successfully done!");
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
            if (e.Name == "F1")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF1);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyF1} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "F2")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF2);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyF2} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "F3")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF3);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyF3} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "F4")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF4);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyF4} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "F5")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF5);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyF5} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "F6")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF6);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyF6} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "F7")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF7);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyF7} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "F8")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF8);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyF8} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "F9")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF9);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyF9} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "F10")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF10);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyF10} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "F11")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF11);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyF11} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "Q")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyQ);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyQ} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "W")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyW);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyW} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "E")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyE);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyE} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "R")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyR);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyR} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "T")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyT);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyT} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "Y")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyY);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyY} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "U")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyU);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyU} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "I")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyI);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyI} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "O")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyO);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyO} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "P")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyP);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyP} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "A")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyA);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyA} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "S")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyS);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyS} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "D")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyD);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyD} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "F")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyF} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "G")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyG);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyG} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "H")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyH);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyH} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "J")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyJ);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyJ} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "K")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyK);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyK} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "L")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyL);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyL} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "Z")
            {
                try
                {
                    IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                    SetForegroundWindow(sacredhandle);

                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyZ);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyZ} successfully sended to Sacred.exe window");
                }
                catch (Exception exception)
                {
                    AppLogger.Log.Fatal(exception.ToString);
                }

                e.Handled = false;
            }

            if (e.Name == "X")
            {
                try
                {
                    IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                    SetForegroundWindow(sacredhandle);

                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyX);

                    AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyX} successfully sended to Sacred.exe window");

                    e.Handled = false;
                }
                catch (Exception exception)
                {
                    AppLogger.Log.Error(exception.ToString);
                }

            }

            if (e.Name == "C")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyC);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyC} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "V")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyV);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyV} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "B")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyN);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyN} successfully sended to Sacred.exe window");

                e.Handled = false;
            }

            if (e.Name == "M")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyM);

                AppLogger.Log.Info($"Key {HotkeySettings.GameHotkeySettings.KeyM} successfully sended to Sacred.exe window");

                e.Handled = false;
            }
        }

        private static void CheckAvailabilityProcess()
        {
            DispatcherTimer timer = new DispatcherTimer();

            timer.Interval = new TimeSpan(0, 0, AppSettings.ApplicationSettings.DelayCheckingSacredProcess);

            timer.Tick += (s, e) =>
            {
                Process[] pname = Process.GetProcessesByName("Sacred");

                if (pname.Length == 0) { DisableHotkeyHandle(); }
            };

            timer.Start();
        }
        
        private static void DisableHotkeyHandle()
        {
            try
            {
                HotkeyManager.Current.Remove("F1");
                HotkeyManager.Current.Remove("F2");
                HotkeyManager.Current.Remove("F3");
                HotkeyManager.Current.Remove("F4");
                HotkeyManager.Current.Remove("F5");
                HotkeyManager.Current.Remove("F6");
                HotkeyManager.Current.Remove("F7");
                HotkeyManager.Current.Remove("F8");
                HotkeyManager.Current.Remove("F9");
                HotkeyManager.Current.Remove("F10");
                HotkeyManager.Current.Remove("F11");
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
