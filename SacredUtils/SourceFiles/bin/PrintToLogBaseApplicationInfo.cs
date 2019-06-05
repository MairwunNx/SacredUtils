using System;
using System.Linq;
using System.Runtime.InteropServices;
using SacredUtils.SourceFiles;
using SacredUtils.SourceFiles.extensions;
using static SacredUtils.SourceFiles.Logger;

namespace SacredUtils.resources.bin
{
    public static class PrintToLogBaseApplicationInfo
    {
        public static void Print()
        {
            if (AppSettings.ApplicationSettings.DisablePrintBaseInfoToLog ||
                ApplicationInfo.AppArguments.Contains("-disablePrintBaseInfoToLog")) return;

            Log.Info("============================================================");

            Log.Info(ApplicationInfo.Type == "Alpha"
                ? $"Starting {ApplicationInfo.Name} configurator version {ApplicationInfo.AlphaVersion}"
                : $"Starting {ApplicationInfo.Name} configurator version {ApplicationInfo.Version}");

            Log.Info($"You have launched an official {ApplicationInfo.Type} build");
            Log.Info($"Current launched SacredUtils app name {ApplicationInfo.CurrentExe}");

            Log.Info(AppDomain.CurrentDomain.IsFullyTrusted
                ? "Current launched SacredUtils application is fully trusted"
                : "Current launched SacredUtils application is not fully trusted");

            Log.Info($"Version of the common language runtime {Environment.Version}");
            Log.Info(
                $"Full version of the common language runtime {RuntimeInformation.FrameworkDescription}");

            Log.Info(
                $"OS version {Environment.OSVersion.VersionString} {RuntimeInformation.OSArchitecture} bit");

            Log.Info(
                $"Bitness of the current SacredUtils process {RuntimeInformation.ProcessArchitecture} bit");

            Log.Info(
                $"Allocated memory for SacredUtils {Environment.WorkingSet / 1024 / 1024} MB or {Environment.WorkingSet / 1024} KB");

            Log.Info($"Running by current user name profile {Environment.UserName}");

            Log.Info(
                $"SacredUtils current domain assemblies count {AppDomain.CurrentDomain.GetAssemblies().Length}");

            Log.Info(
                $"Involved dirs ({ApplicationInfo.InvolvedDirs.Length}) : {ApplicationInfo.InvolvedDirs.ToNormalString()}");

            Log.Info("============================================================");
        }
    }
}
