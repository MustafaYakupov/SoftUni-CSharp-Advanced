using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] actionsInput = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] numbersInput = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int elementsToPush = actionsInput[0];
            int elementsToPop = actionsInput[1];
            int lookUpValue = actionsInput[2];

            Stack<int> stack = new Stack<int>(numbersInput);

            for (int i = 0; i < elementsToPop; i++)
            {
                if (stack.Any())
                {
                    stack.Pop();
                }
            }

            if (stack.Contains(lookUpValue))
            {
                Console.WriteLine("true");
            }
            else if (!stack.Any())
            {
                Console.WriteLine("0");
            }
            else 
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
