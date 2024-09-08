using System;
using System.Linq;

namespace p04TrippleSum
{
    class p04TrippleSum
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            bool notFound = true;
            for (int a = 0; a < arr.Length; a++)
            {
                for (int b = a + 1; b < arr.Length; b++)
                {
                    int sum = arr[a] + arr[b];
                    if (arr.Contains(sum))
                    {
                        Console.WriteLine($"{arr[a]} + {arr[b]} == {sum}");
                        if(notFound)
                        notFound = false;
                    }
                }
            }
            if (notFound)
            {
                Console.WriteLine("No");
            }

        }      
    }         
}              
