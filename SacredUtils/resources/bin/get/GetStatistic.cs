using Config.Net;
using FluentFTP;
using SacredUtils.resources.bin.etc;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SacredUtils.resources.bin.get
{
    public interface IDownloadCount
    {
        int Downloads { get; set; }
    }

    public interface IFirstInstall
    {
        bool First { get; set; }
    }
    
    public static class GetStatistic
    {
        public static async void Get()
        {
            GetLoggerConfig.Log.Info("Checking availability first install settings");

            if (!File.Exists("$SacredUtils\\conf\\firstinstall.json"))
            {
                File.WriteAllBytes("$SacredUtils\\conf\\firstinstall.json", Properties.Resources.firstinstall);

                GetLoggerConfig.Log.Info("First install settings were created in conf folder");
            }

            IFirstInstall firstInstall = new ConfigurationBuilder<IFirstInstall>()
                .UseJsonFile("$SacredUtils\\conf\\firstinstall.json").Build();

            GetLoggerConfig.Log.Info("Checking first installing of SacredUtils ...");

            if (firstInstall.First)
            {
                try
                {
                    GetFtpBase64Pass.Get();

                    FtpClient client = new FtpClient("files.000webhost.com");

                    client.Credentials = new NetworkCredential("mairwunnxstatistic", ApplicationInfo.Connect);

                    GetLoggerConfig.Log.Info("Connecting to statistics Ftp server ...");

                    await Task.Run(() => client.ConnectAsync());

                    GetLoggerConfig.Log.Info("Connecting to statistics Ftp server done!");

                    GetLoggerConfig.Log.Info("Downloading SacredUtils statistic ...");

                    await Task.Run(() => client.DownloadFileAsync("$SacredUtils\\conf\\statinfo.json", "/sacredutils/downloads.json"));

                    GetLoggerConfig.Log.Info("Downloading SacredUtils statistic done!");

                    GetLoggerConfig.Log.Info("Disconnecting of Ftp statistics server ...");

                    await Task.Run(() => client.DisconnectAsync());

                    GetLoggerConfig.Log.Info("Disconnecting of Ftp statistics server done!");

                    Add();
                }
                catch (Exception e)
                {
                    GetLoggerConfig.Log.Error("An error occurred while retrieving the statistics file!");
                    GetLoggerConfig.Log.Error(e.ToString);
                }
            }
        }

        private static void Add()
        {
            try
            {
                IDownloadCount downloadCount = new ConfigurationBuilder<IDownloadCount>()
                    .UseJsonFile("$SacredUtils\\conf\\statinfo.json").Build();

                GetLoggerConfig.Log.Info("Updating statistic file, adding download num ...");

                downloadCount.Downloads = downloadCount.Downloads + 1;

                GetLoggerConfig.Log.Info("Updating statistic file, adding download num done!");
            }
            catch (Exception e)
            {
                GetLoggerConfig.Log.Error(e.ToString);
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

                GetLoggerConfig.Log.Info("Connecting to statistics Ftp server ...");

                await Task.Run(() => client.ConnectAsync());

                GetLoggerConfig.Log.Info("Connecting to statistics Ftp server done!");

                GetLoggerConfig.Log.Info("Uploading SacredUtils statistic ...");

                await Task.Run(() => client.UploadFileAsync("$SacredUtils\\conf\\statinfo.json", "/sacredutils/downloads.json"));

                GetLoggerConfig.Log.Info("Uploading statistic successfully done!");

                GetLoggerConfig.Log.Info("Disconnecting of Ftp statistics server ...");

                await Task.Run(() => client.DisconnectAsync());

                GetLoggerConfig.Log.Info("Disconnecting of Ftp statistics server done!");

                firstInstall.First = false;
            }
            catch (Exception e)
            {
                GetLoggerConfig.Log.Error("An error occurred while uploading the statistics file!");
                GetLoggerConfig.Log.Error(e.ToString);
            }
        }
    }
}
