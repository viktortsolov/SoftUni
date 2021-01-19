using System;
using System.Linq;

namespace _01._Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(Sum(array, 0));
        }

        private static int Sum(int[] array, int index)
        {
            if (index == array.Length - 1)
            {
                return 0;
            }
            int currentSum = array[index] + Sum(array, index + 1);

            return currentSum;
        }
    }
}
