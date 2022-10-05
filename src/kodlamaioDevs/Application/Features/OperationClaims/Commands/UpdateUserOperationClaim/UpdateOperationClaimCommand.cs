using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using static Application.Features.OperationClaims.Constants.Claims;


namespace Application.Features.OperationClaims.Commands.UpdateUserOperationClaim;

public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimDto>,ISecuredRequest
{
    public string Name { get; set; }
    public string[] Roles => new[] { Admin };

    public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand,
        UpdatedOperationClaimDto>
    {
        private IOperationClaimRepository _operationClaimRepository;
        private IMapper _mapper;
        
        public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }


        public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request,
            CancellationToken cancellationToken)
        {
            OperationClaim operationClaim = _mapper.Map<OperationClaim>(request);
            OperationClaim updatedOperationClaim =
                await _operationClaimRepository.UpdateAsync(operationClaim);
            UpdatedOperationClaimDto updatedOperationDto =
                _mapper.Map<UpdatedOperationClaimDto>(updatedOperationClaim);
            return updatedOperationDto;
        }
    }
}