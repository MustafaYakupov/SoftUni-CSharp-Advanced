using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = n[0];
            int cols = n[1];

            int playerRow = 0;
            int playerCol = 0;

            Stack<int> bunnies = new Stack<int>(); // Holds the bunnies coordinates

            string[][] matrix = new string[rows][];


            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine()
                    .ToArray();
                matrix[row] = new string[cols];

                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = input[col].ToString();

                    if (matrix[row][col] == "P")
                    {
                        playerRow = row;
                        playerCol = col;
                    }


                }
            }

            string moves = Console.ReadLine();

            bool won = false;


            foreach (var command in moves)
            {
                string currentCommand = command.ToString();
                matrix[playerRow][playerCol] = ".";

                if (currentCommand == "U")
                {
                    if (playerRow > 0)
                    {
                        playerRow--;
                    }
                    else
                    {
                        won = true;
                    }
                }
                else if (currentCommand == "D")
                {
                    if (playerRow < rows - 1)
                    {
                        playerRow++;
                    }
                    else
                    {
                        won = true;
                    }
                }
                else if (currentCommand == "L")
                {
                    if (playerCol > 0)
                    {
                        playerCol--;
                    }
                    else
                    {
                        won = true;
                    }
                }
                else if (currentCommand == "R")
                {
                    if (playerCol < cols - 1)
                    {
                        playerCol++;
                    }
                    else
                    {
                        won = true;
                    }
                }

                if (won == true)
                {
                    //Clone Bunnies 1 more time
                    BunniesGrow(rows, cols, matrix, bunnies);
                    Console.WriteLine(String.Join(Environment.NewLine, matrix.Select(r => String.Join("", r))));
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    return;
                }

                //Console.WriteLine(String.Join(Environment.NewLine, matrix.Select(r => String.Join(" ", r))));

                if (matrix[playerRow][playerCol] == "B")
                {
                    //Clone Bunnies 1 more time
                    BunniesGrow(rows, cols, matrix, bunnies);
                    Console.WriteLine(String.Join(Environment.NewLine, matrix.Select(r => String.Join("", r))));
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
                }

                //Grow bunnies
                BunniesGrow(rows, cols, matrix, bunnies);

                if (matrix[playerRow][playerCol] == "B")
                {
                    Console.WriteLine(String.Join(Environment.NewLine, matrix.Select(r => String.Join("", r))));
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
                }
            }

        }

        private static void BunniesGrow(int rows, int cols, string[][] matrix, Stack<int> bunnies)
        {
            //Fill up the stack with all the bunnies
            FindBunnies(matrix, bunnies, rows, cols);

            while (bunnies.Count != 0)
            {
                int bunnyCol = bunnies.Pop();
                int bunnyRow = bunnies.Pop();

                // Up
                if (bunnyRow > 0)
                {
                    matrix[bunnyRow - 1][bunnyCol] = "B";
                }
                //Down
                if (bunnyRow < rows - 1)
                {
                    matrix[bunnyRow + 1][bunnyCol] = "B";
                }
                //Left
                if (bunnyCol > 0)
                {
                    matrix[bunnyRow][bunnyCol - 1] = "B";
                }
                //Right
                if (bunnyCol < cols - 1)
                {
                    matrix[bunnyRow][bunnyCol + 1] = "B";
                }

            }
        }

        private static void FindBunnies(string[][] matrix, Stack<int> bunnies, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col] == "B")
                    {
                        bunnies.Push(row);
                        bunnies.Push(col);
                    }
                }
            }
        }
    }
}
