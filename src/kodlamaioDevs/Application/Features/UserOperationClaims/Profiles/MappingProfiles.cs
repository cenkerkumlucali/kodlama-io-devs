using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();
        CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();

        // CreateMap<UserOperationClaim, UpdatedUserOperationClaimDto>().ReverseMap();
        // CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
        //
        // CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();
        // CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();

        CreateMap<UserOperationClaim, UserOperationClaimListDto>().ReverseMap();
        CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();
        
    }
}