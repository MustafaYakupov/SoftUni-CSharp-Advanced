using System;

namespace p12MasterNumbers
{
    class p12MasterNumbers
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 1; i <= input; i++)
            {
                if (IsPalindrome(i) && SumOfDigitsDivBy7(i) && HasEvenDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        
        static bool IsPalindrome(int i)
        {
            bool isPalindrome = false;
            int reversed = 0;
            int oldNumber = i;
            int power = i.ToString().Length - 1;
            int loops = i.ToString().Length;
            //while (i!=0)
            //{
            //    reversed *= 10;
            //    reversed += i % 10;
            //    i /= 10;
            //}
            for (int j = 0; j < loops; j++)
            {
                reversed += (i % 10) * (int)Math.Pow(10, power);
                power--;
                i /= 10;
            }
            if (reversed == oldNumber)
            {
                isPalindrome = true;
            }
            else
            {
                isPalindrome = false;
            }
            return  isPalindrome;
        }

        static bool SumOfDigitsDivBy7(int i)
        {
            int sum = 0;
            while (i != 0)
            {
                sum += i % 10;
                i /= 10;
            }
            if (sum % 7 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        static bool HasEvenDigit(int i)
        {
            int digit = 0;
            bool divides = false;
            while (i != 0)
            {
                 digit = i % 10;
                if (digit % 2 == 0)
                {
                    divides = true;
                    return divides;
                }
                i /= 10;
            }
            return divides;

        }
    }
}
