using System;

namespace LinkedListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            for (int i = 0; i < 5; i++)
            {
                list.AddFirst(new Node(i));
            }

            for (int i = 0; i < 5; i++)
            {
                list.AddLast(new Node(i));
            }

            list.RemoveFirst();
            list.RemoveFirst();
            list.RemoveFirst();

            list.RemoveLast();
            list.RemoveLast();
            list.RemoveLast();

            list.PrintList();
        }
    }
}
