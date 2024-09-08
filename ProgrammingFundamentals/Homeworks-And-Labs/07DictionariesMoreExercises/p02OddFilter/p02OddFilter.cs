using System;
using System.Collections.Generic;
using System.Linq;

namespace p02OddFilter
{
    class p02OddFilter
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            numbers.RemoveAll(x => x % 2 != 0);
            var average = numbers.Average();
            
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > average)
                {
                    numbers[i] ++;
                }
                else if (numbers[i] < average)
                {
                    numbers[i] --;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
