using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using NLog;
using NLog.Targets;
using SacredUtils.resources.bin;
using static SacredUtils.resources.bin.GetLoggerConfig;

namespace SacredUtils
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var getLoggerConfig = new GetLoggerConfig();
            getLoggerConfig.Get();

            Log.Info("Lol, test");




        }
    }
}