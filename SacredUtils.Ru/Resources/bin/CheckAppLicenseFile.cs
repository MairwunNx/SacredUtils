using System;
using System.IO;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;

namespace SacredUtils.Resources.bin
{
    internal class CheckAppLicenseFile
    {
        public void GetAvailableLicenseFile()
        {
            try
            {
                File.WriteAllBytes("license.txt", Properties.Resources.license);
                File.WriteAllBytes("notise.txt", Properties.Resources.notise);
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }
        }
    }
}
