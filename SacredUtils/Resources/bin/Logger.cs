using log4net.Config;
using System;

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