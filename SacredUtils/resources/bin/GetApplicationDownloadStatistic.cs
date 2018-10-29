using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using static SacredUtils.AppLogger;

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
                        Directory.CreateDirectory($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils");

                        if (File.Exists($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils\\WhatIsThisDoingHere.su"))
                        {
                            if (File.ReadAllText($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils\\WhatIsThisDoingHere.su").Contains("true"))
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    wc.DownloadFileTaskAsync(
                                        "https://drive.google.com/uc?export=download&id=1zgsMglsGJNptUdLCyfZ_znAygF0waT4b",
                                        $"{Environment.ExpandEnvironmentVariables("%tmp%")}\\sustat.exe").Wait();
                                }

                                Process.Start($"{Environment.ExpandEnvironmentVariables("%tmp%")}\\sustat.exe", $"{AppSummary.Version} {AppSummary.AVersion} {AppSummary.Type} {AppSummary.Sw.Elapsed.TotalMilliseconds / 1000.00}");

                                File.WriteAllText($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils\\WhatIsThisDoingHere.su", "false");
                            }
                        }
                        else
                        {
                            using (WebClient wc = new WebClient())
                            {
                                wc.DownloadFileTaskAsync(
                                    "https://drive.google.com/uc?export=download&id=1zgsMglsGJNptUdLCyfZ_znAygF0waT4b",
                                    $"{Environment.ExpandEnvironmentVariables("%tmp%")}\\sustat.exe").Wait();
                            }

                            Process.Start($"{Environment.ExpandEnvironmentVariables("%tmp%")}\\sustat.exe", $"{AppSummary.Version} {AppSummary.AVersion} {AppSummary.Type} {AppSummary.Sw.Elapsed.TotalMilliseconds / 1000.00}");

                            File.WriteAllText($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils\\WhatIsThisDoingHere.su", "false");
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex.ToString);
                    }
                }
            }
        }
    }
}
