﻿using System;

namespace p03PrintingTriangle
{
    class p03PrintingTriangle
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                PrintLine(1, i);
            }
            PrintLine(1, n);
            for (int i = n - 1; i >= 0; i--)
            {
                PrintLine(1, i);
            }
        }

        static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    } 
}
