using System;
using System.Collections.Generic;
using System.Linq;

namespace p03EnduranceRally
{
    class p03EnduranceRally
    {
        static void Main(string[] args)
        {
            string[] drivers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            double[] track = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            int[] checkpoints = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            
            foreach (var driver in drivers)
            {
                double fuel = (int)driver[0];
               
                for (int i = 0; i < track.Length; i++)
                {
                    var currentZoneFuel = track[i];

                    if (checkpoints.Contains(i))
                    {
                        fuel += currentZoneFuel;
                    }
                    else
                    {
                        fuel -= currentZoneFuel;
                    }

                    if (fuel <= 0)
                    {
                        Console.WriteLine($"{driver} - reached {i}");
                        break;
                    }
                }
                if (fuel > 0 )
                {
                    Console.WriteLine($"{driver} - fuel left {fuel:f2}");
                }
            }
           
        }
    }
}
