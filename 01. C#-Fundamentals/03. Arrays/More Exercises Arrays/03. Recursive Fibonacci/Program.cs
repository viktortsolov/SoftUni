using System;

namespace _03._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            for (int i = 2; i < n; i++)
            {
                array[0] = 1;
                array[1] = 1;

                array[i] = array[i - 1] + array[i - 2];

            }
            Console.WriteLine(array[n - 1]);
        }
    }
}
