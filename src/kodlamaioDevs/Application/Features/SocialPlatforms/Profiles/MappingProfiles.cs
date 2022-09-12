using Application.Features.SocialPlatforms.Command.CreateSocialPlatform;
using Application.Features.SocialPlatforms.Command.DeleteSocialPlatform;
using Application.Features.SocialPlatforms.Command.UpdateSocialPlatform;
using Application.Features.SocialPlatforms.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.SocialPlatforms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SocialPlatform, CreatedSocialPlatformDto>().ReverseMap();
        CreateMap<SocialPlatform, CreateSocialPlatformCommand>().ReverseMap();

        CreateMap<SocialPlatform, UpdatedSocialPlatformDto>().ReverseMap();
        CreateMap<SocialPlatform, UpdateSocialPlatformCommand>().ReverseMap();

        CreateMap<SocialPlatform, DeletedSocialPlatformDto>().ReverseMap();
        CreateMap<SocialPlatform, DeleteSocialPlatformCommand>().ReverseMap();

        CreateMap<SocialPlatform, SocialPlatformListDto>().ForMember(c => c.UserName,
            opt => opt.MapFrom(c => c.User.FirstName + c.User.LastName)).ReverseMap();
    }
}