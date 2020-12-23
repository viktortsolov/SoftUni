using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int queries = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            for (int i = 0; i < queries; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int numOfCommand = input[0];

                switch (numOfCommand)
                {
                    case 1:
                        int element = input[1];

                        stack.Push(element);
                        break;

                    case 2:
                        if (stack.Count > 0)
                            stack.Pop();
                        break;

                    case 3:
                        if (stack.Count > 0)
                            Console.WriteLine(stack.Max());
                        break;

                    case 4:
                        if (stack.Count > 0)
                            Console.WriteLine(stack.Min());
                        break;

                    default:
                        throw new ArgumentException("Unknown operator");
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
