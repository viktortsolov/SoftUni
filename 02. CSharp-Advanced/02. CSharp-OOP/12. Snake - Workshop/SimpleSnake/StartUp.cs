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

            //TODO: Can I pass wall.left and wall.top?
            Food food = new FoodDollar(wall);

            food.SetRandomPostition(new System.Collections.Generic.Queue<Point>());

            //TODO: CHeck it up

            /*Point point = new Point(10, 10);
            point.Draw('*');
            point.Draw(1, 1, '*');
            point.Draw(2, 2, '*');
            point.Draw(0, 1, '*');*/

        }
    }
}
