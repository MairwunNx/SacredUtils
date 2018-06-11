using System;
using System.IO;
using static SacredUtils.Resources.Core.AppConstStrings;

namespace SacredUtils.Resources.Core
{
    public class CheckAppTempFiles
    {
        public void CheckAvailableTempFiles()
        {
            if (Directory.Exists(AppTempFolder))
            {
                try
                {
                    const string tempDir = AppTempFolder; Directory.Delete(tempDir, true);
                }
                catch (Exception exception)
                {
                     Log.Error(exception.ToString());
                }
            }
        }
    }
}
