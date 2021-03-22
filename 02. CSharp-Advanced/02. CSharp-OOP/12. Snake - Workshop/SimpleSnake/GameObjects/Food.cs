namespace SimpleSnake.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Food : Point
    {
        private readonly Random random;
        private readonly Wall wall;

        protected Food(Wall wall, char symbol, int foodPoints)
            : base(wall.LeftX, wall.TopY)
        {
            this.random = new Random();
            this.FoodPoints = foodPoints;
            this.Symbol = symbol;
            this.wall = wall;
        }

        public char Symbol { get; set; }
        public int FoodPoints { get; }

        public void SetRandomPostition(Queue<Point> snake)
        {
            this.LeftX = this.random.Next(1, this.wall.LeftX - 1);
            this.TopY = this.random.Next(1, this.wall.TopY - 1);

            var isPartOfSnake = snake.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);

            while (isPartOfSnake)
            {
                this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
                this.TopY = this.random.Next(2, this.wall.TopY - 2);

                isPartOfSnake = snake.Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(this.LeftX, this.TopY, this.Symbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake)
            => this.LeftX == snake.LeftX &&
               this.TopY == snake.TopY;
    }
}
