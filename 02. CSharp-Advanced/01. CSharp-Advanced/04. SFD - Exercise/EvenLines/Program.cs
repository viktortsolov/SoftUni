using System;
using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"..\..\..\text.txt"))
            {
                using (StreamWriter writer = new StreamWriter(@"..\..\..\output.txt"))
                {
                    char[] replaceElements = new char[] { '-', '.', ',', '?', '!' };
                    int lineCounter = 0;

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (lineCounter % 2 == 0)
                        {
                            StringBuilder sb = new StringBuilder(line);
                            foreach (char element in replaceElements)
                            {
                                if (sb.ToString().Contains(element))
                                {
                                    sb.Replace(element, '@');
                                }
                            }

                            var list = sb.ToString()
                                .Split(" ")
                                .Reverse()
                                .ToList();

                            sb.Clear();

                            for (int i = 0; i < list.Count; i++)
                            {
                                sb.Append(list[i]);
                                sb.Append(" ");
                            }

                            writer.WriteLine(sb);
                            list.Clear();
                        }

                        lineCounter++;
                    }
                }
            }
        }
    }
}
