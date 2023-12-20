using Telephony.Core;
using Telephony.Core.Interfaces;
using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}