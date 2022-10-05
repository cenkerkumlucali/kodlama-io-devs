using Application.Features.OperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using static Application.Features.OperationClaims.Constants.Claims;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim;

public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>,ISecuredRequest
{
    public string Name { get; set; }
    public string[] Roles => new[] { Admin };

    public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand,
        CreatedOperationClaimDto>
    {
        private IOperationClaimRepository _operationClaimRepository;
        private IMapper _mapper;
        
        public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }


        public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request,
            CancellationToken cancellationToken)
        {
            OperationClaim operationClaim = _mapper.Map<OperationClaim>(request);
            OperationClaim createdOperationClaim =
                await _operationClaimRepository.AddAsync(operationClaim);
            CreatedOperationClaimDto createdOperationDto =
                _mapper.Map<CreatedOperationClaimDto>(createdOperationClaim);
            return createdOperationDto;
        }
    }
}