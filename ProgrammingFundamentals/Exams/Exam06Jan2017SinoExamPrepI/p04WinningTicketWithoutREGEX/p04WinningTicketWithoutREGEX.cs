using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace p04WinningTicketWithoutREGEX
{
    class p04WinningTicketWithoutREGEX
    {
        public class Result
        {
            public int Count { get; set; }

            public char Symbol { get; set; }
        }

        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();


            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }
                var left = ticket.Take(10).ToArray();
                var right =ticket.Skip(10).ToArray();

                var winningTicket = false;

                var leftResult = FindRepeatingSymbols(left);
                if (leftResult.Symbol == '@'
                    || leftResult.Symbol == '#'
                    || leftResult.Symbol == '$'
                    || leftResult.Symbol == '^'
                    && leftResult.Count >= 6)
                {
                    var rightResult = FindRepeatingSymbols(right);
                    if (leftResult.Symbol == rightResult.Symbol
                        && rightResult.Count >= 6)
                    {
                        var jackpot = leftResult.Count == 10 && rightResult.Count == 10
                            ? " Jackpot!"
                            : string.Empty;

                        Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(leftResult.Count, rightResult.Count)}{leftResult.Symbol}{jackpot}");

                        winningTicket = true;
                    }
                   
                }
                if (winningTicket == false)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
        }
        public static Result FindRepeatingSymbols(char[] symbols)
        {
            var previousSymbol = symbols.First();
            int count = 1;
            int maxCount = 0;
            var maxSymbol = default(char);

            for (int i = 1; i < symbols.Length; i++)
            {
                var currentSymbol = symbols[i];

                if (previousSymbol == currentSymbol)
                {
                    count++;
                }
                else
                {
                    if (count > maxCount)
                    {
                        maxCount = count;
                        maxSymbol = previousSymbol;
                    }
                    count = 1;
                }

                if (count > maxCount)
                {
                    maxCount = count;
                    maxSymbol = previousSymbol;
                }
                previousSymbol = currentSymbol;
            }
            return new Result
            {
                Count = maxCount,
                Symbol = maxSymbol
            };
        }
    }
}
