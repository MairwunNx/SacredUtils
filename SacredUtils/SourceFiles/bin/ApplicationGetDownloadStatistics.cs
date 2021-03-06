﻿using System.Net;
using SacredUtils.SourceFiles;
using SacredUtils.SourceFiles.bin;
using SacredUtils.SourceFiles.utils;

namespace SacredUtils.resources.bin
{
    public static class ApplicationGetDownloadStatistics
    {
        public static string Get()
        {
            string downloads;

            try
            {
                if (!NetworkUtils.IsConnected.Value)
                    return "Internet connection not found! Download data N/A!";

                using (WebClient wc = new WebClient())
                {
                    return wc.DownloadString(
                        "https://mairwunnxstatistic.000webhostapp.com/downloads-launches-stat.json");
                }
            }
            catch
            {
                downloads = "Server critical error! Download data N/A!";
            }

            return downloads;
        }
    }
}
