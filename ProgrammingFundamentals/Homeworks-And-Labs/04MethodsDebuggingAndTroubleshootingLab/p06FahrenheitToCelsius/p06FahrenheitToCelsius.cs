using System;

namespace p06FahrenheitToCelsius
{
    class p06FahrenheitToCelsius
    {
        static void Main(string[] args)
        {
            double degrees =  double.Parse(Console.ReadLine());
            double celsius = TempConversion(degrees);
            Console.WriteLine($"{celsius:f2}");
        }
        static double TempConversion(double degrees)
        {
            double celsius = (degrees - 32) * 5 / 9;
            return celsius;
        }
    }
}
