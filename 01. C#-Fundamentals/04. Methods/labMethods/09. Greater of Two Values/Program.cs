using System;
using System.Data;

namespace _09._Greater_of_Two_Values
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
                    int b = int.Parse(Console.ReadLine());
                    int result = GetMax(a, b);
                    Console.WriteLine(result);
                    break;
                /*
                    case "char":
                    char firstChar = char.Parse(Console.ReadLine());
                    char secondChar = char.Parse(Console.ReadLine());
                    int resultChar = GetMax(firstChar, secondChar);
                    Console.WriteLine(resultChar);
                    break;
                */
                case "string":
                    string firstString = Console.ReadLine();
                    string secondString = Console.ReadLine();
                    string resultString = GetMax(firstString, secondString);
                    Console.WriteLine(resultString);
                    break;
            }
        }

        private static string GetMax(string firstString, string secondString)
        {
            int comparison = firstString.CompareTo(secondString);

            if (comparison > 0)
                return firstString;
            else
                return secondString;
        }

        private static int GetMax(int a, int b)
        {
            return Math.Max(a, b);
        }

        /*
        private static void GetMax(char a, char b)
        {
            if (a.CompareTo(b) > 0)
                Console.WriteLine(a);
            else
                Console.WriteLine(b);
        }
        */
    }
}
