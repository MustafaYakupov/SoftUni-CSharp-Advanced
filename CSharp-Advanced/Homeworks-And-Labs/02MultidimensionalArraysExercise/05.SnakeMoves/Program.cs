int[] matrixSizes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

int rows = matrixSizes[0];
int cols = matrixSizes[1];
int counter = cols - 1;

string snake = Console.ReadLine();

char[][] matrix = new char[rows][];
Stack<char> snakeStack = new Stack<char>(snake.Reverse());

for (int row = 0; row <= rows - 1; row++)
{
    matrix[row] = new char[cols];

    if (row % 2 == 0)
    {
        for (int col = 0; col <= cols - 1; col++)
        {
            if (snakeStack.Count == 0)
            {
                snakeStack = new Stack<char>(snake.Reverse());
            }

            matrix[row][col] = snakeStack.Pop();
        }
    }
    else
    {
        for (int col = matrix[row].Length - 1; col >= 0 ; col--)
        {
            if (snakeStack.Count == 0)
            {
                snakeStack = new Stack<char>(snake.Reverse());
            }

            matrix[row][counter] = snakeStack.Pop();
            counter--;
        }

        counter = cols - 1;
    }
}

foreach (var row in matrix)    // Quick way to print
{
    Console.WriteLine(String.Join("", row));
}


