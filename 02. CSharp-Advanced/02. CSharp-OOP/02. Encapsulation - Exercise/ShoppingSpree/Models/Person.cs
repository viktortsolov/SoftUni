using System;
using System.Collections.Generic;

using ShoppingSpree.Common;

namespace ShoppingSpree
{
    public class Person
    {
        private const string NOT_ENOUGH_MONEY_EXC_MSG = "{0} can't afford {1}";
        private const string SUCC_BOUGHT_PRODUCT_MSG = "{0} bought {1}";

        private string name;
        private decimal money;
        private readonly ICollection<Product> bag;

        private Person()
        {
            this.bag = new List<Product>();
        }
        public Person(decimal money, string name)
             : this()
        {
            this.Money = money;
            this.Name = name;
        }

        public decimal Money
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.NEGATIVE_MONEY_EXC_MSG);
                }
                this.money = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
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
        public ICollection<Product> Bag
        {
            get
            {
                return (List<Product>)this.bag;
            }
        }

        public string BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                return string.Format(NOT_ENOUGH_MONEY_EXC_MSG, this.Name, product.Name);
            }
            else
            {
                this.Money -= product.Cost;
                this.Bag.Add(product);
                return string.Format(SUCC_BOUGHT_PRODUCT_MSG, this.Name, product.Name);
            }
        }

        public override string ToString()
        {
            string productsOutput = this.Bag.Count > 0 ? string.Join(", ", this.Bag) : "Nothing bought";

            return $"{this.Name} - {productsOutput}";
        }
    }
}
