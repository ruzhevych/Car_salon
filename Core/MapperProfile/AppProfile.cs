using AutoMapper;
using Core.Dtos;
using Data.Entities;

namespace Core.MapperProfile
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<CreateCarsDto, Cars>();
            CreateMap<CarsDto, Cars>().ReverseMap();
            CreateMap<EditCarsDto, Cars>();
        }
    }
}
