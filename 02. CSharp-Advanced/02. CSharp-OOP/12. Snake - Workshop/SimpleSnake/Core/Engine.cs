namespace SimpleSnake.Core
{
    using SimpleSnake.Enums;
    using SimpleSnake.GameObjects;
    using System;
    using System.IO;
    using System.Threading;

    public class Engine
    {
        private Direction direction;
        private Snake snake;
        private const int sleepTime = 100;
        private Point[] directionsPoints;
        private Wall wall;

        public Engine(Snake snake, Wall wall)
        {
            this.snake = snake;
            this.wall = wall;
            this.direction = Direction.Right;
            this.directionsPoints = new Point[]
            {
                new Point(1, 0),
                new Point(-1, 0),
                new Point(0, 1),
                new Point(0, -1)
            };
        }

        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                var canMove = this.snake.IsMoving(this.directionsPoints[(int)this.direction]);

                if (!canMove)
                {

                    Console.SetCursorPosition(0, this.wall.TopY + 1);
                    Console.WriteLine("Results:");
                    File.AppendAllText("../../../Database/scores.txt", $"You scored: {this.snake.Length} points. Date: {DateTime.Now:d}" + Environment.NewLine);
                    var results = File.ReadAllText("../../../Database/scores.txt");
                    Console.WriteLine(results);

                    Console.WriteLine("Oh nooo!");
                    Thread.Sleep(2000);
                    Console.WriteLine("You lost the game! Good luck next time! :)");

                    Environment.Exit(0);
                }

                Thread.Sleep(sleepTime);
            }
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            if (input.Key == ConsoleKey.LeftArrow)
            {
                if (this.direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (input.Key == ConsoleKey.RightArrow)
            {
                if (this.direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (input.Key == ConsoleKey.UpArrow)
            {
                if (this.direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (input.Key == ConsoleKey.DownArrow)
            {
                if (this.direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }
        }
    }
}
