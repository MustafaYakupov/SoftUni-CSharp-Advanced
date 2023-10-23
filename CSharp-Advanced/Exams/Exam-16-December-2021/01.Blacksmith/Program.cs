using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] steelInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] carbonInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> queueOfSteel = new Queue<int>(steelInput);
            Stack<int> stackOfCarbon = new Stack<int>(carbonInput);
            Dictionary<string, int> forgedSwords = new Dictionary<string, int>();

            while (queueOfSteel.Any() && stackOfCarbon.Any())
            {
                int steel = queueOfSteel.Dequeue();
                int carbon = stackOfCarbon.Pop();
                int sum = steel + carbon;

                if (sum == 70)
                {
                    if (!forgedSwords.ContainsKey("Gladius"))
                    {
                        forgedSwords["Gladius"] = 0;
                    }

                    forgedSwords["Gladius"]++;
                }
                else if (sum == 80)
                {
                    if (!forgedSwords.ContainsKey("Shamshir"))
                    {
                        forgedSwords["Shamshir"] = 0;
                    }

                    forgedSwords["Shamshir"]++;
                }
                else if (sum == 90)
                {
                    if (!forgedSwords.ContainsKey("Katana"))
                    {
                        forgedSwords["Katana"] = 0;
                    }

                    forgedSwords["Katana"]++;
                }
                else if (sum == 110)
                {
                    if (!forgedSwords.ContainsKey("Sabre"))
                    {
                        forgedSwords["Sabre"] = 0;
                    }

                    forgedSwords["Sabre"]++;
                }
                else if (sum == 150)
                {
                    if (!forgedSwords.ContainsKey("Broadsword"))
                    {
                        forgedSwords["Broadsword"] = 0;
                    }

                    forgedSwords["Broadsword"]++;
                }
                else
                {
                    carbon += 5;
                    stackOfCarbon.Push(carbon);
                }
            }

            if (forgedSwords.Count > 0)
            {
                Console.WriteLine($"You have forged {forgedSwords.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (queueOfSteel.Any())
            {
                Console.WriteLine($"Steel left: {string.Join(", ", queueOfSteel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (stackOfCarbon.Any())
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", stackOfCarbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            if (forgedSwords.Any())
            {
                foreach (var sword in forgedSwords.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}
