using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Laptop
    {
        public Laptop()
        {

        }
        public Laptop(string name, int cPUs, decimal price, int year)
        {
            Name = name;
            CPUs = cPUs;
            Price = price;
            Year = year;
        }

        public string Name { get; set; } = "Lenovo";
        public int CPUs { get; set; } = 4;
        public decimal Price { get; set; } = 1000;
        public int Year { get; set; } = 2023;

        public override string ToString()
        {
            return "This is a laptop";
        }
    }
}
