using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class CheckAvailabilityReleaseUpdates
    {
        public static void GetPerm()
        {
            if (CheckAvailabilityInternetConnection.Connect())
            {
                Log.Info("Checking premission for checking release SacredUtils updates ...");

                if (AppSettings.ApplicationSettings.CheckApplicationUpdates)
                {
                    if (GetActualApplicationVersion.Get("release", AppSummary.Version,
                        "https://drive.google.com/uc?export=download&id=13N9ZfalxDfTAIdYxFuGBr8QPMW9OODc_"))
                    {
                        DownloadApplicationNewUpdate.Download(
                            "https://drive.google.com/uc?export=download&id=1sDiiIYW0_JXMqh6IAHMOyf3IKPySCr4Q",
                            "release");
                    }
                }
                else
                {
                    Log.Warn("SacredUtils is running with disabled checking updates!");
                }
            }
        }
    }
}
