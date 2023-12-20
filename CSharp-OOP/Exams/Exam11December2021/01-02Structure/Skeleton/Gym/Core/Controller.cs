using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private IRepository<IEquipment> equipment;
        private List<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;

            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }

            gyms.Add(gym);
            return $"Successfully added {gymType}.";
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = null;

            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }

            this.equipment.Add(equipment);
            return $"Successfully added {equipmentType}.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment eq = equipment.FindByType(equipmentType);

            if (eq == null)
            {
                throw new InvalidOperationException($"There isn't equipment of type {equipmentType}.");
            }

            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            gym.AddEquipment(eq);
            equipment.Remove(eq);

            return $"Successfully added {equipmentType} to {gymName}.";
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = null;
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);

                if (gym.GetType().Name == "WeightliftingGym")
                {
                    return $"The gym is not appropriate.";
                }

                gym.AddAthlete(athlete);
            }
            else if (athleteType == "Weightlifter")
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);

                if (gym.GetType().Name == "BoxingGym")
                {
                    return $"The gym is not appropriate.";
                }

                gym.AddAthlete(athlete);
            }
            else
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            return $"Successfully added {athleteType} to {gymName}.";
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);
            int athletesCount = 0;

            foreach (var athlete in gym.Athletes)
            {
                athlete.Exercise();
                athletesCount++;
            }

            return $"Exercise athletes: {athletesCount}.";
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            double totalWeight = gym.EquipmentWeight;

            return $"The total weight of the equipment in the gym {gymName} is {totalWeight:F2} grams.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().Trim();
        }
    }
}
