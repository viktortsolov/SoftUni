using System;
using System.Collections.Concurrent;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char previousChar = input[0];

            Console.Write(previousChar);
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (previousChar != currentChar)
                {
                    previousChar = currentChar;
                    Console.Write(previousChar);
                }
            }
        }
    }
}
