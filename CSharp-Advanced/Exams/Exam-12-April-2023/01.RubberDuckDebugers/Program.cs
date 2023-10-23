using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RubberDuckDebugers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] timeToCompleteTask = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] numberOfTasks = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> timeQueue = new Queue<int>(timeToCompleteTask);
            Stack<int> numberOfTasksStack = new Stack<int>(numberOfTasks);

            int DarthVaderDuck = 0;
            int ThorDuck = 0;
            int BigBlueDuck = 0;
            int SmallYellowDuck = 0;


            while (timeQueue.Any() && numberOfTasks.Any())
            {
                int time = timeQueue.Peek();
                int task = numberOfTasksStack.Peek();
                int timeForTaskResult = time * task;

                if (timeForTaskResult > 240)
                {
                    int taskValueToDecrese = numberOfTasksStack.Pop();
                    numberOfTasksStack.Push(taskValueToDecrese - 2);

                    int timeValueToMove = timeQueue.Dequeue();
                    timeQueue.Enqueue(timeValueToMove);
                }
                else if(timeForTaskResult >= 0 && timeForTaskResult <= 60)
                {
                    DarthVaderDuck++;

                    RemoveElements(timeQueue, numberOfTasksStack);
                }
                else if (timeForTaskResult >= 61 && timeForTaskResult <= 120)
                {
                    ThorDuck++;

                    RemoveElements(timeQueue, numberOfTasksStack);
                }
                else if (timeForTaskResult >= 121 && timeForTaskResult <= 180)
                {
                    BigBlueDuck++;

                    RemoveElements(timeQueue, numberOfTasksStack);
                }
                else if (timeForTaskResult >= 181 && timeForTaskResult <= 240)
                {
                    SmallYellowDuck++;

                    RemoveElements(timeQueue, numberOfTasksStack);
                }
            }

            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            Console.WriteLine($"Darth Vader Ducky: {DarthVaderDuck}");
            Console.WriteLine($"Thor Ducky: {ThorDuck}");
            Console.WriteLine($"Big Blue Rubber Ducky: {BigBlueDuck}");
            Console.WriteLine($"Small Yellow Rubber Ducky: {SmallYellowDuck}");
        }

        private static void RemoveElements(Queue<int> timeQueue, Stack<int> numberOfTasksStack)
        {
            timeQueue.Dequeue();
            numberOfTasksStack.Pop();
        }
    }
}
