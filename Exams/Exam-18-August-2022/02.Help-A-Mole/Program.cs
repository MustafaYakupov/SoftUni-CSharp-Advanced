using System;

namespace _02.Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];

            int rowMole = -1;
            int colMole = -1;
            int points = 0;

            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine().ToCharArray();

                matrix[row] = input;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'M')
                    {
                        rowMole = row;
                        colMole = col;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (points >= 25) // END WON
                {
                    Console.WriteLine("Yay! The Mole survived another game!");
                    Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
                    break;
                }

                if (command.ToLower() == "end")  // END LOST
                {
                    Console.WriteLine("Too bad! The Mole lost this battle!");
                    Console.WriteLine($"The Mole lost the game with a total of {points} points.");
                    break;
                }

                matrix[rowMole][colMole] = '-';

                if (command.ToLower() == "up")
                {
                    rowMole--;

                    if (!IsInMatrix(rowMole,colMole,size))
                    {
                        rowMole++;
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }
                }
                else if (command.ToLower() == "down")
                {
                    rowMole++;

                    if (!IsInMatrix(rowMole, colMole, size))
                    {
                        rowMole--;
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }
                }
                else if (command.ToLower() == "left")
                {
                    colMole--;

                    if (!IsInMatrix(rowMole, colMole, size))
                    {
                        colMole++;
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }
                }
                else if (command.ToLower() == "right")
                {
                    colMole++;

                    if (!IsInMatrix(rowMole, colMole, size))
                    {
                        colMole--;
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }
                }

                char currentElement = matrix[rowMole][colMole];

                if (char.IsDigit(currentElement))
                {
                    int currentPoints = int.Parse(currentElement.ToString());
                    points += currentPoints;
                    matrix[rowMole][colMole] = 'M';
                }
                else if (currentElement == '-')
                {
                    matrix[rowMole][colMole] = 'M';
                }
                else if (currentElement == 'S')
                {
                    matrix[rowMole][colMole] = '-';
                    points -= 3;

                    for (int row = 0; row < matrix.Length; row++)
                    {
                        for (int col = 0; col < matrix[row].Length; col++)
                        {
                            if (matrix[row][col] == 'S')
                            {
                                rowMole = row;
                                colMole = col;
                                matrix[row][col] = 'M';
                            }
                        }
                    }
                }
            }


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