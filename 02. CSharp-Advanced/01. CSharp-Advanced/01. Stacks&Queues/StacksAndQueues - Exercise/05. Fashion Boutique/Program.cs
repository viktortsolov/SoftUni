using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> boxes = new Stack<int>(array);

            int rackCapacity = int.Parse(Console.ReadLine());

            int racks = 1;
            int currentCapacity = rackCapacity;

            while (boxes.Any())
            {
                int cloth = boxes.Peek();

                if (currentCapacity >= cloth)
                {
                    currentCapacity -= cloth;
                    boxes.Pop();
                }
                else
                {
                    racks++;
                    currentCapacity = rackCapacity;
                }    
            }
            Console.WriteLine(racks);
        }
    }
}
