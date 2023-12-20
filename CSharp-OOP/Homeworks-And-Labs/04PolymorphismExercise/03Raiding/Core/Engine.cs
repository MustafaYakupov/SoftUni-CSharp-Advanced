using _03Raiding.Core.Interfaces;
using _03Raiding.Factories.Interfaces;
using _03Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IHeroFactory heroFactory;
        private readonly ICollection<IBaseHero> heroes;
        public Engine(IHeroFactory heroFactory)
        {
            this.heroFactory = heroFactory;
            heroes = new List<IBaseHero>();
        }

        public void Run()
        {
            int inputLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLines; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                try
                {
                    heroes.Add(heroFactory.Create(type, name));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int bossPower = int.Parse(Console.ReadLine());

            if (heroes.Sum(h => h.Power) >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
