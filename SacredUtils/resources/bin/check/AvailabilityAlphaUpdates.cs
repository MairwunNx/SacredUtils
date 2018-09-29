﻿using Config.Net;
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

        public static void GetGarbage()
        {
            AvailabilityUpdateTemp.Get(); GetConnect();
        }

        public static void GetConnect()
        {
            AppLogger.Log.Info("Checking internet connection for checking alpha updates ...");

            if (AvailabilityInternetConnection.Connect)
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

            IAppSettings alphaUpdateSettings = new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            if (alphaUpdateSettings.CheckAutoAlphaUpdate) { Get(); }
            else
            {
                AppLogger.Log.Info("No permission to check alpha updates!");

                AvailabilityReleaseUpdates.GetInternet();
            }
        }

        public static void Get()
        {
            AppLogger.Log.Info("Checking for release application updates ...");

            try
            {
                const string appAlphaVersionWeb = "https://drive.google.com/uc?export=download&id=1Fc0QIxzUn7-ellW5e4_W1Wv05-V1hsJ8";

                string appAlphaVersion = wc.DownloadString(appAlphaVersionWeb);

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

                    AvailabilityReleaseUpdates.GetInternet();
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
