using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictWordAppear = new Dictionary<string, int>();
            using (StreamReader readerWords = new StreamReader(@"..\..\..\words.txt"))
            {
                using (StreamReader readerText = new StreamReader(@"..\..\..\text.txt"))
                {
                    using (StreamWriter writerInActualResult = new StreamWriter(@"..\..\..\actualReasult.txt"))
                    {
                        using (StreamWriter writerInExpectedResult = new StreamWriter(@"..\..\..\expectedResult.txt"))
                        {
                            string[] wordsArray = readerWords.ReadToEnd().ToLower().Split();

                            while (!readerText.EndOfStream)
                            {
                                string[] lineArray = readerText.ReadLine()
                                    .ToLower()
                                    .Split(new char[] { ',', '.', '!', '?', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                                foreach (var wordInWordsArray in wordsArray)
                                {
                                    foreach (var wordInLineArray in lineArray)
                                    {
                                        if (string.Equals(wordInWordsArray, wordInLineArray))
                                        {
                                            if (!dictWordAppear.ContainsKey(wordInWordsArray))
                                            {
                                                dictWordAppear[wordInWordsArray] = 0;
                                            }

                                            dictWordAppear[wordInWordsArray]++;
                                        }
                                    }
                                }
                            }

                            foreach (var (word, appear) in dictWordAppear)
                            {
                                writerInActualResult.WriteLine($"{word} - {appear}");
                            }

                            var sortedDict = dictWordAppear.OrderByDescending(x => x.Value);
                            foreach (var (word, appear) in sortedDict)
                            {
                                writerInExpectedResult.WriteLine($"{word} - {appear}");
                            }
                        }
                    }
                }
            }
        }
    }
}
