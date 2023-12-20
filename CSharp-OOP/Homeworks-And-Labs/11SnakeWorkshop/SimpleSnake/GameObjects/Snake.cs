using System.Collections.Generic;
using System.Linq;
using SimpleSnake.Core.Interfaces;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char SnakeSymbol = '\u25CF';
        private const char EmptySymbol = ' ';

        private readonly Queue<GameObject> snakeElements;

        public Snake()
        {
            snakeElements = new Queue<GameObject>();
            GenerateSnakeElements();
        }

        public GameObject Head => snakeElements.Last();

        private void GenerateSnakeElements()
        {
            for (int y = 1; y <= 6; y++)
            {
                var obj = new GameObject(SnakeSymbol, 2, y);
                snakeElements.Enqueue(obj);
                obj.Draw();
            }
        }

        internal void Move(GameObject newSnakeHead)
        {
            // TODO: Enqueue head
            snakeElements.Enqueue(newSnakeHead);
            // TODO: Draw head
            newSnakeHead.Draw();

            // TODO: Dequeue tail
            GameObject tail = snakeElements.Dequeue();

            // TOTO: Draw empty tail
            tail = new GameObject(EmptySymbol, tail.X, tail.Y);
            tail.Draw();
        }

        public bool IsCollidesWith(Point point)
        {
            return snakeElements
                .Any(se => se.X == point.X && se.Y == point.Y);
        }

        public void Grow(Point direction, Point currentSnakeHead, int growPoints)
        {
            Point nextPoint = currentSnakeHead;
            for (int i = 0; i < growPoints; i++)
            {
                GameObject newElement = new GameObject(SnakeSymbol, nextPoint.X, nextPoint.Y);
                snakeElements.Enqueue(newElement);
                nextPoint = Point.GetNextPoint(direction, currentSnakeHead);
            }
        }
    }
}