using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SacredUtils
{
    public class GameSettings
    {
        private static void ChangeBooleanValue(string func, object value)
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
                var text = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

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

        public bool UniqueColor
        {
            get
            {
                bool contains = false;

                for (int i = 0; i < File.ReadAllLines("Settings.cfg", Encoding.ASCII).Length; i++)
                {
                    if (File.ReadAllLines("Settings.cfg", Encoding.ASCII)[i].Contains("UNIQUE_COLOR : 1"))
                    {
                        contains = true; break;
                    }
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
                int value = 0;

                for (int i = 0; i < File.ReadAllLines("Settings.cfg", Encoding.ASCII).Length; i++)
                {
                    if (File.ReadAllLines("Settings.cfg", Encoding.ASCII)[i].Contains("CHAT_DELAY : "))
                    {
                        value = int.Parse(File.ReadAllLines("Settings.cfg", Encoding.ASCII)[i].Substring(File.ReadAllLines("Settings.cfg", Encoding.ASCII)[i].IndexOf(": ", StringComparison.Ordinal) + 2));

                        break;
                    }
                }

                return value;
            }

            set => ChangeBooleanValue("CHAT_LINES", value);
        }
    }
}
