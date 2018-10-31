using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class CheckAvailabilityAlphaUpdates
    {
        private static readonly WebClient Wc = new WebClient();

        public static void GetPerm()
        {
            if (CheckAvailabilityInternetConnection.Connect())
            {
                Log.Info("Checking permission for checking alpha SacredUtils updates ...");

                if (AppSettings.ApplicationSettings.CheckAutoAlphaUpdate) { Get(); }
                else { CheckAvailabilityReleaseUpdates.GetPerm(); }
            }
        }

        private static void Get()
        {
            Log.Info("Checking for alpha SacredUtils application updates ...");

            string appAlphaVersion = Wc.DownloadString("https://drive.google.com/uc?export=download&id=1Fc0QIxzUn7-ellW5e4_W1Wv05-V1hsJ8");

            Log.Info($"The last received SacredUtils alpha version {appAlphaVersion}");

            if (!appAlphaVersion.Contains(AppSummary.AVersion))
            {
                Log.Warn($"SacredUtils application {AppSummary.AVersion} is outdated!");
                Log.Info($"Downloading SacredUtils application {appAlphaVersion} update ...");

                GetUpdate();
            }
            else
            {
                Log.Info("SacredUtils application no need to alpha update!");

                CheckAvailabilityReleaseUpdates.GetPerm();
            }
        }

        private static void GetUpdate()
        {
            const string release = @"https://drive.google.com/uc?export=download&id=1xZzaj0v41S7nkSXkn4GWoDTkBtzeRc2Y";

            if (File.Exists("_newVersionSacredUtilsTemp.exe")) { File.Delete("_newVersionSacredUtilsTemp.exe"); }

            Wc.DownloadFileTaskAsync(new Uri(release), "_newVersionSacredUtilsTemp.exe").Wait();

            Log.Info("Downloading new SacredUtils alpha update successfully done!");

            GetUpdateTool();
        }

        private static void GetUpdateTool()
        {
            Wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1Q2syd-44j_VAWDPHnoujdkNl6vRnNADw", "mnxupdater.exe").Wait();

            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
            {
                foreach (Window window in Application.Current.Windows)
                {
                    ((MainWindow)window).UpdateLbl.Visibility = Visibility.Visible;
                }
            }));

            Wc.Dispose();
        }
    }
}
