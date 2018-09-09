using NLog;
using NLog.Targets;
using static SacredUtils.resources.bin.ApplicationInfo;

namespace SacredUtils.resources.bin
{
    public static class GetLoggerConfig
    { 
        public static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public static void Get()
        {
            NLog.Config.LoggingConfiguration config = new NLog.Config.LoggingConfiguration();

            FileTarget logfile = new FileTarget("logfile")
            {
                FileName                     = "${basedir}/$SacredUtils/logs/latest.log",
                ArchiveFileName              = "${basedir}/$SacredUtils/logs/${shortdate}.log.gz",
                Layout                       = "[${longdate}] [${threadid}/${uppercase:${level}}]: ${message}",
                ArchiveOldFileOnStartup      = true,
                EnableArchiveFileCompression = true,
                MaxArchiveFiles              = 10
            };

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logfile);

            LogManager.Configuration = config;

            Log.Info($"Starting {Name} configurator version {Version}");
            Log.Info($"You have launched an official {Type} build");
        }
    }
}
