using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, string> output = new Dictionary<string, string>();

            for (int i = 0; i < number; i++)
            {
                string[] cmdArg = Console.ReadLine().Split();
                string task = cmdArg[0];
                string username = cmdArg[1];

                if (task == "register")
                {
                    string licensePlateNumber = cmdArg[2];
                    if (!output.ContainsKey(username))
                    {
                        output.Add(username, licensePlateNumber);
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                }
                else if (task == "unregister")
                {
                    if (output.ContainsKey(username))
                    {
                        output.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach (var pair in output)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }
        }
    }
}
