using System;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;

namespace SimpleSnake.Utilities
{
    internal class PlatformInteraction
    {
        public static void Draw(GameObject gameObject)
        {
            Console.SetCursorPosition(gameObject.X, gameObject.Y);
            Console.Write(gameObject.DrawSymbol);
        }

        public static Direction GetInput(Direction currentDirection)
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow && currentDirection != Direction.Right)
            {
                currentDirection = Direction.Left;
            }
            else if (userInput.Key == ConsoleKey.RightArrow && currentDirection != Direction.Left)
            {
                currentDirection = Direction.Right;
            }
            else if (userInput.Key == ConsoleKey.UpArrow && currentDirection != Direction.Down)
            {
                currentDirection = Direction.Up;
            }
            else if (userInput.Key == ConsoleKey.DownArrow && currentDirection != Direction.Up)
            {
                currentDirection = Direction.Down;
            }

            return currentDirection;
        }

        public static void GameOver(Wall fieldBoundaries)
        {
            int x = fieldBoundaries.X + 1;
            int y = 3;

            Console.SetCursorPosition(x, y);
            Console.WriteLine("Wold tou like to continue? y/n");

            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.Y)
            {
                Restart();
            }
            else if (userInput.Key == ConsoleKey.N)
            {
                Exit();
            }
        }

        private static void Exit()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game Over!");
            Environment.Exit(1);
        }

        private static void Restart()
        {
            Console.Clear();
            StartUp.Main();
        }


    }
}