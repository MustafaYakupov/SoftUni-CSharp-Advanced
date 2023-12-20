using LogForU.CoreLogForU.Core.Appenders.Interfaces;
using LogForU.CoreLogForU.Core.Enums;
using LogForU.CoreLogForU.Core.IO.Interfaces;
using LogForU.CoreLogForU.Core.Layouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForU.ConsoleApp.Factories.Interfaces
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel, ILogFile logFile = null);
    }
}
