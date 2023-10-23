using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data= new List<Ski>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Ski ski)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            return this.data
                .Remove(this.data
                .Where(x => x.Manufacturer == manufacturer)
                .Where(y => y.Model == model)
                .FirstOrDefault());
        }

        public Ski GetNewestSki()
        {
            var newestSki = this.data.OrderByDescending(x => x.Year).FirstOrDefault();

            if (newestSki != null)
            {
                return newestSki;
            }

            return null;
        }

        public Ski GetSki(string manufacturer, string model)
        { 
            var wantedSki = this.data
                .Where(x => x.Manufacturer == manufacturer)
                .Where(y => y.Model == model)
                .FirstOrDefault();

            if (wantedSki != null)
            {
                return wantedSki;
            }

            return null;
        }

        public int Count => this.data.Count;

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}:");

            foreach (var ski in this.data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
