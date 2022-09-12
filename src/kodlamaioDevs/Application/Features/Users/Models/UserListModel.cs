using Application.Features.Users.Dtos;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.Users.Models;

public class UserListModel:BasePageableModel
{
    public IList<GetUserListDto> Items { get; set; }

}