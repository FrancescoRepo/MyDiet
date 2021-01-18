using AutoMapper;
using MyDiet.Models;
using MyDiet.Models.Dtos;

namespace MyDiet.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDto>();
            CreateMap<PatientDto, Patient>();

            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductCategoryDto, ProductCategory>();

            CreateMap<Product, ProductDto>();
            //.ForMember(dest => dest.ProductCategory.Id, opt => opt.MapFrom(src => src.ProductCategoryId))
            //.ForMember(dest => dest.ProductCategory.Description, opt => opt.MapFrom(src => src.ProductCategory.Description));
            CreateMap<ProductDto, Product>();
                //.ForMember(dest => dest.ProductCategoryId, opt => opt.MapFrom(src => src.ProductCategory.Id));
        }
    }
}
