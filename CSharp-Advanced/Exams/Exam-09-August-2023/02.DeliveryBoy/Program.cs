namespace _02.DeliveryBoy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];
            int rowDelivery = -1;
            int colDelivery = -1;
            int startRow = -1;
            int startCol = -1;

            char[][] matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                matrix[row] = input;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        rowDelivery = row;
                        colDelivery = col;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        rowDelivery--;
                        if (IsInMatrix(rowDelivery, colDelivery, matrix) == false)
                        {
                            Console.WriteLine("The delivery is late. Order is canceled.");

                            matrix[startRow][startCol] = ' ';

                            PrinMatrix(matrix);
                            return;
                        }

                        if (matrix[rowDelivery][colDelivery] == '*')
                        {
                            rowDelivery++;
                        }
                        break;
                    case "down":
                        rowDelivery++;
                        if (IsInMatrix(rowDelivery, colDelivery, matrix) == false)
                        {
                            Console.WriteLine("The delivery is late. Order is canceled.");

                            matrix[startRow][startCol] = ' ';

                            PrinMatrix(matrix);
                            return;
                        }

                        if (matrix[rowDelivery][colDelivery] == '*')
                        {
                            rowDelivery--;
                        }
                        break;
                    case "left":
                        colDelivery--;
                        if (IsInMatrix(rowDelivery, colDelivery, matrix) == false)
                        {
                            Console.WriteLine("The delivery is late. Order is canceled.");

                            matrix[startRow][startCol] = ' ';

                            PrinMatrix(matrix);
                            return;
                        }

                        if (matrix[rowDelivery][colDelivery] == '*')
                        {
                            colDelivery++;
                        }
                        break;
                    case "right":
                        colDelivery++;
                        if (IsInMatrix(rowDelivery, colDelivery, matrix) == false)
                        {
                            Console.WriteLine("The delivery is late. Order is canceled.");

                            matrix[startRow][startCol] = ' ';

                            PrinMatrix(matrix);
                            return;
                        }

                        if (matrix[rowDelivery][colDelivery] == '*')
                        {
                            colDelivery--;
                        }
                        break;
                }

                char currentPosition = matrix[rowDelivery][colDelivery];

                if (currentPosition == '-' || currentPosition == '.')
                {
                    matrix[rowDelivery][colDelivery] = '.';
                }
                else if (currentPosition == 'P')
                {
                    matrix[rowDelivery][colDelivery] = 'R';
                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                }
                else if (currentPosition == '*')
                {
                    continue;
                }
                else if (currentPosition == 'A')
                {
                    matrix[rowDelivery][colDelivery] = 'P';
                    matrix[startRow][startRow] = 'B';
                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    PrinMatrix(matrix);
                    break;
                }
            }
        }

        static bool IsInMatrix(int row, int col, char[][] matrix) // rectangular matrix
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        static void PrinMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}