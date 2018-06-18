using log4net;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SacredUtils.Resources.bin
{
    public class AncillaryConstsStrings
    {
        public const string AppSettings = "Settings.su";

        public const string AppStatistic = "launchstat.dat";

        public const string AppInstallInfo = "installinfo.dat";

        public const string AppDataFolder = ".SacredUtilsData";

        public const string AppTempFolder = "Temp";

        public const string AppUpdaterExe = "SacredUtilsUpdater.exe";

        public const string SacredSettings = "Settings.cfg";

        public const string SacredExe = "Sacred.exe";

        public const string AppReleaseVersion = "1.2R Rv4 B6 (070618)";

        public const string AppAlphaVersion = "1.2A Rv4 B7 (150618)";

        public const string AppColorValue = "User interface color SacredUtils";

        public const string AppCurrentVersion = "1.2A Rv4 B7 (180618)";

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
