using System;

namespace _02._Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(n));
        }

        private static long Factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            long currentFactorial = n * Factorial(n - 1);

            return currentFactorial;
        }
    }
}
