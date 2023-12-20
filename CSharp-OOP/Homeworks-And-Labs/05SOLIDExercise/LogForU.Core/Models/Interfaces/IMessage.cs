using LogForU.CoreLogForU.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForU.CoreLogForU.Core.Models.Interfaces
{
    public interface IMessage
    {
        string CreatedTime { get; }

        string Text { get; }

        ReportLevel ReportLevel { get; }
    }
}
