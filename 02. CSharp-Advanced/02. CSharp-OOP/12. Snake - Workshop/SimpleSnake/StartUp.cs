namespace SimpleSnake
{
    using SimpleSnake.GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            Wall wall = new Wall(60, 20);

            Food food = new FoodDollar(wall);
            Snake snake = new Snake(1, 1);

            food.SetRandomPostition(new System.Collections.Generic.Queue<Point>());
        }
    }
}
