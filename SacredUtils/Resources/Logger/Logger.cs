using log4net.Config;

namespace SacredUtils.Resources.Logger
{
    public static class Logger
    {
        public static void InitLogger() { XmlConfigurator.Configure(); }
    }
}