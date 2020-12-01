using System;
using System.Linq;

namespace _06._Even_and_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sumEven = 0, sumOdd = 0;

            foreach (var item in arr)
            {
                if (item % 2 == 0)
                    sumEven += item;
                else
                    sumOdd += item;
            }
            Console.WriteLine(sumEven - sumOdd);
        }
    }
}
