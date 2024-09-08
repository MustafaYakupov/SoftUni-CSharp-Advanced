using System;
using System.Collections.Generic;
using System.Linq;

namespace p04GrabAndGo
{
    class p04GrabAndGo
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());

            var resultArr = new List<long>();
            int counter = -1;           
            int notFound = 0;

            foreach (var num in arr)
            {
                counter++;
                if (num == number)
                {
                    notFound++;
                    resultArr.Clear();
                    
                    resultArr = arr.Take(counter).ToList();
                   
                }
            }

            long result = resultArr.Sum();

            if (notFound == 0)
            {
                Console.WriteLine("No occurrences were found!");
            }
            else
            {
            Console.WriteLine(result);
            }
        }
    }
}
