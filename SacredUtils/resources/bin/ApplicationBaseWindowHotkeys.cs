using EnumsNET;
using SacredUtils.resources.prp;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using static SacredUtils.AppLogger;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace SacredUtils.resources.bin
{
    public static class ApplicationBaseWindowHotkeys
    {
        public static void KeyDown(object sender, KeyEventArgs e)
        {
            Enums.TryParse(AppSettings.ApplicationSettings.KeyGotoMainMenu, out Key toMain);
            Enums.TryParse(AppSettings.ApplicationSettings.KeyOpenSacredUtilsLogs, out Key openLogs);
            Enums.TryParse(AppSettings.ApplicationSettings.KeyOpenSacredUtilsSettings, out Key openSettings);
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
                try
                {
                    RefreshSettings();

                    Log.Info("Sacred game settings successfully reloaded!");
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString);
                }
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.PageDown)
            {
                // force crash for testing crash-report code.
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed

                Convert.ToBoolean("1");
            }
        }

        public static void RefreshSettings()
        {
            MainWindow.ChatStgOne.DataContext = null;
            MainWindow.FontStgOne.DataContext = null;
            MainWindow.GamePlayStgOne.DataContext = null;
            MainWindow.GamePlayStgTwo.DataContext = null;
            MainWindow.GamePlayStgThree.DataContext = null;
            MainWindow.GraphicsStgOne.DataContext = null;
            MainWindow.GraphicsStgTwo.DataContext = null;
            MainWindow.GraphicsStgThree.DataContext = null;
            MainWindow.SoundStgOne.DataContext = null;

            MainWindow.ChatStgOne.DataContext = new GameChatSettingsOneProperty();
            MainWindow.FontStgOne.DataContext = new GameFontSettingsOneProperty();
            MainWindow.GamePlayStgOne.DataContext = new GamePlaySettingsOneProperty();
            MainWindow.GamePlayStgTwo.DataContext = new GamePlaySettingsTwoProperty();
            MainWindow.GamePlayStgThree.DataContext = new GamePlaySettingsThreeProperty();
            MainWindow.GraphicsStgOne.DataContext = new GameGraphicsSettingsOneProperty();
            MainWindow.GraphicsStgTwo.DataContext = new GameGraphicsSettingsTwoProperty();
            MainWindow.GraphicsStgThree.DataContext = new GameGraphicsSettingsThreeProperty();
            MainWindow.SoundStgOne.DataContext = new GameSoundSettingsOneProperty();
        }
    }
}
