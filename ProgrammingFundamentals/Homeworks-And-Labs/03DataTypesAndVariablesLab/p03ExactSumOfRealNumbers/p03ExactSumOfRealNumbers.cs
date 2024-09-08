using System;

namespace p03ExactSumOfRealNumbers
{
    class p03ExactSumOfRealNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal count = 0;
            for (int i = 0; i < n; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());
                count += number;
            }
            Console.WriteLine($"{count}");
        }
    }
}
