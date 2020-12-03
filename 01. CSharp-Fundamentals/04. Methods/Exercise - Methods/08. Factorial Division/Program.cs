using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            decimal result = FactorialOfFirstNumber(a) / FactorialOfSecondNumber(b);
            Console.WriteLine($"{result:f2}");
        }

        private static decimal FactorialOfFirstNumber(int a)
        {
            decimal result = 1;
            for (int i = 1; i <= a; i++)
                result *= i;

            return result;
        }

        private static decimal FactorialOfSecondNumber(int b)
        {
            decimal result = 1;
            for (int i = 1; i <= b; i++)
                result *= i;

            return result;
        }
    }
}
