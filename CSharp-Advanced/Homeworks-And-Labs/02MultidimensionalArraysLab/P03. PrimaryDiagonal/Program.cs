using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();


                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int currentRow = 0;
            int currentCol = 0;
            int sum = 0;

            while (true)
            {
                if (currentRow >= matrix.GetLength(0) || currentCol >= matrix.GetLength(1))
                {
                     break;
                }

                sum += matrix[currentRow, currentCol];


                currentRow++;
                currentCol++;
            }

            //for (int i = 0; i < matrix.GetLength(0); i++)          // Print primary diagonal
            //{
            //    Console.Write(matrix[i,i] + " ");
            //}
             
            //for (int i = 0; i < matrix.GetLength(0); i++)                 // Print secondary diagonal
            //{
            //    Console.Write(matrix[i, matrix.GetLength(1) - i - 1] + " ");
            //}

            Console.WriteLine(sum);
        }
    }
}
