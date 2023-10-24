namespace _08.CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Engine
    {
        private const string DefaultValueString = "n/a";
        private const int DefaultValueInt = -1;
        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }
        public Engine(string model, int power, int displacement)
            : this(model, power, displacement, DefaultValueString)
        {
        }
        public Engine(string model, int power, string efficiency)
            : this(model, power, DefaultValueInt, efficiency)
        {
        }
        public Engine(string model, int power)
            : this(model, power, DefaultValueInt, DefaultValueString)
        {
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"  {this.Model}:");
            stringBuilder.AppendLine($"    Power: {this.Power}");

            if (this.Displacement == -1)
            {
                stringBuilder.AppendLine($"    Displacement: n/a");
            }
            else
            {
                stringBuilder.AppendLine($"    Displacement: {this.Displacement}");
            }

            stringBuilder.Append($"    Efficiency: {this.Efficiency}");

            return stringBuilder.ToString();
        }
    }
}
