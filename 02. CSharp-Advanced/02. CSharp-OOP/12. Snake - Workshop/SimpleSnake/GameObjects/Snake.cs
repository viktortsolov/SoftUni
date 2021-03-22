namespace SimpleSnake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Snake : Point
    {
        private const char snakeSymbol = '\u25CF';

        private readonly Queue<Point> snakeElements;
        private readonly Wall wall;
        private readonly Food[] foods;

        private int foodIndex = new Random().Next(0, 3);

        public Snake(Wall wall, int leftX, int topY)
            : base(leftX, topY)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            this.foods = new Food[]
            {
                new FoodAsterisk(this.wall),
                new FoodDollar(this.wall),
                new FoodHash(this.wall)
            };

            this.CreateSnake();
            this.foods[foodIndex].SetRandomPostition(this.snakeElements);
        }

        public int Length
            => this.snakeElements.Count;

        public bool IsMoving(Point direction)
        {
            var currentSnakeHead = this.snakeElements.Last();

            GetNextDirection(currentSnakeHead, direction);

            if (IsWallPoint())
            {
                return false;
            }

            if (IsPartOfSnake())
            {
                return false;
            }

            Point newHead = CreateNewHead();

            if (this.foods[foodIndex].IsFoodPoint(newHead))
            {
                this.Eat(direction, newHead);
            }

            RemoveTail();

            return true;
        }

        private void RemoveTail()
        {
            var tail = this.snakeElements.Dequeue();
            tail.Draw(' ');
        }

        private Point CreateNewHead()
        {
            var newHead = new Point(this.LeftX, this.TopY);
            newHead.Draw(snakeSymbol);
            this.snakeElements.Enqueue(newHead);
            return newHead;
        }

        private void Eat(Point direction, Point newHead)
        {
            for (int i = 0; i < this.foods[foodIndex].FoodPoints; i++)
            {
                this.GetNextDirection(newHead, direction);

                newHead = new Point(this.LeftX, this.TopY);
                newHead.Draw(snakeSymbol);

                this.snakeElements.Enqueue(newHead);

            }

            foodIndex = new Random().Next(0, 3);
            this.foods[foodIndex].SetRandomPostition(this.snakeElements);
        }

        private bool IsPartOfSnake()
            => this.snakeElements.Any(x => x.LeftX == this.LeftX &&
                                           x.TopY == this.TopY);

        private bool IsWallPoint()
            => this.LeftX == 0 || this.TopY == 0 ||
                this.LeftX == this.wall.LeftX ||
                this.TopY == this.wall.TopY - 1;

        private void GetNextDirection(Point head, Point direction)
        {
            this.LeftX = head.LeftX + direction.LeftX;
            this.TopY = head.TopY + direction.TopY;
        }

        private void CreateSnake()
        {
            for (int i = 0; i < 6; i++)
            {
                var point = new Point(this.LeftX + i, this.TopY);
                point.Draw(snakeSymbol);
                snakeElements.Enqueue(point);
            }
        }
    }
}
