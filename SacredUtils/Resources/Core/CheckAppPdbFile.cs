using System;
using System.IO;
using static SacredUtils.Resources.Core.AppConstStrings;

namespace SacredUtils.Resources.Core
{
    internal class CheckAppPdbFile
    {
        public void GetAvailablePdbFile()
        {
            Log.Info("Checking availability " + Appnameextension + ".pdb debug file.");

            if (!File.Exists(Appnameextension + ".pdb"))
            {
                try
                {
                    Log.Warn("Debug file " + Appnameextension + ".pdb " + "was not found.");

                    Log.Info("Starting creating debug file " + Appnameextension + ".pdb.");

                    File.WriteAllBytes(Appnameextension + ".pdb", Properties.Resources.SacredUtils);

                    Log.Info("Debug file " + Appnameextension + ".pdb " + "was created by program.");
                }
                catch (Exception exception)
                {
                    Log.Error("An error occurred while creating the debug file " + Appnameextension + ".pdb.");

                    Log.Error(exception.ToString());
                }
            }
            else
            {
                Log.Info("Debug file " + Appnameextension + ".pdb " + "was found.");
            }
        }
    }
}
