using System;
using System.IO;
using System.Text;
using System.Windows;

namespace SacredUtils
{
    public class GameSettings
    {
        private static void ChangeBooleanValue(string func, object value)
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
                MessageBox.Show(e.ToString());
            }
        }

        public bool UniqueColor
        {
            get
            {
                string[] text = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                bool contains = false;

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].Contains("UNIQUE_COLOR : 1")) { contains = true; break; }
                }

                return contains;
            }

            set => ChangeBooleanValue("UNIQUE_COLOR", value ? 1 : 0);
        }

        public int Language
        {
            get
            {
                string[] text = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                int index = 0;

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].Contains("LANGUAGE : RU")) { index = 0; break; }

                    if (text[i].Contains("LANGUAGE : US")) { index = 1; break; }

                    if (text[i].Contains("LANGUAGE : DE")) { index = 2; break; }

                    if (text[i].Contains("LANGUAGE : SP")) { index = 3; break; }

                    if (text[i].Contains("LANGUAGE : FR")) { index = 4; break; }
                }

                return index;
            }

            set
            {
                switch (value)
                {
                    case 0: ChangeBooleanValue("LANGUAGE", "RU"); break;
                    case 1: ChangeBooleanValue("LANGUAGE", "US"); break;
                    case 2: ChangeBooleanValue("LANGUAGE", "DE"); break;
                    case 3: ChangeBooleanValue("LANGUAGE", "SP"); break;
                    case 4: ChangeBooleanValue("LANGUAGE", "FR"); break;
                }
            }
        }

        public int ChatLines
        {
            get
            {
                string[] text = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                int value = 0;

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].Contains("CHAT_LINES : "))
                    {
                        value = int.Parse(text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2));

                        break;
                    }
                }

                return value;
            }

            set => ChangeBooleanValue("CHAT_LINES", value);
        }
    }
}
