using System;
using System.Diagnostics;
using System.IO;

// ReSharper disable EmptyGeneralCatchClause
namespace SacredUtils.resources.bin
{
    public static class GetApplicationDownloadStatistic
    {
        public static void Get()
        {
            if (!AppSettings.ApplicationSettings.DisableTelemetry)
            {
                if (CheckAvailabilityInternetConnection.Connect())
                {
                    try
                    {
                        File.WriteAllBytes($"{Environment.ExpandEnvironmentVariables("%tmp%")}\\sustat.exe", Properties.Resources.SacredUtilsStatistics);

                        Process.Start($"{Environment.ExpandEnvironmentVariables("%tmp%")}\\sustat.exe", $"{AppSummary.Version} {AppSettings.ApplicationSettings.DisableTelemetry.ToString().ToLower()} {AppSettings.ApplicationSettings.WhatIsThisDoingHere.ToString().ToLower()}");

                        AppSettings.ApplicationSettings.WhatIsThisDoingHere = false;
                    }
                    catch { }
                }
            }
        }
    }
}
