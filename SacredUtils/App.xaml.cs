using SacredUtils.resources.bin.check;
using SacredUtils.resources.bin.convert;
using SacredUtils.resources.bin.create;
using SacredUtils.resources.bin.getting;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SacredUtils
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppSummary.Sw.Start();

            try
            {
                if (e.Args.Contains("-fast"))
                {
                    AppLogger.Init(true); SacredGameSettings.ConvertToIni("by program");
                }
                else
                {
                    AppLogger.Init(false); GlobalizerLibrary.Get();

                    ThemeFiles.Create(); LanguageFiles.Create();

                    AvailabilityGameSettings.Get(); ApplicationSettings.Get();

                    SacredGameSettings.ConvertToIni("by program");

                    RequiredApplicationFiles.Get();

                    Task.Run(() => ApplicationStatistic.Get());
                }

                base.OnStartup(e);
            }
            catch (Exception exception)
            {
                AppLogger.Log.Fatal("There was a critical error of the program, sorry please, if the program could not start. Contact the Creator of the utility");
                AppLogger.Log.Fatal("Please contact MairwunNx, MairwunNx@gmail.com. May be it our problem. Sorry. );");

                AppLogger.Log.Fatal(exception.ToString);

                AppLogger.Log.Info("Shutting down SacredUtils configurator ...");

                Environment.Exit(0);
            }
        }
    }
}
