using System;
using System.Linq;

namespace p01RotateArrayofStrings
{
    class p01RotateArrayofStrings
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string lastElement = arr.Last();
            arr.RemoveAt(arr.Count - 1);
            arr.Insert(0, lastElement);

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
