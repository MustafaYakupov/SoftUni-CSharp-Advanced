using LogForU.ConsoleApp.Factories.Interfaces;
using LogForU.CoreLogForU.Core.Appenders;
using LogForU.CoreLogForU.Core.Appenders.Interfaces;
using LogForU.CoreLogForU.Core.Enums;
using LogForU.CoreLogForU.Core.IO.Interfaces;
using LogForU.CoreLogForU.Core.Layouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForU.ConsoleApp.Factories
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel = 0, ILogFile logFile = null)
        {
            switch (type)
            {
                case "ConsoleAppender": return new ConsoleAppender(layout, reportLevel);
                case "FileAppender": return new FileAppender(layout, logFile, reportLevel);
                default: throw new InvalidOperationException("Invalid appender type");
            }
        }
    }
}
