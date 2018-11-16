using SacredUtils.resources.bin;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using static SacredUtils.AppLogger;

namespace SacredUtils
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppSummary.Sw.Start();

            if (e.Args.Contains("-runGame"))
            {
                Log.Info($"-ScreenModeResolution {ScreenResolution.ScreenX}x{ScreenResolution.ScreenY} coordinates");

                ApplicationRunSacredGameWithArgs.Run(e.Args);

                Current.StartupUri = new Uri("resources/pgs/InvisibilityWindowForGame.xaml", UriKind.Relative);

                CheckAvailabilityInternetConnection.GetConnect();

                CreateApplicationNeededFolders.Create();

                GetApplicationSettingsAvailability.Get();

                GetRequiredApplicationFiles.Get();

                Task.Run(() => { GetApplicationDownloadStatistic.Get(); });
            }
            else
            {
                if (e.Args.Contains("-fast"))
                {
                    AppLogger.Init(true);
                }
                else
                {
                    CreateApplicationNeededFolders.Create();

                    GetApplicationSettingsAvailability.Get();

                    AppLogger.Init(false);

                    GetStateGlobalExceptionCatching.Get();

                    PrintToLogBaseApplicationInfo.Print();

                    CheckAvailabilityInternetConnection.GetConnect();

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
        }
    }
}
