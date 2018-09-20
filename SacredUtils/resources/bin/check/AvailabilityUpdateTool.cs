using System.IO;

namespace SacredUtils.resources.bin.check
{
    public static class AvailabilityUpdateTool
    {
        public static void Get()
        {
            if (File.Exists("mnxupdater.exe"))
            {
                File.Delete("mnxupdater.exe");
            }
        }
    }
}
