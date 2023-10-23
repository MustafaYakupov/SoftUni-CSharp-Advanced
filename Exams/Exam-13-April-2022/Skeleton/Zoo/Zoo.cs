using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Animals = new List<Animal>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Animal> Animals { get; private set; }

        public string AddAnimal(Animal animal)
        {
            if (this.Animals.Count < this.Capacity)
            {
                if (string.IsNullOrEmpty(animal.Species))
                {
                    return "Invalid animal species.";
                }

                if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
                {
                    return "Invalid animal diet.";
                }

                this.Animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }
            else
            {
                return "The zoo is full.";
            }
        }

        public int RemoveAnimals(string species)
        {
            var removedAnimals = this.Animals.FindAll(x => x.Species == species);

            foreach (var animal in removedAnimals)
            {
                this.Animals.Remove(animal);
            }

            return removedAnimals.Count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            var animalsWithDiet = this.Animals.FindAll(x => x.Diet == diet);

            return animalsWithDiet;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return this.Animals.FirstOrDefault(x => x.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            var animalsByLength = this.Animals.FindAll(x => x.Length >= minimumLength).FindAll(x => x.Length <= maximumLength);

            return $"There are {animalsByLength.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
