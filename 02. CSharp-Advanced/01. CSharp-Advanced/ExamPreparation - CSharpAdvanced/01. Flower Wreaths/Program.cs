using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = Console.ReadLine()
                                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            Stack<int> lilies = new Stack<int>();
            foreach (var item in first)
            {
                lilies.Push(item);
            }

            var second = Console.ReadLine()
                                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            Queue<int> roses = new Queue<int>();
            foreach (var item in second)
            {
                roses.Enqueue(item);
            }

            int wreaths = 0;

            List<int> sums = new List<int>();

            while (true)
            {
                int lilie = lilies.Pop();
                int rose = roses.Dequeue();

                int sum = lilie + rose;

                if (sum == 15)
                {
                    wreaths++;
                }
                else if (sum < 15)
                {
                    sums.Add(sum);
                }
                else
                {
                    while (sum > 15)
                    {
                        sum -= 2;
                    }

                    if (sum == 15)
                    {
                        wreaths++;
                    }
                    else
                    {
                        sums.Add(sum);
                    }
                }

                if (roses.Count == 0 || lilies.Count == 0)
                {
                    break;
                }
            }

            if (sums.Count != 0)
            {
                wreaths += sums.Sum() / 15;
            }

            if (wreaths < 5)
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
            else
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
        }
    }
}
