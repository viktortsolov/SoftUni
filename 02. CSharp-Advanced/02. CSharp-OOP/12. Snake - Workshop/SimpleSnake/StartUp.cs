namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using System;
    using System.IO;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(60, 20);
            Food food = new FoodDollar(wall);

            Snake snake = new Snake(wall, 1, 6);
            Engine engine = new Engine(snake, wall);

            Console.SetCursorPosition(0, wall.TopY + 1);
            Console.WriteLine("Results: ");
            var results = File.ReadAllText("../../../Database/scores.txt");
            Console.WriteLine(results);

            engine.Run();
        }
    }
}
