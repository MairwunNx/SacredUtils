using System;
using log4net;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace SacredUtils.Resources.Core
{
    internal class CheckLogConfiguration
    {
        private static readonly ILog Log = LogManager.GetLogger("LOGGER");

        private readonly string _appname = Path.GetFileName(Application.ExecutablePath);

        public void GetAvailableLogConfig() // Проверяем наличие конфигурации лога.
        {
            Logger.Logger.InitLogger();

            Log.Info("Проверяем наличие файла конфигурации лога.");

            if (!File.Exists(_appname + ".config"))
            {
                Log.Warn("Файл конфигурации лога не был найден в директории.");

                Log.Info("Создаем файл конфигурации лога из ресурсов SacredUtils.");

                try
                {
                    File.WriteAllBytes(_appname + ".config", Properties.Resources.SacredUtils_exe);

                    Log.Info("Файл конфигурации лога был создан без ошибок.");

                    Log.Info("Для полноценной работы файла конфигурации лога нужна перезагрузка.");

                    Log.Info("Завершение все процессов и задач, перезапуск программы.");

                    Process.Start(_appname); Environment.Exit(0);
                }
                catch (Exception exception)
                {
                    Log.Error("При создании файла конфигурации лога произошла ошибка."); Log.Error(exception.ToString());
                }
            }

            Log.Info("Файл конфигурации лога был найден, продолжаем работу.");
        }
    }
}
