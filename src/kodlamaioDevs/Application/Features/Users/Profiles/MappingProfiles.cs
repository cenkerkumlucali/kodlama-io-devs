using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            
            CreateMap<IPaginate<User>,UserListModel>().ReverseMap();
            CreateMap<User,GetUserListDto>().ReverseMap();
        }
    }
}
