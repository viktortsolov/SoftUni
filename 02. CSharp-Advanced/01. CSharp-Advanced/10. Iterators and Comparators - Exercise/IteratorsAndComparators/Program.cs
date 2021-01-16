using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listyIterator = new ListyIterator<string>(new List<string>());

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] cmdArg = input.Split();

                    string command = cmdArg[0];

                    switch (command)
                    {
                        case "Create":
                            List<string> elements = cmdArg
                                .Skip(1)
                                .ToList();

                            listyIterator = new ListyIterator<string>(elements);
                            break;

                        case "HasNext":
                            Console.WriteLine(listyIterator.HasNext());
                            break;

                        case "Print":
                            listyIterator.Print();
                            break;

                        case "Move":
                            Console.WriteLine(listyIterator.Move());
                            break;

                        case "PrintAll":
                            foreach (var item in listyIterator)
                            {
                                Console.Write($"{item} ");
                            }
                            Console.WriteLine();
                            break;
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
