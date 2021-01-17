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
        }
    }
}
