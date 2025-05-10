using AutoMapper;
using eMarket.Application.DTOs.Category;
using eMarket.Application.DTOs.Product;
using eMarket.Domain.Entities;

namespace eMarket.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<Product, ProductListDto>();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}