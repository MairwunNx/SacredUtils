using System;
using System.IO;

namespace SacredUtils.resources.bin
{
    public static class CreateBackupApplicationSettings
    {
        public static void Create()
        {
            if (Directory.GetFiles("$SacredUtils\\back\\cfg-app").Length > AppSettings.ApplicationSettings.MaxApplicationBackupFiles)
            {
                foreach (FileInfo dir in new DirectoryInfo("$SacredUtils\\back\\cfg-app").EnumerateFiles())
                {
                    dir.Delete();
                }
            }

            if (AppSettings.ApplicationSettings.MakeAutoBackupConfigs)
            {
                File.Copy("$SacredUtils\\conf\\settings.json", $"$SacredUtils\\back\\cfg-app\\config_app_id_{new Random().Next(0, int.MaxValue)}.cfg", true);
            }
            else
            {
                foreach (FileInfo dir in new DirectoryInfo("$SacredUtils\\back\\cfg-app").EnumerateFiles())
                {
                    dir.Delete();
                }
            }
        }
    }
}
