﻿using Application.Features.Auths.Dtos;
using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;

namespace Application.Features.Auths.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //Register
        CreateMap<Core.Security.Entities.User, RegisteredDto>().ReverseMap(); 
        CreateMap<AccessToken, RegisteredDto>().ReverseMap();

        //Login
        CreateMap<Core.Security.Entities.User, LoginedDto>().ReverseMap();
    }
}