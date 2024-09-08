using System;

namespace p02ReverseAnArrayOfIntegers
{
    class p02ReverseAnArrayOfIntegers
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[] array = new int[count]; 
           
            for (int i = 0; i < count; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            for (int i = count - 1; i >= 0; i--)
            {
                Console.WriteLine(array[i] + " ");
                Console.WriteLine();
            }
        }
    }
}
