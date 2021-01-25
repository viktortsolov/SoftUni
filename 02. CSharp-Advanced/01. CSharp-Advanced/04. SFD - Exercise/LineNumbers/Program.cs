using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"..\..\..\text.txt"))
            {
                using (StreamWriter writer = new StreamWriter(@"..\..\..\output.txt"))
                {
                    int lineCounter = 1;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string lineWithoutSpace = line.Replace(" ", "");
                        char[] charArray = lineWithoutSpace.ToCharArray();
                        int sumLetter = 0;
                        int sumPunctuationMarks = 0;

                        foreach (var symbol in charArray)
                        {
                            if (char.IsLetter(symbol))
                            {
                                sumLetter++;
                            }

                            else if (!char.IsLetter(symbol) && !char.IsDigit(symbol))
                            {
                                sumPunctuationMarks++;
                            }
                        }

                        writer.WriteLine($"Line {lineCounter}:{line}({sumLetter})({sumPunctuationMarks})");
                        lineCounter++;
                    }
                }
            }
        }
    }
}
