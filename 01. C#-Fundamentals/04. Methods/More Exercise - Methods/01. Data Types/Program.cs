using System;

namespace _01._Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            switch (command)
            {
                case "int": 
                    int a = int.Parse(Console.ReadLine());
                    IntMethod(a);
                    break;
                case "real":
                    decimal b = decimal.Parse(Console.ReadLine());
                    DecimalMethod(b);
                    break;
                case "string":
                    string text = Console.ReadLine();
                    StringMethod(text);
                    break;
            }
        }

        private static void StringMethod(string text)
        {
            Console.WriteLine($"${text}$");
        }

        private static void DecimalMethod(decimal b)
        {
            Console.WriteLine($"{b * 1.5m:F2}");
        }

        private static void IntMethod(int number)
        {
            Console.WriteLine(number * 2);
        }
    }
}
