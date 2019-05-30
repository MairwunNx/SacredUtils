using System;
using System.IO;
using System.Text;

namespace SacredUtils.resources.bin
{
    public static class ApplicationHotKeyGetSystemKeyValue
    {
        public static string Get(string value)
        {
            string[] text = File.ReadAllLines("$SacredUtils\\conf\\hk.setg.txt", Encoding.UTF8);
            string keyValue = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains(value))
                {
                    string key = Reverse(text[i]);
                    string valueKey = Reverse(key.Replace(" = ", "=").Substring(key.IndexOf('=')));
                    keyValue = ApplicationHotKeyConvertKeyValue.Convert(valueKey);
                }
            }

            return keyValue;
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
