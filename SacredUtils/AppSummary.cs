using System.Diagnostics;
using System.Reflection;

namespace SacredUtils
{
    public static class AppSummary
    {
        public static string Name     = "SacredUtils";
        public static string Version  = "1.2.4.0.151018.R1";
        public static string AVersion = "1.2.4.0.151018.R1";
        public static string Type     = "Release";
        public static string AppPatch = Assembly.GetExecutingAssembly().Location;
        public static string Connect  = "None";
        public static Stopwatch Sw    = new Stopwatch();
    }
}