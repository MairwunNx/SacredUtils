using System;
using System.IO;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;

namespace SacredUtils.Resources.bin
{
    public class CheckAppTempFiles
    {
        public void CheckAvailableTempFiles()
        {
            if (Directory.Exists(AppTempFolder))
            {
                try
                {
                    Directory.Delete(AppTempFolder, true);
                }
                catch (Exception exception)
                {
                     Log.Error(exception.ToString());
                }
            }
        }
    }
}
