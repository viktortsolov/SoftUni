using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static int entries;
        static Queue<int[]> pumps;
        static void Main(string[] args)
        {

            entries = int.Parse(Console.ReadLine());
            pumps = new Queue<int[]>();

            for (int entry = 0; entry < entries; entry++)
                pumps.Enqueue(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

            for (int entry = 0; entry < entries; entry++)
            {
                if (IsSolution())
                {
                    Console.WriteLine(entry);
                    break;
                }
                int[] startingPump = pumps.Dequeue();
                pumps.Enqueue(startingPump);
            }

        }

        static bool IsSolution()
        {
            int tankFuel = 0;
            bool foundAnswer = true;

            for (int entry = 0; entry < entries; entry++)
            {
                int[] currPump = pumps.Dequeue();
                tankFuel += currPump[0] - currPump[1];
                if (tankFuel < 0)
                    foundAnswer = false;
                pumps.Enqueue(currPump);
            }

            if (foundAnswer)
                return true;
            else
                return false;
        }
    }
}