using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace p04WinningTicket
{
    class p04WinningTicket
    {
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
                var left = new string(ticket.Take(10).ToArray());
                var right = new string(ticket.Skip(10).ToArray());

                var winningSymbols = new string[] { "@", "\\$", "#", "\\^" };
                var winningTicket = false;

                foreach (var winningSymbol in winningSymbols)
                {
                    var regex = new Regex($@"{winningSymbols}{{6,}}");
                    var leftMatch = regex.Match(left);

                    if (leftMatch.Success)
                    {
                        var rightMatch = regex.Match(right);
                        if (rightMatch.Success)
                        {
                            winningTicket = true;

                            var leftSymbolsLength = leftMatch.Value.Length;
                            var rightSymbolsLength = rightMatch.Value.Length;
                            var jackpot = leftSymbolsLength == 10 && rightSymbolsLength == 10
                                ? " Jackpot!"    //Ако е 10 отпечатва " Jackpot!"
                                : string.Empty;  //Ако не е, празен стринг

                            Console.WriteLine($"ticket \"{ticket}\" - {Math.Min(leftSymbolsLength, rightSymbolsLength)}{winningSymbol}{jackpot}");

                            break;
                        }
                    }
                }
                if (winningTicket == false)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
        }
    }
}
