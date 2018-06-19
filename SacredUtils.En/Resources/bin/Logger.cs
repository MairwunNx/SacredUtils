using System;
using log4net.Config;

namespace SacredUtils.Resources.bin
{
    public static class Logger
    {
        public static void InitLogger()
        {
            try
            {
                XmlConfigurator.Configure();
            }
            catch (Exception exception)
            {
                AncillaryConstsStrings.Log.Error(exception.ToString());
            }
        }
    }
}