using System;
using System.Linq;

namespace p02RotateAndSum
{
    class p02RotateAndSum
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rotatiions = int.Parse(Console.ReadLine());
            int lastElement;
           
            int[] resultArr = new int[arr.Length];
            
            for (int f = 0; f < rotatiions; f++)
            {
                    lastElement = arr[arr.Length - 1];

                for (int i = arr.Length - 1; i > 0; i--)
                {
                    arr[i] = arr[i - 1];
                    resultArr[i] += arr[i];
                }
                arr[0] = lastElement;
                resultArr[0] += arr[0];
               
            }
            Console.WriteLine(string.Join(" ", resultArr));
        }
    }
}
