using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            VowelsCount(text);
        }

        private static void VowelsCount(string text)
        {
            int count = 0;
            for (int i = 0; i < text.Length; i++)
                if (text[i] == 'A' || text[i] == 'a' ||
                    text[i] == 'U' || text[i] == 'u' ||
                    text[i] == 'I' || text[i] == 'i' ||
                    text[i] == 'E' || text[i] == 'e' ||
                    text[i] == 'O' || text[i] == 'o')
                    count++; 

            Console.WriteLine(count);
        }
    }
}
