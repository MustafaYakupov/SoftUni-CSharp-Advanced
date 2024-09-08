using System;
using System.Collections.Generic;
using System.Linq;

namespace p10PairsbyDifference
{
    class p10PairsbyDifference
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int difference = int.Parse(Console.ReadLine());

            int count = 0;
            var arguments = new List<string>();

            for (int i = 0; i < arr.Length; i++)
            {
                for (int k = i; k < arr.Length; k++)
                {
                    if (Math.Abs(arr[i] - arr[k]) == difference)
                    {
                        count++;
                    }
                }
            }
           
            Console.WriteLine(count);
        }
    }
}
