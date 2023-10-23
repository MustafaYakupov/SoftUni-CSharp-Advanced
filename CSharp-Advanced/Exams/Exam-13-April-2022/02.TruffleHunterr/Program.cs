using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.TruffleHunterr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];

            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                matrix[row] = input;
            }

            int blackTruffleCount = 0;
            int summerTruffleCount = 0;
            int whiteTruffleCount = 0;
            int wildBoarEatenTrufflesCount = 0;

            while (true)
            {
                string commands = Console.ReadLine();

                if (commands == "Stop the hunt")
                {
                    break;
                }

                string[] tokens = commands.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string currentCommand = tokens[0];
                int rowTarget = int.Parse(tokens[1]);
                int colTarget = int.Parse(tokens[2]);
                char currentCell = matrix[rowTarget][colTarget];

                if (currentCommand.ToLower() == "collect")
                {
                    if (currentCell == 'B')
                    {
                        blackTruffleCount++;
                        matrix[rowTarget][colTarget] = '-';
                    }
                    else if (currentCell == 'S')
                    {
                        summerTruffleCount++;
                        matrix[rowTarget][colTarget] = '-';

                    }
                    else if (currentCell == 'W')
                    {
                        whiteTruffleCount++;
                        matrix[rowTarget][colTarget] = '-';

                    }
                }
                else if (currentCommand.ToLower() == "wild_boar")
                {
                    string direction = tokens[3];

                    if (WildBoarEating(matrix, wildBoarEatenTrufflesCount, rowTarget, colTarget, currentCell))
                    {
                        wildBoarEatenTrufflesCount++;
                    }

                    while (true)
                    {
                        if (direction == "up")
                        {
                            rowTarget -= 2;

                            if (!IsInMatrix(rowTarget, colTarget, size))
                            {
                                break;
                            }

                            if (WildBoarEating(matrix, wildBoarEatenTrufflesCount, rowTarget, colTarget, currentCell))
                            {
                                wildBoarEatenTrufflesCount++;
                            }
                        }
                        else if (direction == "down")
                        {
                            rowTarget += 2;

                            if (!IsInMatrix(rowTarget, colTarget, size))
                            {
                                break;
                            }

                            if (WildBoarEating(matrix, wildBoarEatenTrufflesCount, rowTarget, colTarget, currentCell))
                            {
                                wildBoarEatenTrufflesCount++;
                            }
                        }
                        else if (direction == "left")
                        {
                            colTarget -= 2;

                            if (!IsInMatrix(rowTarget, colTarget, size))
                            {
                                break;
                            }

                            if (WildBoarEating(matrix, wildBoarEatenTrufflesCount, rowTarget, colTarget, currentCell))
                            {
                                wildBoarEatenTrufflesCount++;
                            }
                        }
                        else if (direction == "right")
                        {
                            colTarget += 2;

                            if (!IsInMatrix(rowTarget, colTarget, size))
                            {
                                break;
                            }

                            if (WildBoarEating(matrix, wildBoarEatenTrufflesCount, rowTarget, colTarget, currentCell))
                            {
                                wildBoarEatenTrufflesCount++;
                            }
                        }
                    }
                }

            }

            Console.WriteLine($"Peter manages to harvest {blackTruffleCount} black, {summerTruffleCount} summer, and {whiteTruffleCount} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoarEatenTrufflesCount} truffles.");

            foreach (var row in matrix)    // Quick way to print
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }

        private static bool WildBoarEating(char[][] matrix, int wildBoarEatenTrufflesCount, int rowTarget, int colTarget, char currentCell)
        {
            if (currentCell == 'B')
            {
                matrix[rowTarget][colTarget] = '-';
                return true;
            }
            else if (currentCell == 'S')
            {
                matrix[rowTarget][colTarget] = '-';
                return true;
            }
            else if (currentCell == 'W')
            {
                matrix[rowTarget][colTarget] = '-';
                return true;
            }

            return false;
        }

        static bool IsInMatrix(int row, int col, int length) // square matrix
        {
            return row >= 0 && row < length && col >= 0 && col < length;
        }
    }
}
