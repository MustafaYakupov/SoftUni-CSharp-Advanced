using System;
using System.Collections.Generic;
using System.Linq;

namespace p06FilterBase
{
    class p06FilterBase
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            var dictAge = new Dictionary<string, int>();
            var dictSalary = new Dictionary<string, double>();
            var dictPosition = new Dictionary<string, string>();

            while (input[0] != "filter" && input[1] != "base")
            {
                bool isAge = int.TryParse(input[2], out int intNum);
                bool isSalary = double.TryParse(input[2], out double doubleNum);

                if (isAge)
                {
                    dictAge.Add(input[0], int.Parse(input[2]));
                }
                else if (isSalary)
                {
                    dictSalary.Add(input[0], double.Parse(input[2]));
                }
                else
                {
                    dictPosition.Add(input[0], input[2]);
                }

                input = Console.ReadLine().Split(' ').ToArray();
            }
            input = Console.ReadLine().Split(' ').ToArray();

            if (input[0] == "Age")
            {
                foreach (var pair in dictAge)
                {
                    Console.WriteLine($"Name: {pair.Key}");
                    Console.WriteLine($"Age: {pair.Value}");
                    Console.WriteLine("====================");
                }
            }
            else if(input[0] == "Salary")
            {
                foreach (var pair in dictSalary)
                {
                    Console.WriteLine($"Name: {pair.Key}");
                    Console.WriteLine($"Salary: {pair.Value:f2}");
                    Console.WriteLine("====================");
                }
            }
            else if (input[0] == "Position")
            {
                foreach (var pair in dictPosition)
                {
                    Console.WriteLine($"Name: {pair.Key}");
                    Console.WriteLine($"Position: {pair.Value}");
                    Console.WriteLine("====================");
                }
            }
        }
    }
}
