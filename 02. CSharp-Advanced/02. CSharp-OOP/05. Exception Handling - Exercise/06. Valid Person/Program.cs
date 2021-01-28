using System;

namespace _06._Valid_Person
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            try
            {
                Person person = new Person(firstName, lastName, age);
                Console.WriteLine($"{person.FirstName} {person.LastName} is {person.Age} years old.");
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("Exception thrown: {0}", ane.Message);
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine("Exception thrown: {0}", aore.Message);
            }
        }
    }
}
