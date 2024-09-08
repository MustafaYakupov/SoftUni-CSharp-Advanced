using System;

namespace p08CenterPoint
{
    class p08CenterPoint
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            string result = ClosestToTheCenterPoint(x1, y1, x2, y2);
            if (result == "second")
            {
                Console.WriteLine($"({x2}, {y2})");
            }
            else if (result == "first")
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x1}, {y1})");
            }
        }

        static string ClosestToTheCenterPoint(double x1, double y1, double x2, double y2)
        {
            double diagonal1 = Math.Sqrt((x1 * x1) + (y1 * y1));
            double diagonal2 = Math.Sqrt((x2 * x2) + (y2 * y2));
            
            if (diagonal1 > diagonal2)
            {
                return "second";
            }
            else 
            {
                return  "first";
            }
        }
    }
}
