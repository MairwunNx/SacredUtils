using NLog;
using NLog.Targets;
using SacredUtils.resources.bin.etc;
using System;
using System.Management;
using System.Text;
using static SacredUtils.resources.bin.etc.ApplicationInfo;

namespace SacredUtils.resources.bin.logger
{
    public static class Logger
    { 
        public static readonly NLog.Logger Log = LogManager.GetCurrentClassLogger();

        public static void Get()
        {
            string Query = "Select Name from Win32_OperatingSystem";
            NLog.Config.LoggingConfiguration config = new NLog.Config.LoggingConfiguration();
            AppDomain domain = AppDomain.CurrentDomain;

            FileTarget logfile = new FileTarget("logfile")
            {
                FileName                     = "${basedir}/$SacredUtils/logs/latest.log",
                ArchiveFileName              = "${basedir}/$SacredUtils/logs/${shortdate}.log.gz",
                Layout                       = "[${longdate}] [${threadid}/${uppercase:${level}}]: ${message}",
                ArchiveOldFileOnStartup      = true,
                EnableArchiveFileCompression = true,
                Encoding                     = Encoding.UTF8,
                MaxArchiveFiles              = 10
            };
            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logfile);

            LogManager.Configuration = config;

            Log.Info($"Starting {Name} configurator version {ApplicationInfo.Version}");
            Log.Info($"You have launched an official {ApplicationInfo.Type} build");
            Log.Info($"Current launched SacredUtils app name {domain.FriendlyName}");

            Log.Info(domain.IsFullyTrusted
                ? "Current launched SacredUtils application is fully trusted"
                : "Current launched SacredUtils application is not fully trusted");

            Log.Info($"Version of the common language runtime {Environment.Version}");

            Log.Info(Environment.Is64BitOperatingSystem
                ? $"OS version {Environment.OSVersion.VersionString} 64 bit"
                : $"OS version {Environment.OSVersion.VersionString} 32 bit");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(Query);
            // ReSharper disable once InconsistentNaming
            // ReSharper disable once PossibleInvalidCastExceptionInForeachLoop
            foreach (ManagementObject Win32 in searcher.Get())
            {
                // ReSharper disable once InconsistentNaming
                string OSVersion = Win32["Name"] as string;

                if (OSVersion != null)
                {
                    // ReSharper disable once InconsistentNaming
                    string OSName = OSVersion.Substring(0, OSVersion.LastIndexOf("|", StringComparison.Ordinal) - 11);

                    Log.Info($"OS full name {OSName}");
                }
            }

            Log.Info(Environment.Is64BitProcess
                ? "Bitness of the current SacredUtils process 64 bit"
                : "Bitness of the current SacredUtils process 32 bit");

            Log.Info($"Allocated memory for SacredUtils {Environment.WorkingSet / 1024 / 1024} MB");

            Log.Info($"Running by current user name profile {Environment.UserName}");
        }
    }
}
