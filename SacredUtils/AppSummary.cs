using System;
using System.Diagnostics;
using System.Reflection;

namespace SacredUtils
{
    public static class AppSummary
    {
        public static string Name        = "SacredUtils";
        public static string Version     = "1.2.4.4.300319.R1";
        public static string AVersion    = "1.2.4.1.261018.A2";
        public static string Type        = "Release";
        public static string Build       = "52B";
        public static string AppPath     = Assembly.GetExecutingAssembly().Location;
        public static string CurrentPath = Environment.CurrentDirectory;
        public static string CurrentExe  = AppDomain.CurrentDomain.FriendlyName;
        public static int RandomSession  = new Random().Next(0, int.MaxValue);
        public static Stopwatch Sw       = new Stopwatch();
    }
}