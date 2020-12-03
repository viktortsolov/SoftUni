using System;
using System.IO;
using System.Linq;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                Console.WriteLine(IsPalindrome(input)
                                        .ToString()
                                        .ToLower());
                input = Console.ReadLine();
            }
        }

        static bool IsPalindrome(string text)
        {
            var reversed = text.Reverse().ToArray();

            for (int i = 0; i < text.Length; i++)
            {
                if (!(reversed[i] == text[i]))
                    return false;
            }
            return true;
        }
    }
}
