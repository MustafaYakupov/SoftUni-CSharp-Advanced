﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p03KarateStrings
{
    class p03KarateStrings
    {
        static void Main()
        {
            List<char> chars = Console.ReadLine().ToCharArray().ToList();

            int length = 0;

            for (int i = 0; i < chars.Count; i++)
            {
                if (chars[i] == '>')
                {
                    length += int.Parse(chars[i + 1].ToString());
                }
                else
                {
                    if (length > 0)
                    {
                        chars.RemoveAt(i);
                        i--;
                        length--;
                    }
                }
            }
            Console.WriteLine(string.Join("", chars));
            //Console.ReadLine();
        }
    }
}