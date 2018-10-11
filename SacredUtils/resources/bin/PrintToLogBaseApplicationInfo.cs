using System;
using System.Runtime.InteropServices;

namespace SacredUtils.resources.bin
{
    public static class PrintToLogBaseApplicationInfo
    {
        public static void Print()
        {
            AppLogger.Log.Info("============================================================");

            AppLogger.Log.Info($"Starting {AppSummary.Name} configurator version {AppSummary.Version}");
            AppLogger.Log.Info($"You have launched an official {AppSummary.Type} build");
            AppLogger.Log.Info($"Current launched SacredUtils app name {AppDomain.CurrentDomain.FriendlyName}");

            AppLogger.Log.Info(AppDomain.CurrentDomain.IsFullyTrusted // I LOVE PUTIN ❤❤❤❤
                ? "Current launched SacredUtils application is fully trusted"
                : "Current launched SacredUtils application is not fully trusted");

            AppLogger.Log.Info($"Version of the common language runtime {Environment.Version}");
            AppLogger.Log.Info($"Full version of the common language runtime {RuntimeInformation.FrameworkDescription}");

            AppLogger.Log.Info($"OS version {Environment.OSVersion.VersionString} {RuntimeInformation.OSArchitecture} bit");

            AppLogger.Log.Info($"Bitness of the current SacredUtils process {RuntimeInformation.ProcessArchitecture} bit");

            AppLogger.Log.Info($"Allocated memory for SacredUtils {Environment.WorkingSet / 1024 / 1024} MB or {Environment.WorkingSet / 1024} KB");

            AppLogger.Log.Info($"Running by current user name profile {Environment.UserName}");

            AppLogger.Log.Info($"SacredUtils current domain assemblies count {AppDomain.CurrentDomain.GetAssemblies().Length}");

            AppLogger.Log.Info("Involved dirs (6) : conf, logs, back, themes, lang");

            AppLogger.Log.Info("============================================================");
        }
    }
}
