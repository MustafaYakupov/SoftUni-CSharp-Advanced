﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double CatWeightMupltiplier = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMupltiplier => CatWeightMupltiplier;

        public override IReadOnlyCollection<Type> PreferredFoods => new HashSet<Type> { typeof(Meat), typeof(Vegetable) };

        public override string ProduceSound()
            => $"Meow";
    }
}
