using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Models;

public class UserOperationClaimListModel:BasePageableModel
{
    public IList<OperationClaim> Items { get; set; }
}