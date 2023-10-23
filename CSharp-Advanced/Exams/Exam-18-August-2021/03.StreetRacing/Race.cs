using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.Participants = new List<Car>();
        }

        public List<Car> Participants { get; private set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public int Count => this.Participants.Count;

        public void Add(Car car)
        {
            if (this.Participants.FirstOrDefault(x => x.LicensePlate == car.LicensePlate) == null 
                && car.HorsePower <= this.MaxHorsePower
                && this.Participants.Count < this.Capacity
                )
            {
                this.Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            return this.Participants.Remove(this.Participants.FirstOrDefault(x => x.LicensePlate == licensePlate));
        }

        public Car FindParticipant(string licensePlate)
        {
            var participant = this.Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);

            if (participant != null)
            {
                return participant;
            }

            return null;
        }

        public Car GetMostPowerfulCar()
        {
            if (this.Participants.Count > 0)
            {
                var mostPowerfulCar = this.Participants.OrderByDescending(x => x.HorsePower).First();
                return mostPowerfulCar;
            }

            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");
            foreach (var car in this.Participants)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
