using SacredUtils.resources.prp;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace SacredUtils.resources.bin
{
    public static class InstallDefaultSacredGameFonts
    {
        public static void Install()
        {
            try
            {
                int[] sizes;
                int[] sizesRu = { 13, 12, 16, 25, 16, 18, 8 };
                int[] sizesEn = { 13, 12, 16, 20, 16, 18, 8 };

                string[] fonts;
                string[] fontsRu = { "CyrillicChancellor", "AntiquaSSK", "CyrillicChancellor", "AntiquaSSK", "AntiquaSSK", "AntiquaSSK", "CyrillicChancellor" };
                string[] fontsEn = { "AntiquaSSK", "Carolingia", "AntiquaSSK", "Carolingia", "Carolingia", "Carolingia", "AntiquaSSK" };
                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);
                string prefix = "LANGUAGE : ";
                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line == null)
                {
                    switch (MainWindow.ChatStgOne.UiLanguageCmbBox.SelectedIndex)
                    {
                        case 0: ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "RU"); break;
                        case 1: ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "US"); break;
                        case 2: ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "DE"); break;
                        case 3: ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "SP"); break;
                        case 4: ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "FR"); break;
                    }

                    string[] text2 = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                    string prefix2 = "LANGUAGE : ";

                    string line2 = text2.FirstOrDefault(x => x.StartsWith(prefix2));

                    sizes = line2?.Substring(prefix2.Length) == "RU" ? sizesRu : sizesEn;
                    fonts = line2?.Substring(prefix2.Length) == "RU" ? fontsRu : fontsEn;
                }
                else
                {
                    sizes = line.Substring(prefix.Length) == "RU" ? sizesRu : sizesEn;
                    fonts = line.Substring(prefix.Length) == "RU" ? fontsRu : fontsEn;
                }

                for (int i = 0; i < 7; i++)
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

                if (line?.Substring(prefix.Length) == "RU")
                {
                    Directory.CreateDirectory("font");
                    File.WriteAllBytes("font\\antqs__.ttf", Properties.Resources.antqs__);
                    File.WriteAllBytes("font\\CAROLING.ttf", Properties.Resources.cyrillicchancellor);
                }
                else
                {
                    Directory.CreateDirectory("font");
                    File.WriteAllBytes("font\\antqs__.ttf", Properties.Resources.antqs__);
                    File.WriteAllBytes("font\\CAROLING.ttf", Properties.Resources.carolingia);
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
