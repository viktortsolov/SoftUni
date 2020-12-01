using System;
using System.Runtime.Versioning;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double sum = 0;

            int headsetCount = 0,
                mouseCount = 0,
                keyboardCount = 0,
                displayCount = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                    headsetCount++;
                if (i % 3 == 0)
                    mouseCount++;
                if (i % 2 == 0 && i % 3 == 0)
                    keyboardCount++;
            }

            for (int i = 1; i <= keyboardCount; i++)
            {
                if (i % 2 == 0)
                    displayCount++;
            }

            sum = headsetCount * headsetPrice + 
                mouseCount * mousePrice + 
                keyboardCount * keyboardPrice + 
                displayCount * displayPrice;

            Console.WriteLine($"Rage expenses: {sum:f2} lv.");
        }
    }
}
