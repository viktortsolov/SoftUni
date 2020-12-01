using System;

namespace _1._Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double sumOfPlunder = 0;
            for (int i = 1; i <= days; i++)
            {
                sumOfPlunder += dailyPlunder;
                if (i % 3 == 0)
                {
                    sumOfPlunder += dailyPlunder * 0.5;
                }
                if (i % 5 == 0)
                {
                    sumOfPlunder *= 0.7;
                }
            }

            if (sumOfPlunder >= expectedPlunder) 
            {
                Console.WriteLine($"Ahoy! {sumOfPlunder:f2} plunder gained.");
            }
            else
            {
                Console.WriteLine($"Collected only {(sumOfPlunder / expectedPlunder) * 100:f2}% of the plunder.");
            }
        }
    }
}
