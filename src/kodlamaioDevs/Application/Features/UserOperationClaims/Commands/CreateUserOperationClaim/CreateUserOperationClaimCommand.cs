using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using static Application.Features.UserOperationClaims.Constants.Claims;


namespace Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;

public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimDto>,ISecuredRequest
{
    public int UserId { get; set; }
    public int OperationId { get; set; }
    public string[] Roles => new[] { Admin };

    
    public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand,
        CreatedUserOperationClaimDto>
    {
        private IUserOperationClaimRepository _userOperationClaimRepository;
        private IMapper _mapper;


        public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }


        public async Task<CreatedUserOperationClaimDto> Handle(CreateUserOperationClaimCommand request,
            CancellationToken cancellationToken)
        {
            UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request);
            UserOperationClaim createdUserOperationClaim =
                await _userOperationClaimRepository.AddAsync(userOperationClaim);
            CreatedUserOperationClaimDto createdUserOperationDto =
                _mapper.Map<CreatedUserOperationClaimDto>(createdUserOperationClaim);
            return createdUserOperationDto;
        }
    }
}