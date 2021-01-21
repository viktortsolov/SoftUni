using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;

        public Person(double money, string name)
        {
            Money = money;
            Name = name;
        }

        public double Money
        {
            get 
            { 
                return money;
            }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value; 
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }


    }
}
