
namespace _01.TilesMaster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] whiteTiles = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] greyTiles = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Dictionary<string, int> usedTilesLocationAndCount = new Dictionary<string, int>();
            Stack<int> stackWhite = new Stack<int>(whiteTiles);
            Queue<int> queueGrey = new Queue<int>(greyTiles);

            while (stackWhite.Any() && queueGrey.Any())
            {
                int whiteTile = stackWhite.Pop();
                int greyTile = queueGrey.Dequeue();

                if (whiteTile == greyTile)
                {
                    int largerTileToUse = whiteTile + greyTile;

                    if (largerTileToUse == 40)
                    {
                        if (!usedTilesLocationAndCount.ContainsKey("Sink"))
                        {
                            usedTilesLocationAndCount.Add("Sink", 0);
                        }

                        usedTilesLocationAndCount["Sink"]++;
                    }
                    else if (largerTileToUse == 50)
                    {
                        if (!usedTilesLocationAndCount.ContainsKey("Oven"))
                        {
                            usedTilesLocationAndCount.Add("Oven", 0);
                        }

                        usedTilesLocationAndCount["Oven"]++;
                    }
                    else if (largerTileToUse == 60)
                    {
                        if (!usedTilesLocationAndCount.ContainsKey("Countertop"))
                        {
                            usedTilesLocationAndCount.Add("Countertop", 0);
                        }

                        usedTilesLocationAndCount["Countertop"]++;
                    }
                    else if (largerTileToUse == 70)
                    {
                        if (!usedTilesLocationAndCount.ContainsKey("Wall"))
                        {
                            usedTilesLocationAndCount.Add("Wall", 0);
                        }

                        usedTilesLocationAndCount["Wall"]++;
                    }
                    else
                    {
                        if (!usedTilesLocationAndCount.ContainsKey("Floor"))
                        {
                            usedTilesLocationAndCount.Add("Floor", 0);
                        }

                        usedTilesLocationAndCount["Floor"]++;
                    }
                }
                else
                {
                    stackWhite.Push(whiteTile / 2);
                    queueGrey.Enqueue(greyTile);
                }
            }

            if (!stackWhite.Any())
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", stackWhite)}");
            }

            if (!queueGrey.Any())
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", queueGrey)}");
            }

            foreach (var pair in usedTilesLocationAndCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}
