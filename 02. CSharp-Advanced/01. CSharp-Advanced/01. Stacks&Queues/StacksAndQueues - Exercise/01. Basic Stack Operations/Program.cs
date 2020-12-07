using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
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

            Stack<int> stack = new Stack<int>();

            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numToPush; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < numToPop; i++)
            {
                stack.Pop();
            }

            bool isFound = stack.Contains(numToFind);
            if (stack.Any())
            {
                if (isFound)
                {
                    Console.WriteLine(isFound.ToString().ToLower());
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
