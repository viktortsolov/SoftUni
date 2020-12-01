using System;

namespace _05._Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());

            ReturnSign(numberOne, numberTwo, numberThree);
        }
        private static void ReturnSign(int numberOne, int numberTwo, int numberThree)
        {
            int[] numbers = { numberOne, numberTwo, numberThree };
            int countOfNegative = 0;
            int countOfPositive = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                    countOfNegative++;
                else if (numbers[i] > 0)
                    countOfPositive++;
            }

            if (numberOne == 0 || numberTwo == 0 || numberThree == 0)
                Console.WriteLine("zero");
            else if (countOfPositive == 3)
                Console.WriteLine("positive");
            else if (countOfPositive == 1 && countOfNegative == 2)
                Console.WriteLine("positive");
            else
                Console.WriteLine("negative");
        }
    }
}
