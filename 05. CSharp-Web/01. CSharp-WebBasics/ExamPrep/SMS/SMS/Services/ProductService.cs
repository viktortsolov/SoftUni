namespace SMS.Services
{
    using SMS.Contracts;
    using SMS.Data.Common;
    using SMS.Data.Models;
    using SMS.Models.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductService : IProductService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public ProductService(
            IRepository _repo,
            IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public (bool created, string error) Create(CreateProductViewModel model)
        {
            bool created = false;
            string error = null;

            var (isValid, validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            var product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
            };

            try
            {
                repo.Add(product);
                repo.SaveChanges();
                created = true;
            }
            catch (Exception)
            {
                error = "Could not save the product!";
            }

            return (created, error);
        }

        public IEnumerable<ProductListViewModel> GetProducts()
        {
            return repo.All<Product>()
                .Select(x => new ProductListViewModel()
                {
                    ProductName = x.Name,
                    ProductPrice = x.Price.ToString("F2"),
                    ProductId = x.Id
                })
                .ToList();
        }
    }
}
