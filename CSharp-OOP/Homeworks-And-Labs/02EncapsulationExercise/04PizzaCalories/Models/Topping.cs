using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PizzaCalories.Models
{
    public class Topping
    {
        private string type;
        private double weight;
        private const double caloriesPerGram = 2;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                if (string.IsNullOrEmpty(value) 
                    || value.ToLower() != "meat" 
                    && value.ToLower() != "veggies"
                    && value.ToLower() != "cheese"
                    && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double GetCaloriesPerGram
        {
            get
            {
                double modifier = ModifierValue();
                double result = caloriesPerGram * modifier * this.Weight;

                return result;
            }
        }

        private double ModifierValue()
        {
            if (this.Type.ToLower() == "meat")
            {
                return 1.2;
            }
            else if (this.Type.ToLower() == "veggies")
            {
                return 0.8;
            }
            else if (this.Type.ToLower() == "cheese")
            {
                return 1.1;
            }
            else // sause
            {
                return 0.9;
            }
        }
    }
}
