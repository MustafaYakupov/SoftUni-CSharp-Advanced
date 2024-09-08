using System;
using System.Collections.Generic;
using System.Linq;

namespace p03SearchForANumber
{
    class p03SearchForANumber
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] toDoNums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            list.Take(toDoNums[0]);
            
            for (int i = 0; i < toDoNums[1]; i++)
            {
                list.Remove(list[0]);
            }
            if (list.Contains(toDoNums[2]))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
