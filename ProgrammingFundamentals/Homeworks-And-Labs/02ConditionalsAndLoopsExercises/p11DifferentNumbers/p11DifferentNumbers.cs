using System;

namespace p11DifferentNumbers
{
    class p11DifferentNumbers
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            for (int i = a; i <=b; i++)
            {
                for (int j = a; j <= b; j++)
                {
                    for (int k = a; k <= b; k++)
                    {
                        for (int l = a; l <= b; l++)
                        {
                            for (int m = a; m <= b; m++)
                            {
                                if (a<=i &&i< j && j < k && k < l && l < m && m <= b)
                                {
                                    Console.Write($"{i} {j} {k} {l} {m}");
                                    Console.WriteLine();
                                }
                                if (b - a < 5)
                                {
                                    Console.WriteLine("No");
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
