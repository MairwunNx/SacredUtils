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

            RegisterHotkeys();
        }

        public static void RegisterHotkeys()
        {
            try
            {
                HotkeyManager.Current.AddOrReplace("F1", Key.F1, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("F2", Key.F2, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("F3", Key.F3, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("F4", Key.F4, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("F5", Key.F5, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("F6", Key.F6, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("F7", Key.F7, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("F8", Key.F8, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("F9", Key.F9, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("F10", Key.F10, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("F11", Key.F11, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("Q", Key.Q, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("W", Key.W, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("E", Key.E, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("R", Key.R, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("T", Key.T, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("Y", Key.Y, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("U", Key.U, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("I", Key.I, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("O", Key.O, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("P", Key.P, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("A", Key.A, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("S", Key.S, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("D", Key.D, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("F", Key.F, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("G", Key.G, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("H", Key.H, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("J", Key.J, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("K", Key.K, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("L", Key.L, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("Z", Key.Z, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("X", Key.X, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("C", Key.C, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("V", Key.V, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("B", Key.B, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("N", Key.N, ModifierKeys.None, HandleHotKeys);
                HotkeyManager.Current.AddOrReplace("M", Key.M, ModifierKeys.None, HandleHotKeys);

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

                e.Handled = false;
            }

            if (e.Name == "F2")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF2);

                e.Handled = false;
            }

            if (e.Name == "F3")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF3);

                e.Handled = false;
            }

            if (e.Name == "F4")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF4);

                e.Handled = false;
            }

            if (e.Name == "F5")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF5);

                e.Handled = false;
            }

            if (e.Name == "F6")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF6);

                e.Handled = false;
            }

            if (e.Name == "F7")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF7);

                e.Handled = false;
            }

            if (e.Name == "F8")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF8);

                e.Handled = false;
            }

            if (e.Name == "F9")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF9);

                e.Handled = false;
            }

            if (e.Name == "F10")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF10);

                e.Handled = false;
            }

            if (e.Name == "F11")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF11);

                e.Handled = false;
            }

            if (e.Name == "Q")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyQ);

                e.Handled = false;
            }

            if (e.Name == "W")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyW);

                e.Handled = false;
            }

            if (e.Name == "E")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyE);

                e.Handled = false;
            }

            if (e.Name == "R")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyR);

                e.Handled = false;
            }

            if (e.Name == "T")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyT);

                e.Handled = false;
            }

            if (e.Name == "Y")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyY);

                e.Handled = false;
            }

            if (e.Name == "U")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyU);

                e.Handled = false;
            }

            if (e.Name == "I")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyI);

                e.Handled = false;
            }

            if (e.Name == "O")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyO);

                e.Handled = false;
            }

            if (e.Name == "P")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyP);

                e.Handled = false;
            }

            if (e.Name == "A")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyA);

                e.Handled = false;
            }

            if (e.Name == "S")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyS);

                e.Handled = false;
            }

            if (e.Name == "D")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyD);

                e.Handled = false;
            }

            if (e.Name == "F")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyF);

                e.Handled = false;
            }

            if (e.Name == "G")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyG);

                e.Handled = false;
            }

            if (e.Name == "H")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyH);

                e.Handled = false;
            }

            if (e.Name == "J")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyJ);

                e.Handled = false;
            }

            if (e.Name == "K")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyK);

                e.Handled = false;
            }

            if (e.Name == "L")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyL);

                e.Handled = false;
            }

            if (e.Name == "Z")
            {
                try
                {
                    IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                    SetForegroundWindow(sacredhandle);

                    SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyZ);
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

                e.Handled = false;
            }

            if (e.Name == "V")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyV);

                e.Handled = false;
            }

            if (e.Name == "B")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyN);

                e.Handled = false;
            }

            if (e.Name == "M")
            {
                IntPtr sacredhandle = FindWindow("Sacred", "Sacred");

                SetForegroundWindow(sacredhandle);

                SendKeys.SendWait(HotkeySettings.GameHotkeySettings.KeyM);

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
            }
            catch (Exception e)
            {
                AppLogger.Log.Error(e.ToString);
            }
        }
    }
}
