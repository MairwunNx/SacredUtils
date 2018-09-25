using SacredUtils.resources.bin.check;
using SacredUtils.resources.bin.create;
using SacredUtils.resources.bin.logger;
using System;
using System.Threading.Tasks;
using System.Windows;
using SacredUtils.resources.bin.getting;
using SacredGameSettings = SacredUtils.resources.bin.convert.SacredGameSettings;

namespace SacredUtils
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                Logger.Get();

                ApplicationFolders.Create();

                Task.Run(() => AvailabilityUpdateTool.Get());

                Task.Run(() => AvailabilityGameSettings.Get());

                Task.Run(() => ApplicationStatistic.Get());

                Task.Run(() => ThemeFiles.Create());

                Task.Run(() => LanguageFiles.Create());

                GlobalizerLibrary.Get(1);

                new SettingsVersion().Get();

                Task.Run(() => ApplicationLanguage.Get());

                Task.Run(() => ApplicationTheme.Get());

                Task.Run(() => ApplicationScale.Get());

                Task.Run(() => RequiredApplicationFiles.Get());

                base.OnStartup(e);

                SacredGameSettings.ConvertToIni();
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
