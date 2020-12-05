using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbers = new Stack<int>(array);

            string input = string.Empty;

            while ((input = Console.ReadLine()).ToLower() != "end")
            {
                string[] cmdArg = input.Split();

                string command = cmdArg[0].ToLower();

                switch (command)
                {
                    case "add":
                        int first = int.Parse(cmdArg[1]);
                        int second = int.Parse(cmdArg[2]);

                        numbers.Push(first);
                        numbers.Push(second);
                        break;

                    case "remove":
                        int count = int.Parse(cmdArg[1]);
                        if (numbers.Count >= count)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                numbers.Pop();
                            }
                        }
                        break;

                    default:
                        throw new ArgumentException("Unknown operator");
                }
            }
            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
