using System;
using System.Collections.Generic;

namespace _01._Count_Chars_In_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            var dictionary = new Dictionary<char, int>();
            foreach (var letter in input)
            {
                if (letter != ' ')
                {
                    if (!dictionary.ContainsKey(letter))
                    {
                        dictionary.Add(letter, 0);
                    }
                    dictionary[letter]++;
                }
            }

            foreach (var characters in dictionary)
            {
                char currtentKey = characters.Key;
                int currentValue = characters.Value;

                Console.WriteLine($"{currtentKey} -> {currentValue}");
            }
        }
    }
}
