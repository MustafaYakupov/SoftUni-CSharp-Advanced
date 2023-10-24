using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];

            for (int row = 0; row <= matrix.Length - 1; row++)
            {
                int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                matrix[row] = input;
            }

            for (int row = 0; row <= matrix.Length - 2; row++) 
            {
             
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col <= matrix[row].Length - 1; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col <= matrix[row].Length - 1; col++)
                    {
                        matrix[row][col] /= 2;
                    }

                    for (int i = 0; i <= matrix[row + 1].Length - 1; i++)
                    {
                        matrix[row + 1][i] /= 2;
                    }
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "end")
                {
                    break;
                }

                string[] commands = input.Split(' ');

                var action = commands[0];
                var rowToModify = int.Parse(commands[1]);
                var colToModify = int.Parse(commands[2]);
                var value = int.Parse(commands[3]);

                if (rowToModify >= 0 
                    && rowToModify < matrix.Length
                    && colToModify >= 0 
                    && colToModify < matrix[rowToModify].Length)
                {
                    if (action.ToLower() == "add")
                    {
                        matrix[rowToModify][colToModify] += value;
                    }
                    else if (action.ToLower() == "subtract")
                    {
                        matrix[rowToModify][colToModify] -= value;
                    }
                }

            }

            foreach (var row in matrix)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }
    }
}
