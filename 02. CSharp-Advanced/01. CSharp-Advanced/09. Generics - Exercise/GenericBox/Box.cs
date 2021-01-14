using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBox
{
    class Box<T> where T: IComparable
    {
        public Box(List<T> values)
        {
            Values = values;
        }

        public List<T> Values { get; set; } = new List<T>();

        public void Swap(int first, int second)
        {
            T temp = Values[first];
            Values[first] = Values[second];
            Values[second] = temp;
        }

        public int CountOfGreaterElements(T element)
        {
            int counter = 0;

            foreach (T value in Values)
            {
                if (element.CompareTo(value) < 0)
                {
                    counter++;
                }
            }
            return counter;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in Values)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }

            return sb.ToString().Trim();
        }
    }
}
