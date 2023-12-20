using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int power = 80;
        public Druid(string name) 
            : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {power}";
        }
    }
}
