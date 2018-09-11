using System;
using System.Text;

namespace SacredUtils.resources.bin
{
    public static class GetFtpBase64Pass
    {
        public static void Get()
        {
            GetLoggerConfig.Log.Info("Getting nedeed data for download statistics ...");

            byte[] base64EncodedBytes = Convert.FromBase64String("MTEzMTcxNTFQbGVhc2VOb3RDaGFuZ2U=");
            ApplicationInfo.Connect = Encoding.UTF8.GetString(base64EncodedBytes);

            GetLoggerConfig.Log.Info("Getting nedeed data for download statistics done!");
        }
    }
}
