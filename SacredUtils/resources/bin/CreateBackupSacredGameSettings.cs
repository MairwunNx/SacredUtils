using System;
using System.IO;

namespace SacredUtils.resources.bin
{
    public static class CreateBackupSacredGameSettings
    {
        public static void Create()
        {
            if (AppSettings.ApplicationSettings.RemoveBackupFilesOnOverflow)
            {
                if (Directory.GetFiles("$SacredUtils\\back\\cfg-game\\").Length > AppSettings.ApplicationSettings.MaxGameBackupFiles)
                {
                    foreach (FileInfo dir in new DirectoryInfo("$SacredUtils\\back\\cfg-game\\").EnumerateFiles())
                    {
                        dir.Delete();
                    }
                }
            }

            if (AppSettings.ApplicationSettings.MakeAutoBackupConfigs)
            {
                File.Copy(AppSettings.ApplicationSettings.SacredConfigurationFile, $"$SacredUtils\\back\\cfg-game\\config_game_id_{new Random().Next(0, int.MaxValue)}.cfg", true);
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
