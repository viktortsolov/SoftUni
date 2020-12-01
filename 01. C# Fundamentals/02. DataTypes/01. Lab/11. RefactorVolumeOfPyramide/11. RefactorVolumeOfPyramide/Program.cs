using System;

namespace _11._RefactorVolumeOfPyramide
{
    class Program
    {
        static void Main(string[] args)
        {
            double length;
            Console.Write("Length: ");
            length = double.Parse(Console.ReadLine());

            double width;
            Console.Write("Width: ");
            width = double.Parse(Console.ReadLine());

            double height;
            Console.Write("Height: ");
            height = double.Parse(Console.ReadLine());

            double volume = (length * width * height) / 3;
            Console.Write($"Pyramid Volume: {volume:f2}");

        }
    }
}
