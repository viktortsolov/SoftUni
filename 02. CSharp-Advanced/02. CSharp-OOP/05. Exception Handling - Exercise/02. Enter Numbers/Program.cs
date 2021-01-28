using System;

namespace _02._Enter_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                try
                {
                    numbers[i] = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("The entered number was not in correct format.");
                }
                catch (NotFiniteNumberException)
                {
                    Console.WriteLine("The number was invalid!");
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
