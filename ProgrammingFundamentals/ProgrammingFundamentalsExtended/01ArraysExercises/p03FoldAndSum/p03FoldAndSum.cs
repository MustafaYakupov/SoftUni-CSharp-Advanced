using System;
using System.Linq;

namespace p03FoldAndSum
{
    class p03FoldAndSum
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new[] { " " },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int fourth = input.Length / 4;
            int[] firstRow = new int[2 * fourth];
            int[] secondRow = new int[2 * fourth];
            int[] resultArr = new int[input.Length];

            int[] firstK = input.Take(fourth).Reverse().ToArray();
            int[] lastK = input.Skip(3 * fourth).Take(fourth).Reverse().ToArray();

            firstRow = firstK.Concat(lastK).ToArray();
            secondRow = input.Skip(fourth).Take(fourth * 2).ToArray();

            resultArr = firstRow.Zip(secondRow, (x,y) => x + y).ToArray();

            Console.WriteLine(string.Join(" ", resultArr));
        }
    }
}
