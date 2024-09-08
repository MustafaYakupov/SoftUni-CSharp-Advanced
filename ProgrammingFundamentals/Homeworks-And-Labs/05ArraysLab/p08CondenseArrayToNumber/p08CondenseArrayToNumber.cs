using System;
using System.Linq;

namespace p08CondenseArrayToNumber
{
    class p08CondenseArrayToNumber
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();


            while (arr.Length > 1)
            {
                int[] condensed = new int [arr.Length - 1];
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    condensed[i] = arr[i] + arr[i + 1];
                }
                
               arr = condensed;
            }

            foreach (int num in arr)
            {
                Console.WriteLine(num);
            }
        }
    }
}
