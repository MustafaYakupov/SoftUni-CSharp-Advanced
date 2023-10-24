int[] matrixSizes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

int rows = matrixSizes[0];
int cols = matrixSizes[1];

int[][] matrix = new int[rows][];

for (int row = 0; row < rows; row++)
{
    int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

    matrix[row] = input;
}

while (true)
{
    string[] command = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

    if (command[0].ToLower() == "end")
    {
        break;
    }

    if (command[0].ToLower() != "swap" 
        || command.Length != 5 
        || int.Parse(command[1]) < 0 
        || int.Parse(command[2]) < 0
        || int.Parse(command[1]) > matrix.Length - 1
        || int.Parse(command[2]) > matrix.Length - 1
        )
    {
        Console.WriteLine("Invalid input!");
        continue;
    }
    else
    {
        int row1 = int.Parse(command[1]);
        int col1 = int.Parse(command[2]);
        int row2 = int.Parse(command[3]);
        int col2 = int.Parse(command[4]);

        var valueOne = matrix[row1][col1];
        var valueTwo = matrix[row2][col2];

        matrix[row1][col1] = valueTwo;
        matrix[row2][col2] = valueOne;

        foreach (var row in matrix)    // Quick way to print
        {
            Console.WriteLine(String.Join(" ", row));
        }
    }
}