using System;

namespace p05ClaculateTriangleArea
{
    class p05ClaculateTriangleArea
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = AreaOfTriangle(width, height);
            Console.WriteLine(area);
        }

        static double AreaOfTriangle(double width, double height)
        {
            return width * height / 2;
        }
    }
}
