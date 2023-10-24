using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Reverse()
                .ToList();

            int dividerInput = int.Parse(Console.ReadLine());

            Func<int, List<int>, List<int>> modifyCollection = (divider, collection) =>
            {
                List<int> list = new List<int>();

                foreach (var number in collection)
                {
                    if (number % divider != 0)
                    {
                        list.Add(number);
                    }
                }

                return list;
            };

            List<int> modifiedCollection = new List<int>();
            modifiedCollection = modifyCollection(dividerInput, input);

            Console.WriteLine(String.Join(" ", modifiedCollection));
        }
    }
}
