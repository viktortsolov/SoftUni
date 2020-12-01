using System;
using System.Threading;

namespace _10._Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int count = 0;
            double tempPower = power * 0.5;
            while (power>=distance)
            {
                count++;
                power -= distance;

                if (power == tempPower && exhaustionFactor != 0) 
                {
                    power /= exhaustionFactor;
                }
            }

            Console.WriteLine(power);
            Console.WriteLine(count);
        }
    }
}
