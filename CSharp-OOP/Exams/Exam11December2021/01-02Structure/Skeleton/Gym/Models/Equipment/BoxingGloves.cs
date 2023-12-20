using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const int Weight = 227;
        private const int Price = 120;
        public BoxingGloves()
            : base(Weight, Price)
        {
        }
    }
}
