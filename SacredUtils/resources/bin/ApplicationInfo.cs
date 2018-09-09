using System.Reflection;

namespace SacredUtils.resources.bin
{
    public static class ApplicationInfo
    {
        public static readonly string Name    = "SacredUtils";
        public static readonly string Version = "1.2.4.0.3108A1";
        public static readonly string Type    = "Alpha";
        public static readonly string AppName = Assembly.GetExecutingAssembly().Location;
        public static readonly string Lang    = "None";
    }
}