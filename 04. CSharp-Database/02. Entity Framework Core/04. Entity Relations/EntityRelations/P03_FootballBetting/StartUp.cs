namespace P03_FootballBetting
{
    using System;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        static void Main(string[] args)
        {
            FootballBettingContext footballBettingContext = new FootballBettingContext();

            footballBettingContext.Database.Migrate();

            Console.WriteLine("Football Betting Database created successfully!");
        }
    }
}
