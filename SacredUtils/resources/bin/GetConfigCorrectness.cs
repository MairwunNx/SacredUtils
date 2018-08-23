using Config.Net;
using System;
using System.IO;

namespace SacredUtils.resources.bin
{
    public interface IConfigCorrectness
    {
        int SettingsVersion { get; }
    }
    public class GetConfigCorrectness
    {
        public IConfigCorrectness ConfigCorrectness = new ConfigurationBuilder<IConfigCorrectness>()
            .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();
        
        public void Get()
        {
            GetLoggerConfig.Log.Info("Checking application config correctness");

            try
            {
                if (ConfigCorrectness.SettingsVersion < 1)
                {
                    GetLoggerConfig.Log.Warn("Application configuration is outdated!");

                    File.WriteAllBytes("$SacredUtils\\conf\\settings.json", Properties.Resources.settings);

                    GetLoggerConfig.Log.Info("Application configuration has been updated");
                }
                else
                {
                    GetLoggerConfig.Log.Info("Application configuration does not need to be fixed");
                }
            }
            catch (Exception e)
            {
                GetLoggerConfig.Log.Error("Checking application config correctness failed!");
                GetLoggerConfig.Log.Error(e.ToString);

                File.WriteAllBytes("$SacredUtils\\conf\\settings.json", Properties.Resources.settings);
            }
        }
    }
}
