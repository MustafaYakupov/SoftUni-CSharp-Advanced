using System;

namespace p01CharityMarathon
{
    class p01CharityMarathon
    {
        static void Main(string[] args)
        {
            long days = long.Parse(Console.ReadLine());
            long runners = long.Parse(Console.ReadLine());
            long laps = long.Parse(Console.ReadLine());
            long trackLength = long.Parse(Console.ReadLine());
            long trackCapacity = long.Parse(Console.ReadLine());
            double moneyPerKm = double.Parse(Console.ReadLine());

            long participants;

            if (runners > trackCapacity * days)
            {
                participants = trackCapacity * days;
            }
            else
            {
                participants = runners;
            }

            long totalMeters = participants * laps * trackLength;
            long totalKm = totalMeters / 1000;
            double result = totalKm * moneyPerKm;

            Console.WriteLine($"Money raised: {result:F2}");
        }
    }
}
