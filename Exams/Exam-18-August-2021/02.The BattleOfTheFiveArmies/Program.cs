using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.The_BattleOfTheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];

            int rowArmy = -1;
            int colArmy = -1;

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine()
                    .ToCharArray();

                matrix[row] = input;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'A')
                    {
                        rowArmy = row;
                        colArmy = col;
                    }
                }
            }

            while (true)
            {
                if (armor <= 0)
                {
                    matrix[rowArmy][colArmy] = 'X';
                    Console.WriteLine($"The army was defeated at {rowArmy};{colArmy}.");

                    foreach (var row in matrix)    // Quick way to print
                    {
                        Console.WriteLine(String.Join("", row));
                    }

                    return;
                }

                string[] tokens = Console.ReadLine().Split(' ').ToArray();
                string direction = tokens[0];
                int rowEnemy = int.Parse(tokens[1]);
                int colEnemy = int.Parse(tokens[2]);

                matrix[rowArmy][colArmy] = '-';
                matrix[rowEnemy][colEnemy] = 'O';

                if (direction == "up")
                {
                    armor--;
                    rowArmy--;
                    

                    if (!IsInMatrix(rowArmy, colArmy, matrix.Length))
                    {
                        rowArmy++;
                    }
                }
                else if (direction == "down")
                {
                    armor--;
                    rowArmy++;

                    if (!IsInMatrix(rowArmy, colArmy, matrix.Length))
                    {
                        rowArmy--;
                    }
                }
                else if (direction == "left")
                {
                    armor--;
                    colArmy--;

                    if (!IsInMatrix(rowArmy, colArmy, matrix.Length))
                    {
                        colArmy++;
                    }
                }
                else if (direction == "right")
                {
                    armor--;
                    colArmy++;

                    if (!IsInMatrix(rowArmy, colArmy, matrix.Length))
                    {
                        colArmy--;
                    }
                }

                char currentCell = matrix[rowArmy][colArmy];

                if (currentCell == 'M')  // Win the war
                {
                    matrix[rowArmy][colArmy] = '-';

                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");

                    foreach (var row in matrix)    // Quick way to print
                    {
                        Console.WriteLine(String.Join("", row));
                    }

                    return;
                }

                if (currentCell == 'O')   // Enemey fight
                {
                    armor -= 2;
                    matrix[rowArmy][colArmy] = '-';
                }

            }
        }

        static bool IsInMatrix(int row, int col, int length) // square matrix
        {
            return row >= 0 && row < length && col >= 0 && col < length;
        }
    }
}
