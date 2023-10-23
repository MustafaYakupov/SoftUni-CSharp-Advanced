using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[][] matrix = new char[size][];

            int rowOfficer = -1;
            int colOfficer = -1;
            int boughtSwords = 0;

            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine()
                    .ToCharArray();

                matrix[row] = input;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'A')
                    {
                        rowOfficer = row;
                        colOfficer = col;
                    }
                }
            }

            while (true)
            {
                if (boughtSwords >= 65) // Collected more tha 65 coins swords, game ends
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    Console.WriteLine($"The king paid {boughtSwords} gold coins.");
                    matrix[rowOfficer][colOfficer] = 'A';

                    foreach (var row in matrix)    // Quick way to print
                    {
                        Console.WriteLine(String.Join("", row));
                    }

                    return;
                }

                string command = Console.ReadLine();

                matrix[rowOfficer][colOfficer] = '-';

                if (command == "up")
                {
                    rowOfficer--;
                }
                else if (command == "down")
                {
                    rowOfficer++;
                }
                else if (command == "left")
                {
                    colOfficer--;
                }
                else if (command == "right")
                {
                    colOfficer++;
                }

                if (!IsInMatrix(rowOfficer, colOfficer, size)) // Leaves the field. Game ends
                {
                    Console.WriteLine("I do not need more swords!");
                    Console.WriteLine($"The king paid {boughtSwords} gold coins.");
                    
                    foreach (var row in matrix)    // Quick way to print
                    {
                        Console.WriteLine(String.Join("", row));
                    }

                    return;
                }

                char currentCell = matrix[rowOfficer][colOfficer];

                if (char.IsDigit(currentCell))
                {
                    boughtSwords += int.Parse(currentCell.ToString());
                }
                else if (currentCell == 'M')
                {
                    matrix[rowOfficer][colOfficer] = '-';

                    for (int row = 0; row < size; row++)
                    {
                        for (int col = 0; col < size; col++)
                        {
                            if (matrix[row][col] == 'M')
                            {
                                matrix[row][col] = '-';
                                rowOfficer = row;
                                colOfficer = col;
                            }
                        }
                    }
                }
            }
        }

        static bool IsInMatrix(int row, int col, int length) // square matrix
        {
            return row >= 0 && row < length && col >= 0 && col < length;
        }
    }
}
