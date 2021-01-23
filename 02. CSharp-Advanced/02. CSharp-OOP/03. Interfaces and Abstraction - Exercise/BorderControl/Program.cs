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
                if (inputTokens.Length == 3)
                {
                    var name = inputTokens[0];
                    var age = int.Parse(inputTokens[1]);
                    var id = inputTokens[2];
                    IMember citizen = new Member(name, age, id);
                    members.Add(citizen);
                }
                else if (inputTokens.Length == 2)
                {
                    var model = inputTokens[0];
                    var id = inputTokens[1];
                    IMember robot = new Member(model, id);
                    members.Add(robot);
                }
            }

            var fakeId = Console.ReadLine();

            foreach (var member in members)
            {
                if (member.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(member.Id);
                }
            }
        }
    }
}
