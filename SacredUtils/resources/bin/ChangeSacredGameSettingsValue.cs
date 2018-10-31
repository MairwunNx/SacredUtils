using System;
using System.IO;
using System.Text;
using static SacredUtils.AppLogger;

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

                if (!File.ReadAllText(SacredConfigFile, Encoding.ASCII).Contains("FONT : 1, \""))
                {
                    using (StreamWriter file = new StreamWriter(SacredConfigFile, true, Encoding.ASCII))
                    {
                        file.WriteLine($"FONT : 1, \"{font}\", {sizes[0]}");
                    }
                }
                else
                {
                    string[] text1 = File.ReadAllLines(SacredConfigFile, Encoding.ASCII);

                    for (int i = 0; i < text1.Length; i++)
                    {
                        if (text1[i].Contains("FONT : 1, \""))
                        {
                            text1[i] = $"FONT : 1, \"{font}\", {sizes[0]}"; File.WriteAllLines(SacredConfigFile, text1);
                        }
                    }
                }

                if (!File.ReadAllText(SacredConfigFile, Encoding.ASCII).Contains("FONT : 2, \""))
                {
                    using (StreamWriter file = new StreamWriter(SacredConfigFile, true, Encoding.ASCII))
                    {
                        file.WriteLine($"FONT : 2, \"{font}\", {sizes[1]}");
                    }
                }
                else
                {
                    string[] text1 = File.ReadAllLines(SacredConfigFile, Encoding.ASCII);

                    for (int i = 0; i < text1.Length; i++)
                    {
                        if (text1[i].Contains("FONT : 2, \""))
                        {
                            text1[i] = $"FONT : 2, \"{font}\", {sizes[1]}"; File.WriteAllLines(SacredConfigFile, text1);
                        }
                    }
                }

                if (!File.ReadAllText(SacredConfigFile, Encoding.ASCII).Contains("FONT : 3, \""))
                {
                    using (StreamWriter file = new StreamWriter(SacredConfigFile, true, Encoding.ASCII))
                    {
                        file.WriteLine($"FONT : 3, \"{font}\", {sizes[2]}");
                    }
                }
                else
                {
                    string[] text1 = File.ReadAllLines(SacredConfigFile, Encoding.ASCII);

                    for (int i = 0; i < text1.Length; i++)
                    {
                        if (text1[i].Contains("FONT : 3, \""))
                        {
                            text1[i] = $"FONT : 3, \"{font}\", {sizes[2]}"; File.WriteAllLines(SacredConfigFile, text1);
                        }
                    }
                }

                if (!File.ReadAllText(SacredConfigFile, Encoding.ASCII).Contains("FONT : 4, \""))
                {
                    using (StreamWriter file = new StreamWriter(SacredConfigFile, true, Encoding.ASCII))
                    {
                        file.WriteLine($"FONT : 4, \"{font}\", {sizes[3]}");
                    }
                }
                else
                {
                    string[] text1 = File.ReadAllLines(SacredConfigFile, Encoding.ASCII);

                    for (int i = 0; i < text1.Length; i++)
                    {
                        if (text1[i].Contains("FONT : 4, \""))
                        {
                            text1[i] = $"FONT : 4, \"{font}\", {sizes[3]}"; File.WriteAllLines(SacredConfigFile, text1);
                        }
                    }
                }

                if (!File.ReadAllText(SacredConfigFile, Encoding.ASCII).Contains("FONT : 5, \""))
                {
                    using (StreamWriter file = new StreamWriter(SacredConfigFile, true, Encoding.ASCII))
                    {
                        file.WriteLine($"FONT : 5, \"{font}\", {sizes[4]}");
                    }
                }
                else
                {
                    string[] text1 = File.ReadAllLines(SacredConfigFile, Encoding.ASCII);

                    for (int i = 0; i < text1.Length; i++)
                    {
                        if (text1[i].Contains("FONT : 5, \""))
                        {
                            text1[i] = $"FONT : 5, \"{font}\", {sizes[4]}"; File.WriteAllLines(SacredConfigFile, text1);
                        }
                    }
                }

                if (!File.ReadAllText(SacredConfigFile, Encoding.ASCII).Contains("FONT : 6, \""))
                {
                    using (StreamWriter file = new StreamWriter(SacredConfigFile, true, Encoding.ASCII))
                    {
                        file.WriteLine($"FONT : 6, \"{font}\", {sizes[5]}");
                    }
                }
                else
                {
                    string[] text1 = File.ReadAllLines(SacredConfigFile, Encoding.ASCII);

                    for (int i = 0; i < text1.Length; i++)
                    {
                        if (text1[i].Contains("FONT : 6, \""))
                        {
                            text1[i] = $"FONT : 6, \"{font}\", {sizes[5]}"; File.WriteAllLines(SacredConfigFile, text1);
                        }
                    }
                }

                if (!File.ReadAllText(SacredConfigFile, Encoding.ASCII).Contains("FONT : 7, \""))
                {
                    using (StreamWriter file = new StreamWriter(SacredConfigFile, true, Encoding.ASCII))
                    {
                        file.WriteLine($"FONT : 7, \"{font}\", {sizes[6]}");
                    }
                }
                else
                {
                    string[] text1 = File.ReadAllLines(SacredConfigFile, Encoding.ASCII);

                    for (int i = 0; i < text1.Length; i++)
                    {
                        if (text1[i].Contains("FONT : 7, \""))
                        {
                            text1[i] = $"FONT : 7, \"{font}\", {sizes[6]}"; File.WriteAllLines(SacredConfigFile, text1);
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
