using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
 
            StringBuilder text = new StringBuilder();
            Stack<string> lastCommands = new Stack<string>();

            lastCommands.Push(text.ToString());
 
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                int numberOfCommand = int.Parse(command[0]);
 
                switch (numberOfCommand)
                {
                    case 1:
                        text.Append(command[1]);
                        lastCommands.Push(text.ToString());
                        break;

                    case 2:
                        int number = int.Parse(command[1]);
                        text.Remove(text.Length - number, number);
                        lastCommands.Push(text.ToString());
                        break;

                    case 3:
                        int index = int.Parse(command[1]);
                        Console.WriteLine(text[index - 1]);
                        break;

                    case 4:
                        lastCommands.Pop();
                        text = new StringBuilder();
                        text.Append(lastCommands.Peek());
                        break;

                    default:
                        throw new ArgumentException("Unknown operator");
                }
            }
        }
    }
}
