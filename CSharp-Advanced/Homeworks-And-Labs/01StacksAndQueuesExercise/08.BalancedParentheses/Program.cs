using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.BalancedParentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> firstHalfStack = new Stack<char>();
            Queue<char> secondHalfQueue = new Queue<char>();

            for (int i = 0; i < input.Length / 2; i++)
            {
                firstHalfStack.Push(input[i]);
            }

            for (int i = input.Length / 2; i < input.Length; i++)
            {
                secondHalfQueue.Enqueue(input[i]);
            }

            while (firstHalfStack.Count > 0)
            {
                if (firstHalfStack.Peek() == '(' && secondHalfQueue.Peek() == ')')
                {
                    firstHalfStack.Pop();
                    secondHalfQueue.Dequeue();
                }
                else if (firstHalfStack.Peek() == '[' && secondHalfQueue.Peek() == ']')
                {
                    firstHalfStack.Pop();
                    secondHalfQueue.Dequeue();
                }
                else if (firstHalfStack.Peek() == '{' && secondHalfQueue.Peek() == '}')
                {
                    firstHalfStack.Pop();
                    secondHalfQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            
             Console.WriteLine("YES");
           
        }
    }
}
