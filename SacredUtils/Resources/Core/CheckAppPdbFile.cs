using System;
using System.IO;
using static SacredUtils.Resources.Core.AppConstStrings;

namespace SacredUtils.Resources.Core
{
    internal class CheckAppPdbFile
    {
        public void GetAvailablePdbFile()
        {
            if (!File.Exists(AppNameExtension + ".pdb"))
            {
                try
                {
                    File.WriteAllBytes(AppNameExtension + ".pdb", Properties.Resources.SacredUtils);
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }
    }
}
