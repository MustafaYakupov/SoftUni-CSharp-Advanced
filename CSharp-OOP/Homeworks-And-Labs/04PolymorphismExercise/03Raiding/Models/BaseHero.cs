using _03Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        private double power;
        protected BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name { get; set; }
        public int Power  { get; set; }

    public abstract string CastAbility();
    }
}
