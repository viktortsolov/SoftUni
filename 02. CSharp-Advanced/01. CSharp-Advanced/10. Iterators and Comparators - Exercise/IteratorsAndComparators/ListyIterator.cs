using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int currentIndex;
        private List<T> items;

        public ListyIterator(List<T> initialItems)
        {
            currentIndex = 0;
            items = initialItems;
        }

        public int Count => items.Count;

        public bool Move()
        {
            if (HasNext())
            {
                currentIndex++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (currentIndex < Count - 1)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(items[this.currentIndex]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
