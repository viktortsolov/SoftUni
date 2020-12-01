using System;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder resultNumber = new StringBuilder();
            StringBuilder resultLetter = new StringBuilder();
            StringBuilder resultSymbol = new StringBuilder();


            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsDigit(text[i]))
                {
                    resultNumber.Append(text[i]);
                }
                else if(Char.IsLetter(text[i]))
                {
                    resultLetter.Append(text[i]);
                }
                else
                {
                    resultSymbol.Append(text[i]);
                }
            }

            Console.WriteLine(resultNumber);
            Console.WriteLine(resultLetter);
            Console.WriteLine(resultSymbol);
        }
    }
}
