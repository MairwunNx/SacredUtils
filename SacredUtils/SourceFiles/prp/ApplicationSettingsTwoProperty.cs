using System.IO;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;

namespace SacredUtils.SourceFiles.prp
{
    public class ApplicationSettingsTwoProperty
    {
        public bool UpdateCheck
        {
            get => Settings.EnableCheckReleaseUpdates;
            set
            {
                Settings.EnableCheckReleaseUpdates = value;
                Logger.Log.Info($"Checking for updates changed state to {value} by user");
            }
        }

        public bool UpdateAlphaCheck
        {
            get => Settings.EnableCheckAlphaUpdates;
            set
            {
                Settings.EnableCheckAlphaUpdates = value;
                Logger.Log.Info($"Checking for alpha updates changed state to {value} by user");
            }
        }

        public bool MakeBackup
        {
            get => Settings.EnableAutoBackupAppAndGameConfigs;
            set
            {
                Settings.EnableAutoBackupAppAndGameConfigs = value;
                Logger.Log.Info($"Backup making settings changed state to {value} by user");
            }
        }

        public bool License
        {
            get
            {
                if (!File.Exists(ApplicationInfo.LicenseAgreementFile)) return false;
                if (!File.Exists("License.txt")) return false;
                return File.ReadAllText(ApplicationInfo.LicenseAgreementFile).ToLower() == "true";
            }
            set
            {
                File.WriteAllText(
                    ApplicationInfo.LicenseAgreementFile,
                    value.ToString().ToLower()
                );
                Logger.Log.Info($"Accept license changed state to {value} by user");
            }
        }
    }
}
