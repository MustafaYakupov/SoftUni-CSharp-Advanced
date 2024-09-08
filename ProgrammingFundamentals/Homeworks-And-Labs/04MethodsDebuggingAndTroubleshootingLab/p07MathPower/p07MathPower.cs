using System;

namespace p07MathPower
{
    class p07MathPower
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            double result = NumberPower(number, power);
            Console.WriteLine(result);
        }

        static double NumberPower(double number, int power)
        {
           return Math.Pow(number, power); 
        }
    }
}
