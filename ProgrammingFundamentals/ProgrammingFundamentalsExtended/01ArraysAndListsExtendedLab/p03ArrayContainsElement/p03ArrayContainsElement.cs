using System;
using System.Linq;

namespace p03ArrayContainsElement
{
    class p03ArrayContainsElement
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());

            if (arr.Contains(number))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
