using SacredUtils.resources.bin;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace SacredUtils
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                GetLoggerConfig.Get();

                GetAppFolders.Get();

                Task.Run(() => GetStatistic.Get());

                Task.Run(() => CreateThemeFiles.Create());

                Task.Run(() => CreateLanguageFiles.Create());

                GetGlobalizerLib.Get(1);

                new GetSettingsVersion().Get();

                Task.Run(() => new GetRequiredFiles().Get());

                //Task.Run(() => new GetAppSettings().Get());

                base.OnStartup(e); // Launch OnStartup method in WPFSharp.Globalizer.

                //Task.Run(() => new GetLanguage().Get());
            }
            catch (Exception exception)
            {
                GetLoggerConfig.Log.Fatal("There was a critical error of the program, sorry please, if the program could not start. Contact the Creator of the utility");
                GetLoggerConfig.Log.Fatal("Please contact MairwunNx, MairwunNx@gmail.com. May be it our problem. Sorry.");

                GetLoggerConfig.Log.Fatal(exception.ToString);

                GetLoggerConfig.Log.Info("Shutting down SacredUtils configurator ...");

                Environment.Exit(0);
            }
        }
    }
}
