using SacredUtils.resources.bin;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using Application = System.Windows.Application;

namespace SacredUtils.resources.dlg
{
    public partial class ApplicationRunSacredDialog
    {
        static readonly MainWindow MainWindow = (MainWindow)Application.Current.MainWindow;

        public ApplicationRunSacredDialog() => InitializeComponent();

        private void LaunchSacredBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AppSettings.ApplicationSettings.SacredStartArgs == 2)
            {
                if (RunWithCheatsCmbBox.IsChecked == true)
                {
                    if (File.Exists("Sacred.exe"))
                    {
                        AboutDialog.IsOpen = false;

                        AppLogger.Log.Error("Starting Sacred.exe game file with arg CHEATS=1 ...");

                        Process.Start("Sacred.exe", "CHEATS=1");

                        EnableSwitchingLanguage();

                        EnableStretchingScreenshot();

                        EnableEmulateHotkeys();
                    }
                    else
                    {
                        AppLogger.Log.Error("Sacred.exe file not found! Move application to game directory!");
                    }
                }
                else
                {
                    if (File.Exists("Sacred.exe"))
                    {
                        AboutDialog.IsOpen = false;

                        AppLogger.Log.Error("Starting Sacred.exe game file ...");

                        Process.Start("Sacred.exe");

                        EnableSwitchingLanguage();

                        EnableStretchingScreenshot();

                        EnableEmulateHotkeys();
                    }
                    else
                    {
                        AppLogger.Log.Error("Sacred.exe file not found! Move application to game directory!");
                    }
                }
            }
            else if (AppSettings.ApplicationSettings.SacredStartArgs == 1)
            {
                if (RunWithCheatsCmbBox.IsChecked == true)
                {
                    if (File.Exists("Sacred.exe"))
                    {
                        AboutDialog.IsOpen = false;

                        AppLogger.Log.Error("Param selected: Minimizing SacredUtils application ...");

                        MainWindow.WindowState = WindowState.Minimized;

                        AppLogger.Log.Error("Starting Sacred.exe game file with arg CHEATS=1 ...");

                        Process.Start("Sacred.exe", "CHEATS=1");

                        EnableSwitchingLanguage();

                        EnableStretchingScreenshot();

                        EnableEmulateHotkeys();
                    }
                    else
                    {
                        AppLogger.Log.Error("Sacred.exe file not found! Move application to game directory!");
                    }
                }
                else
                {
                    if (File.Exists("Sacred.exe"))
                    {
                        AboutDialog.IsOpen = false;

                        AppLogger.Log.Error("Param selected: Minimizing SacredUtils application ...");

                        MainWindow.WindowState = WindowState.Minimized;

                        AppLogger.Log.Error("Starting Sacred.exe game file ...");

                        Process.Start("Sacred.exe");

                        EnableSwitchingLanguage();

                        EnableStretchingScreenshot();

                        EnableEmulateHotkeys();
                    }
                    else
                    {
                        AppLogger.Log.Error("Sacred.exe file not found! Move application to game directory!");
                    }
                }
            }
            else if (AppSettings.ApplicationSettings.SacredStartArgs == 0)
            {
                //MessageBox.Show("Notification: The mode \"Close SU before launching the game\" does not allow to emulate hot keys, screenshots and language changes.");

                if (RunWithCheatsCmbBox.IsChecked == true)
                {
                    if (File.Exists("Sacred.exe"))
                    {
                        AppLogger.Log.Error("Starting Sacred.exe game file with arg CHEATS=1 ...");

                        Process.Start("Sacred.exe", "CHEATS=1");

                        Environment.Exit(0);
                    }
                    else
                    {
                        AppLogger.Log.Error("Sacred.exe file not found! Move application to game directory!");
                    }
                }
                else
                {
                    if (File.Exists("Sacred.exe"))
                    {
                        AppLogger.Log.Error("Starting Sacred.exe game file ...");

                        Process.Start("Sacred.exe");

                        Environment.Exit(0);
                    }
                    else
                    {
                        AppLogger.Log.Error("Sacred.exe file not found! Move application to game directory!");
                    }
                }
            }
        }

        private void EnableSwitchingLanguage()
        {
            if (RunWithEngLangCmbBox.IsChecked == true)
            {
                AppLogger.Log.Info("Sacred starting with enabled force switching language ...");

                ForceSwitchKeyboardLanguageInGame.RegisterApplication();
            }
        }

        private void EnableStretchingScreenshot()
        { 
            if (RunWithScreenCmbBox.IsChecked == true)
            {
                AppLogger.Log.Info($"Sacred Screenshots starting with {MainWindow.ScreenWidthDevice}x{MainWindow.ScreenHeightDevice} resolution ...");

                ForceStretchSacredGameScreenshot.RegisterKey(false);
            }
        }
        
        private void EnableEmulateHotkeys()
        {
            if (RunWithHotkeysCmbBox.IsChecked == true)
            {
                AppLogger.Log.Info("Sacred starting with enabled hotkeys emulation ...");

                ApplicationStartEmulateHotkeys.RegisterMainHotkeys();
            }
        }

        private void CancelLaunchBtn_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog.IsOpen = false;

            AppLogger.Log.Info("Sacred starting canceled by user");
        }

        // ApplicationStartEmulateHotkeys.RegisterMainHotkeys();
    }
}
