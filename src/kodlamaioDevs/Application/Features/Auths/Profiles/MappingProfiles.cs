using Application.Features.Auths.Dtos;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.Auths.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        
        //Login
        CreateMap<User, LoggedDto>().ReverseMap();
    }
}