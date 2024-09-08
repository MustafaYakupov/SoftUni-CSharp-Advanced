using System;
using System.Linq;

namespace p01LargestCommonEnd
{
    class p01LargestCommonEnd
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine()
                .Split(' ')
                .ToArray();
            string[] array2 = Console.ReadLine()
                .Split(' ')
                .ToArray();
            int countLeft = GetCounter(array1, array2);
            array1 = array1.Reverse().ToArray();
            array2 = array2.Reverse().ToArray();
            int countRight = GetCounter(array1, array2);

            Console.WriteLine(Math.Max(countLeft, countRight));

        }

         static int GetCounter(string[] array1, string[] array2)
        {
            int leftCounter = 0;

            for (int i = 0; i < Math.Min(array1.Length, array2.Length); i++)
            {
                if (array1[i] == array2[i])
                {
                    leftCounter++;
                }
            }
            return leftCounter;
        }
    }
}
