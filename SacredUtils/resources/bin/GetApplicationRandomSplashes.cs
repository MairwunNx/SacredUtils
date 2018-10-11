using System;
using System.IO;
using System.Text;

namespace SacredUtils.resources.bin
{
    public static class GetApplicationRandomSplashes
    {
        public static string GetRandomSplash()
        {
            File.WriteAllText("$SacredUtils\\conf\\splashes.txt", Properties.Resources.splashes, Encoding.UTF8);

            string[] splashes = File.ReadAllLines("$SacredUtils\\conf\\splashes.txt", Encoding.UTF8);

            Random random = new Random();

            return splashes[random.Next(0, splashes.Length)];
        }
    }
}
