using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using SacredUtils.resources.dlg;
using SacredUtils.SourceFiles;
using SacredUtils.SourceFiles.bin;
using SacredUtils.SourceFiles.utils;
using static SacredUtils.SourceFiles.Logger;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;
using Theme = SacredUtils.SourceFiles.theme.Theme;

// ReSharper disable LocalSuppression
namespace SacredUtils.resources.bin
{
    public static class ApplicationBaseWindowHotkeys
    {
        private static int _keyPresses;
        private static int _keyPressesStat;
        private static int _keyPressesChangeLog;

        public static void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Settings.KeyPushUserToMainMenu)
            {
                ChangeApplicationSelectionSettings.UnSelectSettings(
                    MainWindow.UnselectedStg
                );
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control &&
                e.Key == Settings.KeyOpenProgramLatestLogFile &&
                File.Exists("$SacredUtils\\logs\\latest.log"))
            {
                Process.Start(Settings.DefaultOpenLogFileProgram,
                    "$SacredUtils\\logs\\latest.log");
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control &&
                e.Key == Settings.KeyOpenProgramSettingFile &&
                File.Exists("$SacredUtils\\conf\\settings.json"))
            {
                Process.Start(Settings.DefaultOpenLogFileProgram,
                    "$SacredUtils\\conf\\settings.json");
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control &&
                e.Key == Settings.KeyOpenGameSettingsFile &&
                File.Exists(Settings.SacredConfigurationFile))
            {
                Process.Start(Settings.DefaultOpenLogFileProgram,
                    Settings.SacredConfigurationFile);
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control &&
                e.Key == Settings.KeyOpenProgramDirectory)
            {
                Process.Start(ApplicationInfo.CurrentPath);
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control &&
                e.Key == Settings.KeyReloadProgram)
            {
                ApplicationUtils.Reload();
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control &&
                e.Key == Settings.KeyShutdownProgram)
            {
                ApplicationUtils.Shutdown();
            }

            if (e.Key == Key.F5)
            {
                RefreshApplicationSettings.Refresh();
                Log.Info("Sacred game settings successfully reloaded!");
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.PageDown)
            {
                // force crash for testing crash-report code.
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed

                if (_keyPresses == 1) Convert.ToBoolean("1");
                else _keyPresses = 1;
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.L)
            {
                // it code get download statistic from SacredUtils stat server.

                if (_keyPressesStat == 1)
                {
                    _keyPressesStat = 0;
                    string downloadCount = ApplicationGetDownloadStatistics.Get();
                    string[] count = downloadCount.Split('{', '}');
                    MessageBox.Show(count[1].Replace("\"", "").Replace("SacredUtilsDownloads",
                        "SacredUtils Downloads Count"));
                }
                else
                {
                    _keyPressesStat = 1;
                }
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.I)
            {
                // it code open clear cache dialog host, for fixing some bugs. 

                if (_keyPressesStat == 1)
                {
                    _keyPressesStat = 0;
                    ApplicationClearComponentCache.SearchCacheFiles();
                }
                else
                {
                    _keyPressesStat = 1;
                }
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.G)
            {
                if (_keyPressesChangeLog == 1)
                {
                    _keyPressesChangeLog = 0;

                    if (Settings.EnableShowChangeLogAfterUpdate)
                    {
                        ApplicationChangeLogDialog applicationChangeLogDialog =
                            new ApplicationChangeLogDialog();

                        MainWindow.MainWindowInstance.DialogFrame.Visibility = Visibility.Visible;
                        MainWindow.MainWindowInstance.DialogFrame.Content =
                            applicationChangeLogDialog;

                        if (Settings.ApplicationUiTheme == Theme.Dark)
                        {
                            applicationChangeLogDialog.BaseDialog.DialogTheme = BaseTheme.Dark;
                        }

                        applicationChangeLogDialog.BaseDialog.IsOpen = true;
                    }
                }
                else
                {
                    _keyPressesChangeLog = 1;
                }
            }

            if (e.Key == Key.Tab)
            {
                e.Handled = !Settings.EnableApplicationTabKeyButton;
            }
        }
    }
}
