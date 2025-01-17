﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
//02. Convert from base-N to base-10
namespace BaseNToBase10
{
    class BaseNToBase10
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            long fromBase = long.Parse(input[0]);
            string number = input[1];

            BigInteger result = 0;

            int power = number.Length - 1;

            for (int i = 0; i < number.Length; i++)
            {
                BigInteger num = BigInteger.Parse(number[i].ToString());
                result += BigInteger.Multiply(num, BigInteger.Pow(fromBase, power));
                power--;
            }

            Console.WriteLine(result);
        }
    }
}