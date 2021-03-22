namespace SimpleSnake.GameObjects
{
    using System.Collections.Generic;
    using System.Linq;

    public class Snake : Point
    {
        private const char snakeSymbol = '\u25CF';
        private readonly Queue<Point> snakeElements;
        public Snake(int leftX, int topY) 
            : base(leftX, topY)
        {
            this.snakeElements = new Queue<Point>();
            this.CreateSnake();
        }

        public bool isMoving(Point direction)
        {
            var head = this.snakeElements.Last();

            return true;
        }

        private void CreateSnake()
        {
            for (int i = 0; i <= 6; i++)
            {
                var point = new Point(this.LeftX + i, this.TopY);
                point.Draw(snakeSymbol);
                snakeElements.Enqueue(point);
            }
        }
    }
}
