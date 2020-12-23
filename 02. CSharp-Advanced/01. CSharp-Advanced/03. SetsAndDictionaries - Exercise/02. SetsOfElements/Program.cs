using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputLength = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int n = inputLength[0];
            int m = inputLength[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                firstSet.Add(input);
            }

            for (int i = 0; i < m; i++)
            {
                int input = int.Parse(Console.ReadLine());
                secondSet.Add(input);
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
