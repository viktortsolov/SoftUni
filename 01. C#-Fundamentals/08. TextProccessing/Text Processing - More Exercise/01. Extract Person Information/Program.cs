using System;
using System.Text;

namespace _01._Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine();

                int firstNameSymbol = 0;
                int firstAgeSymbol = 0;

                int secondNameSymbol = 0;
                int secondAgeSymbol = 0;

                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == '@')
                    {
                        firstNameSymbol = j;
                    }
                    else if (input[j] == '|')
                    {
                        secondNameSymbol = j;
                    }
                    else if (input[j] == '#')
                    {
                        firstAgeSymbol = j;
                    }
                    else if (input[j] == '*')
                    {
                        secondAgeSymbol = j;
                    }
                }

                string name = string.Empty;
                string ageAsString = string.Empty;

                for (int j = firstNameSymbol + 1; j < secondNameSymbol; j++)
                {
                    name += input[j].ToString();
                }

                for (int j = firstAgeSymbol + 1; j < secondAgeSymbol; j++)
                {
                    ageAsString += input[j].ToString();
                }

                int age = int.Parse(ageAsString);
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
