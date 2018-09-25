using Config.Net;
using FluentFTP;
using SacredUtils.resources.bin.etc;
using SacredUtils.resources.bin.logger;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SacredUtils.resources.bin.getting
{
    public interface IDownloadCount
    {
        int Downloads { get; set; }
    }

    public interface IFirstInstall
    {
        bool First { get; set; }
    }
    
    public static class ApplicationStatistic
    {
        public static async void Get()
        {
            Logger.Log.Info("Checking availability first install settings");

            if (!File.Exists("$SacredUtils\\conf\\firstinstall.json"))
            {
                File.WriteAllBytes("$SacredUtils\\conf\\firstinstall.json", Properties.Resources.firstinstall);

                Logger.Log.Info("First install settings were created in conf folder");
            }

            IFirstInstall firstInstall = new ConfigurationBuilder<IFirstInstall>()
                .UseJsonFile("$SacredUtils\\conf\\firstinstall.json").Build();

            Logger.Log.Info("Checking first installing of SacredUtils ...");

            if (firstInstall.First)
            {
                try
                {
                    FtpBase64Password.Get();

                    FtpClient client = new FtpClient("files.000webhost.com");

                    client.Credentials = new NetworkCredential("mairwunnxstatistic", ApplicationInfo.Connect);

                    Logger.Log.Info("Connecting to statistics Ftp server ...");

                    await Task.Run(() => client.ConnectAsync());

                    Logger.Log.Info("Connecting to statistics Ftp server done!");

                    Logger.Log.Info("Downloading SacredUtils statistic ...");

                    await Task.Run(() => client.DownloadFileAsync("$SacredUtils\\conf\\statinfo.json", "/sacredutils/downloads.json"));

                    Logger.Log.Info("Downloading SacredUtils statistic done!");

                    Logger.Log.Info("Disconnecting of Ftp statistics server ...");

                    await Task.Run(() => client.DisconnectAsync());

                    Logger.Log.Info("Disconnecting of Ftp statistics server done!");

                    Add();
                }
                catch (Exception e)
                {
                    Logger.Log.Error("An error occurred while retrieving the statistics file!");
                    Logger.Log.Error(e.ToString);
                }
            }
        }

        private static void Add()
        {
            try
            {
                IDownloadCount downloadCount = new ConfigurationBuilder<IDownloadCount>()
                    .UseJsonFile("$SacredUtils\\conf\\statinfo.json").Build();

                Logger.Log.Info("Updating statistic file, adding download num ...");

                downloadCount.Downloads = downloadCount.Downloads + 1;

                Logger.Log.Info("Updating statistic file, adding download num done!");
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.ToString);
            }

            Send();
        }

        private static async void Send()
        {
            IFirstInstall firstInstall = new ConfigurationBuilder<IFirstInstall>()
                .UseJsonFile("$SacredUtils\\conf\\firstinstall.json").Build();

            try
            {
                FtpClient client = new FtpClient("files.000webhost.com");

                client.Credentials = new NetworkCredential("mairwunnxstatistic", ApplicationInfo.Connect);

                Logger.Log.Info("Connecting to statistics Ftp server ...");

                await Task.Run(() => client.ConnectAsync());

                Logger.Log.Info("Connecting to statistics Ftp server done!");

                Logger.Log.Info("Uploading SacredUtils statistic ...");

                await Task.Run(() => client.UploadFileAsync("$SacredUtils\\conf\\statinfo.json", "/sacredutils/downloads.json"));

                Logger.Log.Info("Uploading statistic successfully done!");

                Logger.Log.Info("Disconnecting of Ftp statistics server ...");

                await Task.Run(() => client.DisconnectAsync());

                Logger.Log.Info("Disconnecting of Ftp statistics server done!");

                firstInstall.First = false;
            }
            catch (Exception e)
            {
                Logger.Log.Error("An error occurred while uploading the statistics file!");
                Logger.Log.Error(e.ToString);
            }
        }
    }
}
