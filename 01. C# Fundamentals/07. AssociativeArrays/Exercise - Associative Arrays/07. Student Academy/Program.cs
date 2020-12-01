using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<double>>();

            for (int i = 0; i < number; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }
                students[name].Add(grade);
            }

            foreach (var pair in students.OrderByDescending(x => x.Value.Average()))
            {
                if (pair.Value.Average() >= 4.5)
                {
                    Console.WriteLine($"{pair.Key} -> {pair.Value.Average():f2}");
                }
            }
        }
    }
}
