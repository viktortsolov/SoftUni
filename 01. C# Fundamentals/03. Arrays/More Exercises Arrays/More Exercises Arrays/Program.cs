using System;
using System.Runtime.ExceptionServices;

namespace More_Exercises_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrLength = int.Parse(Console.ReadLine());

            string vowels = "EeUuIiOoAa";

            int[] arrayOfSums = new int[arrLength];

            for (int i = 0; i < arrLength; i++)
            {
                string name = Console.ReadLine();

                int sumVowels = 0;
                int sumConsonant = 0;
                int sum = 0;

                for (int j = 0; j < name.Length; j++)
                {
                    char currentLetter = name[j];
                    if (vowels.Contains(currentLetter))
                        sumVowels += currentLetter * name.Length;
                    else
                        sumConsonant += currentLetter / name.Length;
                }
                sum = sumVowels + sumConsonant;
                arrayOfSums[i] = sum;
            }

            Array.Sort(arrayOfSums);

            foreach (var item in arrayOfSums)
                Console.WriteLine(item);
        }
    }
}
