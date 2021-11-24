using AutoMapper;
using ProductShop.Dtos.Input;
using ProductShop.Dtos.Output;
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

            CreateMap<Product, ProductOutputDTO>()
                .ForMember(dest => dest.Seller,
                           opt => opt.MapFrom
                           (scr => $"{scr.Seller.FirstName} {scr.Seller.LastName}"));
        }
    }
}
