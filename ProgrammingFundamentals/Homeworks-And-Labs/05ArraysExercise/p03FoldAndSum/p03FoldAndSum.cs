using System;
using System.Linq;

namespace p03FoldAndSum
{
    class p03FoldAndSum
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = arr.Length / 4;
            int[] leftArr = arr.Take(k).ToArray();
            int[] middleArr = arr.Skip(k).Take(2 * k).ToArray();
            int[] rightArr = arr.Skip(3 * k).Take(k).ToArray();
            int[] resultArr = new int [2*k];

            for (int i = 0; i < k; i++)
            {
                leftArr[i] = arr[i];
                rightArr[i] = arr[3*k + i];
            }
            for (int i = 0; i < 2 * k; i++)
            {
                middleArr[i] = arr[k + i];
            }

            Array.Reverse(leftArr);
            Array.Reverse(rightArr);

            for (int i = 0; i < k; i++)
            {
                resultArr[i] +=  middleArr[i] + leftArr[i] ;
                resultArr[i + k] = middleArr[i + k] + rightArr[i];
            }
           

            Console.WriteLine(string.Join(" ", resultArr));
        }
    }
}
