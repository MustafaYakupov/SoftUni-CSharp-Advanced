using MilitaryElite.Core;
using MilitaryElite.Core.Interfaces;
using MilitaryElite.Models;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite
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