using System;
using System.Collections.Generic;
using System.Linq;

namespace p02AppendLists
{
    class p02AppendLists
    {
        static void Main(string[] args)
        {
            List<List<string>> outerList = Console.ReadLine()
                .Split('|')
                .Reverse()
                .Select(s => s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList())
                .ToList();

            foreach (var innerList in outerList)
            {
                Console.Write(string.Join(" ", innerList) + " ");
            }
            Console.WriteLine();
            
        }
    }
}
