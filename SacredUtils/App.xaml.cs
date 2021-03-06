using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SacredUtils.resources.bin;
using SacredUtils.SourceFiles;
using SacredUtils.SourceFiles.bin;
using SacredUtils.SourceFiles.language;
using SacredUtils.SourceFiles.settings;
using SacredUtils.SourceFiles.theme;
using SacredUtils.SourceFiles.utils;
using static System.IO.Directory;
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
            CreateDirectories();
            ApplicationSettingsManager.LoadSettings();
            GetApplicationSettingsAvailability.Get();

            if (e.Args.Contains("-runGame"))
            {
                Logger.Init(e.Args.Contains("-disableLogging"));

                ExceptionCatching.Init();

                GetRequiredApplicationFiles.Get();

                ApplicationRunSacredGameWithArgs.Run(e.Args);

                Current.StartupUri = new Uri("resources/pgs/InvisibilityWindowForGame.xaml",
                    UriKind.Relative);

                Task.Run(GetApplicationDownloadStatistic.Get);
            }
            else
            {
                Logger.Init(e.Args.Contains("-disableLogging"));

                ExceptionCatching.Init();

                PrintBaseInfo.Print();

                NetworkUtils.LogStatus();

                GetApplicationGlobalizerLibrary.Get();

                LanguageFileManager.CreateLanguageFiles();

                ThemeFileManager.CreateThemeFiles();

                CheckAvailabilityGameSettings.Get();

                CreateBackupApplicationSettings.Create();

                CreateBackupSacredGameSettings.Create();

                GetRequiredApplicationFiles.Get();

                CheckAvailabilityUpdateTemp.Get();

                Task.Run(GetApplicationDownloadStatistic.Get);

                base.OnStartup(e);
            }
        }

        private static void CreateDirectories()
        {
            foreach (var directoryPath in InvolvedDirs)
            {
                CreateDirectory(directoryPath);
            }
        }
    }
}
