using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bulltesSizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] locksSizes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int intelligence = int.Parse(Console.ReadLine());

            Stack<int> bulletsStack = new Stack<int>(bulltesSizes);
            Queue<int> locksQueue = new Queue<int>(locksSizes);

            int bulletsInBarrel = barrelSize;
            int bulletsCost = 0;

            while (true)
            {
                if (bulletsStack.Peek() <= locksQueue.Peek())
                {
                    Console.WriteLine("Bang!");
                    bulletsStack.Pop();
                    bulletsCost += bulletPrice;
                    locksQueue.Dequeue();
                    bulletsInBarrel--;

                    if (bulletsInBarrel == 0 && bulletsStack.Any())
                    {
                        bulletsInBarrel = barrelSize;
                        Console.WriteLine("Reloading!");
                    }

                    if (locksQueue.Count == 0)
                    {
                        Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${intelligence - bulletsCost}");
                        return;
                    }

                    if (bulletsStack.Count == 0)
                    {
                        Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
                        return;
                    }

                    

                }
                else
                {
                    Console.WriteLine("Ping!");
                    bulletsStack.Pop();
                    bulletsCost += bulletPrice;
                    bulletsInBarrel--;

                    if (bulletsInBarrel == 0 && bulletsStack.Any())
                    {
                        bulletsInBarrel = barrelSize;
                        Console.WriteLine("Reloading!");
                    }

                    if (bulletsStack.Count == 0)
                    {
                        Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
                        return;
                    }
                }
            }
        }
    }
}
