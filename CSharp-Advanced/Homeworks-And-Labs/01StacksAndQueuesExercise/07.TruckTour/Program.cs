using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fuelPumpsCount = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();

            for (int i = 0; i < fuelPumpsCount; i++)
            {
                int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

                int petrol = input[0];
                int distance = input[1];

                pumps.Enqueue(input);
            }

            int bestRoute = 0;

            while (true)
            {
                int totalPetrol =  0;

                foreach (var pump in pumps)
                {
                    totalPetrol += pump[0];
                    int currentDistance = pump[1];

                    if (totalPetrol - currentDistance < 0)
                    {
                        totalPetrol = 0;
                        break;
                    }
                    else
                    {
                        totalPetrol -= currentDistance;
                    }
                }

                if (totalPetrol > 0)
                {
                    break;
                }

                bestRoute++;
                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(bestRoute);
        }
    }
}
