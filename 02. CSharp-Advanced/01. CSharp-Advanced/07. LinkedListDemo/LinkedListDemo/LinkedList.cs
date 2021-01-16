﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinkedListDemo
{
    public class LinkedList : IEnumerable<Node>
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public void AddFirst(Node newHead)
        {
            if (Head == null)
            {
                Head = newHead;
                Tail = newHead;
            }
            else 
            {
                newHead.Next = Head;
                Head.Previous = newHead;
                Head = newHead;
            }
        }

        public void AddLast(Node newTail)
        {
            if (Tail == null)
            {
                Tail = newTail;
                Head = newTail;
            }
            else
            {
                newTail.Previous = Tail;
                Tail.Next = newTail;
                Tail = newTail;
            }
        }
        
        public bool Contains(int value)
        {
            bool isFound = false;

            ForEach(node =>
            {
                if (node.Value == value) isFound = true;
            });

            return isFound;
        }

        public void ForEach(Action<Node> action)
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Next;
            }
        }

        public bool Remove(int value)
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    currentNode.Previous.Next = currentNode.Next;
                    currentNode.Next.Previous = currentNode.Previous;
                    return true;
                }
                currentNode = currentNode.Next;
            }

            return false;
        }

        public Node RemoveFirst()
        {
            var oldHead = this.Head;
            this.Head = this.Head.Next;
            Head.Previous = null;
            return oldHead;
        }

        public Node RemoveLast()
        {
            var oldTail = this.Tail;
            Tail = this.Tail.Previous;
            Tail.Next = null;
            return oldTail;
        }

        public void ReversePrintList()
        {
            Node currentNode = Tail;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Previous;
            }
        }

        public void PrintList()
        {
            this.ForEach(node => Console.WriteLine(node.Value));
        }

        public Node[] ToArray()
        {
            List<Node> list = new List<Node>();
            this.ForEach(node => list.Add(node));
            return list.ToArray();
        }

        public IEnumerator<Node> GetEnumerator()
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                yield return currentNode;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
