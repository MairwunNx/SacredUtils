using Config.Net;

namespace SacredUtils.resources.bin
{
    public interface IThemeSettings
    {
        string ColorTheme { get; set; }
    }

    public static class GetTheme
    {
        public static void Get()
        {
            IThemeSettings themeSettings = new ConfigurationBuilder<IThemeSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            ApplicationInfo.Theme = themeSettings.ColorTheme == "light" ? "light" : "dark";
        }
    }
}
