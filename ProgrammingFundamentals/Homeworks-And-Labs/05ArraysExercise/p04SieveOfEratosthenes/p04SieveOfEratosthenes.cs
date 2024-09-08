using System;
using System.Linq;

namespace p04SieveOfEratosthenes
{
    class p04SieveOfEratosthenes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool[] primes = new bool[n + 1];

            for (int i = 0; i < primes.Length; i++)
            {
                primes[i] = true;
            }
            primes[0] = primes[1] = false;

            for (int i = 0; i <= n; i++)
            {
                if (!primes[i])
                {
                    continue;
                }
                Console.Write(i + " ");

                for (int p = 2 * i; p <= n; p+= i)
                {
                    primes[p] = false;
                }
            }
            Console.WriteLine();
        }
    }
}
