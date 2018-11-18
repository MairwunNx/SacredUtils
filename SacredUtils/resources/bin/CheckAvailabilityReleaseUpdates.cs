﻿using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class CheckAvailabilityReleaseUpdates
    {
        private static readonly WebClient Wc = new WebClient();

        public static void GetPerm()
        {
            if (CheckAvailabilityInternetConnection.Connect())
            {
                Log.Info("Checking premission for checking release SacredUtils updates ...");

                if (AppSettings.ApplicationSettings.CheckApplicationUpdates) { Get(); }
                else { Log.Warn("SacredUtils is running with disabled checking updates!"); }
            }
        }

        private static void Get()
        {
            Log.Info("Checking for release SacredUtils application updates ...");

            string appReleaseVersion = Wc.DownloadString("https://drive.google.com/uc?export=download&id=13N9ZfalxDfTAIdYxFuGBr8QPMW9OODc_");

            Log.Info($"The last received SacredUtils release version {appReleaseVersion}");

            if (!appReleaseVersion.Contains(AppSummary.Version))
            {
                Log.Warn($"SacredUtils application {AppSummary.Version} is outdated!");
                Log.Info($"Downloading SacredUtils application {appReleaseVersion} update ...");

                GetUpdate();
            }
            else
            {
                Log.Info("SacredUtils application no need to release update!");
            }
        }

        private static void GetUpdate()
        {
            const string release = @"https://drive.google.com/uc?export=download&id=1sDiiIYW0_JXMqh6IAHMOyf3IKPySCr4Q";

            if (File.Exists("_newVersionSacredUtilsTemp.exe")) { File.Delete("_newVersionSacredUtilsTemp.exe"); }

            Wc.DownloadFileTaskAsync(new Uri(release), "_newVersionSacredUtilsTemp.exe").Wait();

            Log.Info("Downloading new SacredUtils application update successfully done!");

            GetUpdateTool();
        }

        private static void GetUpdateTool()
        {
            Wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1Q2syd-44j_VAWDPHnoujdkNl6vRnNADw", "mnxupdater.exe").Wait();

            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                MainWindow.MainWindowInstance.UpdateLbl.Visibility = Visibility.Visible));

            Wc.Dispose();
        }
    }
}
