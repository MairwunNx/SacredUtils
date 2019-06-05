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
                    Directory.Exists(Path.Combine(ApplicationInfo.Root, "conf")))
                {
                    Directory.Delete(Path.Combine(ApplicationInfo.Root, "conf"), true);
                    return;
                }

                if (!Directory.Exists(ApplicationInfo.Root)) return;
                Directory.Delete(ApplicationInfo.Root, true);
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
