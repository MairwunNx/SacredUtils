using System;
using System.IO;
using System.Net;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class DownloadApplicationNewUpdate
    {
        private static readonly WebClient Wc = new WebClient();

        public static void Download(string update, string type)
        {
            if (File.Exists("_newVersionSacredUtilsTemp.exe")) { File.Delete("_newVersionSacredUtilsTemp.exe"); }

            Wc.DownloadFileTaskAsync(new Uri(update), "_newVersionSacredUtilsTemp.exe").Wait();
            Log.Info($"Downloading new SacredUtils {type} update successfully done!");
            DownloadApplicationUpdateTool.Download();
        }
    }
}
