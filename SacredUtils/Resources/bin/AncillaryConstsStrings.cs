using log4net;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SacredUtils.Resources.bin
{
    public class AncillaryConstsStrings
    {
        // Files in current folder.

        public static string AppLicenseFile = "license.txt";

        public static string AppNotiseFile = "notise.txt";

        public static string AppnameFile = Path.GetFileName(Application.ExecutablePath);

        public static string AppNameWithoutExtension = Path.GetFileNameWithoutExtension(AppnameFile);

        public static string SacredSettingsFile = "Settings.cfg";
        
        public static string AppSettingsFile = "Settings.su";
        
        public static string SacredExeFile = "Sacred.exe";
        
        // Files in .SacredUtilsData folder.

        public static string AppDataFolder = ".SacredUtilsData";

        public static string AppTempFolder = "Temp";

        public static string AppUpdaterFile = "SacredUtilsUpdater.exe";

        public static string AppBackupFolder = $"{AppDataFolder}\\backup";

        public static string AppLngBackupFolder = $"{AppBackupFolder}\\lng";

        public static string AppTempLngFolder = $"{AppDataFolder}\\templng";

        public static string AppVersionFile = $"{AppDataFolder}\\appversion.dat";

        public static string AppDownloadStatFile = $"{AppDataFolder}\\downloadstat.dat";

        public static string AppInstallInfo = $"{AppDataFolder}\\installinfo.dat";

        public static string AppLngDataFile = $"{AppDataFolder}\\language.dat";

        public static string AppStatisticFile = $"{AppDataFolder}\\launchstat.dat";

        public static string AppVoiceoverFile = $"{AppDataFolder}\\voiceoverinfo.dat";

        public static string AppLngErrorFile = $"{AppTempLngFolder}\\langinfo-err.dat";

        // The lines responsible for the version of the program.

        public static string AppReleaseVersion = "1.2R Rv4 B9 (260618)";

        public static string AppAlphaVersion = "1.2A Rv4 B10 (290618)";

        public static string AppCurrentVersion = "1.2A Rv4 B10 (290618)";

        // Lines containing naming options in the configuration.

        public static string AppColorValue = "User interface color SacredUtils";

        // Variables responsible for silent update.

        public static bool Changes = false;

        public static bool SilentAvailableUpdate = false;

        public static bool UpdateProcess = true;

        public static string SilentUpdateNewVer = "";

        // Variables responsible for changelog messages.

        public static string Msg = "";

        public static string Caption = "";

        // etc variables.

        public static ILog Log = LogManager.GetLogger("LOGGER");
        
        public static WebClient Wc = new WebClient();
    }
}
