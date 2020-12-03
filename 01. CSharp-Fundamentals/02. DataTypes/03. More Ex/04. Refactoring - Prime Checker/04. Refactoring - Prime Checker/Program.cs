using System;

namespace _04._Refactoring___Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberToGoTo = int.Parse(Console.ReadLine());
            for (int numbers = 2; numbers <= numberToGoTo; numbers++)
            {
                bool isItPrime = true;
                for (int numberForDivison = 2; numberForDivison < numbers; numberForDivison++)
                {
                    if (numbers % numberForDivison == 0)
                    {
                        isItPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{numbers} -> {(isItPrime.ToString()).ToLower()}");
            }

        }
    }
}
