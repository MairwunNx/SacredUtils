using System;
using System.Diagnostics;
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
        public static readonly string AppPath = Assembly.GetExecutingAssembly().Location;
        public static readonly string CurrentPath = Environment.CurrentDirectory;
        public static readonly string CurrentExe = AppDomain.CurrentDomain.FriendlyName;
        public static readonly int RandomSession = new Random().Next(0, int.MaxValue);
        public static readonly Stopwatch StartupStopwatch = new Stopwatch();
        public static string[] AppArguments = {string.Empty};
    }
}
