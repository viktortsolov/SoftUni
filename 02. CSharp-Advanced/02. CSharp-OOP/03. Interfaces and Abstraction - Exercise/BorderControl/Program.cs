using System;
using System.Collections.Generic;
using BorderControl.Interfaces;
using BorderControl.Models;

namespace BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var members = new List<IMember>();
            while ((input = Console.ReadLine()) != "End")
            {
                var inputTokens = input.Split();
                var type = inputTokens[0];
                switch (type)
                {
                    case "Citizen":
                        IMember citizen = new Member(inputTokens[1], int.Parse(inputTokens[2]), long.Parse(inputTokens[3]), inputTokens[4]);
                        members.Add(citizen);
                        break;
                    case "Pet":
                        IMember pet = new Member(inputTokens[1], inputTokens[2]);
                        members.Add(pet);
                        break;
                    case "Robot":
                        IMember robot = new Member(inputTokens[1], long.Parse(inputTokens[2]));
                        break;
                }
            }

            var searchedYear = Console.ReadLine();

            foreach (var member in members)
            {
                if (member.Birthdate.EndsWith(searchedYear))
                {
                    Console.WriteLine(member.Birthdate);
                }
            }
        }
    }
}
