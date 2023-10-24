using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            SortedSet<string> outputSet = new SortedSet<string>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();

                foreach (var element in input)
                {
                    outputSet.Add(element);
                }
            }

            foreach (var element in outputSet)
            {
                Console.Write(element + " ");
            }
        }
    }
}
