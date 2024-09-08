using System;
using System.Linq;

namespace p08MostFrequentNumber
{
    class p08MostFrequentNumber
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int result = 0;
            int totalOccurances = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int currentNumber = arr[i];
                int currnetOccurances = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    if (currentNumber == arr[j])
                    {
                        currnetOccurances++;
                        if (currnetOccurances > totalOccurances)
                        {
                            totalOccurances = currnetOccurances;
                            result = currentNumber;
                        }
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
