using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isFirstLetterCapital =
                str => char.IsUpper(str[0]);

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => isFirstLetterCapital(x))
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}
