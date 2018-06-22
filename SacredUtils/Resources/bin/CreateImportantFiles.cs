using System;
using System.IO;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;

namespace SacredUtils.Resources.bin
{
    public class CreateImportantFiles
    {
        public void CreateFiles()
        {
            try
            {
                File.WriteAllBytes($"{AppNameWithoutExtension}.pdb", Properties.Resources.SacredUtils);
                File.WriteAllBytes($"{AppnameFile}.config", Properties.Resources.SacredUtils_exe);
                File.WriteAllBytes(AppLicenseFile, Properties.Resources.license);
                File.WriteAllBytes(AppNotiseFile, Properties.Resources.notise);
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }
        }
    }
}