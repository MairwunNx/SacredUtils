using System;
using log4net;
using System.IO;

namespace SacredUtils.Resources.Core
{
    class CheckAppLicenseFile
    {
        private static readonly ILog Log = LogManager.GetLogger("LOGGER");

        public void GetAvailableLicenseFile()
        {
            Log.Info("Создаем файл лицензии Apache 2.0 для SacredUtils.");

            try
            {
                File.WriteAllBytes("license.txt", Properties.Resources.license);

                Log.Info("Файл лицензии Apache 2.0 для SacredUtils был создан без ошибок.");
            }
            catch (Exception exception)
            {
                Log.Error("При создании файла лицензии Apache 2.0 для SacredUtils произошла ошибка.");

                Log.Error(exception.ToString());
            }
        }
    }
}
