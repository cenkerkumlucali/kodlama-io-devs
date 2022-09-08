using Application.Features.UserOperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserOperationClaims.Queries;

public class GetUserOperationClaimByUserQuery : IRequest<UserOperationClaimListModel>
{
    public int UserId { get; set; }

    public class
        GetUserOperationClaimByUserQueryHandler : IRequestHandler<GetUserOperationClaimByUserQuery,
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

        public async Task<UserOperationClaimListModel> Handle(GetUserOperationClaimByUserQuery request,
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