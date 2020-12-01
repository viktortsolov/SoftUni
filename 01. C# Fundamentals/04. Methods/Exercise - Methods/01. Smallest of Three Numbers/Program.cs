using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            GetMin(a, b, c);
        }

        private static void GetMin(int a, int b, int c)
        {
            int minNumberOne = Math.Min(a, b);
            int minNumberTwo = Math.Min(b, c);

            if (minNumberOne < minNumberTwo)
                Console.WriteLine(minNumberOne);
            else
                Console.WriteLine(minNumberTwo);
        }
    }
}
