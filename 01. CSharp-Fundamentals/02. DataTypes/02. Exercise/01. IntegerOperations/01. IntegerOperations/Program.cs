using System;

namespace _01._IntegerOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumer = int.Parse(Console.ReadLine());
            int fourthNumber = int.Parse(Console.ReadLine());

            int result = ((firstNumber + secondNumber) / thirdNumer) * fourthNumber;
            Console.WriteLine(result);
        }
    }
}
