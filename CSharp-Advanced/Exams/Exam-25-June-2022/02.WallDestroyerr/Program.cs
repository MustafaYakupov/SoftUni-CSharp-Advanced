namespace _02.WallDestroyerr
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];

            int rowV = -1;
            int colV = -1;
            int createdHoles = 0;
            int hitRod = 0;

            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine()
                    .ToCharArray();

                matrix[row] = input;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'V')
                    {
                        rowV = row;
                        colV = col;
                        createdHoles++;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command.ToLower() == "end")  // END
                {
                    matrix[rowV][colV] = 'V';
                    Console.WriteLine($"Vanko managed to make {createdHoles} hole(s) and he hit only {hitRod} rod(s).");
                    break;
                }

                switch (command)
                {
                    case "up":
                        matrix[rowV][colV] = '*';
                        rowV--;
                        if (!IsInMatrix(rowV, colV, matrix.Length))
                        {
                            rowV++;
                            continue;
                        }
                        else if (matrix[rowV][colV] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            hitRod++;
                            rowV++;
                            continue;
                        }
                        else if (matrix[rowV][colV] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{rowV}, {colV}]!");
                            continue;
                        }
                        break;
                    case "down":
                        matrix[rowV][colV] = '*';
                        rowV++;
                        if (!IsInMatrix(rowV, colV, matrix.Length))
                        {
                            rowV--;
                            continue;
                        }
                        else if (matrix[rowV][colV] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            hitRod++;
                            rowV--;
                            continue;
                        }
                        else if (matrix[rowV][colV] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{rowV}, {colV}]!");
                            continue;
                        }
                        break;
                    case "left":
                        matrix[rowV][colV] = '*';
                        colV--;
                        if (!IsInMatrix(rowV, colV, matrix.Length))
                        {
                            colV++;
                            continue;
                        }
                        else if (matrix[rowV][colV] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            hitRod++;
                            colV++;
                            continue;
                        }
                        else if (matrix[rowV][colV] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{rowV}, {colV}]!");
                            continue;
                        }
                        break;
                    case "right":
                        matrix[rowV][colV] = '*';
                        colV++;
                        if (!IsInMatrix(rowV, colV, matrix.Length))
                        {
                            colV--;
                            continue;
                        }
                        else if (matrix[rowV][colV] == 'R')
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            hitRod++;
                            colV--;
                            continue;
                        }
                        else if (matrix[rowV][colV] == '*')
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{rowV}, {colV}]!");
                            continue;
                        }
                        break;
                }

                if (matrix[rowV][colV] == 'C')  //END
                {
                    matrix[rowV][colV] = 'E';
                    createdHoles++;
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {createdHoles} hole(s).");
                    break;
                }
                else if (matrix[rowV][colV] == '-')
                {
                    createdHoles++;
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)    // Quick way to print
            {
                Console.WriteLine(String.Join("", row));
            }
            return;
        }

        static bool IsInMatrix(int row, int col, int length) // square matrix
        {
            return row >= 0 && row < length && col >= 0 && col < length;
        }
    }
}