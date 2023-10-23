using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];

            int rowBee = -1;
            int colBee = -1;
            int pollinatedFlowers = 0;

            ReadMatrix(size, matrix, ref rowBee, ref colBee);

            while (true)
            {
                string command = Console.ReadLine();

                if (command.ToLower() == "end")
                {
                    break;
                }

                MoveBee(matrix, ref rowBee, ref colBee, command);

                if (!IsInMatrix(rowBee, colBee, matrix))
                {

                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[rowBee][colBee] == 'f')
                {
                    pollinatedFlowers++;
                    matrix[rowBee][colBee] = 'B';
                }
                else if (matrix[rowBee][colBee] == 'O')
                {
                    MoveBee(matrix, ref rowBee, ref colBee, command);

                    if (matrix[rowBee][colBee] == 'f')
                    {
                        pollinatedFlowers++;
                    }

                    matrix[rowBee][colBee] = 'B';

                    continue;
                }
                else if (matrix[rowBee][colBee] == '.')
                {
                    matrix[rowBee][colBee] = 'B';
                }
            }

            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }

            PrintMatrix(matrix);
        }

        private static void ReadMatrix(int size, char[][] matrix, ref int rowBee, ref int colBee)
        {
            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine().ToCharArray();

                matrix[row] = input;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        rowBee = row;
                        colBee = col;
                    }
                }
            }
        }

        private static void MoveBee(char[][] matrix, ref int rowBee, ref int colBee, string command)
        {
            switch (command)
            {
                case "up":
                    matrix[rowBee][colBee] = '.';
                    rowBee--;
                    break;
                case "down":
                    matrix[rowBee][colBee] = '.';
                    rowBee++;
                    break;
                case "left":
                    matrix[rowBee][colBee] = '.';
                    colBee--;
                    break;
                case "right":
                    matrix[rowBee][colBee] = '.';
                    colBee++;
                    break;
            }
        }

        static bool IsInMatrix(int row, int col, char[][] matrix) // rectangular matrix
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)    // Quick way to print
            {
                Console.WriteLine(String.Join("", row));
            }
        }
    }
}
