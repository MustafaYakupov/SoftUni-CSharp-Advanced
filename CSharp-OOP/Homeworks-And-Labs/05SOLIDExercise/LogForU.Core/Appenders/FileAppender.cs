using LogForU.CoreLogForU.Core.Appenders.Interfaces;
using LogForU.CoreLogForU.Core.Enums;
using LogForU.CoreLogForU.Core.IO.Interfaces;
using LogForU.CoreLogForU.Core.Layouts.Interfaces;
using LogForU.CoreLogForU.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForU.CoreLogForU.Core.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, ILogFile logFile, ReportLevel reportLevel = ReportLevel.Info)
        {
            Layout = layout;
            LogFile = logFile;
            ReportLevel = reportLevel;
        }
        public ILayout Layout { get; private set; }

        public ILogFile LogFile { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesAppended { get; private set; }

        public void AppendMessage(IMessage message)
        {
            string content =
                string.Format(Layout.Format, message.CreatedTime, message.ReportLevel, message.Text);

            LogFile.WriteLine(content);

            File.AppendAllText(LogFile.FullPath, content + Environment.NewLine);

            MessagesAppended++;
        }
        public override string ToString()
            => $"Appender type: {this.GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {MessagesAppended}, File size: {LogFile.Size}";
    }
}
