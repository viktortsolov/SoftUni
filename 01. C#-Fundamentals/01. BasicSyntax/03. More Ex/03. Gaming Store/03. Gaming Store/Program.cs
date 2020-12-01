using System;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            double totalSpent = 0;

            bool gameTime = true;
            string timeForGame = string.Empty;

            while (gameTime)
            {
                string nameOfGame = Console.ReadLine();
                if (nameOfGame == "Game Time")
                {
                    timeForGame = "Game Time"; gameTime = false; break;
                }
                double gamePrice = 0;
                if (nameOfGame == "OutFall 4")
                    gamePrice = 39.99;
                else if (nameOfGame == "CS: OG")
                    gamePrice = 15.99;
                else if (nameOfGame == "Zplinter Zell")
                    gamePrice = 19.99;
                else if (nameOfGame == "Honored 2")
                    gamePrice = 59.99;
                else if (nameOfGame == "RoverWatch")
                    gamePrice = 29.99;
                else if (nameOfGame == "RoverWatch Origins Edition")
                    gamePrice = 39.99;
                else
                { Console.WriteLine("Not Found"); break; }

                if (balance >= gamePrice) 
                { balance -= gamePrice; totalSpent += gamePrice; Console.WriteLine($"Bought {nameOfGame}"); }
                else
                    Console.WriteLine("Too Expensive");

                if (balance == 0)
                { Console.WriteLine("Out of money!"); break; }

            }

            if (timeForGame == "Game Time")
                Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${balance:f2}");
        }
    }
}
