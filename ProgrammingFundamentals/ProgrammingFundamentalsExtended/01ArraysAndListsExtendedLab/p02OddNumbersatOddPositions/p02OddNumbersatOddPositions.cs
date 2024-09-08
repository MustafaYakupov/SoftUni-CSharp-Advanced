using System;
using System.Linq;

namespace p02OddNumbersatOddPositions
{
    class p02OddNumbersatOddPositions
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 != 0)
                {
                    if (arr[i] % 2 != 0)
                    {
                        Console.WriteLine($"Index {i} -> {arr[i]}");
                    }
                }
            }
        }
    }
}
