using System;
using log4net.Config;
using static SacredUtils.Resources.Core.AppConstStrings;

namespace SacredUtils.Resources.Logger
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
                Log.Error(exception.ToString());
            }
        }
    }
}