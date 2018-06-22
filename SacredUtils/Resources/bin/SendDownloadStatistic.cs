using Microsoft.Win32;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;

namespace SacredUtils.Resources.bin
{
    public class SendDownloadStatistic
    {
        public async Task CheckFirstInstallAsync()
        {
            try
            {
                var reg = Registry.CurrentUser.OpenSubKey("Software\\SacredUtils\\Ru\\", true);

                if (reg == null)
                {
                    var key = Registry.CurrentUser.CreateSubKey("Software\\SacredUtils\\Ru", true);

                    key.SetValue("Downloaded", "false"); key.Close();

                    await GetFileStatisticAsync();
                }

                if (reg != null)
                {
                    var key = Registry.CurrentUser.CreateSubKey("Software\\SacredUtils\\Ru", true);
                    var keyValue = key.GetValue("Downloaded").ToString(); key.Close();

                    if (keyValue == "true")
                    {
                        key.SetValue("Downloaded", "false"); key.Close();

                        await GetFileStatisticAsync();
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }
        }

        public async Task GetFileStatisticAsync()
        {
            try
            {
                FtpWebRequest request = await Task.Run(() => (FtpWebRequest)WebRequest.Create("ftp://mairwunnxstatistic@files.000webhost.com/SacredUtils%20Statistic/downloads.txt"));

                await Task.Run(() => request.Method = WebRequestMethods.Ftp.DownloadFile);

                request.Credentials = await Task.Run(() => new NetworkCredential("mairwunnxstatistic", "11317151PleaseNotChange"));

                FtpWebResponse response = await Task.Run(() => (FtpWebResponse)request.GetResponse());

                Stream responseStream = await Task.Run(() => response.GetResponseStream());
                StreamReader reader = new StreamReader(responseStream ?? throw new InvalidOperationException());

                Directory.CreateDirectory(AppDataFolder);

                using (Stream fileStream = File.Create(AppDownloadStatFile))
                {
                    responseStream.CopyTo(fileStream);
                }

                reader.Close(); response.Close(); await SetValueStatisticAsync();
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }
        }

        public async Task SetValueStatisticAsync()
        {
            try
            {
                var text = File.ReadAllText(AppDownloadStatFile);

                var numberOfStartups = Regex.Match(text, @"\d+").Value;

                var newNumberOfStartups = Convert.ToInt32(numberOfStartups) + 1;

                var fileAllText = File.ReadAllLines(AppDownloadStatFile);
                fileAllText[0] = $"; The program is downloaded {newNumberOfStartups} time(s)";
                File.WriteAllLines(AppDownloadStatFile, fileAllText, Encoding.UTF8);

                await SendFileStatisticAsync();
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }
        }

        public async Task SendFileStatisticAsync()
        {
            try
            {
                FtpWebRequest request = await Task.Run(() => (FtpWebRequest)WebRequest.Create("ftp://mairwunnxstatistic@files.000webhost.com/SacredUtils%20Statistic/downloads.txt"));

                await Task.Run(() => request.Method = WebRequestMethods.Ftp.UploadFile);

                await Task.Run(() => request.Credentials = new NetworkCredential("mairwunnxstatistic", "11317151PleaseNotChange"));

                StreamReader sourceStream = await Task.Run(() => new StreamReader(AppDownloadStatFile));
                byte[] fileContents = await Task.Run(() => Encoding.UTF8.GetBytes(sourceStream.ReadToEnd()));
                sourceStream.Close(); request.ContentLength = fileContents.Length;

                Stream requestStream = await Task.Run(() => request.GetRequestStream());
                await Task.Run(() => requestStream.Write(fileContents, 0, fileContents.Length));
                requestStream.Close();

                FtpWebResponse response = await Task.Run(() => (FtpWebResponse)request.GetResponse());

                response.Close();
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }
        }
    }
}
