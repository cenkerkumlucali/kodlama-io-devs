using Application.Features.Technology.Commands.CreateTechnology;
using Application.Features.Technology.Commands.DeleteTechnology;
using Application.Features.Technology.Commands.UpdateTechnology;
using Application.Features.Technology.Dtos;
using Application.Features.Technology.Models;
using Application.Features.UserGithub.Command.CreateUserGithub;
using Application.Features.UserGithub.Dtos;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.UserGithub.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.UserGithub, CreatedUserGithubDto>().ReverseMap();
        CreateMap<Domain.Entities.UserGithub, CreateUserGithubCommand>().ReverseMap();

        CreateMap<Domain.Entities.UserGithub, UpdatedUserGithubDto>().ReverseMap();
        CreateMap<Domain.Entities.UserGithub, UpdateUserGithubCommand>().ReverseMap();

        CreateMap<Domain.Entities.UserGithub, DeletedUserGithubDto>().ReverseMap();
        CreateMap<Domain.Entities.UserGithub, DeleteUserGithubCommand>().ReverseMap();

        CreateMap<Domain.Entities.UserGithub, UserGithubListDto>().ForMember(c => c.UserName,
            opt => opt.MapFrom(c => c.User.FirstName + c.User.LastName)).ReverseMap();
    }
}