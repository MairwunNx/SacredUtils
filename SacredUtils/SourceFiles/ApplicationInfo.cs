using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace SacredUtils.SourceFiles
{
    public static class ApplicationInfo
    {
        public const string Name = "SacredUtils";
        public const string Version = "1.2.4.4.XXXX19.R1";
        public const string AlphaVersion = "1.2.4.1.261018.A2";
        public const string Type = "Release";
        public const string Build = "XXB";
        public const string Root = "$SacredUtils";
        public static readonly string CrashFolder = Path.Combine(Root, "crash-reports");
        public static readonly string AppData = Environment.ExpandEnvironmentVariables("%appdata%");

        public static readonly string AppDataSacredUtils =
            Path.Combine(AppData, Name);

        public static readonly string LicenseAgreementFile =
            Path.Combine(AppDataSacredUtils, "LicenseAgreement.su");

        public static readonly string ConfigFolder = Path.Combine(
            Root,
            "conf",
            "settings.json"
        );

        public static readonly string[] InvolvedDirs =
        {
            Root,
            Path.Combine(Root, "conf"),
            Path.Combine(Root, "logs"),
            Path.Combine(Root, "thms"),
            Path.Combine(Root, "temp"),
            Path.Combine(Root, "lang"),
            Path.Combine(Root, "lang", "ru-RU"),
            Path.Combine(Root, "lang", "en-US"),
            Path.Combine(Root, "back"),
            Path.Combine(Root, "back", "cfg-game"),
            Path.Combine(Root, "back", "cfg-app")
        };

        public static readonly string AppPath = Assembly.GetExecutingAssembly().Location;
        public static readonly string CurrentPath = Environment.CurrentDirectory;
        public static readonly string CurrentExe = AppDomain.CurrentDomain.FriendlyName;
        public static readonly int RandomSession = new Random().Next(0, int.MaxValue);
        public static readonly Stopwatch StartupStopwatch = new Stopwatch();
        public static string[] AppArguments = {string.Empty};
    }
}
