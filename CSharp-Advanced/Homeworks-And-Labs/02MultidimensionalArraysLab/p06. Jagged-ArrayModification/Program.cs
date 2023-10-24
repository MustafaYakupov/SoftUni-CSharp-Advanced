using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p06.Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int rows = int.Parse(Console.ReadLine());

            int[][] arr = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                // Initialize how many elements we have on the current row
                arr[row] = new int[currentRow.Length];

                for (int col = 0; col < currentRow.Length; col++)
                {
                    arr[row][col] = currentRow[col];
                }

            }

            foreach (var row in arr)
            {
                Console.WriteLine(String.Join(", ", row));
            }
        }
    }
}
