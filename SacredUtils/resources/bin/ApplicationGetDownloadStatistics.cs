using System.Net;

namespace SacredUtils.resources.bin
{
    public static class ApplicationGetDownloadStatistics
    {
        public static string Get()
        {
            string downloads;

            try
            {
                WebClient wc = new WebClient();

                return wc.DownloadString(
                    "https://mairwunnxstatistic.000webhostapp.com/downloads-launches-stat.json");
            }
            catch
            {
                downloads = "Server error! Download data N/A!";
            }

            return downloads;
        }
    }
}
