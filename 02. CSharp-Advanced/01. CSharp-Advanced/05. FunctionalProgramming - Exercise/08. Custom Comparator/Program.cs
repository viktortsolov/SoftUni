using System;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Array.Sort(array, (x, y) =>
                (x % 2 == 0 && y % 2 != 0) ? -1 :
                (x % 2 != 0 && y % 2 == 0) ? 1 :
                x.CompareTo(y));

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
