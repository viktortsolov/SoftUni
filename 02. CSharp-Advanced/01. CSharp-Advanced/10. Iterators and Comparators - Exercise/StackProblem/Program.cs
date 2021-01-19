using System;
using System.Linq;

namespace StackProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> myStack = new MyStack<int>();

            string commandInput = string.Empty;

            while ((commandInput = Console.ReadLine()) != "END")
            {
                string[] tokens = commandInput.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if (command == "Push")
                {
                    foreach (var item in tokens.Skip(1).Select(int.Parse))
                    {
                        myStack.Push(item);
                    }
                }
                else if (command == "Pop")
                {
                    if (myStack.Count == 0)
                    {
                        Console.WriteLine("No elements");
                    }
                    else
                    {
                        myStack.Pop();
                    }
                }
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
