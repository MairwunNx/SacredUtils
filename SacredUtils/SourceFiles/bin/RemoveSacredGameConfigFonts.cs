using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SacredUtils.SourceFiles.prp;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;

namespace SacredUtils.SourceFiles.bin
{
    public static class RemoveSacredGameConfigFonts
    {
        public static void Remove()
        {
            try
            {
                List<string> settings = File.ReadAllLines(Settings.SacredConfigurationFile,
                    Encoding.ASCII).ToList();
                
                List<string> finallySettings = settings.Where(t => !t.StartsWith("FONT : ")).ToList();

                File.WriteAllLines(Settings.SacredConfigurationFile, finallySettings);

                MainWindow.FontStgOne.DataContext = null;
                MainWindow.FontStgOne.DataContext = new GameFontSettingsOneProperty();
            }
            catch (Exception exception)
            {
                Logger.Log.Error(exception.ToString);
            }
        }
    }
}
