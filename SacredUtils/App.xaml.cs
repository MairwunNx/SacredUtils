using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SacredUtils.resources.bin;
using SacredUtils.SourceFiles;
using SacredUtils.SourceFiles.bin;
using static SacredUtils.SourceFiles.ApplicationInfo;

namespace SacredUtils
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            StartupStopwatch.Start();
            AppArguments = e.Args;
            SystemInfo.Init();
            ApplicationReset.Reset();
            GetApplicationSettingsAvailability.Get();

            if (e.Args.Contains("-runGame"))
            {
                Logger.Init(e.Args.Contains("-disableLogging"));

                GetRequiredApplicationFiles.Get();

                ApplicationRunSacredGameWithArgs.Run(e.Args);

                Current.StartupUri = new Uri("resources/pgs/InvisibilityWindowForGame.xaml",
                    UriKind.Relative);

                Task.Run(GetApplicationDownloadStatistic.Get);
            }
            else
            {
                Logger.Init(e.Args.Contains("-disableLogging"));

                GetStateGlobalExceptionCatching.Get();

                PrintToLogBaseApplicationInfo.Print();

                NetworkUtils.LogStatus();

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
