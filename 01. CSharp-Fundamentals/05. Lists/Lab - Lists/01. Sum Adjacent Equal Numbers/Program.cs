using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                int nextIndex = 0;
                if (i + 1 > numbers.Count - 1)
                    break;
                else
                    nextIndex = i + 1;

                if (numbers[i] == numbers[nextIndex])
                {
                    numbers[i] += numbers[nextIndex];
                    numbers.RemoveAt(nextIndex);
                    i = -1;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
