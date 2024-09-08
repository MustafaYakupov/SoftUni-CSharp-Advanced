using System;
using System.Linq;

namespace p01LargestCommonEnd
{
    class p01LargestCommonEnd
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(new[] { " " },StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] arr2 = Console.ReadLine().Split(new[] { " " },StringSplitOptions.RemoveEmptyEntries).ToArray();

            var left = CommonEnd(arr1, arr2);

            arr1 = arr1.Reverse().ToArray();
            arr2 = arr2.Reverse().ToArray();
            var right = CommonEnd(arr1, arr2);
            
            Console.WriteLine(Math.Max(left, right));
        }

        static int CommonEnd(string[] arr1, string[] arr2)
        {
            int sum = 0;

            for (int i = 0; i < Math.Min(arr1.Length, arr2.Length); i++)
            {
                if (arr1[i] == arr2[i])
                {
                    sum++;
                }
            }
            return sum;
        }
        
    }
}
