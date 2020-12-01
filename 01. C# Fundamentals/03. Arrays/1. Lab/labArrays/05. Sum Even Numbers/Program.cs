using System;
using System.Linq;

namespace _05._Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sum = 0;

            foreach (var item in arr)
                if (item % 2 == 0)
                    sum += item;

            Console.WriteLine(sum);
        }
    }
}
