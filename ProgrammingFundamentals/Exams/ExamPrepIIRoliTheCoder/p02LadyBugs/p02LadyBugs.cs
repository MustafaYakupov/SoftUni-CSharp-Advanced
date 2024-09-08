using System;
using System.Collections.Generic;
using System.Linq;

namespace p02LadyBugs
{
    class p02LadyBugs
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var field = new int[size];
            var ladybugIndexes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(i => i >= 0 && i < size)
                .ToList();

            foreach (var index in ladybugIndexes)
            {
                field[index] = 1;
            }
           
            while (true)
            {
                var line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                var commandParts = line.Split(' ');

                var currentLadybugIndex = int.Parse(commandParts[0]);
                var direction = commandParts[1];
                var flyLength = int.Parse(commandParts[2]);

                if (direction == "left")
                {
                    flyLength *= -1;
                }

                if (currentLadybugIndex < 0 || currentLadybugIndex >= size)
                {
                    continue;
                }

                if (field[currentLadybugIndex] == 0)
                {
                    continue;
                }

                field[currentLadybugIndex] = 0;

                var nextIndexToLand = currentLadybugIndex;

                while (true)
                {
                    nextIndexToLand += flyLength;

                    if (nextIndexToLand < 0 || nextIndexToLand >= size)
                    {
                        break;  
                    }

                    if (field[nextIndexToLand] == 1)
                    {
                        continue;
                    }

                    field[nextIndexToLand] = 1;
                    break;
                }
            }
            Console.WriteLine(string.Join(" ", field));
        }
    }
}
