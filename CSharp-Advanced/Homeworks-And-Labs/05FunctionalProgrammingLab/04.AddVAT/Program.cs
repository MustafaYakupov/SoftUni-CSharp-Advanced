using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
               .Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
               .Select(double.Parse)
               .Select(x => x * 1.2)
               .ToList();

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number:F2}");
            }
        }
    }
}
