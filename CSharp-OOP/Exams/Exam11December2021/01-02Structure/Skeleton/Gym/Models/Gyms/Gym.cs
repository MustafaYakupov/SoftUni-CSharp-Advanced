using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                capacity = value;
            }
        }

        public double EquipmentWeight
        {
            get
            {
                double totalWeight =  equipment.Sum(x => x.Weight);
                return totalWeight;
            }
        }

        public ICollection<IEquipment> Equipment => equipment;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity == athletes.Count)
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }

            athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} is a {this.GetType().Name}:");

            if (athletes.Count > 0)
            {
                sb.Append("Athletes: ");
                foreach (var athlete in athletes.SkipLast(1))
                {
                    sb.Append($"{athlete.FullName}, ");
                }

                sb.AppendLine($"{athletes.Last().FullName}");

            }
            else
            {
                sb.AppendLine("Athletes: No athletes");
            }

            sb.AppendLine($"Equipment total count: {equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().Trim();
        }
    }
}
