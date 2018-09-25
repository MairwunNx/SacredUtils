using SacredUtils.resources.bin.logger;
using System.Diagnostics;

namespace SacredUtils.resources.bin.open
{
    public static class OpenBrowserLink
    {
        public static void Open(string link)
        {
            Process.Start(link);

            Logger.Log.Info($"{link} link was opened by user");
        }
    }
}
