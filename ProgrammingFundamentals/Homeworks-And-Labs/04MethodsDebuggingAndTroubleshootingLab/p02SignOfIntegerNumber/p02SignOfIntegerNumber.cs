using System;

namespace p02SignOfIntegerNumber
{
    class p02SignOfIntegerNumber
    {
        static void Main(string[] args)
        {
            PrintSign();
        }

        static void PrintSign()
        {
            int number = int.Parse(Console.ReadLine());

            if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive.");
            }
            else if (number < 0)
            {
                Console.WriteLine($"The number {number} is negative.");
            }
            else if (number == 0)
            {
                Console.WriteLine($"The number {number} is zero.");
            }
        }
       


    }
}
