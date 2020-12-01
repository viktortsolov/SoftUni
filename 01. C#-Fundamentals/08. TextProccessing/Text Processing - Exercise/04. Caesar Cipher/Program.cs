using System;
using System.Linq;
using System.Text;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] outText = Console.ReadLine()
                .Select(x => x + 3)
                .Select(x => (char)x)
                .ToArray();

            Console.WriteLine(string.Join("", outText));
        }
    }
}
