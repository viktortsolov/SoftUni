using AutoMapper;
using ProductShop.Dtos.Input;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UserInputDTO, User>();
            CreateMap<ProductInputDTO, Product>();
            CreateMap<CategoryInputDTO, Category>();
            CreateMap<CategoryProductsInputDTO, CategoryProduct>();
        }
    }
}
