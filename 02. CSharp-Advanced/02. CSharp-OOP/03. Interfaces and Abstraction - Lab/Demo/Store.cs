using Demo.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    class Store
    {
        public void BuyProduct(IPrice product, User user)
        {
            decimal price = product.Price;
            if (user.Money < price)
            {
                throw new ArgumentException("There is not enough money in your account!");
            }

            user.Money -= price;
            Console.WriteLine($"Bought: {product} for only {price} leva."); 
        }
    }
}
