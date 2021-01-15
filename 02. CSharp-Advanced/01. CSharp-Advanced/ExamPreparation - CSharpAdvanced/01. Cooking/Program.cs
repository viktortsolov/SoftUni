using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>
                (Console.ReadLine()       
                        .Split()
                        .Select(int.Parse));

            Stack<int> ingrediants = new Stack<int>
                (Console.ReadLine()
                        .Split()
                        .Select(int.Parse));

            int breads = 0;
            int cakes = 0;
            int pastries = 0;
            int fruitPies = 0;

            while (liquids.Count > 0 && ingrediants.Count > 0)
            {
                int sum = liquids.Dequeue() + ingrediants.Peek();

                if (sum == 25)
                {
                    breads++;
                    ingrediants.Pop();

                }
                else if(sum == 50)
                {
                    cakes++;
                    ingrediants.Pop();

                }
                else if(sum == 75)
                {
                    pastries++;
                    ingrediants.Pop();
                }
                else if (sum == 100)
                {
                    fruitPies++;
                    ingrediants.Pop();
                }
                else
                {
                    int[] array = new int[ingrediants.Count];

                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = ingrediants.Pop() + 3;
                    }

                    array = array.Reverse().ToArray();
                    foreach (var item in array)
                    {
                        ingrediants.Push(item);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();

            if (breads > 0 && cakes > 0 && pastries > 0 && fruitPies > 0)
            {
                sb.AppendLine($"Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                sb.AppendLine($"Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count > 0)
            {
                sb.AppendLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                sb.AppendLine($"Liquids left: none");
            }

            if (ingrediants.Count > 0)
            {
                sb.AppendLine($"Ingredients left: {string.Join(", ", ingrediants)}");
            }
            else
            {
                sb.AppendLine($"Ingredients left: none");
            }

            sb.AppendLine($"Bread: {breads}");
            sb.AppendLine($"Cake: {cakes}");
            sb.AppendLine($"Fruit Pie: {fruitPies}");
            sb.AppendLine($"Pastry: {pastries}");

            Console.WriteLine(sb.ToString());
        }
    }
}
