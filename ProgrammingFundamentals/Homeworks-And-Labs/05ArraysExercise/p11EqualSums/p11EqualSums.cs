using System;
using System.Linq;

namespace p11EqualSums
{
    class p11EqualSums
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool isFound = false;

            for (int i = 0; i < arr.Length; i++)
            {
                int[] firstArray = arr.Take(i).ToArray();
                int[] secondArray = arr.Skip(i + 1).ToArray();
                if (firstArray.Sum() == secondArray.Sum())
                {
                    Console.WriteLine(i);
                    isFound = true;
                    break;
                }
               
            }
            if (!isFound)
            {
                Console.WriteLine("no");
            }
        }
        
    }
}
