using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using static Application.Features.OperationClaims.Constants.Claims;


namespace Application.Features.OperationClaims.Commands.DeleteOperationClaim;

public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimDto>,ISecuredRequest
{
    public int Id { get; set; }
    public string[] Roles => new[] { Admin };

    
    public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand,
        DeletedOperationClaimDto>
    {
        private IOperationClaimRepository _operationClaimRepository;
        private IMapper _mapper;
        
        public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }


        public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimCommand request,
            CancellationToken cancellationToken)
        {
            OperationClaim operationClaim = _mapper.Map<OperationClaim>(request);
            OperationClaim deletedOperationClaim =
                await _operationClaimRepository.DeleteAsync(operationClaim);
            DeletedOperationClaimDto deletedOperationDto =
                _mapper.Map<DeletedOperationClaimDto>(deletedOperationClaim);
            return deletedOperationDto;
        }
    }
}