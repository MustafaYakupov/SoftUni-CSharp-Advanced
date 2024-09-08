using System;

namespace p04DistanceBetweenPoints
{
    class p04DistanceBetweenPoints
    {
        static void Main(string[] args)
        {
            var firstPoint = ReadPoint();
            
            var secondPoint = ReadPoint();

            var result = Distance(firstPoint, secondPoint);
            Console.WriteLine($"{result:F3}");
        }
        static Point ReadPoint()
        {
           var pointData =  Console
                .ReadLine()
                .Split(' ');

            var point = new Point
            {
                X = int.Parse(pointData[0]),
                Y = int.Parse(pointData[1])
            };
            return point;
        }

        static double Distance(Point first, Point second)
        {

            var xDiff = first.X - second.X;
            var xPow = xDiff * xDiff;

            var yDiff = first.Y - second.Y;
            var yPow = yDiff * yDiff;

            return Math.Sqrt(xPow + yPow);
        }
    }
}
