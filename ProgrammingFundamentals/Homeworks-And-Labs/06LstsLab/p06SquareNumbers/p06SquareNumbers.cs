using System;
using System.Collections.Generic;
using System.Linq;

namespace p06SquareNumbers
{
    class p06SquareNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToList();
            List<int> selected = numbers.Where(num => Math.Sqrt(num) == (int)Math.Sqrt(num)).ToList();

            selected = selected.OrderByDescending(a => a).ToList();
            Console.WriteLine(string.Join(" ", selected));

            //List<int> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            //List<int> result = new List<int>(numbers.Count);
            //
            //foreach (int number in numbers)
            //{
            //    var square = Math.Sqrt(number);
            //    if (square == (int)square)
            //    {
            //        result.Add(number);
            //    }
            //   
            //}
            //result.Sort((a,b) => b.CompareTo(a));
            ////result.Reverse();
            //Console.WriteLine(string.Join(" ", result));
        }
    }
}
