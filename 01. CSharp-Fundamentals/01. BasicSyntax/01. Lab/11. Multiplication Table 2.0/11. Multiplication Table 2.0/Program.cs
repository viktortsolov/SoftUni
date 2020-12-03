using System;

namespace _11._Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int start = int.Parse(Console.ReadLine());

            if (start > 10)
                Console.WriteLine($"{number} X {start} = {number * start}");
            else
            {
                for (int i = start; i <= 10; i++)
                    Console.WriteLine($"{number} X {i} = {number * i}");
            }
        }
    }
}
