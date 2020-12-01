using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._Take_Or_Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            List<int> numbers = new List<int>();
            List<string> symbols = new List<string>();

            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] >= '0' && message[i] <= '9')
                {
                    numbers.Add(int.Parse(message[i].ToString()));
                }
                else
                {
                    symbols.Add(message[i].ToString());
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }

            int indexForSkip = 0;
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < takeList.Count; i++)
            {
                List<string> temp = new List<string>(symbols);

                temp = temp.Skip(indexForSkip).Take(takeList[i]).ToList();

                result.Append(string.Join("", temp));

                indexForSkip += takeList[i] + skipList[i];
            }

            Console.WriteLine(result.ToString());
        }
    }
}
