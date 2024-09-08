using System;

namespace p07SentenceTheThief
{
    class p07SentenceTheThief
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            long count = long.Parse(Console.ReadLine());
            long maxValue = -9223372036854775808;

            for (int i = 1; i <= count; i++)
            {
                long idNum = long.Parse(Console.ReadLine());

                if (type == "sbyte" && idNum <= sbyte.MaxValue && idNum >= sbyte.MinValue)
                {
                    if (idNum > maxValue)
                    {
                        maxValue = idNum;

                    }
                }
                else if (type == "int" && idNum <= int.MaxValue && idNum >= int.MinValue)
                {
                    if (idNum > maxValue)
                    {
                        maxValue = idNum;
                    }
                }
                else if (type == "long" && idNum <= long.MaxValue && idNum >= long.MinValue)
                {
                    if (idNum > maxValue)
                    {
                        maxValue = idNum;
                    }
                }
            }
           
            double yearsSentence = 0;
            if (maxValue >= 0)
            {
                yearsSentence = Math.Ceiling((double)maxValue / 127);
            }
            else if (maxValue < 0)
            {
                yearsSentence = Math.Ceiling((double)maxValue / (-128));
                
            }
            if (yearsSentence > 1)
            {
                Console.WriteLine($"Prisoner with id {maxValue} is sentenced to {yearsSentence} years");
            }
            else
            {
                Console.WriteLine($"Prisoner with id {maxValue} is sentenced to {yearsSentence} year");
            }
        }
    }
}
