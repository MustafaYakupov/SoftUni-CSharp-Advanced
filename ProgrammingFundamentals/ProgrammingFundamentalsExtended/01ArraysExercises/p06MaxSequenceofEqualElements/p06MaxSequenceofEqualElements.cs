using System;
using System.Collections.Generic;
using System.Linq;

namespace p06MaxSequenceofEqualElements
{
    class p06MaxSequenceofEqualElements
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var currentArr = new List<int>();
            var bestArr = new List<int>();

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == arr[i - 1])
                {
                    currentArr.Add(arr[i]);
                    if (currentArr.Count + 1 > bestArr.Count)
                    {
                        bestArr = currentArr.ToList();
                        bestArr.Add(arr[i]);
                    }
                }
                else
                {
                    currentArr.Clear();
                }
            }
            Console.WriteLine(string.Join(" ", bestArr));

            //int[] arr = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            //
            //int start = 0;
            //int length = 1;
            //int bestStart = 0;
            //int bestLength = 0;
            //
            //for (int i = 1; i < arr.Length; i++)
            //{
            //    if (arr[i] == arr[i - 1])
            //    {
            //        length++;
            //        if (length > bestLength)
            //        {
            //            bestLength = length;
            //            bestStart = start;
            //        }
            //    }
            //    else
            //    {
            //        length = 1;
            //        start = i;
            //    }
            //}
            //
            //for (int i = bestStart; i < bestStart + bestLength; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}
        }
    }
}
