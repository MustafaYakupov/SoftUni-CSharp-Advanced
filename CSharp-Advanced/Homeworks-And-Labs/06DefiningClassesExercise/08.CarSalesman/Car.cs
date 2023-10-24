namespace _08.CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Car
    {
        private const string DefaultValueString = "n/a";
        private const int DefaultValueInt = -1;
        public Car(string model, Engine engine, double weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }
        public Car(string model, Engine engine, double weight)
            : this(model, engine, weight, DefaultValueString)
        {
        }
        public Car(string model, Engine engine, string color)
            : this(model, engine, DefaultValueInt, color)
        {
        }
        public Car(string model, Engine engine)
           : this(model, engine, DefaultValueInt, DefaultValueString)
        {
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public double Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{this.Model}:");
            stringBuilder.AppendLine($"{this.Engine.ToString()}");

            if (this.Weight == -1)
            {
                stringBuilder.AppendLine($"  Weight: n/a");
            }
            else
            {
                stringBuilder.AppendLine($"  Weight: {this.Weight}");
            }

            stringBuilder.Append($"  Color: {this.Color}");

            return stringBuilder.ToString();
        }
    }
}
