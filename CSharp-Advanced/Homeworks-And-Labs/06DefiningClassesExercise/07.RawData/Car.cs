using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car(
            string model, 
            int speed,
            int power,
            int weight,
            string type,
            double tire1Pressure,
            int tire1Age,
            double tire2Pressure,
            int tire2Age,
            double tire3Pressure,
            int tire3Age,
            double tire4Pressure,
            int tire4Age)
        {
            this.Model = model;
            this.Engine = new(speed, power);
            this.Cargo = new(weight, type);
            this.Tires = new Tire[4];
            this.Tires[0] = new(tire1Pressure, tire1Age);
            this.Tires[1] = new(tire2Pressure, tire2Age);
            this.Tires[2] = new(tire3Pressure, tire3Age);
            this.Tires[3] = new(tire4Pressure, tire4Age);
        }

        public Engine Engine
        {
            get
            {
                return this.engine;
            }

            set
            {
                this.engine = value;
            }
        }

        public Cargo Cargo
        {
            get
            {
                return this.cargo;
            }

            set
            {
                this.cargo = value;
            }
        }

        public Tire[] Tires
        {
            get
            {
                return this.tires;
            }

            set
            {
                this.tires = value;
            }
        }

        public string Model 
        {
            get
            {
                return this.model;
            }

            set
            {
                this.model = value;
            }
        }
    }
}
