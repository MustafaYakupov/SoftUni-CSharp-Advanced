using System;
using System.Linq;

namespace p06ReverseAnArrayOfStrings
{
    class p06ReverseAnArrayOfStrings
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ").ToArray();
            string[] reversedArray = input.Reverse().ToArray();

            Console.WriteLine(string.Join(" ", reversedArray));
        }
    }
}
