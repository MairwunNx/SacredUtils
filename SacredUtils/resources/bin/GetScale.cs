using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            IScaleSettings scaleSettings = new ConfigurationBuilder<IScaleSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            ApplicationInfo.Scale = scaleSettings.SacredUtilsGuiScale;
        }
    }
}
