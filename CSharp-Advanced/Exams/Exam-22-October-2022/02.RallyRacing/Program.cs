using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();

            int carRow = 0;
            int carCol = 0;

            int kilometers = 0;

            char[][] matrix = new char[size][];

            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                matrix[row] = input;
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command.ToLower() == "end")
                {
                    matrix[carRow][carCol] = 'C';
                    Console.WriteLine($"Racing car {racingNumber} DNF.");
                    break;
                }

                switch (command)
                {
                    case "left":
                        carCol--;
                        break;
                    case "right":
                        carCol++;
                        break;
                    case "up":
                        carRow--;
                        break;
                    case "down":
                        carRow++;
                        break;
                }

                char stepOnElement = matrix[carRow][carCol];

                if (stepOnElement == '.')
                {
                    kilometers += 10;
                }
                else if (stepOnElement == 'T')
                {
                    kilometers += 30;
                    matrix[carRow][carCol] = '.';

                    for (int row = 0; row < matrix.Length; row++)
                    {
                        for (int col = 0; col < matrix[row].Length; col++)
                        {
                            if (matrix[row][col] == 'T')
                            {
                                matrix[row][col] = '.';
                                carRow = row;
                                carCol = col;
                            }
                        }
                    }
                }
                else if (stepOnElement == 'F')
                {
                    kilometers += 10;
                    matrix[carRow][carCol] = 'C';
                    Console.WriteLine($"Racing car {racingNumber} finished the stage!");
                    break;
                }
            }

            Console.WriteLine($"Distance covered {kilometers} km.");

            foreach (var row in matrix)    // Quick way to print
            {
                Console.WriteLine(String.Join("", row));
            }
        }
    }
}
