using System.Reflection;

namespace SacredUtils.resources.bin
{
    public static class ApplicationInfo
    {
        public static string Name    = "SacredUtils";
        public static string Version = "1.2.4.0.1609A1";
        public static string Type    = "Alpha";
        public static string AppName = Assembly.GetExecutingAssembly().Location;
        public static string Lang    = "None";
        public static string Connect = "None";
        public static string Theme   = "None";
        public static double Scale   = 1.0;
    }
}