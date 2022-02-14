namespace SMS.Contracts
{
    using SMS.Models.Products;
    using System.Collections.Generic;

    public interface IProductService
    {
        (bool created, string error) Create(CreateProductViewModel model);
        IEnumerable<ProductListViewModel> GetProducts();
    }
}
