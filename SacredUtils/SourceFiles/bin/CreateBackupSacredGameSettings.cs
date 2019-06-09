using System.IO;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;

namespace SacredUtils.SourceFiles.bin
{
    public static class CreateBackupSacredGameSettings
    {
        public static void Create()
        {
            if (Settings.EnableRemoveBackupFilesOnOverflow)
            {
                if (Directory.GetFiles("$SacredUtils\\back\\cfg-game\\").Length >= Settings.MaxSacredGameBackupFiles)
                {
                    foreach (FileInfo dir in new DirectoryInfo("$SacredUtils\\back\\cfg-game\\").EnumerateFiles())
                    {
                        dir.Delete();
                    }
                }
            }

            if (Settings.EnableAutoBackupAppAndGameConfigs)
            {
                File.Copy(Settings.SacredConfigurationFile, $"$SacredUtils\\back\\cfg-game\\config_game_id_{ApplicationInfo.RandomSession}.cfg", true);
            }
            else
            {
                foreach (FileInfo dir in new DirectoryInfo("$SacredUtils\\back\\cfg-game\\").EnumerateFiles())
                {
                    dir.Delete();
                }
            }
        }
    }
}
