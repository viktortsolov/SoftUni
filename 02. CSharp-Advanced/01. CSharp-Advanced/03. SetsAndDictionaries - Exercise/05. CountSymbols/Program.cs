using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputWord = Console.ReadLine();
            var dict = new Dictionary<char, int>();
            foreach (var i in inputWord)
            {
                if (!dict.ContainsKey(i))
                {
                    dict.Add(i, 1);
                }
                else
                {
                    dict[i]++;
                }
            }

            foreach (var i in dict.OrderBy(x => x.Key))
            {
                var word = i.Key;
                var times = i.Value;
                Console.WriteLine($"{word}: {times} time/s");
            }
        }
    }
}
