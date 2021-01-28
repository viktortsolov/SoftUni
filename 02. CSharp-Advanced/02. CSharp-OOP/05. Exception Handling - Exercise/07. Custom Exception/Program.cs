using System;

namespace _07._Custom_Exception
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string email = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            try
            {
                Person person = new Person(firstName, lastName, email, age);
                Console.WriteLine($"{person.FirstName} {person.LastName} with email: {person.Email} is {person.Age} years old.");
            }
            catch (InvalidPersonNameException exc)
            {
                Console.WriteLine($"{exc.Username} -> {exc.Message}");
            }
        }
    }
}
