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

        
    }
}
