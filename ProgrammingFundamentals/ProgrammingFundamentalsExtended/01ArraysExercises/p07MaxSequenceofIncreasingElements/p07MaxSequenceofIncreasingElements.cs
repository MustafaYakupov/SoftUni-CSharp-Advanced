using System;
using System.Collections.Generic;
using System.Linq;

namespace p07MaxSequenceofIncreasingElements
{
    class p07MaxSequenceofIncreasingElements
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var currentArr = new List<int>();
            var bestArr = new List<int>();

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[i - 1])
                {
                    currentArr.Add(arr[i]);
                    if (currentArr.Count + 1 > bestArr.Count)
                    {
                        bestArr = currentArr.ToList();
                        bestArr.Insert(0, currentArr[0] - 1);
                    }
                }
                else
                {
                    currentArr.Clear();
                }
            }
            Console.WriteLine(string.Join(" ", bestArr));
        }
    }
}
