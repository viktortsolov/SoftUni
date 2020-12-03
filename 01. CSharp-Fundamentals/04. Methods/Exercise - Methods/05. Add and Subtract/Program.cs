using System;
using System.Security.Cryptography;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int result = (a + b) - c;
            Console.WriteLine(result);
        }
    }
}
