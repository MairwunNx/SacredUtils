using SacredUtils.resources.bin.get;
using System.Diagnostics;

namespace SacredUtils.resources.bin.open
{
    public static class OpenBrowserLink
    {
        public static void Open(string link)
        {
            Process.Start(link);

            GetLoggerConfig.Log.Info($"{link} link was opened by user");
        }
    }
}
