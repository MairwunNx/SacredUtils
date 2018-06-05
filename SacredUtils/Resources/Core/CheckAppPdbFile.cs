using System;
using log4net;
using System.IO;
using System.Windows.Forms;

namespace SacredUtils.Resources.Core
{
    class CheckAppPdbFile
    {
        private static readonly ILog Log = LogManager.GetLogger("LOGGER");
        private static readonly string Appname = Path.GetFileName(Application.ExecutablePath);
        private static readonly string Appnameextension = Path.GetFileNameWithoutExtension(Appname);
        
        public void GetAvailablePdbFile()
        {
            Log.Info("Проверяем / Получаем наличие pdb файла в директории.");

            if (!File.Exists(Appnameextension + ".pdb"))
            {
                try
                {
                    Log.Warn("Файл отладки " + Appnameextension + ".pdb " + "не был найден.");

                    File.WriteAllBytes(Appnameextension + ".pdb", Properties.Resources.SacredUtils);

                    Log.Info("Файл отладки " + Appnameextension + ".pdb " + "был создан из ресурсов программы.");
                }
                catch (Exception exception)
                {
                    Log.Error("При создании файла отладки " + Appnameextension + ".pdb " + "Произошла ошибка.");

                    Log.Error(exception.ToString());
                }
            }
            else
            {
                Log.Info("Файл отладки " + Appnameextension + ".pdb " + "был обнаружен.");
            }
        }
    }
}
