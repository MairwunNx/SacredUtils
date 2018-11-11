using SacredUtils.resources.bin;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using static SacredUtils.AppLogger;
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
                    if (File.Exists(AppSettings.ApplicationSettings.SacredExecutableFileName))
                    {
                        AboutDialog.IsOpen = false;

                        Log.Info($"Starting {AppSettings.ApplicationSettings.SacredExecutableFileName} game file with arg CHEATS=1 ...");
                        
                        Process.Start(AppSettings.ApplicationSettings.SacredExecutableFileName, "CHEATS=1");

                        EnableSwitchingLanguage();

                        EnableStretchingScreenshot();

                        EnableEmulateHotkeys();

                        EnableDisablingWinKey();
                    }
                    else
                    {
                        Log.Error($"{AppSettings.ApplicationSettings.SacredExecutableFileName} file not found! Move application to game directory!");
                    }
                }
                else
                {
                    if (File.Exists(AppSettings.ApplicationSettings.SacredExecutableFileName))
                    {
                        AboutDialog.IsOpen = false;

                        Log.Info($"Starting {AppSettings.ApplicationSettings.SacredExecutableFileName} game file ...");

                        Process.Start(AppSettings.ApplicationSettings.SacredExecutableFileName);

                        EnableSwitchingLanguage();

                        EnableStretchingScreenshot();

                        EnableEmulateHotkeys();

                        EnableDisablingWinKey();
                    }
                    else
                    {
                        Log.Error($"{AppSettings.ApplicationSettings.SacredExecutableFileName} file not found! Move application to game directory!");
                    }
                }
            }
            else if (AppSettings.ApplicationSettings.SacredStartArgs == 1)
            {
                if (RunWithCheatsCmbBox.IsChecked == true)
                {
                    if (File.Exists(AppSettings.ApplicationSettings.SacredExecutableFileName))
                    {
                        AboutDialog.IsOpen = false;

                        Log.Info("Param selected: Minimizing SacredUtils application ...");

                        MainWindow.WindowState = WindowState.Minimized;

                        Log.Info($"Starting {AppSettings.ApplicationSettings.SacredExecutableFileName} game file with arg CHEATS=1 ...");

                        Process.Start(AppSettings.ApplicationSettings.SacredExecutableFileName, "CHEATS=1");

                        EnableSwitchingLanguage();

                        EnableStretchingScreenshot();

                        EnableEmulateHotkeys();

                        EnableDisablingWinKey();
                    }
                    else
                    {
                        Log.Error($"{AppSettings.ApplicationSettings.SacredExecutableFileName} file not found! Move application to game directory!");
                    }
                }
                else
                {
                    if (File.Exists(AppSettings.ApplicationSettings.SacredExecutableFileName))
                    {
                        AboutDialog.IsOpen = false;

                        Log.Info("Param selected: Minimizing SacredUtils application ...");

                        MainWindow.WindowState = WindowState.Minimized;

                        Log.Info($"Starting {AppSettings.ApplicationSettings.SacredExecutableFileName} game file ...");

                        Process.Start(AppSettings.ApplicationSettings.SacredExecutableFileName);

                        EnableSwitchingLanguage();

                        EnableStretchingScreenshot();

                        EnableEmulateHotkeys();

                        EnableDisablingWinKey();
                    }
                    else
                    {
                        Log.Error($"{AppSettings.ApplicationSettings.SacredExecutableFileName} file not found! Move application to game directory!");
                    }
                }
            }
            else if (AppSettings.ApplicationSettings.SacredStartArgs == 0)
            {
                if (RunWithCheatsCmbBox.IsChecked == true)
                {
                    if (File.Exists(AppSettings.ApplicationSettings.SacredExecutableFileName))
                    {
                        Log.Info($"Starting {AppSettings.ApplicationSettings.SacredExecutableFileName} game file with arg CHEATS=1 ...");

                        Process.Start(AppSettings.ApplicationSettings.SacredExecutableFileName, "CHEATS=1");

                        Log.Info("Param selected: Force shutting down SacredUtils ...");

                        Environment.Exit(0);
                    }
                    else
                    {
                        Log.Error($"{AppSettings.ApplicationSettings.SacredExecutableFileName} file not found! Move application to game directory!");
                    }
                }
                else
                {
                    if (File.Exists(AppSettings.ApplicationSettings.SacredExecutableFileName))
                    {
                        Log.Info($"Starting {AppSettings.ApplicationSettings.SacredExecutableFileName} game file ...");

                        Process.Start(AppSettings.ApplicationSettings.SacredExecutableFileName);

                        Log.Info("Param selected: Force shutting down SacredUtils ...");

                        Environment.Exit(0);
                    }
                    else
                    {
                        Log.Error($"{AppSettings.ApplicationSettings.SacredExecutableFileName} file not found! Move application to game directory!");
                    }
                }
            }
        }

        private void EnableSwitchingLanguage()
        {
            if (RunWithEngLangCmbBox.IsChecked == true)
            {
                Log.Info("Sacred starting with enabled force switching language ...");

                ForceSwitchKeyboardLanguageInGame.RegisterApplication();
            }
        }

        private void EnableStretchingScreenshot()
        { 
            if (RunWithScreenCmbBox.IsChecked == true)
            {
                if (AppSettings.ApplicationSettings.ForceEnableFullScreenMode)
                {
                    MainWindow.GraphicsStgTwo.FullScreenMode.IsChecked = true;
                }

                Log.Info($"Sacred Screenshots starting with {MainWindow.ScreenWidthDevice}x{MainWindow.ScreenHeightDevice} resolution ...");

                ForceStretchSacredGameScreenshot.RegisterKey(false);
            }
        }
        
        private void EnableEmulateHotkeys()
        {
            if (RunWithHotkeysCmbBox.IsChecked == true)
            {
                Log.Info("Sacred starting with enabled hotkeys emulation ...");

                ApplicationStartEmulateHotkeys.RegisterMainHotkeys();
            }
        }

        private void EnableDisablingWinKey()
        {
            if (RunWithDisabledWinKeyCmbBox.IsChecked == true)
            {
                Log.Info("Sacred starting with disabled win key ...");

                ForceSacredGameDisableWinKey.RegisterKeys();

                ForceSacredGameDisableWinKey.Disable();
            }
        }

        private void CancelLaunchBtn_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog.IsOpen = false;

            Log.Info("Sacred starting canceled by user");
        }

        // ApplicationStartEmulateHotkeys.RegisterMainHotkeys();
    }
}
