using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lenghtToMatch = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(' ').ToList();

            Func<int, List<string>, List<string>> validateNames = (length, collection) =>
            { 
                List<string> result = new List<string>();

                foreach (var name in collection)
                {
                    if (name.Length <= length)
                    {
                        result.Add(name);
                    }
                }

                return result;
            };

            List<string> output = new List<string>(validateNames(lenghtToMatch, names));

            foreach (var name in output)
            {
                Console.WriteLine(name);
            }
        }
    }
}
