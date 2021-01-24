using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var people = new List<IBuyer>();

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var inputTokens = Console.ReadLine().Split();
                if (inputTokens.Length == 4)
                {
                    var name = inputTokens[0];
                    var age = int.Parse(inputTokens[1]);
                    var id = inputTokens[2];
                    var birthdate = inputTokens[3];
                    IBuyer citizen = new Citizen(name, age, id, birthdate);
                    people.Add(citizen);
                }
                else if (inputTokens.Length == 3)
                {
                    var name = inputTokens[0];
                    var age = int.Parse(inputTokens[1]);
                    var group = inputTokens[2];
                    IBuyer rebel = new Rebel(name, age, group);
                    people.Add(rebel);
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var name = input;
                foreach (var buyer in people)
                {
                    if (buyer.Name == name)
                    {
                        buyer.BuyFood();
                        break;
                    }
                }
            }

            var totalFood = people.Sum(x => x.Food);
            Console.WriteLine(totalFood);
        }
    }
}
