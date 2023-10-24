using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[][] matrix = new int[matrixSize][];

            for (int i = 0; i < matrixSize; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = input;
            }

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;
            int sum = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                primaryDiagonalSum += matrix[i][i];
                secondaryDiagonalSum += matrix[i][matrix[i].Length - 1 - i];
            }

            sum = Math.Max(primaryDiagonalSum, secondaryDiagonalSum) - Math.Min(primaryDiagonalSum, secondaryDiagonalSum);

            Console.WriteLine(sum);
        }
    }
}
