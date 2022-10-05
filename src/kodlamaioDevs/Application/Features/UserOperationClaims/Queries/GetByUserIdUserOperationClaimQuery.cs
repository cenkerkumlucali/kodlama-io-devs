using Application.Features.UserOperationClaims.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserOperationClaims.Queries;

public class GetByUserIdUserOperationClaimQuery:IRequest<GetByUserIdUserOperationClaimDto>
{
    public int UserId { get; set; }
    public class GetByUserIdUserOperationClaimQueryHandler:IRequestHandler<GetByUserIdUserOperationClaimQuery,GetByUserIdUserOperationClaimDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;

        public GetByUserIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<GetByUserIdUserOperationClaimDto> Handle(GetByUserIdUserOperationClaimQuery request, CancellationToken cancellationToken)
        {
            var userOperationClaims = await _userOperationClaimRepository.GetListAsync(
                c=>c.UserId == request.UserId,
                include:m => 
                    m.Include(c => c.User)
                .Include(c => c.OperationClaim));
           var result = userOperationClaims.Items.Where(c => c.UserId == request.UserId);

           GetByUserIdUserOperationClaimDto getByUserIdUserOperationClaimDto = new()
           {
               Email = userOperationClaims.Items.FirstOrDefault(c => c.User.Id == request.UserId).User.Email,
               ClaimsName = userOperationClaims.Items.Select(c => c.OperationClaim.Name)
           };
           return getByUserIdUserOperationClaimDto;

        }
    }
}