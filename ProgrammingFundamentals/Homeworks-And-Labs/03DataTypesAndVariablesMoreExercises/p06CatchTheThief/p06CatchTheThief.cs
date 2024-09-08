using System;

namespace p06CatchTheThief
{
    using System.Numerics;
    class p06CatchTheThief
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            BigInteger count = BigInteger.Parse(Console.ReadLine());
            BigInteger maxValue = -9223372036854775808;

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
            Console.WriteLine(maxValue);
        }
    }
}
