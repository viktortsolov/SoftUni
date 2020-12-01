using System;
using System.Linq;

namespace Exercise_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] train = new int[n];

            for (int i = 0; i < train.Length; i++)
            train[i] = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(' ', train));
            Console.WriteLine(train.Sum());
        }
    }
}
