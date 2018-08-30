using System.Reflection;

namespace SacredUtils.resources.bin
{
    public class ApplicationInfo
    {
        public static string Name    = "SacredUtils";
        public static string Version = "1.2.4.0.3108A1";
        public static string Type    = "Alpha";
        public static string AppName = Assembly.GetExecutingAssembly().Location;
        public static string Lang    = "None";
    }
}