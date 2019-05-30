using System;
using System.IO;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.prp
{
    public class ApplicationSettingsTwoProperty
    {
        public bool UpdateCheck
        {
            get => AppSettings.ApplicationSettings.CheckApplicationUpdates;

            set
            {
                AppSettings.ApplicationSettings.CheckApplicationUpdates = value;

                Log.Info($"Checking for updates changed state to {value} by user");
            }
        }

        public bool UpdateAlphaCheck
        {
            get => AppSettings.ApplicationSettings.CheckAutoAlphaUpdate;

            set
            {
                AppSettings.ApplicationSettings.CheckAutoAlphaUpdate = value;

                Log.Info($"Checking for alpha updates changed state to {value} by user");
            }
        }

        public bool MakeBackup
        {
            get => AppSettings.ApplicationSettings.MakeAutoBackupAppGameConfigs;

            set
            {
                AppSettings.ApplicationSettings.MakeAutoBackupAppGameConfigs = value;

                Log.Info($"Backup making settings changed state to {value} by user");
            }
        }

        public bool License
        {
            get => File.Exists($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils\\LicenseAgreement.su") && File.Exists("License.txt") && File.ReadAllText($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils\\LicenseAgreement.su").Contains("true");

            set
            {
                File.WriteAllText($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils\\LicenseAgreement.su", value.ToString().ToLower());

                Log.Info($"Accept license changed state to {value} by user");
            }
        }
    }
}
