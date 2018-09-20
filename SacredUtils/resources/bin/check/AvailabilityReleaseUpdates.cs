using Config.Net;
using SacredUtils.resources.bin.etc;
using SacredUtils.resources.bin.get;
using System;
using System.IO;
using System.Net;

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
            GetLoggerConfig.Log.Info("Checking internet connection for checking release updates ...");

            if (AvailabilityInternetConnection.Connect)
            {
                GetLoggerConfig.Log.Info("Internet connection was sucessfully found!");

                GetPerm();
            }
            else
            {
                GetLoggerConfig.Log.Warn("**** APPLICATION IS RUNNING IN OFFLINE MODE!");
                GetLoggerConfig.Log.Warn("The SacredUtils will make no attempt to download new updates. Sorry.");
            }
        }

        public static void GetPerm()
        {
            GetLoggerConfig.Log.Info("Checking premission for checking release updates ...");

            IReleaseUpdateSettings releaseUpdateSettings = new ConfigurationBuilder<IReleaseUpdateSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            if (releaseUpdateSettings.CheckAutoUpdate) { Get(); }
            else
            {
                GetLoggerConfig.Log.Warn("**** APPLICATION IS RUNNING WITH DISABLED CHECKING UPDATE!");
                GetLoggerConfig.Log.Warn("The SacredUtils will make no attempt to download new updates. Sorry.");
                GetLoggerConfig.Log.Warn("To change this, set \"CheckAutoUpdate\" to \"true\" in the $SacredUtils/cfg/settings.json file.");
            }
        }

        public static void Get()
        {
            GetLoggerConfig.Log.Info("Checking for release application updates ...");

            const string appReleaseVersionWeb = "https://drive.google.com/uc?export=download&id=13N9ZfalxDfTAIdYxFuGBr8QPMW9OODc_";

            string appReleaseVersion = wc.DownloadString(appReleaseVersionWeb);

            GetLoggerConfig.Log.Info($"The last received SacredUtils release version {appReleaseVersion}");

            if (!appReleaseVersion.Contains(ApplicationInfo.Version))
            {
                GetLoggerConfig.Log.Warn($"SacredUtils application {ApplicationInfo.Version} is outdated!");
                GetLoggerConfig.Log.Info($"Downloading {appReleaseVersion} update ...");

                GetUpdate(); 
            }
            else
            {
                GetLoggerConfig.Log.Info("SacredUtils application no need to update!");
            }
        }

        public async static void GetUpdate()
        {
            const string release = @"https://drive.google.com/uc?export=download&id=1xZzaj0v41S7nkSXkn4GWoDTkBtzeRc2Y";

            try
            {
                if (File.Exists("_newVersionSacredUtilsTemp.exe"))
                {
                    File.Delete("_newVersionSacredUtilsTemp.exe");
                }

                await wc.DownloadFileTaskAsync(new Uri(release), "_newVersionSacredUtilsTemp.exe");

                GetLoggerConfig.Log.Info("Downloading new update successfully done!");

                GetUpdateTool();
            }
            catch (Exception e)
            {
                GetLoggerConfig.Log.Error("An error occurred while getting SacredUtils updates!");
                GetLoggerConfig.Log.Error(e.ToString);
            }
        }

        public static void GetUpdateTool()
        {
            File.WriteAllBytes("mnxupdater.exe", Properties.Resources.mnxupdater);

            // Показываем лейбл, но я пока не придумал, как это сделать.
        }
    }
}
