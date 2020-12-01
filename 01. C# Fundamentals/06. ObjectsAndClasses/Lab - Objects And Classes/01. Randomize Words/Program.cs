using System;

namespace _01._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            Random rnd = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int n = rnd.Next(0, words.Length);

                string temp = words[i];
                words[i] = words[n];
                words[n] = temp;
            }
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
