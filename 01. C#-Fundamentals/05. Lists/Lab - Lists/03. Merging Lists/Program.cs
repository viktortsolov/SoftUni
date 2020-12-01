using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
			List<int> firstNumbers = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();

			List<int> secondNumbers = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();

			List<int> result = new List<int>();

			if (firstNumbers.Count >= secondNumbers.Count)
			{
				for (int i = 0; i < firstNumbers.Count; i++)
				{
					result.Add(firstNumbers[i]);
					if (i < secondNumbers.Count)
					{
						result.Add(secondNumbers[i]);
					}
				}
			}
			else
			{
				for (int i = 0; i < secondNumbers.Count; i++)
				{
					if (i < firstNumbers.Count)
					{
						result.Add(firstNumbers[i]);
					}
					result.Add(secondNumbers[i]);
				}
			}
			Console.WriteLine(string.Join(" ", result));
		}
    }
}
