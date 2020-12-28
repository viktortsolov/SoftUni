using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            List<string> people = Console.ReadLine()
                .Split()
                .ToList();

            Func<string, int> getASCIISum = str => str.Select(c => (int)c).Sum();

            Func<List<string>, int, Func<string, int>, string> nameFunc = (people, n, func)
                => people.FirstOrDefault(p => func(p) >= n);

            string result = nameFunc(people, number, getASCIISum);
            Console.WriteLine(result);
        }
    }
}
