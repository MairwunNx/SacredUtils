using System;
using System.Linq;
using System.Runtime.InteropServices;
using SacredUtils.SourceFiles.extensions;
using static SacredUtils.AppSettings;
using static SacredUtils.SourceFiles.ApplicationInfo;
using static SacredUtils.SourceFiles.Logger;

#pragma warning disable 162
// ReSharper disable UnreachableCode
// ReSharper disable ConditionIsAlwaysTrueOrFalse
namespace SacredUtils.SourceFiles
{
    public static class PrintBaseInfo
    {
        public static void Print()
        {
            if (ApplicationSettings.DisablePrintBaseInfoToLog ||
                AppArguments.Contains("-disablePrintBaseInfoToLog"))
            {
                return;
            }

            Log.Info("============================================================");
            Log.Info(ApplicationInfo.Type == "Alpha"
                ? $"Starting {Name} configurator version {AlphaVersion}"
                : $"Starting {Name} configurator version {ApplicationInfo.Version}");
            Log.Info($"You have launched an official {ApplicationInfo.Type} build");
            Log.Info($"Current launched SacredUtils app name {CurrentExe}");
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
                $"Involved dirs ({InvolvedDirs.Length}) : {InvolvedDirs.ToNormalString()}");
            Log.Info("============================================================");
        }
    }
}
