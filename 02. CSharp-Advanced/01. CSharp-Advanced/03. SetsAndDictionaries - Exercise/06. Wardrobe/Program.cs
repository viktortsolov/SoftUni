using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                                        .Split(" -> ");

                string colour = input[0];
                string[] clothesModel = input[1].Split(',');

                if (!clothes.ContainsKey(colour))
                {
                    clothes[colour] = new Dictionary<string, int>();
                }

                for (int k = 0; k < clothesModel.Length; k++)
                {
                    if (!clothes[colour].ContainsKey(clothesModel[k]))
                    {
                        clothes[colour].Add(clothesModel[k], 0);
                    }
                    clothes[colour][clothesModel[k]]++;
                }
            }

            string[] colorAndCloth = Console.ReadLine().Split();
            foreach (var item in clothes)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var cloth in item.Value)
                {
                    if (item.Key == colorAndCloth[0])
                    {
                        if (cloth.Key == colorAndCloth[1])
                        {
                            Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                            continue;
                        }
                    }
                    Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                }
            }
        }
    }
}
