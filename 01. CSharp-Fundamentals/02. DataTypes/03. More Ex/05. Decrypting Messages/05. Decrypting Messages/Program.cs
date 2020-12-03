using System;

namespace _05._Decrypting_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            string finalResult = string.Empty;
            char unCrypted;

            for (int i = 0; i < number; i++)
            {
                char crypted = char.Parse(Console.ReadLine());
                unCrypted = (char)(crypted + n);

                finalResult += unCrypted;
            }

            Console.WriteLine(finalResult);
        }
    }
}
