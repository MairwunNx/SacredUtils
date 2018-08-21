using NLog;
using NLog.Targets;

namespace SacredUtils.resources.bin
{
    public class GetLoggerConfig
    { 
        public static Logger Log = LogManager.GetCurrentClassLogger();

        public void Get()
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new FileTarget("logfile")
            {
                FileName = "${basedir}/$SacredUtils/logs/latest.log",
                ArchiveFileName = "${basedir}/$SacredUtils/logs/${shortdate}.log.gz",
                Layout = "[${longdate}] [${threadid}/${uppercase:${level}}]: ${message}",
                ArchiveOldFileOnStartup = true,
                EnableArchiveFileCompression = true,
                MaxArchiveFiles = 10
            };

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logfile);

            LogManager.Configuration = config;
        }
    }
}
