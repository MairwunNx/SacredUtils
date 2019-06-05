using System;
using System.IO;
using System.Linq;
using static SacredUtils.SourceFiles.ApplicationInfo;

namespace SacredUtils.SourceFiles
{
    public static class ApplicationReset
    {
        public static void Reset()
        {
            try
            {
                if (!AppArguments.Contains("-fullReset")) return;

                if (AppArguments.Contains("-fullResetPConf") &&
                    Directory.Exists(Path.Combine(Root, "conf")))
                {
                    Directory.Delete(Path.Combine(Root, "conf"), true);
                    return;
                }

                if (!Directory.Exists(Root)) return;
                Directory.Delete(Root, true);
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
