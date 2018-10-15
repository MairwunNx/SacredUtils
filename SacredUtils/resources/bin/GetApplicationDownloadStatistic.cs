using Config.Net;
using FluentFTP;
using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SacredUtils.resources.bin
{
    public interface IDownloadCount
    {
        int Downloads { get; set; }
    }

    public interface IStartCount
    {
        int Launches { get; set; }
        int AuthorLaunches { get; set; } 
    }

    public static class GetApplicationDownloadStatistic
    {
        public static async void Get()
        {
            if (!AppSettings.ApplicationSettings.DisableTelemetry)
            {
                if (CheckAvailabilityInternetConnection.Connect())
                {
                    AppSummary.Connect = Encoding.UTF8.GetString(Convert.FromBase64String("MTEzMTcxNTFQbGVhc2VOb3RDaGFuZ2U="));

                    try
                    {
                        FtpClient client = new FtpClient("files.000webhost.com");

                        client.Credentials = new NetworkCredential("mairwunnxstatistic", AppSummary.Connect);

                        await Task.Run(() => client.ConnectAsync());

                        if (AppSettings.ApplicationSettings.WhatIsThisDoingHere)
                        {
                            await Task.Run(() => client.DownloadFileAsync("$SacredUtils\\conf\\statinfo.json", "/stat.sacredutils/downloads.json"));
                            await Task.Run(() => client.DownloadFileAsync("$SacredUtils\\conf\\userinfo.txt", "/stat.sacredutils/userinfo.txt"));
                        }

                        await Task.Run(() => client.DownloadFileAsync("$SacredUtils\\conf\\runinfo.json", "/stat.sacredutils/runinfo.json"));

                        await Task.Run(() => client.DisconnectAsync());

                        Add();
                    }
                    catch (Exception e)
                    {
                        AppLogger.Log.Error("An error occurred while retrieving the statistics file!");
                        AppLogger.Log.Error(e.ToString);
                    }
                }
            }
        }

        private static void Add()
        {
            if (AppSettings.ApplicationSettings.WhatIsThisDoingHere)
            {
                IDownloadCount downloadCount = new ConfigurationBuilder<IDownloadCount>()
                    .UseJsonFile("$SacredUtils\\conf\\statinfo.json").Build();

                downloadCount.Downloads = downloadCount.Downloads + 1;

                using (StreamWriter file = new StreamWriter("$SacredUtils\\conf\\userinfo.txt", true, Encoding.UTF8))
                {
                    file.WriteLine($"ID: ({GetCurrentMachineHardwareID.GetHWID()}) | USER: ({Environment.UserName}) | SYSTEM: ({Environment.OSVersion.VersionString} {RuntimeInformation.OSArchitecture}) | SUVERSTION: ({AppSummary.Version})");
                }
            }

            if (Environment.UserName != "Nynxx")
            {
                IStartCount startCount = new ConfigurationBuilder<IStartCount>()
                    .UseJsonFile("$SacredUtils\\conf\\runinfo.json").Build();

                startCount.Launches = startCount.Launches + 1;
            }
            else
            {
                IStartCount startCount = new ConfigurationBuilder<IStartCount>()
                    .UseJsonFile("$SacredUtils\\conf\\runinfo.json").Build();

                startCount.AuthorLaunches = startCount.AuthorLaunches + 1;
            }

            Send();
        }

        private static async void Send()
        {
            try
            {
                FtpClient client = new FtpClient("files.000webhost.com");

                client.Credentials = new NetworkCredential("mairwunnxstatistic", AppSummary.Connect);

                await Task.Run(() => client.ConnectAsync());

                if (AppSettings.ApplicationSettings.WhatIsThisDoingHere)
                {
                    await Task.Run(() => client.UploadFileAsync("$SacredUtils\\conf\\statinfo.json", "/stat.sacredutils/downloads.json"));
                    await Task.Run(() => client.UploadFileAsync("$SacredUtils\\conf\\userinfo.txt", "/stat.sacredutils/userinfo.txt"));
                }
                    
                await Task.Run(() => client.UploadFileAsync("$SacredUtils\\conf\\runinfo.json", "/stat.sacredutils/runinfo.json"));

                await Task.Run(() => client.DisconnectAsync());

                if (AppSettings.ApplicationSettings.WhatIsThisDoingHere)
                {
                    File.Delete("$SacredUtils\\conf\\statinfo.json");
                    File.Delete("$SacredUtils\\conf\\userinfo.txt");

                    AppSettings.ApplicationSettings.WhatIsThisDoingHere = false;
                }
                
                File.Delete("$SacredUtils\\conf\\runinfo.json");
               
                AppLogger.Log.Info("!enod sdaolnwod scitsitats noitacilppa slitUdercaS gnidneS");
            }
            catch (Exception e)
            {
                AppLogger.Log.Error("An error occurred while uploading the SacredUtils statistics file!");
                AppLogger.Log.Error(e.ToString);
            }
        }
    }
}
