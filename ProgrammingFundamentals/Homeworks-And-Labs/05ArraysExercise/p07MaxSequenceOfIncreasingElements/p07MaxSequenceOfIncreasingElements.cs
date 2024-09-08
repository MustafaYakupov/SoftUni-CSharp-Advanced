using System;
using System.Linq;

namespace p07MaxSequenceOfIncreasingElements
{
    class p07MaxSequenceOfIncreasingElements
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int startIndex = 0;
            int sequenceLength = 1;
            int bestIndex = 0;
            int bestLength = 0;

            for (int i = 1; i < arr.Length; i++)
            {

                if (arr[i] > arr[i - 1])
                {
                    sequenceLength++;
                    if (sequenceLength > bestLength)
                    {
                        bestLength = sequenceLength;
                        bestIndex = startIndex;
                    }
                }
                else
                {
                    startIndex = i;
                    sequenceLength = 1;
                }



            }
            for (int i = bestIndex; i < bestIndex + bestLength; i++)
            {
                Console.Write(arr[i] + " ");
            }

        }
    }
}
