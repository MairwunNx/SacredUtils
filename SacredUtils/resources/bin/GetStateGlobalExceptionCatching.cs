using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SacredUtils.resources.bin
{
    public static class GetStateGlobalExceptionCatching
    {
        public static void Get()
        {
            if (AppSettings.ApplicationSettings.EnableGlobalExceptionCatching)
            {
                if (!File.Exists($"{AppSummary.AppPatchExeName.Remove(AppSummary.AppPatchExeName.IndexOf('.'))}.pdb"))
                {
                    File.WriteAllBytes($"{AppSummary.AppPatchExeName.Remove(AppSummary.AppPatchExeName.IndexOf('.'))}.pdb", Properties.Resources.SacredUtils);
                }

                Subscribe();
            }
        }

        private static void Subscribe()
        {
            AppDomain.CurrentDomain.UnhandledException += Catch;
        }

        private static void Catch(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;

            AppLogger.Log.Fatal("\n\n    There was a critical error that provoked the forced termination of the program.\n    Crash-report-log was created in $SacredUtils\\crash-reports, send it crash-report-log to MairwunNx\n");

            DateTime now = DateTime.Now;

            Directory.CreateDirectory("$SacredUtils\\crash-reports");

            File.WriteAllText(
                $"$SacredUtils\\crash-reports\\crash-{DateTime.Now.ToString(AppSettings.ApplicationSettings.ScreenShotSaveFilePattern)}-su.txt",
                $"---- SacredUtils Crash Report Details ----\n\n    There was a critical error of the program, sorry please, if the program could not start \n    Please contact MairwunNx, MairwunNx@gmail.com. May be it our problem. Sorry. );\n\n    In extreme cases, write in the VK (rus) or telegram (eng) (telegram \\ vk (@MairwunNx))\n\nCrash Created Time: {now}\nDescription: There was a severe problem during SacredUtils loading that has caused the SacredUtils to fail\n\nSacredUtils Version: {AppSummary.Version} \\ {AppSummary.AVersion} {AppSummary.Type}\n\nOperating System: {Environment.OSVersion.VersionString} {RuntimeInformation.OSArchitecture}\n\n{e.ToString()}");
            
            Environment.Exit(0);
        }
    }
}
