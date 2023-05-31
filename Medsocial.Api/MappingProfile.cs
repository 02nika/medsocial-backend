using AutoMapper;
using Entities.Models;
using Shared.Dtos;

namespace Medsocial.Solution;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<UserStatusDto, UserStatus>().ReverseMap();
    }
}