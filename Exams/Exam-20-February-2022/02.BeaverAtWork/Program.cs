using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];

            int rowBeaver = -1;
            int colBeaver = -1;
            int branchesCount = 0;
            List<char> collectedBranches = new List<char>();

            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                matrix[row] = input;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        rowBeaver = row;
                        colBeaver = col;
                    }

                    if (char.IsLower(matrix[row][col]))
                    {
                        branchesCount++;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (branchesCount == 0) // End WON
                {
                    Console.Write($"The Beaver successfully collect {collectedBranches.Count} wood branches: ");

                    Console.WriteLine($"{string.Join(", ", collectedBranches)}.");

                    foreach (var row in matrix)    // Quick way to print
                    {
                        Console.WriteLine(String.Join(" ", row));
                    }

                    return;
                }

                if (command.ToLower() == "end") // End LOST
                {
                    Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesCount} branches left.");

                    foreach (var row in matrix)    // Quick way to print
                    {
                        Console.WriteLine(String.Join(" ", row));
                    }

                    return;
                }

                matrix[rowBeaver][colBeaver] = '-';

                if (command.ToLower() == "up")
                {
                    rowBeaver--;

                    if (!IsInMatrix(rowBeaver, colBeaver,size))
                    {
                        rowBeaver++;

                        if (collectedBranches.Count > 0)
                        {
                            collectedBranches.RemoveAt(collectedBranches.Count - 1);
                        }
                    }

                    if (matrix[rowBeaver][colBeaver] == 'F')
                    {
                        if (rowBeaver == 0)
                        {
                            matrix[rowBeaver][colBeaver] = '-';
                            rowBeaver = size - 1;

                            if (char.IsLower(matrix[rowBeaver][colBeaver]))
                            {
                                collectedBranches.Add(matrix[rowBeaver][colBeaver]);
                                branchesCount--;
                            }

                            matrix[rowBeaver][colBeaver] = 'B';

                        }
                        else
                        {
                            matrix[rowBeaver][colBeaver] = '-';
                            rowBeaver = 0;

                            if (char.IsLower(matrix[rowBeaver][colBeaver]))
                            {
                                collectedBranches.Add(matrix[rowBeaver][colBeaver]);
                                branchesCount--;
                            }

                            matrix[rowBeaver][colBeaver] = 'B';
                        }
                    }
                }
                else if (command.ToLower() == "down")
                {
                    rowBeaver++;

                    if (!IsInMatrix(rowBeaver, colBeaver, size))
                    {
                        rowBeaver--;

                        if (collectedBranches.Count > 0)
                        {
                            collectedBranches.RemoveAt(collectedBranches.Count - 1);
                        }
                    }

                    if (matrix[rowBeaver][colBeaver] == 'F')
                    {
                        if (rowBeaver == size - 1)
                        {
                            matrix[rowBeaver][colBeaver] = '-';
                            rowBeaver = 0;

                            if (char.IsLower(matrix[rowBeaver][colBeaver]))
                            {
                                collectedBranches.Add(matrix[rowBeaver][colBeaver]);
                                branchesCount--;
                            }

                            matrix[rowBeaver][colBeaver] = 'B';
                        }
                        else
                        {
                            matrix[rowBeaver][colBeaver] = '-';
                            rowBeaver = size - 1;

                            if (char.IsLower(matrix[rowBeaver][colBeaver]))
                            {
                                collectedBranches.Add(matrix[rowBeaver][colBeaver]);
                                branchesCount--;
                            }

                            matrix[rowBeaver][colBeaver] = 'B';
                        }
                    }
                }
                else if (command.ToLower() == "left")
                {
                    colBeaver--;

                    if (!IsInMatrix(rowBeaver, colBeaver, size))
                    {
                        colBeaver++;

                        if (collectedBranches.Count > 0)
                        {
                            collectedBranches.RemoveAt(collectedBranches.Count - 1);
                        }
                    }

                    if (matrix[rowBeaver][colBeaver] == 'F')
                    {
                        if (colBeaver == 0)
                        {
                            matrix[rowBeaver][colBeaver] = '-';
                            colBeaver = size - 1;

                            if (char.IsLower(matrix[rowBeaver][colBeaver]))
                            {
                                collectedBranches.Add(matrix[rowBeaver][colBeaver]);
                                branchesCount--;
                            }

                            matrix[rowBeaver][colBeaver] = 'B';
                        }
                        else
                        {
                            matrix[rowBeaver][colBeaver] = '-';
                            colBeaver = 0;

                            if (char.IsLower(matrix[rowBeaver][colBeaver]))
                            {
                                collectedBranches.Add(matrix[rowBeaver][colBeaver]);
                                branchesCount--;
                            }

                            matrix[rowBeaver][colBeaver] = 'B';
                        }
                    }
                }
                else if (command.ToLower() == "right")
                {
                    colBeaver++;

                    if (!IsInMatrix(rowBeaver, colBeaver, size))
                    {
                        colBeaver--;

                        if (collectedBranches.Count > 0)
                        {
                            collectedBranches.RemoveAt(collectedBranches.Count - 1);
                        }
                    }

                    if (matrix[rowBeaver][colBeaver] == 'F')
                    {
                        if (colBeaver == size - 1)
                        {
                            matrix[rowBeaver][colBeaver] = '-';
                            colBeaver = 0;

                            if (char.IsLower(matrix[rowBeaver][colBeaver]))
                            {
                                collectedBranches.Add(matrix[rowBeaver][colBeaver]);
                                branchesCount--;
                            }

                            matrix[rowBeaver][colBeaver] = 'B';
                        }
                        else
                        {
                            matrix[rowBeaver][colBeaver] = '-';
                            colBeaver = size - 1;

                            if (char.IsLower(matrix[rowBeaver][colBeaver]))
                            {
                                collectedBranches.Add(matrix[rowBeaver][colBeaver]);
                                branchesCount--;
                            }

                            matrix[rowBeaver][colBeaver] = 'B';
                        }
                    }

                }

                char currentCell = matrix[rowBeaver][colBeaver];

                if (char.IsLower(currentCell))
                {
                    collectedBranches.Add(currentCell);
                    branchesCount--;
                    matrix[rowBeaver][colBeaver] = 'B';
                }
            }
        }
        static bool IsInMatrix(int row, int col, int length) // square matrix
        {
            return row >= 0 && row < length && col >= 0 && col < length;
        }
    }
}
