using System;

namespace p04TouristInformation
{
    class p04TouristInformation
    {
        static void Main(string[] args)
        {
            string unit = Console.ReadLine();
            double value = double.Parse(Console.ReadLine());
            if (unit == "miles")
            {
                Console.WriteLine($"{value} {unit} = {value * 1.6:f2} kilometers");
            }
            else if (unit == "inches")
            {
                Console.WriteLine($"{value} {unit} = {value * 2.54:f2} centimeters");
            }
            else if (unit == "feet")
            {
                Console.WriteLine($"{value} {unit} = {value * 30:f2} centimeters");
            }
            else if (unit == "yards")
            {
                Console.WriteLine($"{value} {unit} = {value * 0.91:f2} meters");
            }
            else if (unit == "gallons")
            {
                Console.WriteLine($"{value} {unit} = {value * 3.8:f2} liters");
            }
        }
    }
}
