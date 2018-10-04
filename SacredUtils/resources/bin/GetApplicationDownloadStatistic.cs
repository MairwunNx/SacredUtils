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

                AppLogger.Log.Info("Checking for first installing of SacredUtils application ...");

                if (AppSettings.ApplicationSettings.WhatIsThisDoingHere)
                {
                    try
                    {
                        FtpClient client = new FtpClient("files.000webhost.com");

                        client.Credentials = new NetworkCredential("mairwunnxstatistic", AppSummary.Connect);

                        AppLogger.Log.Info("Connecting to SacredUtils application statistics Ftp server ...");

                        await Task.Run(() => client.ConnectAsync());

                        AppLogger.Log.Info("Connecting to SacredUtils application statistics Ftp server done!");

                        AppLogger.Log.Info("Downloading SacredUtils application statistic from Ftp server ...");

                        await Task.Run(() => client.DownloadFileAsync("$SacredUtils\\conf\\statinfo.json", "/sacredutils/downloads.json"));

                        AppLogger.Log.Info("Downloading SacredUtils application statistic from Ftp done!");

                        AppLogger.Log.Info("Disconnecting of SacredUtils application Ftp statistics server ...");

                        await Task.Run(() => client.DisconnectAsync());

                        AppLogger.Log.Info("Disconnecting of SacredUtils application Ftp statistics server done!");

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
            try
            {
                IDownloadCount downloadCount = new ConfigurationBuilder<IDownloadCount>()
                    .UseJsonFile("$SacredUtils\\conf\\statinfo.json").Build();

                AppLogger.Log.Info("Updating SacredUtils application statistic file, adding download num ...");

                downloadCount.Downloads = downloadCount.Downloads + 1;

                AppLogger.Log.Info("Updating SacredUtils application statistic file, adding download num done!");
            }
            catch (Exception e)
            {
                AppLogger.Log.Error(e.ToString);
            }

            Send();
        }

        private static async void Send()
        {
            try
            {
                FtpClient client = new FtpClient("files.000webhost.com");

                client.Credentials = new NetworkCredential("mairwunnxstatistic", AppSummary.Connect);

                AppLogger.Log.Info("Connecting to SacredUtils application statistics Ftp server ...");

                await Task.Run(() => client.ConnectAsync());

                AppLogger.Log.Info("Connecting to SacredUtils application statistics Ftp server done!");

                AppLogger.Log.Info("Uploading SacredUtils application statistic to Ftp server ...");

                await Task.Run(() => client.UploadFileAsync("$SacredUtils\\conf\\statinfo.json", "/sacredutils/downloads.json"));

                AppLogger.Log.Info("Uploading SacredUtils application statistic to Ftp server done!");

                AppLogger.Log.Info("Disconnecting of SacredUtils application Ftp statistics server ...");

                await Task.Run(() => client.DisconnectAsync());

                AppLogger.Log.Info("Disconnecting of SacredUtils application Ftp statistics server done!");

                File.Delete("$SacredUtils\\conf\\statinfo.json");

                AppSettings.ApplicationSettings.WhatIsThisDoingHere = false;
            }
            catch (Exception e)
            {
                AppLogger.Log.Error("An error occurred while uploading the SacredUtils statistics file!");
                AppLogger.Log.Error(e.ToString);
            }
        }
    }
}
