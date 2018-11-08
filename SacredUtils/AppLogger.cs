using NLog;
using NLog.Config;
using NLog.Targets;
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
                if (!AppSettings.ApplicationSettings.DisableApplicationLogging && AppSettings.ApplicationSettings.ApplicationLoggingMethodName)
                {
                    LoggingConfiguration config = new LoggingConfiguration();

                    FileTarget logfile = new FileTarget("logfile")
                    {
                        FileName = "${basedir}/$SacredUtils/logs/latest.log",
                        ArchiveFileName = "${basedir}/$SacredUtils/logs/${shortdate}.log.gz",
                        Layout = "[${longdate}] [${callsite}] [${threadid}/${uppercase:${level}}]: ${message}",
                        ArchiveOldFileOnStartup = AppSettings.ApplicationSettings.ArchiveOldFileOnStartup,
                        EnableArchiveFileCompression = AppSettings.ApplicationSettings.EnableArchiveFileCompression,
                        Encoding = Encoding.UTF8,
                        MaxArchiveFiles = AppSettings.ApplicationSettings.MaxApplicationArchiveFiles
                    };

                    config.AddRule(LogLevel.Info, LogLevel.Fatal, logfile);

                    LogManager.Configuration = config;
                }
                else if (!AppSettings.ApplicationSettings.DisableApplicationLogging)
                {
                    LoggingConfiguration config = new LoggingConfiguration();

                    FileTarget logfile = new FileTarget("logfile")
                    {
                        FileName = "${basedir}/$SacredUtils/logs/latest.log",
                        ArchiveFileName = "${basedir}/$SacredUtils/logs/${shortdate}.log.gz",
                        Layout = "[${longdate}] [${threadid}/${uppercase:${level}}]: ${message}",
                        ArchiveOldFileOnStartup = AppSettings.ApplicationSettings.ArchiveOldFileOnStartup,
                        EnableArchiveFileCompression = AppSettings.ApplicationSettings.EnableArchiveFileCompression,
                        Encoding = Encoding.UTF8,
                        MaxArchiveFiles = AppSettings.ApplicationSettings.MaxApplicationArchiveFiles
                    };

                    config.AddRule(LogLevel.Info, LogLevel.Fatal, logfile);

                    LogManager.Configuration = config;
                }
            }
        }
    }
}
