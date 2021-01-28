using System;

namespace _05._Convert.ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double number = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("TYhe number was in incorrect format.");
            }
        }
    }
}
