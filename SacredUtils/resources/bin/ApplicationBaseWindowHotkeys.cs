using EnumsNET;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using static SacredUtils.AppLogger;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace SacredUtils.resources.bin
{
    public static class ApplicationBaseWindowHotkeys
    {
        private static int _keyPresses;
        private static int _keyPressesStat;
        
        public static void KeyDown(object sender, KeyEventArgs e)
        {
            Enums.TryParse(AppSettings.ApplicationSettings.KeyGotoMainMenu, out Key toMain);
            Enums.TryParse(AppSettings.ApplicationSettings.KeyOpenSacredUtilsLogs, out Key openLogs);
            Enums.TryParse(AppSettings.ApplicationSettings.KeyOpenSacredUtilsSettings, out Key openSettings);
            Enums.TryParse(AppSettings.ApplicationSettings.KeyOpenSacredGameSettings, out Key openGameSettings);
            Enums.TryParse(AppSettings.ApplicationSettings.KeyOpenSacredUtilsDirectory, out Key openDirectory);
            Enums.TryParse(AppSettings.ApplicationSettings.KeyReloadSacredUtils, out Key reloadSacredUtils);
            Enums.TryParse(AppSettings.ApplicationSettings.KeyShutdownSacredUtils, out Key shutdownSacredUtils);
            Enums.TryParse(AppSettings.ApplicationSettings.KeyReloadFastSacredUtils, out Key fastReloadSacredUtils);

            if (e.Key == toMain)
            {
                ChangeApplicationSelectionSettings.UnSelectSettings(MainWindow.UnselectedStg);
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == openLogs)
            {
                if (File.Exists("$SacredUtils\\logs\\latest.log"))
                {
                    Process.Start(AppSettings.ApplicationSettings.DefaultOpenLogFileProgram, "$SacredUtils\\logs\\latest.log");
                }
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == openSettings)
            {
                if (File.Exists("$SacredUtils\\conf\\settings.json"))
                {
                    Process.Start(AppSettings.ApplicationSettings.DefaultOpenLogFileProgram, "$SacredUtils\\conf\\settings.json");
                }
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == openGameSettings)
            {
                if (File.Exists(AppSettings.ApplicationSettings.SacredConfigurationFile))
                {
                    Process.Start(AppSettings.ApplicationSettings.DefaultOpenLogFileProgram, AppSettings.ApplicationSettings.SacredConfigurationFile);
                }
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == openDirectory)
            {
                Process.Start(AppSummary.CurrentPath);
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == reloadSacredUtils)
            {
                Process.Start(AppSummary.AppPath); Environment.Exit(0);
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == shutdownSacredUtils)
            {
                ApplicationBaseWindowShutdown.Shutdown();
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == fastReloadSacredUtils)
            {
                Process.Start(AppSummary.AppPath, " -fast"); Environment.Exit(0);
            }

            if (e.Key == Key.F5)
            {
                RefreshApplicationSettings.Refresh(); Log.Info("Sacred game settings successfully reloaded!");
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.PageDown)
            {
                // force crash for testing crash-report code.
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed

                if (_keyPresses == 1) { _keyPresses = 0; Convert.ToBoolean("1"); }
                else { _keyPresses = 1; }
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.L)
            {
                // it code get download statistic from SacredUtils stat server.

                if (_keyPressesStat == 1)
                {
                    _keyPressesStat = 0;

                    string downloadCount = ApplicationGetDownloadStatistics.Get();

                    string[] count = downloadCount.Split('{', '}');

                    MessageBox.Show(count[1].Replace("\"", "").Replace("SacredUtilsDownloads", "SacredUtils Downloads Count"));
                }
                else
                {
                    _keyPressesStat = 1;
                }
            }
        }
    }
}
