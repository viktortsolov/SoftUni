namespace SMS.Services
{
    using Microsoft.EntityFrameworkCore;
    using SMS.Contracts;
    using SMS.Data.Common;
    using SMS.Data.Models;
    using SMS.Models.Carts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CartService : ICartService
    {
        private readonly IRepository repo;
        public CartService(
            IRepository _repo)
        {
            repo = _repo;
        }

        public IEnumerable<CartViewModel> AddProduct(string productId, string userId)
        {
            var user = GetUser(userId);

            var product = repo.All<Product>()
                .FirstOrDefault(p => p.Id == productId);

            user.Cart.Products.Add(product);

            try
            {
                repo.SaveChanges();
            }
            catch (Exception)
            {
            }

            return user
                .Cart
                .Products
                .Select(p => new CartViewModel()
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString("F2")
                });
        }

        public void BuyProducts(string userId)
        {
            var user = GetUser(userId);

            user
                .Cart
                .Products
                .Clear();

            repo.SaveChanges();
        }

        private User GetUser(string userId)
            => repo.All<User>()
                            .Where(u => u.Id == userId)
                            .Include(u => u.Cart)
                            .ThenInclude(c => c.Products)
                            .FirstOrDefault();

        public IEnumerable<CartViewModel> GetProducts(string userId)
        {
            var user = GetUser(userId);

            return user
                .Cart
                .Products
                .Select(p => new CartViewModel()
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString("F2")
                });
        }
    }
}
