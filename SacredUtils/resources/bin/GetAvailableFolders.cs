using System.IO;

namespace SacredUtils.resources.bin
{
    public class GetAvailableFolders
    {
        public void Get()
        {
            Directory.CreateDirectory("$SacredUtils");
            Directory.CreateDirectory("$SacredUtils\\conf");
            Directory.CreateDirectory("$SacredUtils\\lang");
            Directory.CreateDirectory("$SacredUtils\\logs");
            Directory.CreateDirectory("$SacredUtils\\temp");
            Directory.CreateDirectory("$SacredUtils\\back");
        }
    }
}
