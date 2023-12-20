using LogForU.CoreLogForU.Core.Appenders.Interfaces;
using LogForU.CoreLogForU.Core.Enums;
using LogForU.CoreLogForU.Core.Loggers.Interfaces;
using LogForU.CoreLogForU.Core.Models;
using LogForU.CoreLogForU.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForU.CoreLogForU.Core.Loggers
{
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public void Info(string dateTime, string text)
            => AppendAll(dateTime, text, ReportLevel.Info);

        public void Warning(string dateTime, string text)
            => AppendAll(dateTime, text, ReportLevel.Warning);

        public void Error(string dateTime, string text)
            => AppendAll(dateTime, text, ReportLevel.Error);

        public void Critical(string dateTime, string text)
            => AppendAll(dateTime, text, ReportLevel.Critical);


        public void Fatal(string dateTime, string text)
            => AppendAll(dateTime, text, ReportLevel.Fatal);

        private void AppendAll(string dateTime, string text, ReportLevel reportLevel)
        {
            IMessage message = new Message(dateTime, text, reportLevel);

            foreach (IAppender appender in appenders)
            {
                if (message.ReportLevel >= appender.ReportLevel)
                {
                    appender.AppendMessage(message);
                }
            }
        }
    }
}
