using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            this.Model = model;
            this.Capacity = capacity;
            this.Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }

        public int Count
        {
            get
            { 
                return this.Multiprocessor.Count;
            }
        }

        public void Add(CPU cpu)
        {
            if (this.Capacity > this.Multiprocessor.Count)
            {
                this.Multiprocessor.Add(cpu);
            }
        } 

        public bool Remove(string brand)
        {
            var cpuToRemove = this.Multiprocessor.Where(x => x.Brand == brand).FirstOrDefault();

            if (cpuToRemove != null)
            {
                this.Multiprocessor.Remove(cpuToRemove);
                return true;
            }
            else return false;
        }

        public CPU MostPowerful()
        {
            var mostPowerfulCPU = this.Multiprocessor.OrderByDescending(x => x.Frequency).FirstOrDefault();

            if (mostPowerfulCPU != null)
            {
                return mostPowerfulCPU;
            }
            else
            {
                return null;
            }

        }

        public CPU GetCPU(string brand)
        {
            var CPUToGet = this.Multiprocessor.FirstOrDefault(x => x.Brand == brand);

            if (CPUToGet != null)
            {
                return CPUToGet;
            }
            else
            {
                return null;
            }
        }

        public string Report()
        {
            StringBuilder sb = new();

            sb.AppendLine($"CPUs in the Computer {this.Model}:");

            foreach (var cpu in this.Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
