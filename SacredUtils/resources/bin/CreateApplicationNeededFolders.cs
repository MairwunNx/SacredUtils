using System.IO;

namespace SacredUtils.resources.bin
{
    public static class CreateApplicationNeededFolders
    {
        public static void Create()
        {
            Directory.CreateDirectory("$SacredUtils\\conf");
            Directory.CreateDirectory("$SacredUtils\\logs");
            Directory.CreateDirectory("$SacredUtils\\themes");
            Directory.CreateDirectory("$SacredUtils\\lang\\ru-RU");
            Directory.CreateDirectory("$SacredUtils\\lang\\en-US");
            Directory.CreateDirectory("$SacredUtils\\back\\cfg-game");
            Directory.CreateDirectory("$SacredUtils\\back\\cfg-app");

            AppLogger.Log.Info("SacredUtils directories was successfully re-created!");
        }
    }
}
