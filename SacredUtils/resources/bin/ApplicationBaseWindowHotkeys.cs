using SacredUtils.resources.prp;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Input;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

namespace SacredUtils.resources.bin
{
    public static class ApplicationBaseWindowHotkeys
    {
        public static void KeyDown(object sender, KeyEventArgs e)
        {
            Enum.TryParse(AppSettings.ApplicationSettings.KeyGotoMainMenu, out Key toMain);
            Enum.TryParse(AppSettings.ApplicationSettings.KeyOpenSacredUtilsLogs, out Key openLogs);
            Enum.TryParse(AppSettings.ApplicationSettings.KeyOpenSacredUtilsSettings, out Key openSettings);
            Enum.TryParse(AppSettings.ApplicationSettings.KeyOpenSacredUtilsDirectory, out Key openDirectory);
            Enum.TryParse(AppSettings.ApplicationSettings.KeyReloadSacredUtils, out Key reloadSacredUtils);
            Enum.TryParse(AppSettings.ApplicationSettings.KeyShutdownSacredUtils, out Key shutdownSacredUtils);
            Enum.TryParse(AppSettings.ApplicationSettings.KeyReloadFastSacredUtils, out Key fastReloadSacredUtils);

            if (e.Key == toMain)
            {
                ChangeApplicationSelectionSettings.UnSelectSettings(MainWindow.UnselectedStg);
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == openLogs)
            {
                if (File.Exists("$SacredUtils\\logs\\latest.log"))
                {
                    Process.Start("notepad", "$SacredUtils\\logs\\latest.log");
                }
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == openSettings)
            {
                if (File.Exists("$SacredUtils\\conf\\settings.json"))
                {
                    Process.Start("notepad", "$SacredUtils\\conf\\settings.json");
                }
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == openDirectory)
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                Process.Start(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName));
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == reloadSacredUtils)
            {
                Process.Start(AppSummary.AppPatch); Environment.Exit(0);
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == shutdownSacredUtils)
            {
                ApplicationBaseWindowShutdown.Shutdown();
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == fastReloadSacredUtils)
            {
                Process.Start(AppSummary.AppPatch, " -fast"); Environment.Exit(0);
            }

            if (e.Key == Key.F5)
            {
                try
                {
                    MainWindow.ChatStgOne.DataContext = null;
                    MainWindow.ChatStgOne.DataContext = new GameChatSettingsOneProperty();

                    MainWindow.FontStgOne.DataContext = null;
                    MainWindow.FontStgOne.DataContext = new GameFontSettingsOneProperty();

                    MainWindow.GamePlayStgOne.DataContext = null;
                    MainWindow.GamePlayStgOne.DataContext = new GamePlaySettingsOneProperty();

                    MainWindow.GamePlayStgTwo.DataContext = null;
                    MainWindow.GamePlayStgTwo.DataContext = new GamePlaySettingsTwoProperty();

                    MainWindow.GamePlayStgThree.DataContext = null;
                    MainWindow.GamePlayStgThree.DataContext = new GamePlaySettingsThreeProperty();

                    MainWindow.GraphicsStgOne.DataContext = null;
                    MainWindow.GraphicsStgOne.DataContext = new GameGraphicsSettingsOneProperty();

                    MainWindow.GraphicsStgTwo.DataContext = null;
                    MainWindow.GraphicsStgTwo.DataContext = new GameGraphicsSettingsTwoProperty();

                    MainWindow.GraphicsStgThree.DataContext = null;
                    MainWindow.GraphicsStgThree.DataContext = new GameGraphicsSettingsThreeProperty();

                    MainWindow.SoundStgOne.DataContext = null;
                    MainWindow.SoundStgOne.DataContext = new GameSoundSettingsOneProperty();

                    AppLogger.Log.Info("Sacred game settings successfully reloaded!");
                }
                catch (Exception ex)
                {
                    AppLogger.Log.Error(ex.ToString);
                }
            }
        }
    }
}
