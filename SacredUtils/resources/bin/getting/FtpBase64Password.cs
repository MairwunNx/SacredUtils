using SacredUtils.resources.bin.etc;
using SacredUtils.resources.bin.logger;
using System;
using System.Text;

namespace SacredUtils.resources.bin.getting
{
    public static class FtpBase64Password
    {
        public static void Get()
        {
            Logger.Log.Info("Getting needed data for download statistics ...");

            byte[] base64EncodedBytes = Convert.FromBase64String("MTEzMTcxNTFQbGVhc2VOb3RDaGFuZ2U=");
            ApplicationInfo.Connect = Encoding.UTF8.GetString(base64EncodedBytes);

            Logger.Log.Info("Getting needed data for download statistics done!");
        }
    }
}
