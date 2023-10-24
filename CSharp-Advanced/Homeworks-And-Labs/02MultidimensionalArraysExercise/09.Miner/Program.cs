int size = int.Parse(Console.ReadLine());

string[] commands = Console.ReadLine()
    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
    .ToArray();

char[][] matrix = new char[size][];

int startRow = -1;
int startCol = -1;
int existingCoals = 0;

for (int row = 0; row < size; row++)
{
    char[] input = Console.ReadLine()
        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();

    matrix[row] = input;

    for (int col = 0; col < size; col++)
    {
        if (matrix[row][col] == 's')
        {
            startRow = row;
            startCol = col;
        }

        if (matrix[row][col] == 'c')
        {
            existingCoals++;
        }
    }
}

foreach (var command in commands)
{
    if (command.ToLower() == "left")
    {
        if (IsInMatrix(startRow, startCol - 1, size))
        {
            startCol = startCol - 1;

            char currentElement = matrix[startRow][startCol];

            if (currentElement == 'e')
            {
                Console.WriteLine($"Game over! ({startRow}, {startCol})");
                return;
            }
            else if (currentElement == 'c')
            {
                matrix[startRow][startCol] = '*';
                existingCoals--;

                if (existingCoals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                    return;
                }
            }
        }
    }
    else if (command.ToLower() == "right")
    {
        if (IsInMatrix(startRow, startCol + 1, size))
        {
            startCol = startCol + 1;

            char currentElement = matrix[startRow][startCol];

            if (currentElement == 'e')
            {
                Console.WriteLine($"Game over! ({startRow}, {startCol})");
                return;
            }
            else if (currentElement == 'c')
            {
                matrix[startRow][startCol] = '*';
                existingCoals--;

                if (existingCoals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                    return;
                }
            }
        }
    }
    else if (command.ToLower() == "up")
    {
        if (IsInMatrix(startRow - 1, startCol, size))
        {
            startRow = startRow - 1;

            char currentElement = matrix[startRow][startCol];

            if (currentElement == 'e')
            {
                Console.WriteLine($"Game over! ({startRow}, {startCol})");
                return;
            }
            else if (currentElement == 'c')
            {
                matrix[startRow][startCol] = '*';
                existingCoals--;

                if (existingCoals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                    return;
                }
            }
        }
    }
    else if (command.ToLower() == "down")
    {
        if (IsInMatrix(startRow + 1, startCol, size))
        {
            startRow = startRow + 1;

            char currentElement = matrix[startRow][startCol];

            if (currentElement == 'e')
            {
                Console.WriteLine($"Game over! ({startRow}, {startCol})");
                return;
            }
            else if (currentElement == 'c')
            {
                matrix[startRow][startCol] = '*';
                existingCoals--;

                if (existingCoals == 0)
                {
                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                    return;
                }
            }
        }
    }
}

Console.WriteLine($"{existingCoals} coals left. ({startRow}, {startCol})");

// foreach (var row in matrix)    // Quick way to print
// {
//     Console.WriteLine(String.Join(" ", row));
// }

// static void StepOnValdaiton(char currentElement, int startRow, int startCol, int existingCoals,  char[][] matrix)
// {
//     if (currentElement == 'e')
//     {
//         Console.WriteLine($"Game over! ({startRow}, {startCol})");
//         return;
//     }
//     else if (currentElement == 'c')
//     {
//         matrix[startRow][startCol] = '*';
//         existingCoals--;
// 
//         if (existingCoals == 0)
//         {
//             Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
//             return;
//         }
//     }
// }

static bool IsInMatrix(int row, int col, int length)
{
    return row >= 0 && row < length && col >= 0 && col < length;
}