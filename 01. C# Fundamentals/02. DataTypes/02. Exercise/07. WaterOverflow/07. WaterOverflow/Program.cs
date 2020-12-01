using System;

namespace _07._WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumOfLiters = 0;

            for (int i = 0; i < n; i++)
            {
                int liters = int.Parse(Console.ReadLine());

                if (liters + sumOfLiters > 255)
                {
                    Console.WriteLine("Insufficient capacity!"); continue;
                }
                sumOfLiters += liters;
            }

            Console.WriteLine(sumOfLiters);
        }
    }
}
