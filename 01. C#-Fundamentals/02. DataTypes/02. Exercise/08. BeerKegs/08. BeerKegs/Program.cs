using System;

namespace _08._BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double max = int.MinValue;

            string biggestKen = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string modelOfKen = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * (double)height;
                if (volume > max)
                { max = volume; biggestKen = modelOfKen; }
            }

            Console.WriteLine(biggestKen);

        }
    }
}
