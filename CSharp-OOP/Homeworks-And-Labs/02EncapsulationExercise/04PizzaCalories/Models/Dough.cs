using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PizzaCalories.Models
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;
        private const int caloriesPerGram = 2;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType 
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }
        public string BakingTechnique 
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }

        }
        public double Weight 
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public double GetCaloriesPerGram
        {
            get
            {
                double calories = (caloriesPerGram * this.Weight) * GetFlourTypeValue() * GetBakingTechniqueValue(); 
                return calories;
            }
        }

        private double GetFlourTypeValue()
        {
            if (this.FlourType.ToLower() == "white")
            {
                return 1.5;
            }
            else
            {
                return 1.0;
            }
        }

        private double GetBakingTechniqueValue()
        {
            if (this.BakingTechnique.ToLower() == "crispy")
            {
                return 0.9;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                return 1.1;
            }
            else
            {
                return 1.0;
            }
        }
    }
}
