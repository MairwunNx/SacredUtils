using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using EnumsNET;
using MaterialDesignThemes.Wpf;
using SacredUtils.resources.dlg;
using SacredUtils.SourceFiles;
using SacredUtils.SourceFiles.utils;
using static SacredUtils.SourceFiles.Logger;

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
            Enums.TryParse(AppSettings.ApplicationSettings.KeyApplicationGotoMainMenu,
                out Key toMain);
            Enums.TryParse(AppSettings.ApplicationSettings.KeyOpenSacredUtilsLogFile,
                out Key openLogs);
            Enums.TryParse(AppSettings.ApplicationSettings.KeyOpenSacredUtilsSettingFile,
                out Key openSettings);
            Enums.TryParse(AppSettings.ApplicationSettings.KeyOpenSacredGameSettingsFile,
                out Key openGameSettings);
            Enums.TryParse(AppSettings.ApplicationSettings.KeyOpenSacredUtilsDirectory,
                out Key openDirectory);
            Enums.TryParse(AppSettings.ApplicationSettings.KeyDefaultReloadSacredUtils,
                out Key reloadSacredUtils);
            Enums.TryParse(AppSettings.ApplicationSettings.KeyDefaultShutdownSacredUtils,
                out Key shutdownSacredUtils);

            if (e.Key == toMain)
            {
                ChangeApplicationSelectionSettings.UnSelectSettings(
                    MainWindow.UnselectedStg
                );
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control &&
                e.Key == openLogs &&
                File.Exists("$SacredUtils\\logs\\latest.log"))
            {
                Process.Start(AppSettings.ApplicationSettings.DefaultOpenLogFileProgram,
                    "$SacredUtils\\logs\\latest.log");
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control &&
                e.Key == openSettings &&
                File.Exists("$SacredUtils\\conf\\settings.json"))
            {
                Process.Start(AppSettings.ApplicationSettings.DefaultOpenLogFileProgram,
                    "$SacredUtils\\conf\\settings.json");
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control &&
                e.Key == openGameSettings &&
                File.Exists(AppSettings.ApplicationSettings.SacredConfigurationFile))
            {
                Process.Start(AppSettings.ApplicationSettings.DefaultOpenLogFileProgram,
                    AppSettings.ApplicationSettings.SacredConfigurationFile);
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == openDirectory)
            {
                Process.Start(ApplicationInfo.CurrentPath);
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == reloadSacredUtils)
            {
                ApplicationUtils.Reload();
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == shutdownSacredUtils)
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

                    if (AppSettings.ApplicationSettings.ApplicationShowChangeLog)
                    {
                        ApplicationChangeLogDialog applicationChangeLogDialog =
                            new ApplicationChangeLogDialog();

                        MainWindow.MainWindowInstance.DialogFrame.Visibility = Visibility.Visible;
                        MainWindow.MainWindowInstance.DialogFrame.Content =
                            applicationChangeLogDialog;

                        if (AppSettings.ApplicationSettings.ApplicationUiColorTheme == "dark")
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
                e.Handled = AppSettings.ApplicationSettings.DisableApplicationTabKeyButton;
            }
        }
    }
}
