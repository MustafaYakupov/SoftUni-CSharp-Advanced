using _03Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Raiding.Factories.Interfaces
{
    public interface IHeroFactory
    {
        IBaseHero Create(string type, string name);
    }
}
