using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int fib = int.Parse(Console.ReadLine());

            Console.WriteLine(Fibonacci(fib));
        }

        private static int Fibonacci(int fib)
        {
            if (fib == 0)
                return 0;
            if (fib == 1 || fib == 2)
                return 1;

            int first = Fibonacci(fib - 1);
            int second = Fibonacci(fib - 2);

            return first + second;
        }
    }
}
