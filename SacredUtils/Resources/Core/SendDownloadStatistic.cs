using System;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static SacredUtils.Resources.Core.AppConstStrings;

namespace SacredUtils.Resources.Core
{
    internal class SendDownloadStatistic
    {
        public async Task CheckFirstInstallAsync()
        {
            try
            {
                Log.Info("Starting reading regedit HKEY_CURRENT_USER, SacredUtils .Statistic.");

                var currentUser = Registry.CurrentUser;
                var subKey = currentUser.OpenSubKey("SacredUtils .Statistic");

                Log.Info("Get key value downloads in SacredUtils .Statistic.");

                var first = subKey?.GetValue("downloads").ToString(); subKey?.Close();

                Log.Info("Getting key value downloads in SacredUtils .Statistic done.");

                Log.Info("Reading regedit HKEY_CURRENT_USER, SacredUtils .Statistic done.");

                Log.Info("Checking key value 'Downloaded' in SacredUtils .Statistic.");

                if (first == "true")
                {
                    Log.Info("Value of key 'Downloaded' in SacredUtils .Statistic = true.");

                    try
                    {
                        Log.Info("Changing key value on false in SacredUtils .Statistic.");

                        subKey.SetValue("downloads", "false");

                        Log.Info("Changing key value on false in SacredUtils .Statistic done.");

                        Log.Info("Closing and save value key in  SacredUtils .Statistic.");

                        subKey.Close();

                        Log.Info("Closing and save value key in  SacredUtils .Statistic done.");
                    }
                    catch (Exception exception)
                    {
                        Log.Error("An error occurred while working with regedit, contact MairwunNx.");

                        Log.Error(exception.ToString());
                    }

                    Log.Info("SacredUtils was installed for the first time. We will put this in the database.");

                    await GetFileDownloadStatisticAsync();
                }
                else if (first == "false")
                {
                    Log.Info("The program has already been downloaded. The entry into the database is canceled.");
                }
            }
            catch (Exception exception)
            {
                Log.Warn(exception.ToString());

                Log.Info("SacredUtils was installed for the first time. We will put this in the database.");

                var currentUser = Registry.CurrentUser;
                var subKey = currentUser.CreateSubKey("SacredUtils .Statistic");

                Log.Info("Creating key in downloads in SacredUtils .Statistic with parametr false.");

                subKey?.SetValue("downloads", "false");

                Log.Info("Creating key in downloads with parametr false done.");

                Log.Info("Closing and save value key in SacredUtils .Statistic.");

                subKey?.Close();

                Log.Info("Closing and save value key in SacredUtils .Statistic done.");

                Log.Info("SacredUtils was installed for the first time. We will put this in the database.");

                await GetFileDownloadStatisticAsync();
            }
        }

        public async Task GetFileDownloadStatisticAsync()
        {
            try
            {
                Log.Info("Starting creating ftp request on ftp://mairwunnxsta...");

                FtpWebRequest request = await Task.Run(() => (FtpWebRequest)WebRequest.Create("ftp://mairwunnxstatistic@files.000webhost.com/SacredUtils%20Statistic/downloads.txt"));

                await Task.Run(() => request.Method = WebRequestMethods.Ftp.DownloadFile);

                Log.Info("Creating ftp request on ftp://mairwunnxstatistic... done.");

                Log.Info("We verify authorization on ftp-web hosting with MairwunNx data.");

                request.Credentials = await Task.Run(() => new NetworkCredential("mairwunnxstatistic", "11317151PleaseNotChange"));

                Log.Info("Verify authorization on ftp-web hosting with MairwunNx data done.");

                FtpWebResponse response = await Task.Run(() => (FtpWebResponse)request.GetResponse());

                Stream responseStream = await Task.Run(() => response.GetResponseStream());
                StreamReader reader = new StreamReader(responseStream ?? throw new InvalidOperationException());

                Log.Info("Creating directory .SacredUtils Data if he not exists.");

                Directory.CreateDirectory(AppDataFolder);

                Log.Info("Creating directory .SacredUtils Data done.");

                using (Stream fileStream = File.Create(AppDataFolder + "/" + "downloadstat.dat"))
                {
                    Log.Info("Creating file downloadstat.dat in directory .SacredUtils Data.");

                    responseStream.CopyTo(fileStream);

                    Log.Info("File downloadstat.dat was created/downloaded by ftp.");
                }

                Log.Info("Closing processes and closing web requests.");

                reader.Close(); response.Close(); await SetValueFileStatisticAsync();
            }
            catch (Exception exception)
            {
                Log.Error("An error occurred while working with ftp client, contact MairwunNx.");

                Log.Error(exception.ToString());
            }
        }

        public async Task SetValueFileStatisticAsync()
        {
            try
            {
                Log.Info("Starting reading statistic in downloadstat.dat file.");

                var text = File.ReadAllText(AppDataFolder + "/" + "downloadstat.dat");

                Log.Info("Reading statistic in downloadstat.dat file done.");

                Log.Info("Looking for a number on a regular expression \\d+ in file downloadstat.dat.");

                var numberOfStartups = Regex.Match(text, @"\d+").Value;

                Log.Info("Looking for a number on a regular expression \\d+ in file downloadstat.dat done.");

                var newNumberOfStartups = Convert.ToInt32(numberOfStartups) + 1;

                var fileAllText = File.ReadAllLines(AppDataFolder + "/" + "downloadstat.dat");
                fileAllText[0] = "; The program is downloaded " + newNumberOfStartups + " time(s)";
                File.WriteAllLines(AppDataFolder + "/" + "downloadstat.dat", fileAllText, Encoding.UTF8);

                Log.Info("Change in the number of downloads of the program done.");

                Log.Info("Data of downloads SacredUtils was saved in downloadstat.dat.");

                Log.Info("We are preparing to create a FTP-web request for hosting.");

                await SendFileDownloadStatisticAsync();
            }
            catch (Exception exception)
            {
                Log.Error("The task to calculate the SacredUtils downloads failed.");

                Log.Error(exception.ToString());
            }
        }

        public async Task SendFileDownloadStatisticAsync()
        {
            try
            {
                Log.Info("Starting creating ftp request on ftp://mairwunnxsta...");

                FtpWebRequest request = await Task.Run(() => (FtpWebRequest)WebRequest.Create("ftp://mairwunnxstatistic@files.000webhost.com/SacredUtils%20Statistic/downloads.txt"));

                await Task.Run(() => request.Method = WebRequestMethods.Ftp.UploadFile);

                Log.Info("Creating ftp request on ftp://mairwunnxstatistic... done.");

                Log.Info("We verify authorization on ftp-web hosting with MairwunNx data.");

                await Task.Run(() => request.Credentials = new NetworkCredential("mairwunnxstatistic", "11317151PleaseNotChange"));

                Log.Info("Verify authorization on ftp-web hosting with MairwunNx data done.");

                StreamReader sourceStream = await Task.Run(() => new StreamReader(AppDataFolder + "/" + "downloadstat.dat"));
                byte[] fileContents = await Task.Run(() => Encoding.UTF8.GetBytes(sourceStream.ReadToEnd()));
                sourceStream.Close(); request.ContentLength = fileContents.Length;

                Log.Info("Starting uploading downloadstat.dat file on FTP server.");

                Stream requestStream = await Task.Run(() => request.GetRequestStream());
                await Task.Run(() => requestStream.Write(fileContents, 0, fileContents.Length));
                requestStream.Close();

                Log.Info("Uploading downloadstat.dat file on FTP server done.");

                Log.Info("Closing processes and closing web requests.");

                FtpWebResponse response = await Task.Run(() => (FtpWebResponse)request.GetResponse());

                response.Close();
            }
            catch (Exception exception)
            {
                Log.Error("An error occurred while working with ftp client, contact MairwunNx.");

                Log.Error(exception.ToString());
            }
        }
    }
}
