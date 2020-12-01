using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            PrintInRange(start, end);
        }

        private static void PrintInRange(char start, char end)
        {
            int startCharacter = Math.Min(start, end);
            int endCharacter = Math.Max(start, end);

            for (int i = ++startCharacter; i < endCharacter; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
