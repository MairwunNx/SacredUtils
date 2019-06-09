using System.IO;
using SacredUtils.SourceFiles.settings;

namespace SacredUtils.SourceFiles.bin
{
    public static class CreateBackupApplicationSettings
    {
        public static void Create()
        {
            if (ApplicationSettingsManager.Settings.EnableRemoveBackupFilesOnOverflow)
            {
                if (Directory.GetFiles("$SacredUtils\\back\\cfg-app").Length >=
                    ApplicationSettingsManager.Settings.MaxApplicationBackupFiles)
                {
                    foreach (FileInfo dir in new DirectoryInfo("$SacredUtils\\back\\cfg-app")
                        .EnumerateFiles())
                    {
                        dir.Delete();
                    }
                }
            }

            if (ApplicationSettingsManager.Settings.EnableAutoBackupAppAndGameConfigs)
            {
                if (File.Exists(ApplicationInfo.ConfigFolder))
                {
                    File.Copy("$SacredUtils\\conf\\settings.json",
                        $"$SacredUtils\\back\\cfg-app\\config_app_id_{ApplicationInfo.RandomSession}.cfg",
                        true);
                }
            }
            else
            {
                foreach (FileInfo dir in new DirectoryInfo("$SacredUtils\\back\\cfg-app")
                    .EnumerateFiles())
                {
                    dir.Delete();
                }
            }
        }
    }
}
