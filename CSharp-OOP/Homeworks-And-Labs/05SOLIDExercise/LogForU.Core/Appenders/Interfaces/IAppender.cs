using LogForU.CoreLogForU.Core.Enums;
using LogForU.CoreLogForU.Core.Layouts.Interfaces;
using LogForU.CoreLogForU.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForU.CoreLogForU.Core.Appenders.Interfaces
{
    public interface IAppender
    {
        public ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        int MessagesAppended { get; }

        void AppendMessage(IMessage message);
    }
}
