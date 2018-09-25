using Config.Net;
using SacredUtils.resources.bin.etc;
using SacredUtils.resources.bin.logger;

namespace SacredUtils.resources.bin.getting
{
    public interface IScaleSettings
    {
        double SacredUtilsGuiScale { get; }
    }

    public static class ApplicationScale
    {
        public static void Get()
        {
            Logger.Log.Info("Getting application gui scale ...");

            IScaleSettings scaleSettings = new ConfigurationBuilder<IScaleSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            ApplicationInfo.Scale = scaleSettings.SacredUtilsGuiScale;

            Logger.Log.Info("Getting application gui scale done!");

            Logger.Log.Info($"Application starting with {ApplicationInfo.Scale} gui scale");
        }
    }
}
