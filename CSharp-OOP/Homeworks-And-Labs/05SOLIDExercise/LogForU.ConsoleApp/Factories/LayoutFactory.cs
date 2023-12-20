using LogForU.ConsoleApp.CustomLayouts;
using LogForU.ConsoleApp.Factories.Interfaces;
using LogForU.CoreLogForU.Core.Layouts;
using LogForU.CoreLogForU.Core.Layouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForU.ConsoleApp.Factories
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            switch (type)
            {
                case "SimpleLayout": return new SimpleLayout();
                case "XmlLayout": return new XmlLayout();
                default: throw new InvalidOperationException("Invalid layout type");
            }
        }
    }
}
