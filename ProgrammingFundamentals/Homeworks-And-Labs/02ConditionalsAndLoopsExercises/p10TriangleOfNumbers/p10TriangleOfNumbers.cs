﻿using System;

namespace p10TriangleOfNumbers
{
    class p10TriangleOfNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int k = 1; k <= i; k++)
                {
                    
                    Console.Write(i+ " ");
                }
                Console.WriteLine();
            }
        }
    }
}
