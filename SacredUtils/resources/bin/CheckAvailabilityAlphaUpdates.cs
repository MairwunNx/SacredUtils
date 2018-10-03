using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace SacredUtils.resources.bin
{
    public static class CheckAvailabilityAlphaUpdates
    {
        static WebClient wc = new WebClient();

        public static void GetConnection()
        {
            if (CheckAvailabilityInternetConnection.Connect())
            {
                GetGarbage();
            }
        } 

        public static void GetGarbage()
        {
            CheckAvailabilityUpdateTemp.Get(); GetPerm();
        }

        private static void GetPerm()
        {
            AppLogger.Log.Info("Checking permission for checking alpha updates ...");

            if (AppSettings.ApplicationSettings.CheckAutoAlphaUpdate)
            {
                AppLogger.Log.Info("Checking internet connection for checking alpha updates ...");

                Get();
            }
            else
            {
                CheckAvailabilityReleaseUpdates.GetConnection();
            }
        }

        private static void Get()
        {
            AppLogger.Log.Info("Checking for release application updates ...");

            try
            {
                string appAlphaVersion = wc.DownloadString("https://drive.google.com/uc?export=download&id=1Fc0QIxzUn7-ellW5e4_W1Wv05-V1hsJ8");

                AppLogger.Log.Info($"The last received SacredUtils release version {appAlphaVersion}");

                if (!appAlphaVersion.Contains(AppSummary.AVersion))
                {
                    AppLogger.Log.Warn($"SacredUtils application {AppSummary.AVersion} is outdated!");
                    AppLogger.Log.Info($"Downloading {appAlphaVersion} update ...");

                    GetUpdate();
                }
                else
                {
                    AppLogger.Log.Info("SacredUtils application no need to alpha update!");

                    CheckAvailabilityReleaseUpdates.GetConnection();
                }
            }
            catch (Exception e)
            {
                AppLogger.Log.Info("Checking SacredUtils alpha updates done with error!");
                AppLogger.Log.Info(e.ToString);
            }
        }

        private static void GetUpdate()
        {
            const string release = @"https://drive.google.com/uc?export=download&id=1xZzaj0v41S7nkSXkn4GWoDTkBtzeRc2Y";

            try
            {
                if (File.Exists("_newVersionSacredUtilsTemp.exe"))
                {
                    File.Delete("_newVersionSacredUtilsTemp.exe");
                }

                wc.DownloadFileTaskAsync(new Uri(release), "_newVersionSacredUtilsTemp.exe");

                AppLogger.Log.Info("Downloading new alpha update successfully done!");

                GetUpdateTool();
            }
            catch (Exception e)
            {
                AppLogger.Log.Error("An error occurred while getting SacredUtils alpha updates!");
                AppLogger.Log.Error(e.ToString);
            }
        }

        private static void GetUpdateTool()
        {
            File.WriteAllBytes("mnxupdater.exe", Properties.Resources.mnxupdater);

            try
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                    foreach (Window window in Application.Current.Windows)
                    {
                        ((MainWindow) window).UpdateLbl.Visibility = Visibility.Visible;
                    }
                }));
            }
            catch (Exception e)
            {
                AppLogger.Log.Error(e.ToString);
            }
        }
    }
}
