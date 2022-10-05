using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using static Application.Features.UserOperationClaims.Constants.Claims;


namespace Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;

public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>,ISecuredRequest
{
    public int Id { get; set; }
    public string[] Roles => new[] { Admin };


    public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand,
        DeletedUserOperationClaimDto>
    {
        private IUserOperationClaimRepository _userOperationClaimRepository;
        private IMapper _mapper;


        public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }
        
        public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request,
            CancellationToken cancellationToken)
        {
            UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(request);
            UserOperationClaim deletedUserOperationClaim =
                await _userOperationClaimRepository.DeleteAsync(userOperationClaim);
            DeletedUserOperationClaimDto deletedUserOperationDto =
                _mapper.Map<DeletedUserOperationClaimDto>(deletedUserOperationClaim);
            return deletedUserOperationDto;
        }
    }
}