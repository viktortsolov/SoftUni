using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private double cost;

        public Product(double cost, string name)
        {
            Cost = cost;
            Name = name;
        }

        public double Cost
        {
            get
            { 
                return cost;
            }
            set
            { 
                cost = value; 
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
                name = value; 
            }
        }

    }
}
