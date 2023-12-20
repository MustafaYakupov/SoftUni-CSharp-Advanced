using LogForU.ConsoleApp.Core;
using LogForU.ConsoleApp.Core.Interfaces;
using LogForU.CoreLogForU.Core.Appenders;
using LogForU.CoreLogForU.Core.Appenders.Interfaces;
using LogForU.CoreLogForU.Core.Loggers;
using LogForU.CoreLogForU.Core.Loggers.Interfaces;

namespace LogForU.ConsoleApp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}