using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.TheSquirrel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] moves = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            int squirrelRow = -1;
            int squirrelCol = -1;

            int totalHAzelnuts = 0;
            int collectedHazelnuts = 0;

            char[][] matrix = new char[size][];

            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine()
                    .ToArray();

                matrix[row] = input;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 's')
                    {
                        squirrelRow = row;
                        squirrelCol = col;
                    }

                    if (matrix[row][col] == 'h')
                    {
                        totalHAzelnuts++;
                    }
                }
            }

            foreach (var direction in moves) // Check if the squirrel leaves the field
            {
                if ((direction == "left" && squirrelCol == 0) ||
                    (direction == "right" && squirrelCol == size - 1) ||
                    (direction == "up" && squirrelRow == 0) ||
                    (direction == "down" && squirrelRow == size - 1))
                {
                    // Game ends
                    Console.WriteLine("The squirrel is out of the field.");
                    Console.WriteLine($"Hazelnuts collected: {collectedHazelnuts}");
                    return;
                }

                switch (direction)
                {
                    case "left":
                        squirrelCol--;
                        break;
                    case "right":
                        squirrelCol++;
                        break;
                    case "up":
                        squirrelRow--;
                        break;
                    case "down":
                        squirrelRow++;
                        break;
                }
               
                if (matrix[squirrelRow][squirrelCol] == 'h')
                {
                    matrix[squirrelRow][squirrelCol] = '*';
                    collectedHazelnuts++;
                    totalHAzelnuts--;

                    if (totalHAzelnuts == 0)
                    {
                        // game ends
                        Console.WriteLine("Good job! You have collected all hazelnuts!");
                        Console.WriteLine($"Hazelnuts collected: {collectedHazelnuts}");
                        return;
                    }
                }
                else if (matrix[squirrelRow][squirrelCol] == 't')
                {
                    // game ends
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    Console.WriteLine($"Hazelnuts collected: {collectedHazelnuts}");
                    return;
                }
            }

            Console.WriteLine("There are more hazelnuts to collect.");
            Console.WriteLine($"Hazelnuts collected: {collectedHazelnuts}");
        }
    }
}
