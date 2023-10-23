using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BlindMan_sBuff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            int playerRow = -1;
            int playerCol = -1;

            int touchedOpponents = 0;
            int movesMade = 0;

            char[][] matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine()
                    .Split(' ')
                    .Select(char.Parse)
                    .ToArray();

                matrix[row] = input;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'B')  // My player initial position
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            while (true)
            {
                string move = Console.ReadLine();

                if (move.ToLower() == "finish")   // End of game
                {
                    Console.WriteLine($"Game over!");
                    Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {movesMade}");
                    return;
                }

                switch (move)
                {
                    case "up":
                        if (IsInMatrix(playerRow - 1, playerCol, matrix) 
                            && matrix[playerRow - 1][playerCol] != 'O')
                        {
                            char nextElement = matrix[playerRow - 1][playerCol];

                            if (nextElement == '-')
                            {
                                movesMade++;
                                matrix[playerRow][playerCol] = '-';
                                matrix[playerRow - 1][playerCol] = 'B';
                                playerRow--;
                            }
                            else if (nextElement == 'P')
                            {
                                movesMade++;
                                touchedOpponents++;
                                matrix[playerRow][playerCol] = '-';
                                matrix[playerRow - 1][playerCol] = '-';
                                playerRow--;

                                if (touchedOpponents == 3)
                                {
                                    Console.WriteLine($"Game over!");
                                    Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {movesMade}");
                                    return;
                                }
                            }
                        }
                        break;
                    case "down":
                        if (IsInMatrix(playerRow + 1, playerCol, matrix)
                            && matrix[playerRow + 1][playerCol] != 'O')
                        {
                            char nextElement = matrix[playerRow + 1][playerCol];

                            if (nextElement == '-')
                            {
                                movesMade++;
                                matrix[playerRow][playerCol] = '-';
                                matrix[playerRow + 1][playerCol] = 'B';
                                playerRow++;
                            }
                            else if (nextElement == 'P')
                            {
                                movesMade++;
                                touchedOpponents++;
                                matrix[playerRow][playerCol] = '-';
                                matrix[playerRow + 1][playerCol] = '-';
                                playerRow++;

                                if (touchedOpponents == 3)
                                {
                                    Console.WriteLine($"Game over!");
                                    Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {movesMade}");
                                    return;
                                }
                            }
                        }
                        break;
                    case "left":
                        if (IsInMatrix(playerRow, playerCol - 1, matrix)
                            && matrix[playerRow][playerCol - 1] != 'O')
                        {
                            char nextElement = matrix[playerRow][playerCol - 1];

                            if (nextElement == '-')
                            {
                                movesMade++;
                                matrix[playerRow][playerCol] = '-';
                                matrix[playerRow][playerCol - 1] = 'B';
                                playerCol--;
                            }
                            else if (nextElement == 'P')
                            {
                                movesMade++;
                                touchedOpponents++;
                                matrix[playerRow][playerCol] = '-';
                                matrix[playerRow][playerCol - 1] = '-';
                                playerCol--;

                                if (touchedOpponents == 3)
                                {
                                    Console.WriteLine($"Game over!");
                                    Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {movesMade}");
                                    return;
                                }
                            }
                        }
                        break;
                    case "right":
                        if (IsInMatrix(playerRow, playerCol + 1, matrix)
                            && matrix[playerRow][playerCol + 1] != 'O')
                        {
                            char nextElement = matrix[playerRow][playerCol + 1];

                            if (nextElement == '-')
                            {
                                movesMade++;
                                matrix[playerRow][playerCol] = '-';
                                matrix[playerRow][playerCol + 1] = 'B';
                                playerCol++;
                            }
                            else if (nextElement == 'P')
                            {
                                movesMade++;
                                touchedOpponents++;
                                matrix[playerRow][playerCol] = '-';
                                matrix[playerRow][playerCol + 1] = '-';
                                playerCol++;

                                if (touchedOpponents == 3)
                                {
                                    Console.WriteLine($"Game over!");
                                    Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {movesMade}");
                                    return;
                                }
                            }
                        }
                        break;
                }
            }

            
        }

        private static void Print(int touchedOpponents, int movesMade)
        {
            Console.WriteLine($"Game over!");
            Console.WriteLine($"Touched opponents: {touchedOpponents} Moves made: {movesMade}");
            return;
        }

        static bool IsInMatrix(int row, int col, char[][] matrix) // rectangular matrix
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }
    }
}
