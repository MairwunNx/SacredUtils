using Config.Net;
// ReSharper disable InconsistentNaming

namespace SacredUtils
{
    public interface IGameSettings
    {
        [Option(Alias = "ACCEPT_LICENSE", DefaultValue = "1")]
        int ACCEPT_LICENSE { get; set; }

        [Option(Alias = "AUTOSAVE", DefaultValue = "1")]
        int AUTOSAVE { get; set; }

        [Option(Alias = "AUTOSAVEDELAY", DefaultValue = "300")]
        int AUTOSAVEDELAY { get; set; }

        [Option(Alias = "AUTOTRACKENEMY", DefaultValue = "1")]
        int AUTOTRACKENEMY { get; set; }

        [Option(Alias = "CHAT_ALPHA", DefaultValue = "130")]
        int CHAT_ALPHA { get; set; }

        [Option(Alias = "CHAT_DELAY", DefaultValue = "8")]
        int CHAT_DELAY { get; set; }

        [Option(Alias = "CHAT_LINES", DefaultValue = "5")]
        int CHAT_LINES { get; set; }

        [Option(Alias = "COMBINE_SLOTS", DefaultValue = "1")]
        int COMBINE_SLOTS { get; set; }

        [Option(Alias = "COMPAT_VIDEO", DefaultValue = "1")]
        int COMPAT_VIDEO { get; set; }

        [Option(Alias = "DEFAULT_SKILLS", DefaultValue = "1")]
        int DEFAULT_SKILLS { get; set; }

        [Option(Alias = "DETAILLEVEL", DefaultValue = "2")]
        int DETAILLEVEL { get; set; }

        [Option(Alias = "EXPLOREMAP", DefaultValue = "1")]
        int EXPLOREMAP { get; set; }

        [Option(Alias = "FIRST_LOGIN", DefaultValue = "0")]
        int FIRST_LOGIN { get; set; }

        [Option(Alias = "FONTAA", DefaultValue = "1")]
        int FONTAA { get; set; }

        [Option(Alias = "FONTFILTER", DefaultValue = "1")]
        int FONTFILTER { get; set; }

        [Option(Alias = "FONTPAGES", DefaultValue = "1")]
        int FONTPAGES { get; set; }

        [Option(Alias = "FORCE_BLACK_SHADOW", DefaultValue = "0")]
        int FORCE_BLACK_SHADOW { get; set; }

        [Option(Alias = "FSAA_FILTER", DefaultValue = "1")]
        int FSAA_FILTER { get; set; }

        [Option(Alias = "FULLSCREEN", DefaultValue = "1")]
        int FULLSCREEN { get; set; }

        [Option(Alias = "GFX32", DefaultValue = "1")]
        int GFX32 { get; set; }

        [Option(Alias = "GFXLOADING", DefaultValue = "LOADING0.BMP")]
        string GFXLOADING { get; set; }

        [Option(Alias = "GFXSTARTUP", DefaultValue = "LOADING1.BMP")]
        int GFXSTARTUP { get; set; }

        [Option(Alias = "GFX_LIMIT128", DefaultValue = "0")]
        int GFX_LIMIT128 { get; set; }

        [Option(Alias = "LADDER_EXPORT", DefaultValue = "0")]
        int LADDER_EXPORT { get; set; }

        [Option(Alias = "LANGUAGE", DefaultValue = "null")]
        string LANGUAGE { get; set; }

        [Option(Alias = "LOG", DefaultValue = "0")]
        int LOG { get; set; }

        [Option(Alias = "LOGGING", DefaultValue = "0")]
        int LOGGING { get; set; }

        [Option(Alias = "MINIMAP_ALPHA", DefaultValue = "110")]
        int MINIMAP_ALPHA { get; set; }

        [Option(Alias = "MUSICVOLUME", DefaultValue = "55")]
        int MUSICVOLUME { get; set; }

        [Option(Alias = "NETLOG", DefaultValue = "0")]
        int NETLOG { get; set; }

        [Option(Alias = "NETWORK_SPEEDSETTINGS", DefaultValue = "1")]
        int NETWORK_SPEEDSETTINGS { get; set; }

        [Option(Alias = "NIGHT_DARKNESS", DefaultValue = "25")]
        int NIGHT_DARKNESS { get; set; }

        [Option(Alias = "PICKUPANIM", DefaultValue = "0")]
        int PICKUPANIM { get; set; }

        [Option(Alias = "PICKUPAUTO", DefaultValue = "0")]
        int PICKUPAUTO { get; set; }

        [Option(Alias = "SCREEN_QUAKE", DefaultValue = "0")]
        int SCREEN_QUAKE { get; set; }

        [Option(Alias = "SFXVOLUME", DefaultValue = "55")]
        int SFXVOLUME { get; set; }

        [Option(Alias = "SHOWEXTRO", DefaultValue = "1")]
        int SHOWEXTRO { get; set; }

        [Option(Alias = "SHOWMOVIE", DefaultValue = "1")]
        int SHOWMOVIE { get; set; }

        [Option(Alias = "SHOWPOTIONS", DefaultValue = "1")]
        int SHOWPOTIONS { get; set; }

        [Option(Alias = "SHOW_ENEMYINFO", DefaultValue = "1")]
        int SHOW_ENEMYINFO { get; set; }

        [Option(Alias = "SHOW_HEROINFO", DefaultValue = "1")]
        int SHOW_HEROINFO { get; set; }

        [Option(Alias = "SOUND", DefaultValue = "1")]
        int SOUND { get; set; }

        [Option(Alias = "SOUNDQUALITY", DefaultValue = "1")]
        int SOUNDQUALITY { get; set; }

        [Option(Alias = "TASKBAR_ICONS", DefaultValue = "1")]
        int TASKBAR_ICONS { get; set; }

        [Option(Alias = "UNIQUE_COLOR", DefaultValue = "1")]
        int UNIQUE_COLOR { get; set; }

        [Option(Alias = "VIOLENCE", DefaultValue = "1")]
        int VIOLENCE { get; set; }

        [Option(Alias = "VOICEVOLUME", DefaultValue = "55")]
        int VOICEVOLUME { get; set; }

        [Option(Alias = "WAITRETRACE", DefaultValue = "0")]
        int WAITRETRACE { get; set; }

        [Option(Alias = "WARNING_LEVEL", DefaultValue = "25")]
        int WARNING_LEVEL { get; set; }
    }

    public static class GameSettings
    {
        public static readonly IGameSettings SacredGameSettings =
            new ConfigurationBuilder<IGameSettings>()
                .UseIniFile("$SacredUtils\\temp\\~Settings.ini").Build();
    }
}
