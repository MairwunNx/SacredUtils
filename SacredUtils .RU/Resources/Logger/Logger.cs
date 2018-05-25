using log4net;
using log4net.Config;

namespace SacredUtils.Resources.Logger
{
    public static class Logger
    {
        public static ILog log = LogManager.GetLogger("LOGGER");

        public static ILog Log { get { return log; } }

        public static void InitLogger() { XmlConfigurator.Configure(); }
    }
}
