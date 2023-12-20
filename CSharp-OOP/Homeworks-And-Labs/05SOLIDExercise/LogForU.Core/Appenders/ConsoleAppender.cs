using LogForU.CoreLogForU.Core.Appenders.Interfaces;
using LogForU.CoreLogForU.Core.Enums;
using LogForU.CoreLogForU.Core.Layouts.Interfaces;
using LogForU.CoreLogForU.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForU.CoreLogForU.Core.Appenders
{
    public class ConsoleAppender : IAppender 
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
        {
            Layout = layout;
            ReportLevel = reportLevel;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesAppended { get; private set; }

        public void AppendMessage(IMessage message)
        {
            Console.WriteLine(string.Format(Layout.Format, message.CreatedTime, message.ReportLevel, message.Text));

            MessagesAppended++;
        }
        public override string ToString()
            => $"Appender type: {this.GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {MessagesAppended}";
    }
}
