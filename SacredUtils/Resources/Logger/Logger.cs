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
                Log.Info("Starting reading logger configuration.");

                XmlConfigurator.Configure();

                Log.Info("Reading logger configuration done.");
            }
            catch (Exception exception)
            {
                Log.Error("Reading logger configuration done with error.");

                Log.Error(exception.ToString());
            }
        }
    }
}