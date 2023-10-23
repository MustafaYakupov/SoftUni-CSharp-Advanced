using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;

        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.Fish = new List<Fish>();
        }

        public List<Fish> Fish
        {
            get
            {
                return this.fish;
            }

            set
            {
                this.fish = value;
            }
        }

        public string Material { get; set; }
        public int Capacity { get; set; }

        public int Count => this.Fish.Count;

        public string AddFish(Fish fish)
        {
            if (this.Fish.Count < this.Capacity)
            {
                if (string.IsNullOrEmpty(fish.FishType) || fish.Weight <= 0 || fish.Length <= 0)
                {
                    return "Invalid fish.";
                }
                else
                {
                    this.Fish.Add(fish);
                    return $"Successfully added {fish.FishType} to the fishing net.";
                }
            }
            else
            {
                return "Fishing net is full.";
            }
        }

        public bool ReleaseFish(double weight)
        {
            return this.Fish.Remove(this.Fish.FirstOrDefault(x => x.Weight == weight));
        }

        public Fish GetFish(string fishType)
        {
            return this.Fish.FirstOrDefault(x => x.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            return this.Fish.OrderByDescending(x => x.Length).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");

            foreach (var fish in this.Fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
