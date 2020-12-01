using System;

namespace _04._Back_in_30_minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            if (minutes >= 30)
            {
                hours++;
                minutes = minutes - 30;
                if (hours == 24)
                    hours = 0;
            }
            else
                minutes += 30;

            Console.WriteLine($"{hours}:{minutes:D2}");
        }
    }
}
