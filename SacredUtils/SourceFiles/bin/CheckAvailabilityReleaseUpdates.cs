using SacredUtils.resources.bin;
using SacredUtils.SourceFiles.utils;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;

namespace SacredUtils.SourceFiles.bin
{
    public static class CheckAvailabilityReleaseUpdates
    {
        public static void GetPerm()
        {
            if (!NetworkUtils.IsConnected.Value) return;

            Logger.Log.Info("Checking premission for checking release SacredUtils updates ...");

            if (Settings.EnableCheckReleaseUpdates)
            {
                if (GetActualApplicationVersion.Get("release", ApplicationInfo.Version,
                    "https://drive.google.com/uc?export=download&id=13N9ZfalxDfTAIdYxFuGBr8QPMW9OODc_"))
                {
                    DownloadApplicationNewUpdate.Download(
                        "https://drive.google.com/uc?export=download&id=1sDiiIYW0_JXMqh6IAHMOyf3IKPySCr4Q",
                        "release");
                }
            }
            else
            {
                Logger.Log.Warn("SacredUtils is running with disabled checking updates!");
            }
        }
    }
}
