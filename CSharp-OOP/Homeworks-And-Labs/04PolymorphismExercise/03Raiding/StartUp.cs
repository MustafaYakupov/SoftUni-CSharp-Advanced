using _03Raiding.Core;
using _03Raiding.Core.Interfaces;
using _03Raiding.Factories;
using _03Raiding.Factories.Interfaces;
using _03Raiding.Models;
using _03Raiding.Models.Interfaces;

namespace _03Raiding
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IHeroFactory heroFactory = new HeroFactory();

            IEngine engine = new Engine(heroFactory);

            engine.Run();
        }
    }
}