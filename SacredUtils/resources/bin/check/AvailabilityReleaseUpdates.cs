using Config.Net;
using SacredUtils.resources.bin.application;
using SacredUtils.resources.bin.logger;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace SacredUtils.resources.bin.check
{
    public static class AvailabilityReleaseUpdates
    {
        static WebClient wc = new WebClient();

        public interface IReleaseUpdateSettings 
        {
            bool CheckAutoUpdate { get; }
        }

        public static void GetInternet()
        {
            Logger.Log.Info("Checking internet connection for checking release updates ...");

            if (AvailabilityInternetConnection.Connect)
            {
                Logger.Log.Info("Internet connection was sucessfully found!");

                GetPerm();
            }
            else
            {
                Logger.Log.Warn("**** APPLICATION IS RUNNING IN OFFLINE MODE!");
                Logger.Log.Warn("The SacredUtils will make no attempt to download new updates. Sorry.");
            }
        }

        public static void GetPerm()
        {
            Logger.Log.Info("Checking premission for checking release updates ...");

            IReleaseUpdateSettings releaseUpdateSettings = new ConfigurationBuilder<IReleaseUpdateSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            if (releaseUpdateSettings.CheckAutoUpdate) { Get(); }
            else
            {
                Logger.Log.Warn("**** APPLICATION IS RUNNING WITH DISABLED CHECKING UPDATE!");
                Logger.Log.Warn("The SacredUtils will make no attempt to download new updates. Sorry.");
                Logger.Log.Warn("To change this, set \"CheckAutoUpdate\" to \"true\" in the $SacredUtils/cfg/settings.json file.");
            }
        }

        public static void Get()
        {
            Logger.Log.Info("Checking for release application updates ...");

            try
            {
                const string appReleaseVersionWeb = "https://drive.google.com/uc?export=download&id=13N9ZfalxDfTAIdYxFuGBr8QPMW9OODc_";

                string appReleaseVersion = wc.DownloadString(appReleaseVersionWeb);

                Logger.Log.Info($"The last received SacredUtils release version {appReleaseVersion}");

                if (!appReleaseVersion.Contains(ApplicationInfo.Version))
                {
                    Logger.Log.Warn($"SacredUtils application {ApplicationInfo.Version} is outdated!");
                    Logger.Log.Info($"Downloading {appReleaseVersion} update ...");

                    GetUpdate();
                }
                else
                {
                    Logger.Log.Info("SacredUtils application no need to update!");
                }
            }
            catch (Exception e)
            {
                Logger.Log.Info("Checking SacredUtils release updates done with error!");
                Logger.Log.Info(e.ToString);
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

                Logger.Log.Info("Downloading new update successfully done!");

                GetUpdateTool();
            }
            catch (Exception e)
            {
                Logger.Log.Error("An error occurred while getting SacredUtils updates!");
                Logger.Log.Error(e.ToString);
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
                Logger.Log.Error(e.ToString);
            }
        }
    }
}
