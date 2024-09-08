using System;
using System.Collections.Generic;
using System.Linq;

namespace p04HornetAssault
{
    class p04HornetAssault
    {
        static void Main(string[] args)
        {
            var beehies = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var hornets = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<int> beehiesLeft = new List<int>();
            int hornetsPower = hornets.Sum();

            for (int i = 0; i < beehies.Count; i++)
            {
                if (beehies[i] >= hornetsPower)
                {
                    if (beehies[i] - hornetsPower > 0)
                    {
                        beehiesLeft.Add(beehies[i] - hornetsPower);
                    }
                    hornetsPower -= hornets[0];
                    hornets.RemoveAt(0);
                }
            }

            if (beehiesLeft.Count > 0)
            {
                Console.WriteLine(string.Join(" ", beehiesLeft));
            }
            else
            {
                Console.WriteLine(string.Join(" ", hornets));
            }
        }
    }
}
