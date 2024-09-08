using System;

using System.Linq;


namespace p07SumArrays
{
    class p07SumArrays
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int largerLength = Math.Max(firstArray.Length, secondArray.Length);
                
            for (int i = 0; i < largerLength; i++)
            {
                int firstValue = firstArray[i % firstArray.Length];
                int secondValue = secondArray[i % secondArray.Length];
                Console.Write("{0} ", firstValue + secondValue);
            }
        }
    }
}
