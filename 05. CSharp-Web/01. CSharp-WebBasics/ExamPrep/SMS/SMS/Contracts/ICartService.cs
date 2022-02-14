namespace SMS.Contracts
{
    using SMS.Models.Carts;
    using System.Collections.Generic;

    public interface ICartService
    {
        IEnumerable<CartViewModel> AddProduct(string productId, string userId);

        void BuyProducts(string userId);

        IEnumerable<CartViewModel> GetProducts(string userId);
    }
}
