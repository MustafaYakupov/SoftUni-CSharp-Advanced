using System;
using System.Linq;

namespace p10PairsByDifference
{
    class p10PairsByDifference
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int difference = int.Parse(Console.ReadLine());
            int differenceOccurences = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (Math.Abs(arr[i] - arr[j]) == difference)
                    {
                        differenceOccurences++;
                    }
                }
            }
            Console.WriteLine(differenceOccurences);
        }
    }
}
