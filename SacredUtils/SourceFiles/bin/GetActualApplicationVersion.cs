using System.Net;
using static SacredUtils.SourceFiles.Logger;

namespace SacredUtils.resources.bin
{
    public static class GetActualApplicationVersion
    {
        private static readonly WebClient Wc = new WebClient();

        public static bool Get(string type, string version, string url)
        {
            Log.Info($"Checking for {type} SacredUtils application updates ...");

            string appLatestVersion = Wc.DownloadString(url);

            Log.Info($"The last received SacredUtils {type} version {appLatestVersion}");

            if (!appLatestVersion.Contains(version))
            {
                Log.Warn($"SacredUtils application {version} is outdated!");
                Log.Info($"Downloading SacredUtils application {appLatestVersion} update ...");
                return true;
            }

            Log.Info($"SacredUtils application no need to {type} update!");
            return false;
        }
    }
}
