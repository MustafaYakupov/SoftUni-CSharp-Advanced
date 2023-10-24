using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p06.Jagged_AarrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] arr = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                arr[row] = input;
            }

            while (true)
            {
                var command = Console.ReadLine();

                if (command.ToLower() == "end")
                {
                    break;
                }

                var commandParts = command.Split();

                var function = commandParts[0];
                var rowToChange = int.Parse(commandParts[1]);
                var colToChange = int.Parse(commandParts[2]);
                var value = int.Parse(commandParts[3]);

                if (rowToChange < 0
                    || rowToChange >= arr.Length
                    || colToChange < 0 
                    || colToChange >= arr[rowToChange].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (function == "Add")
                    {
                        arr[rowToChange][colToChange] += value; 
                    }
                    else if (function == "Subtract")
                    {
                        arr[rowToChange][colToChange] -= value;

                    }
                }

                
                    
                
            }

            foreach (var row in arr)
            {
                Console.WriteLine(String.Join(" ", row));
            }
            
        }
    }
}
