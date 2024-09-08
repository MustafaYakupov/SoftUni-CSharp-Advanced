using System;
using System.Collections.Generic;
using System.Linq;

namespace p06SumReversedNumbers
{
    class p06SumReversedNumbers
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(' ')
                .ToList();

            int result = 0;

            for (int i = 0; i < list.Count; i++)
            {
                string currentNumber = list[i];
                string reversed = "";

                for (int j = currentNumber.Length - 1; j >= 0; j--)
                {
                    reversed += currentNumber[j];
                }
                result += int.Parse(reversed);
            }
            Console.WriteLine(result);
        } 
    }
}
