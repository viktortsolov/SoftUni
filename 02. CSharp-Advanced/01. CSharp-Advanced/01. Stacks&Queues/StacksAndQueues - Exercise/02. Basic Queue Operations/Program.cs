using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numToPush = input[0];
            int numToPop = input[1];
            int numToFind = input[2];

            Queue<int> queue = new Queue<int>();

            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numToPush; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < numToPop; i++)
            {
                queue.Dequeue();
            }

            bool isFound = queue.Contains(numToFind);
            if (queue.Count > 0)
            {
                if (isFound)
                {
                    Console.WriteLine(isFound.ToString().ToLower());
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
