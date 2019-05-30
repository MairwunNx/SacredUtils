using System.IO;

namespace SacredUtils.resources.bin
{
    public static class CreateBackupSacredGameSettings
    {
        public static void Create()
        {
            if (AppSettings.ApplicationSettings.RemoveBackupFilesOnOverflow)
            {
                if (Directory.GetFiles("$SacredUtils\\back\\cfg-game\\").Length >= AppSettings.ApplicationSettings.MaxSacredGameBackupFiles)
                {
                    foreach (FileInfo dir in new DirectoryInfo("$SacredUtils\\back\\cfg-game\\").EnumerateFiles())
                    {
                        dir.Delete();
                    }
                }
            }

            if (AppSettings.ApplicationSettings.MakeAutoBackupAppGameConfigs)
            {
                File.Copy(AppSettings.ApplicationSettings.SacredConfigurationFile, $"$SacredUtils\\back\\cfg-game\\config_game_id_{AppInfo.RandomSession}.cfg", true);
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
