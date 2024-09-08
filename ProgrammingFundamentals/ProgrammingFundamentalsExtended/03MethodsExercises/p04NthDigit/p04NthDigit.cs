using System;
using System.Linq;

namespace p04NthDigit
{
    class p04NthDigit
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine(); 
            int index = int.Parse(Console.ReadLine());
            
            string output = FindNthDigit(number, index);
            Console.WriteLine(output);
        }

        static string FindNthDigit(string number, int index)
        {
            char[] reversed = number.ToCharArray();
            Array.Reverse(reversed);
            string result = reversed[index - 1].ToString();

            return result;
        }
    }
}
