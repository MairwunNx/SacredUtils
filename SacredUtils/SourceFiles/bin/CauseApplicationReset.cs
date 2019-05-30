using System;
using System.IO;
using System.Linq;
using static SacredUtils.AppInfo;

namespace SacredUtils.resources.bin
{
    public static class CauseApplicationReset
    {
        public static void Reset()
        {
            try
            {
                if (!AppArguments.Contains("-fullReset")) return;

                if (AppArguments.Contains("-fullResetPConf") &&
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
