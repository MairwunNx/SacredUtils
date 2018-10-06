using Config.Net;
using FluentFTP;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SacredUtils.resources.bin
{
    public interface IDownloadCount
    {
        int Downloads { get; set; }
    }
    
    public static class GetApplicationDownloadStatistic
    {
        public static async void Get()
        {
            if (CheckAvailabilityInternetConnection.Connect())
            {
                AppSummary.Connect = Encoding.UTF8.GetString(Convert.FromBase64String("MTEzMTcxNTFQbGVhc2VOb3RDaGFuZ2U="));

                if (AppSettings.ApplicationSettings.WhatIsThisDoingHere)
                {
                    try
                    {
                        FtpClient client = new FtpClient("files.000webhost.com");

                        client.Credentials = new NetworkCredential("mairwunnxstatistic", AppSummary.Connect);

                        await Task.Run(() => client.ConnectAsync());

                        await Task.Run(() => client.DownloadFileAsync("$SacredUtils\\conf\\statinfo.json", "/sacredutils/downloads.json"));

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
            IDownloadCount downloadCount = new ConfigurationBuilder<IDownloadCount>()
                .UseJsonFile("$SacredUtils\\conf\\statinfo.json").Build();

            downloadCount.Downloads = downloadCount.Downloads + 1;

            Send();
        }

        private static async void Send()
        {
            try
            {
                FtpClient client = new FtpClient("files.000webhost.com");

                client.Credentials = new NetworkCredential("mairwunnxstatistic", AppSummary.Connect);

                await Task.Run(() => client.ConnectAsync());

                await Task.Run(() => client.UploadFileAsync("$SacredUtils\\conf\\statinfo.json", "/sacredutils/downloads.json"));

                await Task.Run(() => client.DisconnectAsync());

                File.Delete("$SacredUtils\\conf\\statinfo.json");

                AppSettings.ApplicationSettings.WhatIsThisDoingHere = false;

                AppLogger.Log.Info("Sending SacredUtils application statistics downloads done!");
            }
            catch (Exception e)
            {
                AppLogger.Log.Error("An error occurred while uploading the SacredUtils statistics file!");
                AppLogger.Log.Error(e.ToString);
            }
        }
    }
}
