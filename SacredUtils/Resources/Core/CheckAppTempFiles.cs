using System;
using System.IO;
using static SacredUtils.Resources.Core.AppConstStrings;

namespace SacredUtils.Resources.Core
{
    public class CheckAppTempFiles
    {
        public void CheckAvailableTempFiles() // Проверяем наличие временных файлов.
        {
            Log.Info("Проверяем / Получаем временные файлы в текущей директории.");

            if (Directory.Exists(AppTempFolder))
            {
                Log.Info("Временные файлы были обнаружены в директории. Мы их удалим.");

                try
                {
                    const string tempDir = AppTempFolder; Directory.Delete(tempDir, true);

                    Log.Info("Временные файлы были удалены из директории без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Error("При удалении временных файлов произошла ошибка."); Log.Error(exception.ToString());
                }
            }
            else if (!Directory.Exists(AppTempFolder))
            {
                Log.Info("Временные файлы SacredUtils не найдены, продолжаем работу.");
            }
        }
    }
}
