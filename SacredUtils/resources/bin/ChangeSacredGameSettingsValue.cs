using System;
using System.IO;
using System.Text;

namespace SacredUtils.resources.bin
{
    public static class ChangeSacredGameSettingsValue
    {
        public static void ChangeSettingValue(string func, object value)
        {
            try
            {
                if (!File.ReadAllText("Settings.cfg", Encoding.ASCII).Contains($"{func} : "))
                {
                    using (StreamWriter file = new StreamWriter("Settings.cfg", true, Encoding.ASCII))
                    {
                        file.WriteLine($"{func} : {value}");
                    }
                }
                else
                {
                    string[] text = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i].Contains($"{func} : "))
                        {
                            text[i] = $"{func} : {value}";

                            File.WriteAllLines("Settings.cfg", text);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                AppLogger.Log.Error("Unable to apply the setting due to an unknown error.");
                AppLogger.Log.Error(e.ToString);
            }
        }

        public static void ChangeSettingFontValue(string font)
        {
            try
            {
                if (!File.ReadAllText("Settings.cfg", Encoding.ASCII).Contains("FONT : 1, \""))
                {
                    using (StreamWriter file = new StreamWriter("Settings.cfg", true, Encoding.ASCII))
                    {
                        file.WriteLine($"FONT : 1, \"{font}\", 10");
                    }
                }
                else
                {
                    string[] text1 = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                    for (int i = 0; i < text1.Length; i++)
                    {
                        if (text1[i].Contains("FONT : 1, \""))
                        {
                            text1[i] = $"FONT : 1, \"{font}\", 10"; File.WriteAllLines("Settings.cfg", text1);
                        }
                    }
                }

                if (!File.ReadAllText("Settings.cfg", Encoding.ASCII).Contains("FONT : 2, \""))
                {
                    using (StreamWriter file = new StreamWriter("Settings.cfg", true, Encoding.ASCII))
                    {
                        file.WriteLine($"FONT : 2, \"{font}\", 10");
                    }
                }
                else
                {
                    string[] text1 = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                    for (int i = 0; i < text1.Length; i++)
                    {
                        if (text1[i].Contains("FONT : 2, \""))
                        {
                            text1[i] = $"FONT : 2, \"{font}\", 10"; File.WriteAllLines("Settings.cfg", text1);
                        }
                    }
                }

                if (!File.ReadAllText("Settings.cfg", Encoding.ASCII).Contains("FONT : 3, \""))
                {
                    using (StreamWriter file = new StreamWriter("Settings.cfg", true, Encoding.ASCII))
                    {
                        file.WriteLine($"FONT : 3, \"{font}\", 12");
                    }
                }
                else
                {
                    string[] text1 = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                    for (int i = 0; i < text1.Length; i++)
                    {
                        if (text1[i].Contains("FONT : 3, \""))
                        {
                            text1[i] = $"FONT : 3, \"{font}\", 12"; File.WriteAllLines("Settings.cfg", text1);
                        }
                    }
                }

                if (!File.ReadAllText("Settings.cfg", Encoding.ASCII).Contains("FONT : 4, \""))
                {
                    using (StreamWriter file = new StreamWriter("Settings.cfg", true, Encoding.ASCII))
                    {
                        file.WriteLine($"FONT : 4, \"{font}\", 15");
                    }
                }
                else
                {
                    string[] text1 = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                    for (int i = 0; i < text1.Length; i++)
                    {
                        if (text1[i].Contains("FONT : 4, \""))
                        {
                            text1[i] = $"FONT : 4, \"{font}\", 15"; File.WriteAllLines("Settings.cfg", text1);
                        }
                    }
                }

                if (!File.ReadAllText("Settings.cfg", Encoding.ASCII).Contains("FONT : 5, \""))
                {
                    using (StreamWriter file = new StreamWriter("Settings.cfg", true, Encoding.ASCII))
                    {
                        file.WriteLine($"FONT : 5, \"{font}\", 12");
                    }
                }
                else
                {
                    string[] text1 = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                    for (int i = 0; i < text1.Length; i++)
                    {
                        if (text1[i].Contains("FONT : 5, \""))
                        {
                            text1[i] = $"FONT : 5, \"{font}\", 12"; File.WriteAllLines("Settings.cfg", text1);
                        }
                    }
                }

                if (!File.ReadAllText("Settings.cfg", Encoding.ASCII).Contains("FONT : 6, \""))
                {
                    using (StreamWriter file = new StreamWriter("Settings.cfg", true, Encoding.ASCII))
                    {
                        file.WriteLine($"FONT : 6, \"{font}\", 12");
                    }
                }
                else
                {
                    string[] text1 = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                    for (int i = 0; i < text1.Length; i++)
                    {
                        if (text1[i].Contains("FONT : 6, \""))
                        {
                            text1[i] = $"FONT : 6, \"{font}\", 12"; File.WriteAllLines("Settings.cfg", text1);
                        }
                    }
                }

                if (!File.ReadAllText("Settings.cfg", Encoding.ASCII).Contains("FONT : 7, \""))
                {
                    using (StreamWriter file = new StreamWriter("Settings.cfg", true, Encoding.ASCII))
                    {
                        file.WriteLine($"FONT : 7, \"{font}\", 8");
                    }
                }
                else
                {
                    string[] text1 = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                    for (int i = 0; i < text1.Length; i++)
                    {
                        if (text1[i].Contains("FONT : 7, \""))
                        {
                            text1[i] = $"FONT : 7, \"{font}\", 8"; File.WriteAllLines("Settings.cfg", text1);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                AppLogger.Log.Error("Unable to apply the setting due to an unknown error.");
                AppLogger.Log.Error(e.ToString);
            }
        }
    }
}
