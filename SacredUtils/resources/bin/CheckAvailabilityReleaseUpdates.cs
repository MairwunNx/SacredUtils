using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace SacredUtils.resources.bin
{
    public static class CheckAvailabilityReleaseUpdates
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

        public static void GetPerm()
        {
            AppLogger.Log.Info("Checking premission for checking release updates ...");

            if (AppSettings.ApplicationSettings.CheckAutoUpdate)
            {
                Get(); 
            }
            else
            {
                AppLogger.Log.Warn("**** APPLICATION IS RUNNING WITH DISABLED CHECKING UPDATE!");
                AppLogger.Log.Warn("The SacredUtils will make no attempt to download new updates. Sorry.");
                AppLogger.Log.Warn("To change this, set \"CheckAutoUpdate\" to \"true\" in the $SacredUtils/cfg/settings.json file.");
            }
        }

        public static void Get()
        {
            AppLogger.Log.Info("Checking for release application updates ...");

            try
            {
                string appReleaseVersion = wc.DownloadString("https://drive.google.com/uc?export=download&id=13N9ZfalxDfTAIdYxFuGBr8QPMW9OODc_");

                AppLogger.Log.Info($"The last received SacredUtils release version {appReleaseVersion}");

                if (!appReleaseVersion.Contains(AppSummary.Version))
                {
                    AppLogger.Log.Warn($"SacredUtils application {AppSummary.Version} is outdated!");
                    AppLogger.Log.Info($"Downloading {appReleaseVersion} update ...");

                    GetUpdate();
                }
                else
                {
                    AppLogger.Log.Info("SacredUtils application no need to update!");
                }
            }
            catch (Exception e)
            {
                AppLogger.Log.Info("Checking SacredUtils release updates done with error!");
                AppLogger.Log.Info(e.ToString);
            }
        }

        public static void GetUpdate()
        {
            const string release = @"https://drive.google.com/uc?export=download&id=1sDiiIYW0_JXMqh6IAHMOyf3IKPySCr4Q";

            try
            {
                if (File.Exists("_newVersionSacredUtilsTemp.exe"))
                {
                    File.Delete("_newVersionSacredUtilsTemp.exe");
                }

                wc.DownloadFileTaskAsync(new Uri(release), "_newVersionSacredUtilsTemp.exe");

                AppLogger.Log.Info("Downloading new update successfully done!");

                GetUpdateTool();
            }
            catch (Exception e)
            {
                AppLogger.Log.Error("An error occurred while getting SacredUtils updates!");
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
                        ((MainWindow)window).UpdateLbl.Visibility = Visibility.Visible;
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
