using SacredUtils.resources.bin.check;
using SacredUtils.resources.bin.create;
using SacredUtils.resources.bin.get;
using SacredUtils.resources.bin.logger;
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
                Logger.Get();

                AppFolders.Create();

                Task.Run(() => AvailabilityUpdateTool.Get());

                Task.Run(() => AvailabilityGameSettings.Get());

                Task.Run(() => GetStatistic.Get());

                Task.Run(() => ThemeFiles.Create());

                Task.Run(() => LanguageFiles.Create());

                GetGlobalizerLib.Get(1);

                new GetSettingsVersion().Get();

                Task.Run(() => GetLanguage.Get());

                Task.Run(() => GetTheme.Get());

                Task.Run(() => GetScale.Get());

                Task.Run(() => GetRequiredFiles.Get());

                base.OnStartup(e);
            }
            catch (Exception exception)
            {
                Logger.Log.Fatal("There was a critical error of the program, sorry please, if the program could not start. Contact the Creator of the utility");
                Logger.Log.Fatal("Please contact MairwunNx, MairwunNx@gmail.com. May be it our problem. Sorry. );");

                Logger.Log.Fatal(exception.ToString);

                Logger.Log.Info("Shutting down SacredUtils configurator ...");

                Environment.Exit(0);
            }
        }
    }
}
