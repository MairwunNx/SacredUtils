using System.IO;
using System.Text;
using static SacredUtils.SourceFiles.Logger;

namespace SacredUtils.resources.bin
{
    public static class GetRequiredApplicationFiles
    {
        public static void Get()
        {
            if (AppSettings.ApplicationSettings.ApplicationLicenseFileCreate)
            {
                File.WriteAllBytes("License.txt", Properties.Resources.License);

                Log.Info("SacredUtils License file was successfully re-created!");
            }

            if (!File.Exists("$SacredUtils\\conf\\mk.setg.json"))
            {
                File.WriteAllBytes("$SacredUtils\\conf\\mk.setg.json", Properties.Resources.mk_setg);
            }

            if (!File.Exists("$SacredUtils\\conf\\splashes.txt"))
            {
                File.WriteAllText("$SacredUtils\\conf\\splashes.txt", Properties.Resources.splashes, Encoding.UTF8);
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

            if (!File.Exists("$SacredUtils\\conf\\hk.setg.txt"))
            {
                File.WriteAllBytes("$SacredUtils\\conf\\hk.setg.txt", Properties.Resources.hk_setg);
            }

            if (!File.Exists("$SacredUtils\\conf\\hk.regr.txt"))
            {
                File.WriteAllBytes("$SacredUtils\\conf\\hk.regr.txt", Properties.Resources.hk_regr);
            }

            if (!File.Exists("$SacredUtils\\conf\\ar.lava.txt"))
            {
                File.WriteAllText("$SacredUtils\\conf\\ar.lava.txt", Properties.Resources.ar_lava);
            }

            if (!File.Exists("$SacredUtils\\conf\\ar.watr.txt"))
            {
                File.WriteAllText("$SacredUtils\\conf\\ar.watr.txt", Properties.Resources.ar_watr);
            }

            if (!File.Exists("$SacredUtils\\conf\\ar.odtx.txt"))
            {
                File.WriteAllText("$SacredUtils\\conf\\ar.odtx.txt", Properties.Resources.ar_odtx);
            }
        }
    }
}
