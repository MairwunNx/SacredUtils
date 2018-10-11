namespace SacredUtils.resources.prp
{
    public class ApplicationSettingsTwoProperty
    {
        public bool UpdateCheck
        {
            get => AppSettings.ApplicationSettings.CheckAutoUpdate;

            set
            {
                AppSettings.ApplicationSettings.CheckAutoUpdate = value;

                AppLogger.Log.Info($"Checking for updates changed state to {value} by user");
            }
        }

        public bool UpdateAlphaCheck
        {
            get => AppSettings.ApplicationSettings.CheckAutoAlphaUpdate;

            set
            {
                AppSettings.ApplicationSettings.CheckAutoAlphaUpdate = value;

                AppLogger.Log.Info($"Checking for alpha updates changed state to {value} by user");
            }
        }

        public bool MakeBackup
        {
            get => AppSettings.ApplicationSettings.MakeAutoBackupConfigs;

            set
            {
                AppSettings.ApplicationSettings.MakeAutoBackupConfigs = value;

                AppLogger.Log.Info($"Backup making settings changed state to {value} by user");
            }
        }

        public bool License
        {
            get => AppSettings.ApplicationSettings.AcceptLicense;

            set
            {
                AppSettings.ApplicationSettings.AcceptLicense = value;

                AppLogger.Log.Info($"Accept license changed state to {value} by user");
            }
        }
    }
}
