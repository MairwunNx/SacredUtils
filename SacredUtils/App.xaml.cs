using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SacredUtils.resources.bin;
using static SacredUtils.AppInfo;

namespace SacredUtils
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            StartupStopwatch.Start();
            AppArguments = e.Args;
            SystemInfo.Init();
            CauseApplicationReset.Reset();

            if (e.Args.Contains("-runGame"))
            {
                AppLogger.Init(e.Args.Contains("-disableLogging"));

                GetRequiredApplicationFiles.Get();

                ApplicationRunSacredGameWithArgs.Run(e.Args);

                Current.StartupUri = new Uri("resources/pgs/InvisibilityWindowForGame.xaml",
                    UriKind.Relative);

                Task.Run(GetApplicationDownloadStatistic.Get);
            }
            else
            {
                AppLogger.Init(e.Args.Contains("-disableLogging"));

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

                Task.Run(GetApplicationDownloadStatistic.Get);

                base.OnStartup(e);
            }
        }
    }
}
