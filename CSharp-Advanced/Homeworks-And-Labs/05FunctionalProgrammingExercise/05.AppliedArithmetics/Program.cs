using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            Func<string, List<int>, List<int>> calculate = (action, collection) =>
            {
                List<int> list = new List<int>();

                foreach (var number in collection)
                {
                    if (action.ToLower() == "add")
                    {
                        list.Add(number + 1);
                    }
                    else if (action.ToLower() == "multiply")
                    {
                        list.Add(number * 2);
                    }
                    else if (action.ToLower() == "subtract")
                    {
                        list.Add(number - 1);
                    }
                }

                return list;
            };

            Action<List<int>> print = numbers => Console.WriteLine(String.Join(" ", numbers));

            while (true)
            {
                string action = Console.ReadLine(); 

                if (action.ToLower() == "end")
                {
                    break;
                }

                if (action.ToLower() == "print")
                {
                    print(input);
                }
                else
                {
                    input = calculate(action, input);

                }
            }
        }
    }
}
