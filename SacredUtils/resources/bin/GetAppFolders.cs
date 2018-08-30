using System.IO;

namespace SacredUtils.resources.bin
{
    public class GetAppFolders
    {
        public void Get()
        {
            Directory.CreateDirectory("$SacredUtils");
            Directory.CreateDirectory("$SacredUtils\\conf");
            Directory.CreateDirectory("$SacredUtils\\lang");
            Directory.CreateDirectory("$SacredUtils\\logs");
            Directory.CreateDirectory("$SacredUtils\\temp");
            Directory.CreateDirectory("$SacredUtils\\back");
            Directory.CreateDirectory("$SacredUtils\\themes");
            Directory.CreateDirectory("$SacredUtils\\lang\\ru-RU");
            Directory.CreateDirectory("$SacredUtils\\lang\\en-US");
            Directory.CreateDirectory("$SacredUtils\\themes\\dark");
            Directory.CreateDirectory("$SacredUtils\\themes\\light");
        }
    }
}
