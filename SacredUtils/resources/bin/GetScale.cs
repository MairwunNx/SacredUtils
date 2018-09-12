using Config.Net;

namespace SacredUtils.resources.bin
{
    public interface IScaleSettings
    {
        double SacredUtilsGuiScale { get; }
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
