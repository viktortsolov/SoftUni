namespace SimpleSnake.GameObjects
{
    public class FoodAsterisk : Food
    {
        //TODO: Change symbols
        private const char symbol = '*';
        private const int points = 1;

        public FoodAsterisk(Wall wall) 
            : base(wall, symbol, points)
        {
        }
    }
}
