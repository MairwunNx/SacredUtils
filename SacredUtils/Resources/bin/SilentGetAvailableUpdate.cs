using System;
using System.IO;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;

namespace SacredUtils.Resources.bin
{
    public class SilentGetAvailableUpdate
    {
        public void GetAvailableUpdate()
        {
            var fileText = File.ReadAllText(AppSettings);

            try
            {
                const string appLatestVersionWeb = "https://drive.google.com/uc?export=download&id=13N9ZfalxDfTAIdYxFuGBr8QPMW9OODc_";

                var appLatestVersion = Wc.DownloadString(appLatestVersionWeb);

                if (!appLatestVersion.Contains(AppReleaseVersion))
                {
                    SilentAvailableUpdate = true; SilentUpdateNewVer = appLatestVersion;
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }
        }
    }
}
