using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArg = input.Split();
                string name = cmdArg[0];
                string id = cmdArg[1];
                int age = int.Parse(cmdArg[2]);

                Person person = new Person(name, id, age);

                people.Add(person);
            }

            people = people.OrderBy(x => x.Age).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, people));
        }
    }

    class Person
    {
        public Person(string name, string iD, int age)
        {
            Name = name;
            ID = iD;
            Age = age;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
