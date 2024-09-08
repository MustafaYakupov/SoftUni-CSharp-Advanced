using System;
using System.Linq;
using System.Numerics;

namespace p01SinoTheWalker
{
    class p01SinoTheWalker
    {
        static void Main(string[] args)
        {
            string[] leavingTime = Console.ReadLine().Split(':').ToArray();
            BigInteger steps = BigInteger.Parse(Console.ReadLine());
            BigInteger secondsPerStep = BigInteger.Parse(Console.ReadLine());

            BigInteger timeWalking = steps * secondsPerStep;
            BigInteger leavingHour = BigInteger.Parse(leavingTime[0])*3600;
            BigInteger leavingMinutes = BigInteger.Parse(leavingTime[1])*60;
            BigInteger leavingSeconds = BigInteger.Parse(leavingTime[2]);
            BigInteger arrivingSeconds = leavingSeconds + timeWalking;

            BigInteger totalTimeInSeconds = leavingHour + leavingMinutes + arrivingSeconds;

            BigInteger arriveHour = (totalTimeInSeconds / 3600) % 24;
            BigInteger arriveMinute = (totalTimeInSeconds / 60) % 60;
            BigInteger arriveSecond = totalTimeInSeconds % 60;


            Console.WriteLine($"Time Arrival: {arriveHour:00}:{arriveMinute:00}:{arriveSecond:00}");
        }
    }
}
