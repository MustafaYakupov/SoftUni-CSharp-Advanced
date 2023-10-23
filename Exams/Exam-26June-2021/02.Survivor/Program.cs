using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                matrix[row] = input;
            }

            int collectedTokens = 0;
            int opponentsTokens = 0;

            while (true)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (tokens[0].ToLower() == "gong")
                {
                    foreach (var row in matrix)    // Quick way to print
                    {
                        Console.WriteLine(String.Join(" ", row));
                    }

                    Console.WriteLine($"Collected tokens: {collectedTokens}");
                    Console.WriteLine($"Opponent's tokens: {opponentsTokens}");
                    return;
                }

                if (tokens[0].ToLower() == "find")
                {
                    int rowMyPlayer = int.Parse(tokens[1]); 
                    int colMyPlayer = int.Parse(tokens[2]);

                    if (IsInMatrix(rowMyPlayer, colMyPlayer, matrix))
                    {
                        if (matrix[rowMyPlayer][colMyPlayer] == 'T')
                        {
                            matrix[rowMyPlayer][colMyPlayer] = '-';
                            collectedTokens++;
                        }
                    }
                }
                else if (tokens[0].ToLower() == "opponent")
                {
                    int rowOpponent = int.Parse(tokens[1]);
                    int colOpponent = int.Parse(tokens[2]);
                    string direction = tokens[3];

                    if (IsInMatrix(rowOpponent, colOpponent, matrix))
                    {
                        if (matrix[rowOpponent][colOpponent] == 'T')
                        {
                            matrix[rowOpponent][colOpponent] = '-';
                            opponentsTokens++;
                        }
                    }

                    if (direction.ToLower() == "up")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            rowOpponent--;

                            if (IsInMatrix(rowOpponent, colOpponent, matrix))
                            {
                                if (matrix[rowOpponent][colOpponent] == 'T')
                                {
                                    matrix[rowOpponent][colOpponent] = '-';
                                    opponentsTokens++;
                                }
                            }
                        }
                    }
                    else if (direction.ToLower() == "down")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            rowOpponent++;

                            if (IsInMatrix(rowOpponent, colOpponent, matrix))
                            {
                                if (matrix[rowOpponent][colOpponent] == 'T')
                                {
                                    matrix[rowOpponent][colOpponent] = '-';
                                    opponentsTokens++;
                                }
                            }
                        }
                    }
                    else if (direction.ToLower() == "left")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            colOpponent--;

                            if (IsInMatrix(rowOpponent, colOpponent, matrix))
                            {
                                if (matrix[rowOpponent][colOpponent] == 'T')
                                {
                                    matrix[rowOpponent][colOpponent] = '-';
                                    opponentsTokens++;
                                }
                            }
                        }
                    }
                    else if (direction.ToLower() == "right")
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            colOpponent++;

                            if (IsInMatrix(rowOpponent, colOpponent, matrix))
                            {
                                if (matrix[rowOpponent][colOpponent] == 'T')
                                {
                                    matrix[rowOpponent][colOpponent] = '-';
                                    opponentsTokens++;
                                }
                            }
                        }
                    }
                }
            }
        }

        static bool IsInMatrix(int row, int col, char[][] matrix) // rectangular matrix
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }
    }
}
