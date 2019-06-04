using System;
using System.IO;
using System.Text;
using static SacredUtils.SourceFiles.Logger;

namespace SacredUtils.resources.bin
{
    public static class ChangeSacredGameSettingsValue
    {
        private static readonly string SacredConfigFile = AppSettings.ApplicationSettings.SacredConfigurationFile;

        public static void ChangeSettingValue(string func, object value)
        {
            try
            {
                if (!File.ReadAllText(SacredConfigFile, Encoding.ASCII).Contains($"{func} : "))
                {
                    using (StreamWriter file = new StreamWriter(SacredConfigFile, true, Encoding.ASCII))
                    {
                        file.WriteLine($"{func} : {value}");
                    }
                }
                else
                {
                    string[] text = File.ReadAllLines(SacredConfigFile, Encoding.ASCII);

                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i].Contains($"{func} : "))
                        {
                            text[i] = $"{func} : {value}";

                            File.WriteAllLines(SacredConfigFile, text);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error("Unable to apply the setting due to an unknown error.");
                Log.Error(e.ToString);
            }
        }

        public static void ChangeSettingFontValue(string font)
        {
            try
            {
                string[] sizes = AppSettings.ApplicationSettings.SacredFontSizeArray.Split('|');

                for (int i = 0; i < 7; i++)
                {
                    int fontSettings = i + 1;

                    if (File.ReadAllText(SacredConfigFile, Encoding.ASCII).Contains($"FONT : {fontSettings}, \""))
                    {
                        string[] text1 = File.ReadAllLines(SacredConfigFile, Encoding.ASCII);

                        for (int j = 0; j < text1.Length; j++)
                        {
                            if (text1[j].Contains($"FONT : {fontSettings}, \""))
                            {
                                text1[j] = $"FONT : {fontSettings}, \"{font}\", {sizes[i]}";
                                File.WriteAllLines(SacredConfigFile, text1);
                            }
                        }
                    }
                    else
                    {
                        using (StreamWriter file = new StreamWriter(SacredConfigFile, true, Encoding.ASCII))
                        {
                            file.WriteLine($"FONT : {fontSettings}, \"{font}\", {sizes[i]}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error("Unable to apply the setting due to an unknown error.");
                Log.Error(e.ToString);
            }
        }
    }
}
