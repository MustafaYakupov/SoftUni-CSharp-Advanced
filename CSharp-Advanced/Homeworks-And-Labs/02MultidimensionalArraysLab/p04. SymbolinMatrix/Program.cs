using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p04.SymbolinMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            char[,] matrix = new char[dimensions, dimensions];

            int[] positions = new int[2];

            bool valid = false;

            for (int row = 0; row < dimensions; row++)
            {
                char[] symbols = Console.ReadLine()
                .ToArray();

                for (int col = 0; col < dimensions; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            string symbolToMatch = Console.ReadLine();

            for (int row = 0; row < dimensions; row++)
            {

                for (int col = 0; col < dimensions; col++)
                {
                    if (matrix[row, col].ToString() == symbolToMatch)
                    {
                        if (valid == false)
                        {
                            positions[0] = row;
                            positions[1] = col;
                            valid = true;
                        }
                    }
                }
            }

            if (valid == true)
            {
                Console.WriteLine($"({positions[0]}, {positions[1]})");
            }
            else
            {
                Console.WriteLine($"{symbolToMatch} does not occur in the matrix");
            }
        }
    }
}
