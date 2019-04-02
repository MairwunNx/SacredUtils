using System.IO;

namespace SacredUtils.resources.bin
{
    public static class ApplicationBaseMakeFullReset
    {
        public static void Reset(bool onlySettings)
        {
            if (onlySettings && Directory.Exists("$SacredUtils\\conf"))
            {
                Directory.Delete("$SacredUtils\\conf", true); return;
            }

            if (Directory.Exists("$SacredUtils")) Directory.Delete("$SacredUtils", true);
        }
    }
}
