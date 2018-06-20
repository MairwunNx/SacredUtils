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
                const string appLatestVersionWeb = "https://drive.google.com/uc?export=download&id=1rc3mqaf3Afc_qcWHON1PDhzded6nAaPs";

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
