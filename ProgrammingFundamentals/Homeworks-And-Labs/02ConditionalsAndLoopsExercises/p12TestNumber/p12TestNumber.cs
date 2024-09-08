using System;

namespace p12TestNumber
{
    class p12TestNumber
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int maxSum = int.Parse(Console.ReadLine());
            double sum = 0;
            double totalSum = 0;
            double count = 0;

            for (int i = n; i >= 1; i--)
            {
                for (int k = 1; k <= m; k++)
                {
                    if (totalSum >= maxSum)
                        break;
                    else
                    {
                        sum = i * k * 3;
                        totalSum += sum;
                    }
                    count++;
                }
                if (totalSum >= maxSum)
                {
                    break;
                }
            }
            if (totalSum < maxSum)
            {
                Console.WriteLine($"{count } combinations");
                Console.WriteLine($"Sum: {totalSum  }");
            }
            else
            {
                Console.WriteLine($"{count} combinations");
                Console.WriteLine($"Sum: {totalSum} >= {maxSum}");
            }
        }
    }
}
