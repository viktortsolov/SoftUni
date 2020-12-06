using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> songs = new Queue<string>(input.Split(", "));

            while (songs.Count > 0)
            {
                input = Console.ReadLine();

                if (input == "Play")
                {
                    songs.Dequeue();
                }
                else if (input == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
                else
                {
                    input = input.Remove(0, 3).Trim();
                    if (songs.Contains(input))
                    {
                        Console.WriteLine($"{input} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(input);
                    }
                }

                
            }
            Console.WriteLine("No more songs!");
        }
    }
}
