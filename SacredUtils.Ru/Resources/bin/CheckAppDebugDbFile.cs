using System;
using System.IO;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;

namespace SacredUtils.Resources.bin
{
    internal class CheckAppDebugDbFile
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
