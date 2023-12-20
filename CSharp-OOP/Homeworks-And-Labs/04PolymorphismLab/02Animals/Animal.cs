using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }

        public string Name { get; set; }
        public string FavouriteFood { get; set; }

        public virtual string ExplainSelf()
        {
            StringBuilder sb = new();
            sb.AppendLine($"I am {this.Name} and my fovourite food is {this.FavouriteFood}");

            return sb.ToString().Trim();
        }
    }
}
