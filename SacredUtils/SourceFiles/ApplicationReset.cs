using System;
using System.IO;
using System.Linq;

namespace SacredUtils.SourceFiles
{
    public static class ApplicationReset
    {
        public static void Reset()
        {
            try
            {
                if (!ApplicationInfo.AppArguments.Contains("-fullReset")) return;

                if (ApplicationInfo.AppArguments.Contains("-fullResetPConf") &&
                    Directory.Exists("$SacredUtils\\conf"))
                {
                    Directory.Delete("$SacredUtils\\conf", true);
                    return;
                }

                if (!Directory.Exists("$SacredUtils")) return;
                Directory.Delete("$SacredUtils", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    "Logger not initialized, so for throwing exception i use console."
                );
                Console.WriteLine(ex);
            }
        }
    }
}
