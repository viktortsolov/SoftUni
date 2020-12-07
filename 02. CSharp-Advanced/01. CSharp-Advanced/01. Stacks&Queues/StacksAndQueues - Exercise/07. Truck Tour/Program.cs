using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> pumps = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                pumps.Enqueue(item: Console.ReadLine());
            }
            
            int index = 0;
            int counter = 0;
            int length = pumps.Count;

            for (int i = 0; i < length; i++)
            {
                int totalAmount = 0;
                bool isCompleted = true;

                for (int j = 0; j < length; j++)
                {
                    string currentPump = pumps.Dequeue();
                    int[] currentPumpsValues = currentPump.Split().Select(int.Parse).ToArray();
                    int currentAmount = currentPumpsValues[0];
                    int distance = currentPumpsValues[1];

                    totalAmount += currentAmount;

                    if (totalAmount >= distance)
                    {
                        totalAmount -= distance;
                    }
                    else
                    {
                        isCompleted = false;
                    }
                    pumps.Enqueue(currentPump);
                }
                if (isCompleted)
                {
                    index = i;
                    break;
                }
                pumps.Enqueue(item: pumps.Dequeue());
            }
            
            Console.WriteLine(index);
        }
    }
}
