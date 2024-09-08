using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03SumAdjasentEqualNumbers
{
    class p03SumAdjasentEqualNumbers
    {
        static void Main(string[] args)
        {
            List<double> input = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            int index = 0;

            while (index < input.Count - 1)
            {
                if (input[index] == input[index + 1])
                {
                    input[index] *= 2;
                    input.RemoveAt(index + 1);  

                    if (index > 0)
                    {
                        index--;
                    }
                }
                else
                {
                    index++;
                }
            }
            Console.WriteLine(string.Join(" ", input));
        }
    }
}
