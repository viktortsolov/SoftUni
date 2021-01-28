using System;
using System.Linq;

namespace _07._Custom_Exception
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, string email, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
        }

        public string FirstName 
        { 
            get
            {
                return firstName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Any(x => char.IsDigit(x) || char.IsSymbol(x)))
                {
                    throw new InvalidPersonNameException(firstName, "The last name cannot be null or empty. The last name cannot contains digit or symbols.");
                }
                firstName = value;
            }
        }
        public string LastName 
        {
            get
            {
                return lastName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Any(x=>char.IsDigit(x) || char.IsSymbol(x)))
                {
                    throw new InvalidPersonNameException(lastName, "The last name cannot be null or empty. The last name cannot contains digit or symbols.");
                }
                lastName = value;
            }
        }
        public string Email { get; set; }
        public int Age 
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException("value", "Age should be in range [0 ... 120].");
                }
                age = value;
            }
        }
    }
}
