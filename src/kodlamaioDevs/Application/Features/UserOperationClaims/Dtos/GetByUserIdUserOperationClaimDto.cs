using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Dtos;

public class GetByUserIdUserOperationClaimDto
{
    public string Email { get; set; }
    public IEnumerable<string> ClaimsName { get; set; }
}