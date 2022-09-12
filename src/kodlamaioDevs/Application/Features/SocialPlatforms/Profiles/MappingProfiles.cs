using System.Collections.Concurrent;
using Application.Features.SocialPlatforms.Command.CreateSocialPlatform;
using Application.Features.SocialPlatforms.Command.DeleteSocialPlatform;
using Application.Features.SocialPlatforms.Command.UpdateSocialPlatform;
using Application.Features.SocialPlatforms.Dtos;
using Application.Features.SocialPlatforms.Models;
using AutoMapper;
using Core.Persistence.Paging;
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

        CreateMap<SocialPlatform, SocialPlatformListDto>().ForMember(c => c.Email,
            opt => opt.MapFrom(c => c.User.Email)).ReverseMap();
        CreateMap<IPaginate<SocialPlatform>, GetListSocialPlatformDto>()
            .ForMember(c => c.Email, opt => opt.MapFrom(c => c.Items.First())).ReverseMap();
        CreateMap<IPaginate<SocialPlatform>, SocialPlatformModel>().ReverseMap();

    }
}