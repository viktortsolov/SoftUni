using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            int currPos = 0;
            string sequence;
            string regex = @"&(?<type>.+)&[^<]*<(?<coord>.+)>";

            while ((sequence = Console.ReadLine()) != "find")
            {
                int keyLength = key.Count;
                int sequenceLength = sequence.Length;
                var sb = new StringBuilder();

                for (int i = keyLength; i < sequenceLength; i++)
                {
                    key.Add(key[currPos]);
                    currPos++;
                }

                for (int i = 0; i < sequenceLength; i++)
                {
                    sb.Append((char)(sequence[i] - key[i]));
                }

                Match m = Regex.Match(sb.ToString(), regex);

                if (m.Success)
                {
                    string type = m.Groups["type"].Value;
                    string coord = m.Groups["coord"].Value;
                    Console.WriteLine($"Found {type} at {coord}");
                }
            }
        }
    }
}
