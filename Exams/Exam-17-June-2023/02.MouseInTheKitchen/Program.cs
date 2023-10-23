using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.MouseInTheKitchen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int mouseRow = -1;
            int mouseCol = -1;
            int cheeseCount = 0;

            char[][] matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                matrix[row] = input;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'M')
                    {
                        mouseRow = row;
                        mouseCol = col;
                    }

                    if (matrix[row][col] == 'C')
                    {
                        cheeseCount++;
                    }
                }
            }

            while (true)
            {
                string move = Console.ReadLine();

                if (move.ToLower() == "danger")
                {
                    break;
                }

                matrix[mouseRow][mouseCol] = '*';

                switch (move)
                {
                    case "up":
                        if (IsNotInMatrix(mouseRow - 1, mouseCol, matrix))
                        {
                            Console.WriteLine("No more cheese for tonight!");
                            matrix[mouseRow][mouseCol] = 'M';

                            PrintMatrix(matrix);

                            return;
                        }
                        else
                        {
                            if (matrix[mouseRow - 1][mouseCol] != '@')
                            {
                                mouseRow--;
                            }
                        }
                        break;
                    case "down":
                        if (IsNotInMatrix(mouseRow + 1, mouseCol, matrix))
                        {
                            Console.WriteLine("No more cheese for tonight!");
                            matrix[mouseRow][mouseCol] = 'M';

                            PrintMatrix(matrix);

                            return;
                        }
                        else
                        {
                            if (matrix[mouseRow + 1][mouseCol] != '@')
                            {
                                mouseRow++;
                            }
                        }
                        break;
                    case "left":
                        if (IsNotInMatrix(mouseRow, mouseCol - 1, matrix))
                        {
                            Console.WriteLine("No more cheese for tonight!");
                            matrix[mouseRow][mouseCol] = 'M';

                            PrintMatrix(matrix);

                            return;
                        }
                        else
                        {
                            if (matrix[mouseRow][mouseCol - 1] != '@')
                            {
                                mouseCol--;
                            }
                        }
                        break;
                    case "right":
                        if (IsNotInMatrix(mouseRow, mouseCol + 1, matrix))
                        {
                            Console.WriteLine("No more cheese for tonight!");
                            matrix[mouseRow][mouseCol] = 'M';

                            PrintMatrix(matrix);

                            return;
                        }
                        else
                        {
                            if (matrix[mouseRow][mouseCol + 1] != '@')
                            {
                                mouseCol++;
                            }
                        }
                        break;
                }

                if (matrix[mouseRow][mouseCol] == 'C')
                {
                    cheeseCount--;
                    
                    if (cheeseCount == 0)
                    {
                        matrix[mouseRow][mouseCol] = 'M';

                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");

                        PrintMatrix(matrix);

                        return;
                    }
                }
                else if (matrix[mouseRow][mouseCol] == 'T')
                {
                    matrix[mouseRow][mouseCol] = 'M';

                    Console.WriteLine("Mouse is trapped!");

                    PrintMatrix(matrix);

                    return;
                }
                else if (matrix[mouseRow][mouseCol] == '*')
                {
                    matrix[mouseRow][mouseCol] = 'M';
                }
                
            }

            Console.WriteLine("Mouse will come back later!");

            PrintMatrix(matrix);
        }

        static bool IsNotInMatrix(int row, int col, char[][] matrix) // rectangular matrix
        {
            return row < 0 || row >= matrix.Length || col < 0 || col >= matrix[row].Length;
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
