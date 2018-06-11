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
                Log.Info("Starting re/generate license Apache 2.0 file.");

                File.WriteAllBytes("license.txt", Properties.Resources.license);

                Log.Info("License Apache 2.0 file was created by program.");
            }
            catch (Exception exception)
            {
                Log.Error("An error occurred while creating the license Apache 2.0 file.");

                Log.Error(exception.ToString());
            }
        }
    }
}
