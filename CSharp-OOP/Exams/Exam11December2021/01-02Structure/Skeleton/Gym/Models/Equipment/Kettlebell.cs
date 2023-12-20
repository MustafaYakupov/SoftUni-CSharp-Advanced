using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const int Weight = 10000;
        private const int Price = 80;
        public Kettlebell() 
            : base(Weight, Price)
        {
        }
    }
}
