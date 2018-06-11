using log4net;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SacredUtils.Resources.Core
{
    public class AppConstStrings
    {
        #region ConstsStrings

        public const string AppSettings = "Settings.su";
        
        public const string AppStatistic = "launchstat.dat";

        public const string AppInstallInfo = "installinfo.dat";

        public const string AppDataFolder = ".SacredUtilsData";

        public const string AppTempFolder = "Temp";

        public const string AppUpdaterExe = "SacredUtilsUpdater.exe";

        public const string SacredSettings = "Settings.cfg";

        public const string SacredExe = "Sacred.exe";

        public const string AppReleaseVersion = "1.2R Rv4 B6 (070618)";

        public const string AppAlphaVersion = "1.2A Rv4 B7 (120618)";

        public const string AppColorValue = "User interface color SacredUtils";

        #endregion

        #region StaticReadonlyStrings
        
        public static readonly ILog Log = LogManager.GetLogger("LOGGER");
        public static readonly string Appname = Path.GetFileName(Application.ExecutablePath);
        public static readonly string AppNameExtension = Path.GetFileNameWithoutExtension(Appname);
        public static readonly WebClient Wc = new WebClient();

        #endregion
    }
}