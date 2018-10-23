using System.IO;

namespace SacredUtils.resources.bin
{
    public static class GetRequiredApplicationFiles
    {
        public static void Get()
        {
            if (AppSettings.ApplicationSettings.LicenseFileCreate)
            {
                File.WriteAllBytes("License.txt", Properties.Resources.AppLicense);

                AppLogger.Log.Info("SacredUtils License file was successfully re-created!");
            }

            if (!File.Exists("$SacredUtils\\conf\\hotkeys.json"))
            {
                File.WriteAllBytes("$SacredUtils\\conf\\hotkeys.json", Properties.Resources.hotkeys);
            }

            if (!File.Exists("$SacredUtils\\conf\\hk.keyb.txt"))
            {
                File.WriteAllBytes("$SacredUtils\\conf\\hk.keyb.txt", Properties.Resources.hk_keyb);
            }

            if (!File.Exists("$SacredUtils\\conf\\hk.orig.txt"))
            {
                File.WriteAllBytes("$SacredUtils\\conf\\hk.orig.txt", Properties.Resources.hk_orig);
            }
        }
    }
}
