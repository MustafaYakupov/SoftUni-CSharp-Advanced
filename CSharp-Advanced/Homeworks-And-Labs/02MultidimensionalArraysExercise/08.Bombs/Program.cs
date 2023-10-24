using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[][] matrix = new int[size][];

            for (int row = 0; row < size; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = input;
                matrix[row] = input;
            }

            string[] bombCoordiantes = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            foreach (var bomb in bombCoordiantes)
            {
                int[] coordinates = bomb.Split(',').Select(int.Parse).ToArray();
                int bombRow = coordinates[0];
                int bombCol = coordinates[1];

                int damage = matrix[bombRow][bombCol];

                if (IsInMatrix(bombRow - 1, bombCol, size) 
                    && matrix[bombRow - 1][bombCol] > 0) // up
                {
                    matrix[bombRow - 1][bombCol] -= damage;
                }

                if (IsInMatrix(bombRow - 1, bombCol - 1, size) 
                    && matrix[bombRow - 1][bombCol - 1] > 0) // up-left diagonal
                {
                    matrix[bombRow - 1][bombCol - 1] -= damage;
                }

                if (IsInMatrix(bombRow - 1, bombCol + 1, size) 
                    && matrix[bombRow - 1][bombCol + 1] > 0)  // up-right diagonal
                {
                    matrix[bombRow - 1][bombCol + 1] -= damage;
                }

                if (IsInMatrix(bombRow, bombCol - 1, size) 
                    && matrix[bombRow][bombCol - 1] > 0) // left
                {
                    matrix[bombRow][bombCol - 1] -= damage;
                }

                if (IsInMatrix(bombRow, bombCol + 1, size) 
                    && matrix[bombRow][bombCol + 1] > 0) // right
                {
                    matrix[bombRow][bombCol + 1] -= damage;
                } 

                if (IsInMatrix(bombRow + 1, bombCol - 1, size) 
                    && matrix[bombRow + 1][bombCol - 1] > 0) // down-left diagonal
                {
                    matrix[bombRow + 1][bombCol - 1] -= damage;
                }

                if (IsInMatrix(bombRow + 1, bombCol + 1, size)
                    && matrix[bombRow + 1][bombCol + 1] > 0) // down-right diagonal 
                {
                    matrix[bombRow + 1][bombCol + 1] -= damage;
                }

                if (IsInMatrix(bombRow + 1, bombCol, size) 
                    && matrix[bombRow + 1][bombCol] > 0) // down
                {
                    matrix[bombRow + 1][bombCol] -= damage;
                }

                matrix[bombRow][bombCol] = 0;
            }

            int counter = 0;
            int sum = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row][col] > 0)
                    {
                        counter++;
                        sum += matrix[row][col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {counter}");
            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }

                Console.WriteLine();
            }
        }

        static bool IsInMatrix(int row, int col, int length)
        {
            return row >= 0 && row < length && col >= 0 && col < length;
        }
    }
}
