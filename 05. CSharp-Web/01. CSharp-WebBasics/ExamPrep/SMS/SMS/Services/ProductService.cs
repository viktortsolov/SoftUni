namespace SMS.Services
{
    using SMS.Contracts;
    using SMS.Data.Common;
    using SMS.Models.Products;

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

        public (bool created, string error) Create(CreateViewModel model)
        {
            var (isValid, error) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, error);
            }
        }
    }
}
