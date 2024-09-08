using System;
using System.Linq;

namespace p08MostFrequentNumber
{
    class p08MostFrequentNumber
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
           
            int bestCount = 0;
            int bestNum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int counter = 0;
                int currentNum = arr[i];
                for (int k = i; k < arr.Length; k++)
                {
                    if (currentNum == arr[k])
                    {
                        counter++;
                        if (counter > bestCount)
                        {
                            bestCount = counter;
                            bestNum = currentNum;
                        }
                    }
                }
            }
            Console.WriteLine(bestNum);
        }
    }
}
