using Application.Features.OperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using static Application.Features.OperationClaims.Constants.Claims;

namespace Application.Features.OperationClaims.Queries;

public class ListOperationClaimQuery : IRequest<OperationClaimListModel>,ISecuredRequest
{
    public PageRequest PageRequest { get; set; }
    public string[] Roles => new[] { Admin };


    public class ListOperationClaimQueryHandler : IRequestHandler<ListOperationClaimQuery,OperationClaimListModel>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private IMapper _mapper;

        public ListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository,
            IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }

        public async Task<OperationClaimListModel> Handle(ListOperationClaimQuery request,
            CancellationToken cancellationToken)
        {
            IPaginate<OperationClaim> operationClaims = await _operationClaimRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
            OperationClaimListModel operationClamListModel =
                _mapper.Map<OperationClaimListModel>(operationClaims);
            return operationClamListModel;
        }
    }
}