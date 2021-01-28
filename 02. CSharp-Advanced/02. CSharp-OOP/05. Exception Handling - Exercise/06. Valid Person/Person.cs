using System;

namespace _06._Valid_Person
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "The first name cannot be null or empty.");
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("value", "The last name cannot be null or empty.");
                }
                lastName = value;
            }
        }
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
