using System;
using System.Collections.Generic;
using System.Linq;

namespace p01RemoveNegativesAndReverse
{
    class p01RemoveNegativesAndReverse
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
            }
            if (numbers.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                numbers.Reverse();
            Console.WriteLine(string.Join(" ", numbers));
            }

        }
    }
}
