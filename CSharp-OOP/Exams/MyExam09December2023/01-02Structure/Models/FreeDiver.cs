using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    partial class FreeDiver : Diver
    {
        private const int OXYGENLEVEL = 120;
        public FreeDiver(string name) 
            : base(name, OXYGENLEVEL)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            OxygenLevel -= (int)Math.Round(TimeToCatch * 0.6, MidpointRounding.AwayFromZero);

            if (OxygenLevel <= 0)
            {
                this.UpdateHealthStatus();
            }
        }

        public override void RenewOxy()
        {
            OxygenLevel = OXYGENLEVEL;
        }
    }
}
