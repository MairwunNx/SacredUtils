using System.IO;
using System.Text;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class GetRequiredApplicationFiles
    {
        public static void Get()
        {
            if (AppSettings.ApplicationSettings.LicenseFileCreate)
            {
                File.WriteAllBytes("License.txt", Properties.Resources.AppLicense);

                Log.Info("SacredUtils License file was successfully re-created!");
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

            if (!File.Exists("$SacredUtils\\conf\\hk.orsf.txt"))
            {
                File.WriteAllBytes("$SacredUtils\\conf\\hk.orsf.txt", Properties.Resources.hk_orsf);
            }

            if (!File.Exists("$SacredUtils\\conf\\hk.kesf.txt"))
            {
                File.WriteAllBytes("$SacredUtils\\conf\\hk.kesf.txt", Properties.Resources.hk_kesf);
            }

            File.WriteAllText("$SacredUtils\\conf\\splashes.txt", Properties.Resources.splashes, Encoding.UTF8);
        }
    }
}
