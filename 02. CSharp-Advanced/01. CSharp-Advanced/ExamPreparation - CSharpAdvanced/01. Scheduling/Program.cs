using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int tasksToBeKilled = int.Parse(Console.ReadLine());

            while (true)
            {
                if (threads.Peek() >= tasks.Peek())
                {
                    if (tasks.Pop() == tasksToBeKilled)
                    {
                        Console.WriteLine($"Thread with value {threads.Peek()} killed task {tasksToBeKilled}");
                        Console.WriteLine(string.Join(" ", threads));
                        break;
                    }
                    else
                    {
                        threads.Dequeue();
                    }
                    
                }
                else if (threads.Peek() < tasks.Peek())
                {
                    if (tasks.Peek() == tasksToBeKilled)
                    {
                        Console.WriteLine($"Thread with value {threads.Peek()} killed task {tasksToBeKilled}");
                        Console.WriteLine(string.Join(" ", threads));
                        break;
                    }
                    else 
                        threads.Dequeue();
                }
            }
        }
    }
}
