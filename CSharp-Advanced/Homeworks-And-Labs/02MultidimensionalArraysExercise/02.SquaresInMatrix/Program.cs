using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSizes[0];
            int cols = matrixSizes[1];

            string[][] matrix = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                matrix[row] = input;
            }

            int counter = 0;

            for (int row = 0; row <= matrix.Length - 2; row++)
            {
                for (int col = 0; col <= matrix[row].Length - 2; col++)
                {
                    if (matrix[row][col] == matrix[row][col + 1] 
                        && matrix[row ][col + 1]  == matrix[row + 1][col + 1] 
                        && matrix[row + 1][col + 1] == matrix[row + 1][col])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
