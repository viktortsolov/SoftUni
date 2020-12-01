using System;

namespace _02._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int start = (int)Math.Min(first, second);
            int end = (int)Math.Max(first, second);

            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int currentChar = (int)(input[i]);
                if (currentChar > start && currentChar < end)
                {
                    sum += currentChar;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
