using System;

namespace _01._Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Sign up")
            {
                string[] cmdArg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = cmdArg[0];

                switch (command)
                {
                    case "Case":
                        string lowerOrUpper = cmdArg[1];
                        if (lowerOrUpper == "lower")
                        {
                            username = username.ToLower();
                        }
                        else if (lowerOrUpper == "upper")
                        {
                            username = username.ToUpper();
                        }
                        Console.WriteLine(username);
                        break;

                    case "Reverse":
                        int startIndex = int.Parse(cmdArg[1]);
                        int endIndex = int.Parse(cmdArg[2]);

                        bool isValid = (startIndex >= 0 && startIndex < username.Length) &&
                                       (endIndex >= 0 && endIndex < username.Length);

                        if (isValid)
                        {
                            string substring = username.Substring(startIndex, endIndex - startIndex + 1);
                            string result = string.Empty;

                            for (int i = substring.Length - 1; i >= 0; i--)
                            {
                                result += substring[i];
                            }
                            Console.WriteLine(result);
                        }
                        break;

                    case "Cut":
                        string contain = cmdArg[1];

                        if (username.Contains(contain))
                        {
                            int index = username.IndexOf(contain);
                            username = username.Remove(index, contain.Length);
                            Console.WriteLine(username);
                        }
                        else
                        {
                            Console.WriteLine($"The word {username} doesn't contain {contain}.");
                        }
                        break;

                    case "Replace":
                        char symbol = char.Parse(cmdArg[1]);

                        username = username.Replace(symbol, '*');
                        Console.WriteLine(username);
                        break;

                    case "Check":
                        symbol = char.Parse(cmdArg[1]);

                        if (username.Contains(symbol))
                        {
                            Console.WriteLine("Valid");
                        }
                        else
                        {
                            Console.WriteLine($"Your username must contain {symbol}.");
                        }
                        break;
                }
            }
        }
    }
}