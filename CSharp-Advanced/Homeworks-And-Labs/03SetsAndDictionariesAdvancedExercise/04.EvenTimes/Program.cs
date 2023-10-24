using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());

            Dictionary<int, int> evenCountNumber = new Dictionary<int, int>();

            for (int i = 0; i < numbersCount; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!evenCountNumber.ContainsKey(number))
                {
                    evenCountNumber.Add(number, 0);
                }

                evenCountNumber[number]++;
            }

            foreach (var kvp in evenCountNumber)
            {
                if (kvp.Value % 2 == 0)
                {
                    Console.WriteLine(kvp.Key);
                }
            }
        }
    }
}
