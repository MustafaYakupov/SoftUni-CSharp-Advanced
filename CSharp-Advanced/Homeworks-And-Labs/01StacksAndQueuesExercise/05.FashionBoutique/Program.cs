using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInBoxes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            int clothesSum = 0;
            int racksCount = 1;

            Stack<int> clothesStack = new Stack<int>(clothesInBoxes);

            while (clothesStack.Count > 0)
            {
                clothesSum += clothesStack.Peek();

                if (clothesSum > rackCapacity)
                {
                    racksCount++;
                    clothesSum = 0;
                }
                else
                {
                    clothesStack.Pop();
                }
            }

            Console.WriteLine(racksCount);
        }
    }
}
