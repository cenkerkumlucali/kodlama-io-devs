using Application.Features.UserOperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.UserOperationClaims.Constants.Claims;


namespace Application.Features.UserOperationClaims.Queries;

public class ListUserOperationClaimQuery : IRequest<UserOperationClaimListModel>,ISecuredRequest
{
    public int UserId { get; set; }
    public string[] Roles => new[] { Admin };

    public class
        GetUserOperationClaimByUserQueryHandler : IRequestHandler<ListUserOperationClaimQuery,
            UserOperationClaimListModel>
    {
        IUserOperationClaimRepository _userOperationClaimRepository;
        IMapper _mapper;

        public GetUserOperationClaimByUserQueryHandler(IUserOperationClaimRepository userOperationClaimRepository,
            IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<UserOperationClaimListModel> Handle(ListUserOperationClaimQuery request,
            CancellationToken cancellationToken)
        {
            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(
                include: m => m.Include(c => c.User)
                    .Include(c => c.OperationClaim)
            );
            UserOperationClaimListModel userOperationClamListModel =
                _mapper.Map<UserOperationClaimListModel>(userOperationClaims);
            return userOperationClamListModel;
        }
    }
}