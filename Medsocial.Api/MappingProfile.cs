using AutoMapper;
using Entities.Models;
using Shared.Dtos;

namespace Medsocial.Solution;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserDto, User>().ReverseMap();

        CreateMap<CityDto, City>().ReverseMap();
        CreateMap<CountryDto, Country>().ReverseMap();
        CreateMap<TimezoneDto, Timezone>().ReverseMap();
        CreateMap<Gender, GenderDto>().ReverseMap();
    }
}