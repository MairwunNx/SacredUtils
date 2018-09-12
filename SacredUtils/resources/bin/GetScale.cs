using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Config.Net;

namespace SacredUtils.resources.bin
{
    public interface IScaleSettings
    {
        double SacredUtilsGuiScale { get; set; }
    }

    public static class GetScale
    {
        public static void Get()
        {
            GetLoggerConfig.Log.Info("Getting application gui scale ...");

            IScaleSettings scaleSettings = new ConfigurationBuilder<IScaleSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            ApplicationInfo.Scale = scaleSettings.SacredUtilsGuiScale;

            GetLoggerConfig.Log.Info("Getting application gui scale done!");

            GetLoggerConfig.Log.Info($"Application starting with {ApplicationInfo.Scale} gui scale ...");
        }
    }
}
