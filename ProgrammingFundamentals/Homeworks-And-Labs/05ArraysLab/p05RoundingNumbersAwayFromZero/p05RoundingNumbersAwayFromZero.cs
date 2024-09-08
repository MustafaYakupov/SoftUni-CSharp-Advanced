using System;
using System.Linq;

namespace p05RoundingNumbersAwayFromZero
{
    class p05RoundingNumbersAwayFromZero
    {
        static void Main(string[] args)
        {
            double[] arr = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                double number = arr[i];
                var roundedNumber = Math.Round(number, MidpointRounding.AwayFromZero);
                Console.WriteLine($"{number} => {roundedNumber}");
            }
        }
    }
}
