using SacredUtils.resources.bin.check;
using SacredUtils.resources.bin.create;
using SacredUtils.resources.bin.getting;
using SacredUtils.resources.bin.logger;
using System;
using System.Threading.Tasks;
using System.Windows;
using static SacredUtils.resources.bin.application.ApplicationInfo;
using SacredGameSettings = SacredUtils.resources.bin.convert.SacredGameSettings;

namespace SacredUtils
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Sw.Start();

            try
            {
                Logger.Get();

                GlobalizerLibrary.Get();

                ThemeFiles.Create();

                LanguageFiles.Create();

                ApplicationSettings.Get();

                AvailabilityGameSettings.Get();

                SacredGameSettings.ConvertToIni("by program");

                RequiredApplicationFiles.Get();

                Task.Run(() => ApplicationStatistic.Get());

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
