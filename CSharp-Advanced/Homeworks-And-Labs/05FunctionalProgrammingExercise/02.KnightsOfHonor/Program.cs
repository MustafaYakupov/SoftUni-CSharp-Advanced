using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            Action<string,string[]> print = (x,y) =>
            {
                foreach (var name in input)
                {
                    Console.WriteLine($"{x} {name}");
                }
            };

            print("Sir", input);
        }
    }
}
