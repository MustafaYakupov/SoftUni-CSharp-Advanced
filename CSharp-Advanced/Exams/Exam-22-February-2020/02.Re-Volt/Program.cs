using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Re_Volt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());


            char[][] matrix = new char[size][];
            int rowPlayer = -1;
            int colPlayer = -1; 

            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine()
                    .ToCharArray();

                matrix[row] = input;

                for (int col = 0; col < size; col++)
                {
                    if (matrix[row][col] == 'f')
                    {
                        rowPlayer = row;
                        colPlayer = col;
                        matrix[row][col] = '-';
                    }
                }
            }

            for (int i = 0; i < commandsCount; i++)
            {
                string direction = Console.ReadLine();

                if (direction == "up")
                {
                    rowPlayer--;

                    if (!IsInMatrix(rowPlayer, colPlayer, size))
                    {
                        rowPlayer = size - 1;
                    }

                    if (matrix[rowPlayer][colPlayer] == 'B')
                    {
                        rowPlayer--;

                        if (!IsInMatrix(rowPlayer, colPlayer, size))
                        {
                            rowPlayer = size - 1;
                        }
                    }
                    else if (matrix[rowPlayer][colPlayer] == 'T')
                    {
                        rowPlayer++;
                    }
                }
                else if (direction == "down")
                {
                    rowPlayer++;

                    if (!IsInMatrix(rowPlayer, colPlayer, size))
                    {
                        rowPlayer = 0;
                    }

                    if (matrix[rowPlayer][colPlayer] == 'B')
                    {
                        rowPlayer++;

                        if (!IsInMatrix(rowPlayer, colPlayer, size))
                        {
                            rowPlayer = 0;
                        }
                    }
                    else if (matrix[rowPlayer][colPlayer] == 'T')
                    {
                        rowPlayer--;
                    }
                }
                else if (direction == "left")
                {
                    colPlayer--;

                    if (!IsInMatrix(rowPlayer, colPlayer, size))
                    {
                        colPlayer = size - 1;
                    }

                    if (matrix[rowPlayer][colPlayer] == 'B')
                    {
                        colPlayer--;

                        if (!IsInMatrix(rowPlayer, colPlayer, size))
                        {
                            colPlayer = size - 1;
                        }
                    }
                    else if (matrix[rowPlayer][colPlayer] == 'T')
                    {
                        colPlayer++;
                    }
                }
                else if (direction == "right")
                {
                    colPlayer++;

                    if (!IsInMatrix(rowPlayer, colPlayer, size))
                    {
                        colPlayer = 0;
                    }

                    if (matrix[rowPlayer][colPlayer] == 'B')
                    {
                        colPlayer++;

                        if (!IsInMatrix(rowPlayer, colPlayer, size))
                        {
                            colPlayer = 0;
                        }
                    }
                    else if (matrix[rowPlayer][colPlayer] == 'T')
                    {
                        colPlayer--;
                    }
                }

                if (matrix[rowPlayer][colPlayer] == 'F')
                {
                    matrix[rowPlayer][colPlayer] = 'f';
                    Console.WriteLine("Player won!");

                    foreach (var row in matrix)    // Quick way to print
                    {
                        Console.WriteLine(String.Join("", row));
                    }

                    return;
                }
            }

            Console.WriteLine("Player lost!");
            matrix[rowPlayer][colPlayer] = 'f';

            foreach (var row in matrix)    // Quick way to print
            {
                Console.WriteLine(String.Join("", row));
            }
        }
        static bool IsInMatrix(int row, int col, int length) // square matrix
        {
            return row >= 0 && row < length && col >= 0 && col < length;
        }
    }
}
