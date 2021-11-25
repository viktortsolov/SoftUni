using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierInputDTO, Supplier>();
            CreateMap<PartInputDTO, Part>();
            CreateMap<CarInputDTO, Car>();
            CreateMap<CustomerInputDTO, Customer>();
            CreateMap<SaleInputDTO, Sale>();
        }
    }
}
