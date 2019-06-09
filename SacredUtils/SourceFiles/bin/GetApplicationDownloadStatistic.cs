using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using SacredUtils.SourceFiles.settings;
using SacredUtils.SourceFiles.utils;

namespace SacredUtils.SourceFiles.bin
{
    public static class GetApplicationDownloadStatistic
    {
        public static void Get()
        {
            if (!ApplicationSettingsManager.Settings.EnableApplicationTelemetry) { return; }

            if (!NetworkUtils.IsConnected.Value) { return; }

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

                        Process.Start($"{Environment.ExpandEnvironmentVariables("%tmp%")}\\sustat.exe", $"{ApplicationInfo.Version} {ApplicationInfo.AlphaVersion} {ApplicationInfo.Type} {ApplicationInfo.StartupStopwatch.Elapsed.TotalMilliseconds / 1000.00}");

                        File.WriteAllText($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils\\WhatIsThisDoingHere.su", "false");
                    }
                }
                else
                {
                    // todo: fix sending statistic
                    WebClient wc = new WebClient();

                    wc.DownloadFileTaskAsync(
                         "https://drive.google.com/uc?export=download&id=1zgsMglsGJNptUdLCyfZ_znAygF0waT4b",
                         $"{Environment.ExpandEnvironmentVariables("%tmp%")}\\sustat.exe").Wait();

                    wc.DownloadFileCompleted += (s, e) =>
                    {
                        Process.Start($"{Environment.ExpandEnvironmentVariables("%tmp%")}\\sustat.exe",
                            $"{ApplicationInfo.Version} {ApplicationInfo.AlphaVersion} {ApplicationInfo.Type} {ApplicationInfo.StartupStopwatch.Elapsed.TotalMilliseconds / 1000.00}");

                        File.WriteAllText(
                            $"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils\\WhatIsThisDoingHere.su",
                            "false");
                    };
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.ToString);
            }
        }
    }
}
