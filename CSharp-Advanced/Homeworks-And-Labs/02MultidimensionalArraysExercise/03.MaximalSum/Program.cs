using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MaxSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSizes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSizes[0];
            int cols = matrixSizes[1];
            int maxSum = int.MinValue;
            int maxRow = int.MinValue;
            int maxCol = int.MinValue;

            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

                matrix[row] = input;
            }

            for (int row = 0; row <= matrix.Length - 3; row++)
            {
                for (int col = 0; col <= matrix[row].Length - 3; col++)
                {
                    var currentSum =
                        matrix[row][col]
                        + matrix[row][col + 1]
                        + matrix[row][col + 2]
                        + matrix[row + 1][col]
                        + matrix[row + 1][col + 1]
                        + matrix[row + 1][col + 2]
                        + matrix[row + 2][col]
                        + matrix[row + 2][col + 1]
                        + matrix[row + 2][col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[maxRow][maxCol]} {matrix[maxRow][maxCol + 1]} {matrix[maxRow][maxCol + 2]}");
            Console.WriteLine($"{matrix[maxRow + 1][maxCol]} {matrix[maxRow + 1][maxCol + 1]} {matrix[maxRow + 1][maxCol + 2]}");
            Console.WriteLine($"{matrix[maxRow + 2][maxCol]} {matrix[maxRow + 2][maxCol + 1]} {matrix[maxRow + 2][maxCol + 2]}");
        }
    }
}
