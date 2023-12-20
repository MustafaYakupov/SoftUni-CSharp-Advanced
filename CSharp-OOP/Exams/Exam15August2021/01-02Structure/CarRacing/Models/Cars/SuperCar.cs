using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double InitialFuel = 80;
        private const double FuelConsumption = 10;
        public SuperCar(string make, string model, string vIN, int horsePower) 
            : base(make, model, vIN, horsePower, InitialFuel, FuelConsumption)
        {
        }
    }
}
