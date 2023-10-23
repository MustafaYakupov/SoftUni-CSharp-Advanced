namespace _02.NavyBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int rowSubmarine = -1;
            int colSubmarine = -1;
            int battleCruisers = 3;
            int hitByMineCounter = 0;

            char[][] matrix = new char[size][];

            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine()
                    .ToCharArray();

                matrix[row] = input;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        rowSubmarine = row;
                        colSubmarine = col;
                    }
                }
            }

            while (true)
            {
                string move = Console.ReadLine();

                matrix[rowSubmarine][colSubmarine] = '-';

                switch (move)
                {
                    case "up":
                        rowSubmarine--;
                        break;
                    case "down":
                        rowSubmarine++;
                        break;
                    case "left":
                        colSubmarine--;
                        break;
                    case "right":
                        colSubmarine++;
                        break;
                }

                char currentPosition = matrix[rowSubmarine][colSubmarine];

                if (currentPosition == 'C')
                {
                    matrix[rowSubmarine][colSubmarine] = '-';
                    battleCruisers--;

                    if (battleCruisers == 0)
                    {
                        matrix[rowSubmarine][colSubmarine] = 'S';
                        Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                        break;
                    }
                }
                else if (currentPosition == '*')
                {
                    matrix[rowSubmarine][colSubmarine] = '-';
                    hitByMineCounter++;

                    if (hitByMineCounter == 3) // Game over
                    {
                        matrix[rowSubmarine][colSubmarine] = 'S';
                        Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{rowSubmarine}, {colSubmarine}]!");
                        break;
                    }
                }
            }


            foreach (var row in matrix)    // Quick way to print
            {
                Console.WriteLine(String.Join("", row));
            }
        }
    }
}