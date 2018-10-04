using System.IO;

namespace SacredUtils.resources.bin
{
    public static class GetRequiredApplicationFiles
    {
        public static void Get()
        {
            if (AppSettings.ApplicationSettings.DebugFileCreate)
            {
                File.WriteAllBytes("SacredUtils.pdb", Properties.Resources.SacredUtils);

                AppLogger.Log.Info("SacredUtils Debug file was successfully re-created!");
            }

            if (AppSettings.ApplicationSettings.LicenseFileCreate)
            {
                File.WriteAllBytes("License.txt", Properties.Resources.AppLicense);

                AppLogger.Log.Info("SacredUtils License file was successfully re-created!");
            }
        }
    }
}
