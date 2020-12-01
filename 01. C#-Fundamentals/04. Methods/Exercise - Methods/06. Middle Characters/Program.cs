using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Console.WriteLine(MiddleChars(text));
        }

        static string MiddleChars(string text)
        {
            string result = string.Empty;

            if (text.Length % 2 == 1)
                result = text[text.Length / 2].ToString();
            else
                result = text[text.Length / 2 - 1].ToString() + 
                         text[text.Length / 2].ToString();

            return result;
        }
    }
}
