using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] setSizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int firstSet = setSizes[0];
            int secondtSet = setSizes[1];

            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();
            HashSet<int> finalSet = new HashSet<int>();

            for (int i = 0; i < firstSet; i++)
            {
                int input = int.Parse(Console.ReadLine());

                setOne.Add(input);
            }

            for (int i = 0; i < secondtSet; i++)
            {
                int input = int.Parse(Console.ReadLine());

                setTwo.Add(input);
            }

            foreach (var number in setOne)
            {
                if (setTwo.Contains(number))
                {
                    finalSet.Add(number);
                }
            }

            foreach (var number in finalSet)
            {
                Console.Write(number + " ");
            }
        }
    }
}
