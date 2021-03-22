namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        //\u25A0 = ■

        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
            this.SetHorizontalLine(0);
            this.SetHorizontalLine(this.TopY - 1);

            this.SetVerticalLine(0);
            this.SetVerticalLine(this.LeftX);
        }
        private void SetHorizontalLine(int top)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, top, '■');
            }
        }

        private void SetVerticalLine(int left)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(left, topY, '■');
            }
        }
    }
}
