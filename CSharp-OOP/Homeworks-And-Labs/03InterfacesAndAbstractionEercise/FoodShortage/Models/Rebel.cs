using FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage.Models
{
    public class Rebel : IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name { get; set ; }
        public int Age { get ; set ; }
        public string Group { get ; set ; }
        public int Food { get ; set ; } = 0;

        public int BuyFood()
        {
            this.Food += 5;
            return this.Food;
        }
    }
}
