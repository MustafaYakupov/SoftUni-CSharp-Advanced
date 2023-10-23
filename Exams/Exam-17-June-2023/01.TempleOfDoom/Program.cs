using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.TempleOfDoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] tools = Console.ReadLine()              // Queue
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] substances = Console.ReadLine()              // Stack
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> challenges = Console.ReadLine()              
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Queue<int> toolsQueue = new Queue<int>(tools);
            Stack<int> substancesStack = new Stack<int>(substances);

            while (true)
            {
                if (challenges.Count == 0)
                {
                    Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");

                    if (toolsQueue.Any())
                    {
                        Console.WriteLine($"Tools: {String.Join(", ", toolsQueue)}");
                    }

                    if (substancesStack.Any())
                    {
                        Console.WriteLine($"Substances: {String.Join(", ", substancesStack)}");
                    }
                    return;
                }

                if (!toolsQueue.Any() || !substancesStack.Any())
                {
                    Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");

                    if (toolsQueue.Any())
                    {
                        Console.WriteLine($"Tools: {String.Join(", ", toolsQueue)}");
                    }

                    if (substancesStack.Any())
                    {
                        Console.WriteLine($"Substances: {String.Join(", ", substancesStack)}");
                    }

                    Console.WriteLine($"Challenges: {String.Join(", ", challenges)}");
                    return;
                }

                int currentTool = toolsQueue.Peek();
                int currentSubstance = substancesStack.Peek();
                int multiplied = currentTool * currentSubstance;

                if (challenges.Contains(multiplied))
                {
                    toolsQueue.Dequeue();
                    substancesStack.Pop();
                    challenges.Remove(multiplied);
                }
                else
                {
                    int queueElementToMove = toolsQueue.Dequeue();
                    toolsQueue.Enqueue(queueElementToMove + 1);

                    int stackElementToMove = substancesStack.Pop();

                    if (stackElementToMove - 1 != 0)
                    {
                        substancesStack.Push(stackElementToMove - 1);
                    }
                }
            }
        }
    }
}
