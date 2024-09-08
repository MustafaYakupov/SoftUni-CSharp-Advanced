using System;
using System.Collections.Generic;
using System.Linq;

namespace p07CountNumbers
{
    class p07CountNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            numbers.Sort();
            int[] count = new int[1001];

            foreach (int number in numbers)
            {
                count[number]++;
            }
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > 0)
                {
                    Console.WriteLine($"{i} => {count[i]}");
                }
            }
        }
    }
}
