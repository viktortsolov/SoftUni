using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            char command = char.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine(Calculate(a, command, b));
        }

        private static double Calculate(int a, char command, int b)
        {
            double result = 0;

            switch (command)
            {
                case '+':
                    result = (double)(a + b); break;
                case '-':
                    result = (double)(a - b); break;
                case '*':
                    result = (double)(a * b); break;
                case '/':
                    result = (double)(a / b); break;
            }
            return result;
        }
    }
}
