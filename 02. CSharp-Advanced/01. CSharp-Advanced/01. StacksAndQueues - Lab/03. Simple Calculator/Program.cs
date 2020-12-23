using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<string> stack = new Stack<string>(input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse());

            while (stack.Count > 1)
            {
                int operandOne = int.Parse(stack.Pop());
                string option = stack.Pop();
                int operandTwo = int.Parse(stack.Pop());

                switch (option)
                {
                    case "+":
                        stack.Push((operandOne + operandTwo).ToString());
                        break;

                    case "-":
                        stack.Push((operandOne - operandTwo).ToString());
                        break;

                    default:
                        throw new ArgumentException("Unknown operator");
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
