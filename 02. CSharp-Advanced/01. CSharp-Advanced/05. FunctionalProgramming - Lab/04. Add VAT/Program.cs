using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x =>
                {
                    double num = double.Parse(x);
                    return num * 1.2;
                })
                .ToList()
                .ForEach(x => Console.WriteLine($"{x:f2}"));
        }
    }
}
