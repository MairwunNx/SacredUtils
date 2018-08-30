using Config.Net;
using FluentFTP;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SacredUtils.resources.bin
{
    public interface IDownloadCount
    {
        int Downloads { get; set; }
    }

    public interface IFirstInstall
    {
        bool First { get; set; }
    }
    
    public class GetStatistic
    {
        public async void Get()
        {
            GetLoggerConfig.Log.Info("Checking availability first install settings");

            if (!File.Exists("$SacredUtils\\conf\\firstinstall.json"))
            {
                File.WriteAllBytes("$SacredUtils\\conf\\firstinstall.json", Properties.Resources.firstinstall);

                GetLoggerConfig.Log.Info("First install settings were created in conf folder");
            }

            IFirstInstall firstInstall = new ConfigurationBuilder<IFirstInstall>()
                .UseJsonFile("$SacredUtils\\conf\\firstinstall.json").Build();

            if (firstInstall.First)
            {
                try
                {
                    FtpClient client = new FtpClient("145.14.145.124");

                    client.Credentials = new NetworkCredential("mairwunnxstatistic", "11317151PleaseNotChange");

                    await Task.Run(() => client.Connect());

                    await Task.Run(() => client.DownloadFileAsync("$SacredUtils\\conf\\statinfo.json", "/sacredutils/downloads.json"));

                    await Task.Run(() => client.Disconnect());

                    GetLoggerConfig.Log.Info("Download statistic successfully downloaded!");

                    Add();
                }
                catch (Exception e)
                {
                    GetLoggerConfig.Log.Error("An error occurred while retrieving the statistics file!");
                    GetLoggerConfig.Log.Error(e.ToString);
                }
            }
        }

        public void Add()
        {
            try
            {
                IDownloadCount downloadCount = new ConfigurationBuilder<IDownloadCount>()
                    .UseJsonFile("$SacredUtils\\conf\\statinfo.json").Build();

                GetLoggerConfig.Log.Info("Updating statistic file, adding download num");

                downloadCount.Downloads = downloadCount.Downloads + 1;
            }
            catch (Exception e)
            {
                GetLoggerConfig.Log.Error(e.ToString);
            }

            Send();
        }

        public async void Send()
        {
            IFirstInstall firstInstall = new ConfigurationBuilder<IFirstInstall>()
                .UseJsonFile("$SacredUtils\\conf\\firstinstall.json").Build();

            try
            {
                FtpClient client = new FtpClient("145.14.145.124");

                client.Credentials = new NetworkCredential("mairwunnxstatistic", "11317151PleaseNotChange");

                await Task.Run(() => client.Connect());

                await Task.Run(() => client.UploadFileAsync("$SacredUtils\\conf\\statinfo.json", "/sacredutils/downloads.json"));

                await Task.Run(() => client.Disconnect());

                GetLoggerConfig.Log.Info("Upload statistic successfully done!");

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
