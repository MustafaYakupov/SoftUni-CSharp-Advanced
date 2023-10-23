using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }

        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip  { get; set; }

        public int Count => this.Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (this.Drones.Count < this.Capacity)
            {
                if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand))
                {
                    return "Invalid drone.";
                }

                if (drone.Range < 5 || drone.Range > 15)
                {
                    return "Invalid drone.";
                }

                this.Drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";
            }
            else
            {
                return "Airfield is full.";
            }
        }

        public bool RemoveDrone(string name)
        {
            return this.Drones.Remove(this.Drones.FirstOrDefault(x => x.Name == name));
        }

        public int RemoveDroneByBrand(string brand)
        {
            var removedDrones = this.Drones.FindAll(x => x.Brand == brand);

            if (removedDrones.Count > 0)
            {
                foreach (var item in removedDrones)
                {
                    this.Drones.Remove(item);
                }

                return removedDrones.Count;
            }
            else
            {
                return 0;
            }
        }

        public Drone FlyDrone(string name)
        {
            var droneToFly = this.Drones.FirstOrDefault(x => x.Name == name);
            

            if (droneToFly == null)
            {
                return null;
            }

            this.Drones.FirstOrDefault(x => x.Name == name).Available = false;

            return droneToFly;
        }

        public List<Drone> FlyDronesByRange(int range)
        { 
            List<Drone> flyingDrones = this.Drones.FindAll(x => x.Range >= range);

            foreach (var drone in flyingDrones)
            {
                this.Drones.FirstOrDefault(x => x.Name == drone.Name).Available = false;
            }

            return flyingDrones;
        }

        public string Report()
        {
            var notFlyingDrones = this.Drones.FindAll(x => x.Available == true);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (var drone in notFlyingDrones)
            {
                sb.AppendLine(drone.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
