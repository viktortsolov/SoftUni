using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> time = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            double sumOfLeft = 0;
            double sumOfRight = 0;

            int index = time.Count / 2;

            //first racer time
            for (int i = 0; i < index; i++)
            {
                if (time[i] == 0)
                {
                    sumOfLeft *= (double)0.8;
                }
                else
                {
                    sumOfLeft += (double)time[i];
                }
            }

            time.Reverse();

            //second racer time
            for (int i = 0; i < index; i++)
            {
                if (time[i] == 0)
                {
                    sumOfRight *= (double)0.8;
                }
                else
                {
                    sumOfRight += (double)time[i];
                }
            }

            if (sumOfLeft < sumOfRight)
            {
                Console.WriteLine($"The winner is left with total time: {sumOfLeft:f1}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {sumOfRight:f1}");
            }
        }
    }
}
