using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ActionPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            Action<string[]> print = x => 
            {
                foreach (string word in x)
                {
                    Console.WriteLine(word);
                }
            };

            print(input);
        }
    }
}
