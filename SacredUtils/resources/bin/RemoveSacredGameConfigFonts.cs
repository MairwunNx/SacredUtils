using SacredUtils.resources.prp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SacredUtils.resources.bin
{
    public static class RemoveSacredGameConfigFonts
    {
        public static void Remove()
        {
            try
            {
                List<string> settings = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile,
                    Encoding.ASCII).ToList();
                
                List<string> finallySettings = new List<string>();

                for (int i = 0; i < settings.Count; i++)
                {
                    if (!settings[i].StartsWith("FONT : "))
                    {
                        finallySettings.Add(settings[i]);
                    }
                }

                File.WriteAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, finallySettings);

                MainWindow.FontStgOne.DataContext = null;
                MainWindow.FontStgOne.DataContext = new GameFontSettingsOneProperty();
            }
            catch (Exception exception)
            {
                AppLogger.Log.Error(exception.ToString);
            }
        }
    }
}
