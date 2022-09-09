using Core.Security.JWT;

namespace Application.Features.Auths.Dtos;

public class LoginedDto
{
    public AccessToken AccessToken { get; set; }
}