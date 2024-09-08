using System;

namespace p11GeometryCalculator
{
    class p11GeometryCalculator
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double triangleArea = TriangleArea(side, height);
                Console.WriteLine($"{triangleArea:f2}");
            }
            else if (type == "square")
            {
                double side = double.Parse(Console.ReadLine());
                double squareArea = SquareArea(side);
                Console.WriteLine($"{squareArea:f2}");
            }
            else if (type == "rectangle")
            {
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double rectangleArea = RectangleArea(width, height);
                Console.WriteLine($"{rectangleArea:f2}");
            }
            else if (type == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double circleArea = CircleArea(radius);
                Console.WriteLine($"{circleArea:f2}");
            }

        }

        static double CircleArea(double radius)
        {
            double result = Math.PI * Math.Pow(radius, 2);
            return result;
        }

        static double RectangleArea(double width, double height)
        {
            double result = width * height;
            return result;
        }

        static double SquareArea(double side)
        {
            double result = side * side;
            return result;
        }

        static double TriangleArea(double side, double height)
        {
            double result = (side * height) / 2;
            return result;
        }
    }
}
