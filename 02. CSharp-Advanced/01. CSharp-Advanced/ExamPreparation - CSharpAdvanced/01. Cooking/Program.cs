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
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> ingrediants = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int breads = 0;
            int cakes = 0;
            int pastries = 0;
            int fruitPies = 0;

            bool areCooked = false;
            bool areEmpty = false;

            StringBuilder stringBuilder = new StringBuilder();
            while (!areEmpty)
            {
                int liquid = liquids.Dequeue();
                int ingrediant = ingrediants.Pop();

                int sum = liquid + ingrediant;
                switch (sum)
                {
                    case 25:
                        breads++;
                        break;

                    case 50:
                        cakes++;
                        break;

                    case 75:
                        pastries++;
                        break;

                    case 100:
                        fruitPies++;
                        break;

                    default:
                        ingrediants.Push(ingrediant + 3);
                        break;
                }

                areCooked = breads > 0 && cakes > 0 && pastries > 0 && fruitPies > 0;
                areEmpty = liquids.Count == 0 || ingrediants.Count == 0;

            }


            if (areCooked)
            {
                stringBuilder.AppendLine("Wohoo! You succeeded in cooking all the food!");

                string resultLiquids = liquids.Count == 0 ? "none" : string.Join(", ", liquids);
                stringBuilder.AppendLine($"Liquids left: {resultLiquids}");

                string resultIngrediants = ingrediants.Count == 0 ? "none" : string.Join(", ", ingrediants);
                stringBuilder.AppendLine($"Ingredients left: {resultIngrediants}");

                stringBuilder.AppendLine($"Bread: {breads}\nCake: {cakes}\nFruit Pie: {fruitPies}\nPastry: {pastries}");
            }
            else
            {
                stringBuilder.AppendLine("Ugh, what a pity! You didn't have enough materials to cook everything.");

                string resultLiquids = liquids.Count == 0 ? "none" : string.Join(", ", liquids);
                stringBuilder.AppendLine($"Liquids left: {resultLiquids}");

                string resultIngrediants = ingrediants.Count == 0 ? "none" : string.Join(", ", ingrediants);
                stringBuilder.AppendLine($"Ingredients left: {resultIngrediants}");

                stringBuilder.AppendLine($"Bread: {breads}\nCake: {cakes}\nFruit Pie: {fruitPies}\nPastry: {pastries}");
            }
            Console.WriteLine(stringBuilder.ToString().Trim());
        }
    }
}
