using LogForU.CoreLogForU.Core.Layouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForU.ConsoleApp.Factories.Interfaces
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
