using LogForU.CoreLogForU.Core.Enums;
using LogForU.CoreLogForU.Core.Exceptions;
using LogForU.CoreLogForU.Core.Models.Interfaces;
using LogForU.CoreLogForU.Core.Utilis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForU.CoreLogForU.Core.Models
{
    public class Message : IMessage
    {
        private string createdTime;
        private string text;

        public Message(string createdTime, string text, ReportLevel reportLevel)
        {
            CreatedTime = createdTime;
            Text = text;
            ReportLevel = reportLevel;
        }

        public string CreatedTime
        {
            get => createdTime;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyCreatedTimeException();
                }

                if (!DateTimeValidator.ValidateDateTime(value))
                {
                    throw new InvalidDateTimeException();
                }

                createdTime = value;
            }
        }

        public string Text
        {
            get => text;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyMessageTextException();
                }

                text = value;
            }
        }

        public ReportLevel ReportLevel { get; private set; }
    }
}
