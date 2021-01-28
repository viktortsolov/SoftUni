using System;

namespace _01._Square_Root
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                if (n < 0)
                {
                    throw new NotFiniteNumberException("The entered number was negative.");
                }
                var squareRoot = Math.Sqrt(n);
                Console.WriteLine(squareRoot);
            }
            catch (NotFiniteNumberException nan)
            {
                Console.WriteLine(nan.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("The number was in incorrect format.");
            }
        }
    }
}
