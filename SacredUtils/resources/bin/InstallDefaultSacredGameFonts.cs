using SacredUtils.resources.prp;
using System;
using System.IO;
using System.Text;

namespace SacredUtils.resources.bin
{
    public static class InstallDefaultSacredGameFonts
    {
        public static void Install()
        {
            try
            {
                int[] sizes = { 13, 12, 16, 25, 16, 18, 8 };
                string[] fonts = { "CyrillicChancellor", "AntiquaSSK", "CyrillicChancellor", "AntiquaSSK", "AntiquaSSK", "AntiquaSSK", "CyrillicChancellor" };

                for (var i = 0; i < 7; i++)
                {
                    int fontSettings = i + 1;

                    if (File.ReadAllText(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII).Contains($"FONT : {fontSettings}, \""))
                    {
                        string[] text1 = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                        for (int j = 0; j < text1.Length; j++)
                        {
                            if (text1[j].Contains($"FONT : {fontSettings}, \""))
                            {
                                text1[j] = $"FONT : {fontSettings}, \"{fonts[i]}\", {sizes[i]}";

                                File.WriteAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, text1);
                            }
                        }
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(AppSettings.ApplicationSettings.SacredConfigurationFile, true, Encoding.ASCII))
                        {
                            file.WriteLine($"FONT : {fontSettings}, \"{fonts[i]}\", {sizes[i]}");
                        }
                    }
                }

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
