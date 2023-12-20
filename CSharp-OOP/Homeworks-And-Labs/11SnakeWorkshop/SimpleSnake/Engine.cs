using System;
using System.Threading;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using SimpleSnake.Utilities;

namespace SimpleSnake;

public class Engine
{
    public const int SleepTime = 100;

    private Food[] foods;
    private Wall fieldBoundaries;
    private Snake snake;
    private Direction currentDirection;
    private Point[] pointsOfDirection;
    private GameState state;
    private Random random;
    private Food foodReference;

    public Engine(Wall fieldBoundaries, Snake snake)
    {
        CreateDirections();

        random = new Random();

        foods = new Food[]
        {
            new FoodAsterisk(),
            new FoodDollar(),
            new FoodHash()
        };

        this.fieldBoundaries = fieldBoundaries;
        this.snake = snake;
    }


    private void CreateDirections()
    {
        pointsOfDirection = new Point[]
        {
            new Point(1, 0),
            new Point(-1, 0),
            new Point(0, 1),
            new Point(0, -1),
        };
    }

    public void Start()
    {
        PlaceFoodOnField();

        while (state != GameState.Over)
        {
            if (Console.KeyAvailable)
            {
                currentDirection = GetDirection();
            }

            state = UpdateSnake(pointsOfDirection[(int)currentDirection]);

            if (state == GameState.FoodEaten)
            {
                PlaceFoodOnField();
                state = GameState.Running;
            }

            Thread.Sleep(SleepTime);
        }

        PlatformInteraction.GameOver(fieldBoundaries);
    }

    private GameState UpdateSnake(Point direction)
    {
        GameObject currentSnakeHead = snake.Head;
        Point nextHeadPoint = Point.GetNextPoint(direction, currentSnakeHead);

        if (snake.IsCollidesWith(nextHeadPoint))
        {
            return GameState.Over;
        }

        GameObject snakeNewHead = new GameObject(currentSnakeHead.DrawSymbol, nextHeadPoint.X, nextHeadPoint.Y);

        if (fieldBoundaries.IsCollidesWith(snakeNewHead))
        {
            return GameState.Over;
        }

        snake.Move(snakeNewHead);

        if (foodReference.IsCollidesWith(snakeNewHead))
        {
            snake.Grow(direction, currentSnakeHead, foodReference.Points);
            return GameState.FoodEaten;
        }

        return GameState.Running;
    }

    private Direction GetDirection()
    {
        return PlatformInteraction.GetInput(currentDirection);
    }

    private void PlaceFoodOnField()
    {
        int randomFoodIndex = random.Next(0, foods.Length - 1);
        foodReference = foods[randomFoodIndex];

        do
        {
            foodReference.X = random.Next(2, fieldBoundaries.X - 2);
            foodReference.Y = random.Next(2, fieldBoundaries.Y - 2);
        } while (snake.IsCollidesWith(foodReference));

        foodReference.Draw();
    }
}

internal enum GameState
{
    Idle,
    Start,
    FoodEaten,
    Running,
    Over
}