using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            Predicate<string> isLengthGood = str => str.Length <= length;

            Console.ReadLine()
                .Split()
                .Where(str => isLengthGood(str))
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
