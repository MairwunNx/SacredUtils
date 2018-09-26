using System.Diagnostics;
using System.Reflection;

namespace SacredUtils.resources.bin.etc
{
    public static class ApplicationInfo
    {
        public static string Name     = "SacredUtils";
        public static string Version  = "1.2.4.0.2009A1";
        public static string AVersion = "1.2.4.0.2009A1";
        public static string Type     = "Alpha";
        public static string AppName  = Assembly.GetExecutingAssembly().Location;
        public static string Lang     = "None";
        public static string Connect  = "None";
        public static string Theme    = "None";
        public static double Scale    = 1.0;
        public static Stopwatch sw    = new Stopwatch();
    }
}