using System;

namespace p01PokeMon
{
    class p01PokeMon
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int targetDistance = int.Parse(Console.ReadLine());
            int exhaustionFactory = int.Parse(Console.ReadLine());

            int currentPower = pokePower;
            var count = 0;
            

            while (currentPower >= targetDistance)
            {
                currentPower -= targetDistance;
                count++;
                if (currentPower == pokePower / 2 && currentPower % 2 == 0 && exhaustionFactory != 0)
                {
                    currentPower /= exhaustionFactory;
                }
            }
            Console.WriteLine(currentPower);
            Console.WriteLine(count);
        }
    }
}
