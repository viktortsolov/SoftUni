namespace SMS.Contracts
{
    using SMS.Models.Products;

    public interface IProductService
    {
        (bool created, string error) Create(CreateViewModel model);
    }
}
