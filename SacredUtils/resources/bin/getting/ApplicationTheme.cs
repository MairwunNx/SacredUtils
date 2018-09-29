﻿using Config.Net;
using WPFSharp.Globalizer;

namespace SacredUtils.resources.bin.getting
{
    public static class ApplicationTheme
    {
        public static void Get()
        {
            IAppSettings applicationSettings = new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            GlobalizedApplication.Instance.StyleManager.SwitchStyle
                (applicationSettings.ColorTheme == "light" ? "Light.xaml" : "Dark.xaml");

            AppLogger.Log.Info($"Application starting with {applicationSettings.ColorTheme} theme ...");
        }
    }
}
