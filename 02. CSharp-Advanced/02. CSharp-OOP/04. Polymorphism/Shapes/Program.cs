using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle(3);

            Console.WriteLine(circle.Draw());

            Shape rect = new Rectangle(10, 10);

            Console.WriteLine(rect.Draw());
        }
    }
}
