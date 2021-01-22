using System;

using ShoppingSpree.Common;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Cost = cost;
            this.Name = name;
        }

        public decimal Cost
        {
            get
            { 
                return this.cost;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.NEGATIVE_MONEY_EXC_MSG);
                }
                this.cost = value; 
            }
        }
        public string Name
        {
            get
            { 
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.EMPTY_NAME_EXC_MSG);
                }
                this.name = value; 
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
