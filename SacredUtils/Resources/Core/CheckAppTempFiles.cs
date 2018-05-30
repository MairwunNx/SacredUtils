using System;
using log4net;
using System.IO;

namespace SacredUtils.Resources.Core
{
    public class CheckAppTempFiles
    {
        private static readonly ILog Log = LogManager.GetLogger("LOGGER");
        
        public void CheckAvailableTempFiles() // Проверяем наличие временных файлов.
        {
            Log.Info("Проверяем / Получаем временные файлы в текущей директории.");

            if (Directory.Exists("Temp"))
            {
                Log.Info("Временные файлы были обнаружены в директории. Мы их удалим.");

                try
                {
                    const string tempDir = "Temp"; Directory.Delete(tempDir, true);

                    Log.Info("Временные файлы были удалены из директории без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Error("При удалении временных файлов произошла ошибка."); Log.Error(exception.ToString());
                }
            }
            else if (!Directory.Exists("Temp"))
            {
                Log.Info("Временные файлы SacredUtils не найдены, продолжаем работу.");
            }
        }
    }
}
