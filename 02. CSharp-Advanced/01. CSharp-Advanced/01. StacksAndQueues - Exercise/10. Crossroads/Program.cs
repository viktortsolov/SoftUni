using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int seconds = int.Parse(Console.ReadLine());
            int freeWindows = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int counter = 0;

            while (true)
            {
                string car = Console.ReadLine();

                int greenLights = seconds;
                int passSeconds = freeWindows;

                if (car == "END")
                {
                    Console.WriteLine($"Everyone is safe.{Environment.NewLine}" +
                        $"{counter} total cars passed the crossroads.");
                    return;
                }

                if (car == "green")
                {
                    while (greenLights > 0 && cars.Count != 0)
                    {

                        string firstInQueue = cars.Dequeue();
                        greenLights -= firstInQueue.Count();
                        if (greenLights >= 0)
                        {
                            counter++;
                        }

                        else
                        {
                            passSeconds += greenLights;
                            if (passSeconds < 0)
                            {
                                Console.WriteLine($"A crash happened!{Environment.NewLine}" +
                                    $"{firstInQueue} was hit at" +
                                    $" {firstInQueue[firstInQueue.Length + passSeconds]}.");
                                return;
                            }
                            counter++;
                        }
                    }
                }

                else
                {
                    cars.Enqueue(car);
                }
            }
        }
    }
}
