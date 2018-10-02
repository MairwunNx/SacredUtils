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

                AppLogger.Log.Info("Debug file were created in this folder");
            }
            else
            {
                AppLogger.Log.Info("No permission to create debug file!");
            }

            if (AppSettings.ApplicationSettings.LicenseFileCreate)
            {
                File.WriteAllBytes("License.txt", Properties.Resources.AppLicense);

                AppLogger.Log.Info("License file were created in this folder");
            }
            else
            {
                AppLogger.Log.Info("No permission to create license file!");
            }
        }
    }
}
