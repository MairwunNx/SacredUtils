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
        private static readonly WebClient Wc = new WebClient();

        public static void GetPerm()
        {
            if (CheckAvailabilityInternetConnection.Connect())
            {
                AppLogger.Log.Info("Checking premission for checking release SacredUtils updates ...");

                if (AppSettings.ApplicationSettings.CheckAutoUpdate)
                {
                    Get();
                }
                else
                {
                    AppLogger.Log.Warn("SacredUtils application is running with disabled checking updates!");
                }
            }
        }

        private static void Get()
        {
            AppLogger.Log.Info("Checking for release SacredUtils application updates ...");

            try
            {
                string appReleaseVersion = Wc.DownloadString("https://drive.google.com/uc?export=download&id=13N9ZfalxDfTAIdYxFuGBr8QPMW9OODc_");

                AppLogger.Log.Info($"The last received SacredUtils application release version {appReleaseVersion}");

                if (!appReleaseVersion.Contains(AppSummary.Version))
                {
                    AppLogger.Log.Warn($"SacredUtils application {AppSummary.Version} is outdated!");
                    AppLogger.Log.Info($"Downloading SacredUtils application {appReleaseVersion} update ...");

                    GetUpdate();
                }
                else
                {
                    AppLogger.Log.Info("SacredUtils application no need to release update!");
                }
            }
            catch (Exception e)
            {
                AppLogger.Log.Info("Checking SacredUtils release updates done with error!");
                AppLogger.Log.Info(e.ToString);
            }
        }

        private static void GetUpdate()
        {
            const string release = @"https://drive.google.com/uc?export=download&id=1sDiiIYW0_JXMqh6IAHMOyf3IKPySCr4Q";

            try
            {
                if (File.Exists("_newVersionSacredUtilsTemp.exe"))
                {
                    File.Delete("_newVersionSacredUtilsTemp.exe");
                }

                Wc.DownloadFileTaskAsync(new Uri(release), "_newVersionSacredUtilsTemp.exe");

                AppLogger.Log.Info("Downloading new SacredUtils application update successfully done!");

                GetUpdateTool();
            }
            catch (Exception e)
            {
                AppLogger.Log.Error("An error occurred while getting SacredUtils updates!");
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
