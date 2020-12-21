using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int seconds = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            int secondToPass = seconds + freeWindow;
            int track = 0;

            Queue<string> cars = new Queue<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "green")
                {
                    foreach (var item in cars)
                    {
                        for (int i = 0; i < item.Length; i++)
                        {
                            track++;
                            if (track > secondToPass)
                            {
                                Console.WriteLine("ERROR");
                                break;
                            }
                        }
                    }
                }
                cars.Enqueue(input);
            }
        }
    }
}
