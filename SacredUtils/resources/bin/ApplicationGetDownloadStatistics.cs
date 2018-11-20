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
                if (CheckAvailabilityInternetConnection.Connect())
                {
                    using (WebClient wc = new WebClient())
                    {
                        return wc.DownloadString(
                            "https://mairwunnxstatistic.000webhostapp.com/downloads-launches-stat.json");
                    }
                }

                return "Internet connection not found! Download data N/A!";
            }
            catch
            {
                downloads = "Server critical error! Download data N/A!";
            }

            return downloads;
        }
    }
}
