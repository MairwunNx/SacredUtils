using System;
using System.IO;
using System.Net;
using log4net;
using Microsoft.Win32;

namespace SacredUtils.Resources.Core
{
    class SendDownloadStatistic
    {
        private RegistryKey _localMachineKey = Registry.LocalMachine;
        private static readonly ILog Log = LogManager.GetLogger("LOGGER");

        public void CheckFirstInstall()
        {
            try
            {
                var currentUser = Registry.CurrentUser;
                var subKey = currentUser.OpenSubKey("SacredUtils .Statistic");

                var first = subKey.GetValue("Download").ToString(); subKey.Close();

                if (first == "true") { GetFileDownloadStatistic(); }
            }
            catch (Exception exception)
            {
                var currentUser = Registry.CurrentUser;
                var subKey = currentUser.CreateSubKey("SacredUtils .Statistic");

                subKey.SetValue("Download", "false"); subKey.Close(); GetFileDownloadStatistic();
            }
        }

        public void GetFileDownloadStatistic()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://mairwunnxstatistic@files.000webhost.com/SacredUtils%20Statistic/downloads.txt");
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            request.Credentials = new NetworkCredential("mairwunnxstatistic", "no no no :)");

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());

            reader.Close(); response.Close();
        }

        public void SetValueFileStatistic()
        {

        }

        public void SendFileDownloadStatistic()
        {

        }
    }
}
