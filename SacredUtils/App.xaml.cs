using SacredUtils.resources.bin;
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
                    AppLogger.Init(true);
                }
                else
                {
                    AppLogger.Init(false);

                    PrintToLogBaseApplicationInfo.Print();

                    CheckAvailabilityInternetConnection.GetConnect();

                    CreateApplicationNeededFolders.Create();

                    GetApplicationSettingsValue.Get();

                    GetApplicationGlobalizerLibrary.Get();

                    CreateApplicationLanguageFiles.Create();

                    CreateApplicationThemeFiles.Create();

                    CheckAvailabilityGameSettings.Get();

                    CreateBackupApplicationSettings.Create();

                    CreateBackupSacredGameSettings.Create();

                    GetRequiredApplicationFiles.Get();

                    CheckAvailabilityUpdateTemp.Get();
                }

                base.OnStartup(e);

                Task.Run(() => { GetApplicationDownloadStatistic.Get(); });
            }
            catch (Exception exception)
            {
                AppLogger.Log.Fatal("\n\n    There was a critical error of the program, sorry please, if the program could not start \n    Please contact MairwunNx, MairwunNx@gmail.com. May be it our problem. Sorry. );\n\n    In extreme cases, write in the VK (rus) or telegram (eng) (telegram \\ vk (@MairwunNx))\n");

                AppLogger.Log.Fatal(exception.ToString);

                AppLogger.Log.Info("Shutting down SacredUtils configurator ...");

                Environment.Exit(0);
            }
        }
    }
}
