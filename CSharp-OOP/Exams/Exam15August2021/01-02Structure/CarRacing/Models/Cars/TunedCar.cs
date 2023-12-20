using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double InitialFuel = 65;
        private const double FuelConsumption = 7.5;

        public TunedCar(string make, string model, string vIN, int horsePower) 
            : base(make, model, vIN, horsePower, InitialFuel, FuelConsumption)
        {
        }
    }
}
