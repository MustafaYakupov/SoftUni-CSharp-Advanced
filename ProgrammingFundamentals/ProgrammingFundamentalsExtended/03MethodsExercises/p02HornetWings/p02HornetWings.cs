using System;

namespace p02HornetWings
{
    class p02HornetWings
    {
        static void Main(string[] args)
        {
            int wingFlaps = int.Parse(Console.ReadLine());
            double distancePer1000Flaps = double.Parse(Console.ReadLine());
            int flapsUntilBreak = int.Parse(Console.ReadLine());
            
            double totalTime = GetTime(wingFlaps, flapsUntilBreak);
            double distance = GetDistance(wingFlaps, distancePer1000Flaps);
            
            Console.WriteLine($"{distance:f2} m.");
            Console.WriteLine($"{totalTime} s.");
        }

        static double GetTime(int wingFlaps, int flapsUntilBreak)
        {
            double time = wingFlaps / 100;
            double rest = (wingFlaps / flapsUntilBreak) * 5;
            double totalTime = time + rest;
            return totalTime;
        }

        static double GetDistance(int flaps, double distance)
        {
            double result = (flaps / 1000) * distance;
            return result;
        }
    }
}
