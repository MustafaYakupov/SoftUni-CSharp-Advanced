using _03Raiding.Factories.Interfaces;
using _03Raiding.Models;
using _03Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Raiding.Factories
{
    public class HeroFactory : IHeroFactory
    {
        public IBaseHero Create(string type, string name)
        {
            switch (type)
            {
                case "Druid":
                    return new Druid(name);
                case "Paladin":
                    return new Paladin(name);
                case "Rogue":
                    return new Rogue(name);
                case "Warrior":
                    return new Warrior(name);
                default:
                    throw new ArgumentException("Invalid hero!");
            }
        }
    }
}
