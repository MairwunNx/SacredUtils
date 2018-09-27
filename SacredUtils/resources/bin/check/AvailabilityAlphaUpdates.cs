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
    public static class AvailabilityAlphaUpdates
    {
        static WebClient wc = new WebClient();

        public interface IAlphaUpdateSettings
        {
            bool CheckAutoAlphaUpdate { get; }
        }

        public static void GetConnect()
        {
            Logger.Log.Info("Checking internet connection for checking alpha updates ...");

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
            Logger.Log.Info("Checking premission for checking alpha updates ...");

            IAlphaUpdateSettings alphaUpdateSettings = new ConfigurationBuilder<IAlphaUpdateSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            if (alphaUpdateSettings.CheckAutoAlphaUpdate) { Get(); }
            else
            {
                Logger.Log.Info("No permission to check alpha updates!");

                AvailabilityReleaseUpdates.GetInternet();
            }
        }

        public static void Get()
        {
            Logger.Log.Info("Checking for release application updates ...");

            try
            {
                const string appAlphaVersionWeb = "https://drive.google.com/uc?export=download&id=1Fc0QIxzUn7-ellW5e4_W1Wv05-V1hsJ8";

                string appAlphaVersion = wc.DownloadString(appAlphaVersionWeb);

                Logger.Log.Info($"The last received SacredUtils release version {appAlphaVersion}");

                if (!appAlphaVersion.Contains(ApplicationInfo.AVersion))
                {
                    Logger.Log.Warn($"SacredUtils application {ApplicationInfo.AVersion} is outdated!");
                    Logger.Log.Info($"Downloading {appAlphaVersion} update ...");

                    GetUpdate();
                }
                else
                {
                    Logger.Log.Info("SacredUtils application no need to alpha update!");

                    AvailabilityReleaseUpdates.GetInternet();
                }
            }
            catch (Exception e)
            {
                Logger.Log.Info("Checking SacredUtils alpha updates done with error!");
                Logger.Log.Info(e.ToString);
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

                Logger.Log.Info("Downloading new alpha update successfully done!");

                GetUpdateTool();
            }
            catch (Exception e)
            {
                Logger.Log.Error("An error occurred while getting SacredUtils alpha updates!");
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
                        ((MainWindow) window).UpdateLbl.Visibility = Visibility.Visible;
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
