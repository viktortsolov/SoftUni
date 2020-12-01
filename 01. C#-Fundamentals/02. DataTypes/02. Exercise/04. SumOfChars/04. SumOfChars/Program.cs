using System;

namespace _04._SumOfChars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumOfChars = 0;
            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());

                sumOfChars += letter;
            }

            Console.WriteLine($"The sum equals: {sumOfChars}");
        }
    }
}
