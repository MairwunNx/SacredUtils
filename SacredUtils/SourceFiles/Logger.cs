using System.Text;
using NLog;
using NLog.Config;
using NLog.Targets;
using static SacredUtils.AppSettings;

namespace SacredUtils.SourceFiles
{
    public static class Logger
    {
        public static readonly NLog.Logger Log = LogManager.GetCurrentClassLogger();

        private const string DefaultLayout =
            "[${longdate}] [${threadid}/${uppercase:${level}}]: ${message}";

        public static void Init(bool disableLogging)
        {
            if (disableLogging ||
                ApplicationSettings.DisableApplicationLogging)
            {
                return;
            }

            LoggingConfiguration config = new LoggingConfiguration();
            FileTarget logfile = new FileTarget("logfile")
            {
                FileName = "${basedir}/$SacredUtils/logs/latest.log",
                ArchiveFileName = "${basedir}/$SacredUtils/logs/${shortdate}.log.gz",
                Layout = ResolveLayout(ApplicationSettings.ApplicationLoggingMethodName),
                ArchiveOldFileOnStartup = ApplicationSettings.ArchiveOldFileOnStartup,
                EnableArchiveFileCompression = ApplicationSettings.EnableArchiveFileCompression,
                Encoding = Encoding.UTF8,
                MaxArchiveFiles = ApplicationSettings.MaxApplicationArchiveFiles
            };
            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logfile);
            LogManager.Configuration = config;
        }

        private static string ResolveLayout(bool methodLogging)
        {
            if (methodLogging)
            {
                return DefaultLayout.Replace(
                    "[${longdate}] ",
                    "[${longdate}] [${callsite}] "
                );
            }

            return DefaultLayout;
        }
    }
}
