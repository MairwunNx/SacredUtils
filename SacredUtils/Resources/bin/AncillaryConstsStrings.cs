using log4net;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SacredUtils.Resources.bin
{
    public class AncillaryConstsStrings
    {
        public static string AppSettings = "Settings.su";

        public static string AppStatistic = "launchstat.dat";

        public static string AppInstallInfo = "installinfo.dat";

        public static string AppDataFolder = ".SacredUtilsData";

        public static string AppBackupFolder = $"{AppDataFolder}\\backup";

        public static string AppLngBackupFolder = $"{AppBackupFolder}\\lng";

        public static string AppLngDataFolder = $"{AppDataFolder}\\language.dat";
        
        public static string AppTempLngFolder = $"{AppDataFolder}\\templng";

        public static string AppTempFolder = "Temp";

        public static string AppUpdaterExe = "SacredUtilsUpdater.exe";

        public static string SacredSettings = "Settings.cfg";

        public static string SacredExe = "Sacred.exe";

        public static string AppReleaseVersion = "1.2R Rv4 B7 (190618)";

        public static string AppAlphaVersion = "1.2A Rv4 B7 (150618)";

        public static string AppColorValue = "User interface color SacredUtils";

        public static string AppCurrentVersion = "1.2R Rv4 B7 (190618)";

        public static string Msg = "";
        
        public static string Caption = "";

        public static bool Changes = false;

        public static bool SilentAvailableUpdate = false;

        public static bool UpdateProcess = true;

        public static string SilentUpdateNewVer = "";

        public static readonly ILog Log = LogManager.GetLogger("LOGGER");
        public static readonly string Appname = Path.GetFileName(Application.ExecutablePath);
        public static readonly string AppNameWithoutExtension = Path.GetFileNameWithoutExtension(Appname);
        public static readonly WebClient Wc = new WebClient();
    }
}
