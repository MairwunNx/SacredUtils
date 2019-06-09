using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using SacredUtils.SourceFiles.bin;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;

namespace SacredUtils.SourceFiles.dlg
{
    public partial class ApplicationRunSacredDialog
    {
        public ApplicationRunSacredDialog() => InitializeComponent();

        private void LaunchSacredBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.SacredStartArgs == 2)
            {
                if (RunWithCheatsCmbBox.IsChecked == true)
                {
                    if (File.Exists(Settings.SacredExecutableFileName))
                    {
                        BaseDialog.IsOpen = false;

                        Logger.Log.Info($"Starting {Settings.SacredExecutableFileName} game file with arg CHEATS=1 ...");
                        
                        Process.Start(Settings.SacredExecutableFileName, "CHEATS=1");

                        EnableSwitchingLanguage();

                        EnableStretchingScreenshot();

                        EnableEmulateHotkeys();

                        EnableDisablingWinKey();
                    }
                    else
                    {
                        Logger.Log.Error($"{Settings.SacredExecutableFileName} file not found! Move application to game directory!");
                    }
                }
                else
                {
                    if (File.Exists(Settings.SacredExecutableFileName))
                    {
                        BaseDialog.IsOpen = false;

                        Logger.Log.Info($"Starting {Settings.SacredExecutableFileName} game file ...");

                        Process.Start(Settings.SacredExecutableFileName);

                        EnableSwitchingLanguage();

                        EnableStretchingScreenshot();

                        EnableEmulateHotkeys();

                        EnableDisablingWinKey();
                    }
                    else
                    {
                        Logger.Log.Error($"{Settings.SacredExecutableFileName} file not found! Move application to game directory!");
                    }
                }
            }
            else if (Settings.SacredStartArgs == 1)
            {
                if (RunWithCheatsCmbBox.IsChecked == true)
                {
                    if (File.Exists(Settings.SacredExecutableFileName))
                    {
                        BaseDialog.IsOpen = false;

                        Logger.Log.Info("Param selected: Minimizing SacredUtils application ...");

                        MainWindow.MainWindowInstance.WindowState = WindowState.Minimized;

                        Logger.Log.Info($"Starting {Settings.SacredExecutableFileName} game file with arg CHEATS=1 ...");

                        Process.Start(Settings.SacredExecutableFileName, "CHEATS=1");

                        EnableSwitchingLanguage();

                        EnableStretchingScreenshot();

                        EnableEmulateHotkeys();

                        EnableDisablingWinKey();
                    }
                    else
                    {
                        Logger.Log.Error($"{Settings.SacredExecutableFileName} file not found! Move application to game directory!");
                    }
                }
                else
                {
                    if (File.Exists(Settings.SacredExecutableFileName))
                    {
                        BaseDialog.IsOpen = false;

                        Logger.Log.Info("Param selected: Minimizing SacredUtils application ...");

                        MainWindow.MainWindowInstance.WindowState = WindowState.Minimized;

                        Logger.Log.Info($"Starting {Settings.SacredExecutableFileName} game file ...");

                        Process.Start(Settings.SacredExecutableFileName);

                        EnableSwitchingLanguage();

                        EnableStretchingScreenshot();

                        EnableEmulateHotkeys();

                        EnableDisablingWinKey();
                    }
                    else
                    {
                        Logger.Log.Error($"{Settings.SacredExecutableFileName} file not found! Move application to game directory!");
                    }
                }
            }
            else if (Settings.SacredStartArgs == 0)
            {
                if (RunWithCheatsCmbBox.IsChecked == true)
                {
                    if (File.Exists(Settings.SacredExecutableFileName))
                    {
                        Logger.Log.Info($"Starting {Settings.SacredExecutableFileName} game file with arg CHEATS=1 ...");

                        Process.Start(Settings.SacredExecutableFileName, "CHEATS=1");

                        Logger.Log.Info("Param selected: Force shutting down SacredUtils ...");

                        Environment.Exit(0);
                    }
                    else
                    {
                        Logger.Log.Error($"{Settings.SacredExecutableFileName} file not found! Move application to game directory!");
                    }
                }
                else
                {
                    if (File.Exists(Settings.SacredExecutableFileName))
                    {
                        Logger.Log.Info($"Starting {Settings.SacredExecutableFileName} game file ...");

                        Process.Start(Settings.SacredExecutableFileName);

                        Logger.Log.Info("Param selected: Force shutting down SacredUtils ...");

                        Environment.Exit(0);
                    }
                    else
                    {
                        Logger.Log.Error($"{Settings.SacredExecutableFileName} file not found! Move application to game directory!");
                    }
                }
            }
        }

        private void EnableSwitchingLanguage()
        {
            if (RunWithEngLangCmbBox.IsChecked != true) { return; }

            Logger.Log.Info("Sacred starting with enabled force switching language ...");

            ForceSwitchKeyboardLanguageInGame.RegisterApplication();
        }

        private void EnableStretchingScreenshot()
        { 
            if (RunWithScreenCmbBox.IsChecked != true) { return; }

            if (Settings.ForceEnableFullScreenMode)
            {
                MainWindow.GraphicsStgTwo.FullScreenMode.IsChecked = true;
            }
            
            ForceStretchSacredGameScreenshot.RegisterKey(false);
        }
        
        private void EnableEmulateHotkeys()
        {
            if (RunWithHotkeysCmbBox.IsChecked != true) { return; }

            Logger.Log.Info("Sacred starting with enabled hotkeys emulation ...");

            ApplicationStartEmulateHotkeys.RegisterMainHotkeys();
        }

        private void EnableDisablingWinKey()
        {
            if (RunWithDisabledWinKeyCmbBox.IsChecked != true) { return; }

            Logger.Log.Info("Sacred starting with disabled win key ...");

            ForceSacredGameDisableWinKey.RegisterKeys();

            ForceSacredGameDisableWinKey.Disable();
        }

        private void CancelLaunchBtn_Click(object sender, RoutedEventArgs e) => BaseDialog.IsOpen = false;
    }
}
