using System;
using System.Collections.Generic;

namespace _08._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string token = string.Empty;

            Queue<string> cars = new Queue<string>();
            int counter = 0;

            while ((token = Console.ReadLine()).ToLower() != "end")
            {
                if (token.ToLower() != "green")
                {
                    cars.Enqueue(token);
                }
                else if (token.ToLower() == "green")
                {
                    for (int i = 0; i < count; i++)
                    {
                        string car;
                        if (cars.TryDequeue(out car))
                        {
                            Console.WriteLine($"{car} passed!");
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
