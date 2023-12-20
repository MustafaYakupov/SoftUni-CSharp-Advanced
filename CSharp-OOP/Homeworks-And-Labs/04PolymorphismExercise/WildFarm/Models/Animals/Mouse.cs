using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double MouseWeightMupltiplier = 0.10;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightMupltiplier => MouseWeightMupltiplier;

        public override IReadOnlyCollection<Type> PreferredFoods => new HashSet<Type> { typeof(Vegetable), typeof(Fruit) };

        public override string ProduceSound()
            => $"Squeak";

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
