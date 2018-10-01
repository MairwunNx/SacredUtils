using Config.Net;
using System;
using System.IO;

namespace SacredUtils.resources.bin.getting
{
    public static class ApplicationSettings
    {
        public static void Get()
        {
            if (!File.Exists("$SacredUtils\\conf\\settings.json"))
            {
                try
                {
                    File.WriteAllBytes("$SacredUtils\\conf\\settings.json", Properties.Resources.settings);
                }
                catch (Exception exception)
                {
                    AppLogger.Log.Error(exception.ToString());
                }
            }
            else
            {
                IAppSettings applicationSettings =
                    new ConfigurationBuilder<IAppSettings>()
                        .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

                if (Directory.GetFiles("$SacredUtils\\back\\cfg-app").Length >
                    applicationSettings.MaxApplicationBackupFiles)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo("$SacredUtils\\back\\cfg-app");

                    foreach (FileInfo dir in directoryInfo.EnumerateFiles())
                    {
                        dir.Delete();
                    }
                }

                if (applicationSettings.MakeAutoBackupConfigs)
                {
                    Random rnd = new Random();

                    File.Copy("settings.cfg", $"$SacredUtils\\back\\cfg-app\\config_app_id_{rnd.Next(0, Int32.MaxValue)}.cfg", true);
                }
            }
        }
    }
}
