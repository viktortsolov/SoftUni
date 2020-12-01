using System;

namespace _07._Theathre_Promotions
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());
            int ticket = 0;

            if (day == "weekday")
            {
                if (age >= 0 && age <= 18)
                { ticket = 12; Console.WriteLine($"{ticket}$"); }
                else if (age > 18 && age <= 64)
                { ticket = 18; Console.WriteLine($"{ticket}$"); }
                else if (age > 64 && age <= 122)
                { ticket = 12; Console.WriteLine($"{ticket}$"); }
                else
                    Console.WriteLine("Error!");
            }
            else if (day == "weekend")
            {
                if (age >= 0 && age <= 18)
                { ticket = 15; Console.WriteLine($"{ticket}$"); }
                else if (age > 18 && age <= 64)
                { ticket = 20; Console.WriteLine($"{ticket}$"); }
                else if (age > 64 && age <= 122)
                { ticket = 15; Console.WriteLine($"{ticket}$"); }
                else
                    Console.WriteLine("Error!");
            }
            else if (day == "holiday")
            {
                if (age >= 0 && age <= 18)
                { ticket = 5; Console.WriteLine($"{ticket}$"); }
                else if (age > 18 && age <= 64)
                { ticket = 12; Console.WriteLine($"{ticket}$"); }
                else if (age > 64 && age <= 122)
                { ticket = 10; Console.WriteLine($"{ticket}$"); }
                else
                    Console.WriteLine("Error!");
            }
        }
    }
}
