using System;
using System.IO;
using static SacredUtils.Resources.Core.AppConstStrings;

namespace SacredUtils.Resources.Core
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
