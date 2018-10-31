using SacredUtils.resources.bin;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static SacredUtils.AppLogger;

namespace SacredUtils
{
    public partial class App
    {
        public static int ScreenWidthDevice = Screen.PrimaryScreen.Bounds.Width;
        public static int ScreenHeightDevice = Screen.PrimaryScreen.Bounds.Height;

        protected override void OnStartup(StartupEventArgs e)
        {
            AppSummary.Sw.Start();

            if (e.Args.Contains("-runGame"))
            {
                Log.Info($"Screenshoting enable with {ScreenWidthDevice}x{ScreenHeightDevice} resolution");

                ApplicationRunSacredGameWithArgs.Run(e.Args);

                Current.StartupUri = new Uri("resources/pgs/InvisibilityWindowForGame.xaml", UriKind.Relative);

                CheckAvailabilityInternetConnection.GetConnect();

                CreateApplicationNeededFolders.Create();

                GetApplicationSettingsValue.Get();

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

                    GetApplicationSettingsValue.Get();

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
