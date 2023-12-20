using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }


        public Dough Dough
        {
            get
            {
                return this.dough;
            }
             private set
            {
                this.dough = value;
            }
        }

        public int GetNumberOfToppings => this.toppings.Count;

        public double GetTotalCalories
        {
            get
            {
                double totalCalories = 0;

                foreach (var item in this.toppings)
                {
                    totalCalories += item.GetCaloriesPerGram;
                }

                totalCalories += this.Dough.GetCaloriesPerGram;

                return totalCalories;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{Name} - {GetTotalCalories:f2} Calories.";
        }
    }
}
