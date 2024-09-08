using System;
using System.Collections.Generic;
using System.Linq;

namespace p06FoldAndSum
{
    class p06FoldAndSum
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = arr.Length / 4;

            int[] leftArr = arr.Take(k).Reverse().ToArray();
            int[] midArr = arr.Skip(k).Take(2 * k).ToArray();
            int[] rightArr = arr.Skip(3 * k).Take(k).Reverse().ToArray();
            int[] foldedMidArray = leftArr.Concat(rightArr).ToArray();
            
            var resultArr = midArr.Select((x, i) => x + foldedMidArray[i]);
            
            Console.WriteLine(string.Join(" ", resultArr));
        }
    }
}
