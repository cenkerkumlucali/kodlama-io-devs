using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using static Application.Features.UserOperationClaims.Constants.Claims;


namespace Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;

public class UpdateUserOperationClaimCommand : IRequest<UpdatedUserOperationClaimDto>,ISecuredRequest
{
    public int UserId { get; set; }
    public int OperationId { get; set; }
    public string[] Roles => new[] { Admin };

    public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand,
        UpdatedUserOperationClaimDto>
    {
        private IUserOperationClaimRepository _userOperationClaimRepository;
        private IMapper _mapper;


        public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }


        public async Task<UpdatedUserOperationClaimDto> Handle(UpdateUserOperationClaimCommand request,
            CancellationToken cancellationToken)
        {
            UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request);
            UserOperationClaim updatedUserOperationClaim =
                await _userOperationClaimRepository.UpdateAsync(userOperationClaim);
            UpdatedUserOperationClaimDto updatedUserOperationDto =
                _mapper.Map<UpdatedUserOperationClaimDto>(updatedUserOperationClaim);
            return updatedUserOperationDto;
        }
    }
}