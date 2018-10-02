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

        public static void GetGarbage()
        {
            CheckAvailabilityUpdateTemp.Get(); GetConnect();
        }

        public static void GetConnect()
        {
            AppLogger.Log.Info("Checking internet connection for checking alpha updates ...");

            if (CheckAvailabilityInternetConnection.Connect)
            {
                AppLogger.Log.Info("Internet connection was sucessfully found!");

                GetPerm();
            }
            else
            {
                AppLogger.Log.Warn("**** APPLICATION IS RUNNING IN OFFLINE MODE!");
                AppLogger.Log.Warn("The SacredUtils will make no attempt to download new updates. Sorry.");
            }
        }

        public static void GetPerm()
        {
            AppLogger.Log.Info("Checking premission for checking alpha updates ...");

            if (AppSettings.ApplicationSettings.CheckAutoAlphaUpdate)
            {
                Get();
            }
            else
            {
                AppLogger.Log.Info("No permission to check alpha updates!");

                CheckAvailabilityReleaseUpdates.GetInternet();
            }
        }

        public static void Get()
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

                    CheckAvailabilityReleaseUpdates.GetInternet();
                }
            }
            catch (Exception e)
            {
                AppLogger.Log.Info("Checking SacredUtils alpha updates done with error!");
                AppLogger.Log.Info(e.ToString);
            }
        }

        public static void GetUpdate()
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

        public static void GetUpdateTool()
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
