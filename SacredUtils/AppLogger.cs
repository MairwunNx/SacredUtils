using Config.Net;
using NLog;
using NLog.Targets;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace SacredUtils
{
    public static class AppLogger
    { 
        public static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static void Init(bool fast)
        {
            if (!fast)
            {
                IAppSettings applicationSettings =
                    new ConfigurationBuilder<IAppSettings>()
                        .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

                if (!applicationSettings.DisableLogging)
                {
                    NLog.Config.LoggingConfiguration config = new NLog.Config.LoggingConfiguration();
                    AppDomain domain = AppDomain.CurrentDomain;

                    FileTarget logfile = new FileTarget("logfile")
                    {
                        FileName = "${basedir}/$SacredUtils/logs/latest.log",
                        ArchiveFileName = "${basedir}/$SacredUtils/logs/${shortdate}.log.gz",
                        Layout = "[${longdate}] [${threadid}/${uppercase:${level}}]: ${message}",
                        ArchiveOldFileOnStartup = applicationSettings.ArchiveOldFileOnStartup,
                        EnableArchiveFileCompression = applicationSettings.EnableArchiveFileCompression,
                        Encoding = Encoding.UTF8,
                        MaxArchiveFiles = applicationSettings.MaxArchiveFiles
                    };

                    config.AddRule(LogLevel.Info, LogLevel.Fatal, logfile);

                    LogManager.Configuration = config;

                    Log.Info("============================================================");

                    Log.Info($"Starting {AppSummary.Name} configurator version {AppSummary.Version}");
                    Log.Info($"You have launched an official {AppSummary.Type} build");
                    Log.Info($"Current launched SacredUtils app name {domain.FriendlyName}");

                    Log.Info(domain.IsFullyTrusted
                        ? "Current launched SacredUtils application is fully trusted"
                        : "Current launched SacredUtils application is not fully trusted");

                    Log.Info($"Version of the common language runtime {Environment.Version}");
                    Log.Info($"Full version of the common language runtime {RuntimeInformation.FrameworkDescription}");

                    Log.Info($"OS version {Environment.OSVersion.VersionString} {RuntimeInformation.OSArchitecture} bit");

                    // I LOVE PUTIN ❤❤❤❤

                    Log.Info($"Bitness of the current SacredUtils process {RuntimeInformation.ProcessArchitecture} bit");

                    Log.Info($"Allocated memory for SacredUtils {Environment.WorkingSet / 1024 / 1024} MB or {Environment.WorkingSet / 1024} KB");

                    Log.Info($"Running by current user name profile {Environment.UserName}");

                    Log.Info($"Status archiving old log file on startup {logfile.ArchiveOldFileOnStartup}");

                    Log.Info($"Status enabling archiving log file compression {logfile.EnableArchiveFileCompression}");

                    Log.Info($"Status log files current encoding value {logfile.Encoding}");

                    Log.Info($"Status max archives log files value {logfile.MaxArchiveFiles}");

                    Directory.CreateDirectory("$SacredUtils\\conf");
                    Directory.CreateDirectory("$SacredUtils\\logs");
                    Directory.CreateDirectory("$SacredUtils\\temp");
                    Directory.CreateDirectory("$SacredUtils\\themes");
                    Directory.CreateDirectory("$SacredUtils\\lang\\ru-RU");
                    Directory.CreateDirectory("$SacredUtils\\lang\\en-US");
                    Directory.CreateDirectory("$SacredUtils\\back\\cfg-game");
                    Directory.CreateDirectory("$SacredUtils\\back\\cfg-app");

                    Log.Info("Involved dirs (7) : conf, logs, temp, back, themes, lang");

                    Log.Info("============================================================");
                }
            }
        }
    }
}
