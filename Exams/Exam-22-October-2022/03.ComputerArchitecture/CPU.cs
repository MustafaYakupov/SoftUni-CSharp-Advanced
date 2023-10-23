using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        public CPU(string brand, int cores, double frequency)
        {
            this.Brand = brand;
            this.Cores = cores;
            this.Frequency = frequency;
        }
        public string Brand { get; set; }
        public int Cores { get; set; }
        public double Frequency { get; set; }  //Format the Frequency to the first digit after the decimal point!

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Brand} CPU:");
            sb.AppendLine($"Cores: {this.Cores}");
            sb.AppendLine($"Frequency: {this.Frequency:f1} GHz");


            return sb.ToString().Trim();
        }
    }
}
