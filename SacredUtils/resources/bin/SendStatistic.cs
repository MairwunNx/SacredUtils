using Config.Net;
using FluentFTP;
using System;
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
    
    public class SendStatistic
    {
        public IFirstInstall FirstInstall = new ConfigurationBuilder<IFirstInstall>()
            .UseJsonFile("$SacredUtils\\conf\\firstinstall.json").Build();

        public async void Get()
        {
            if (FirstInstall.First)
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
            try
            {
                FtpClient client = new FtpClient("145.14.145.124");

                client.Credentials = new NetworkCredential("mairwunnxstatistic", "11317151PleaseNotChange");

                await Task.Run(() => client.Connect());

                await Task.Run(() => client.UploadFileAsync("$SacredUtils\\conf\\statinfo.json", "/sacredutils/downloads.json"));

                await Task.Run(() => client.Disconnect());

                GetLoggerConfig.Log.Info("Upload statistic successfully done!");

                FirstInstall.First = false;
            }
            catch (Exception e)
            {
                GetLoggerConfig.Log.Error("An error occurred while uploading the statistics file!");
                GetLoggerConfig.Log.Error(e.ToString);
            }
        }
    }
}
