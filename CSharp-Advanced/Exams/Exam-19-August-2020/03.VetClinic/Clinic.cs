using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }

       public List<Pet> Data
       {
           get
           { 
               return this.data;
           }
       
           set
           {
               this.data = value;
           }
       }
        public int Capacity { get; private set; }

        public int Count
        {
            get
            {
                return this.Data.Count();
            }
        }

        public void Add(Pet pet)
        {
            if (Capacity > this.Data.Count)
            {
                this.Data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            var petToRemove = this.Data.Where(x => x.Name == name).FirstOrDefault();

            if (petToRemove != null)
            {
                this.Data.Remove(petToRemove);
                return true;
            }
            else return false;
        }

        public Pet GetPet(string name, string owner)
        {
            var petToReturn = this.Data.Where(x => x.Name == name).Where(x => x.Owner == owner).FirstOrDefault();

            if (petToReturn != null)
            {
                return petToReturn;
            }
            else
            {
                return null;
            }
        }

        public Pet GetOldestPet()
        {
            if (this.Data.Count > 0)
            {
                var oldestPet = this.Data.OrderByDescending(x => x.Age).FirstOrDefault();
                return oldestPet;
            }
            else
            {
                return null;
            }
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in this.Data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().Trim();
        }
    }
}
