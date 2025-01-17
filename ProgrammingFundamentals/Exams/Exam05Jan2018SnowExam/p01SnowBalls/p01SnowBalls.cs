﻿using System;
using System.Numerics;

class Snowballs
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        BigInteger maxValue = 0;

        string result = String.Empty;

        for (int i = 0; i < n; i++)
        {
            int snowballSnow = int.Parse(Console.ReadLine());
            int snowballTime = int.Parse(Console.ReadLine());
            int snowballQuality = int.Parse(Console.ReadLine());

            BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

            if (snowballValue > maxValue)
            {
                maxValue = snowballValue;
                result = $"{snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})";
            }
        }

        Console.WriteLine(result);
    }
}