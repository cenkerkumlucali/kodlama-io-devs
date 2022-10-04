using Core.Security.Enums;
using Core.Security.JWT;

namespace Application.Features.Auths.Dtos;

public class LoggedDto:RefreshedTokenDto
{
    public AuthenticatorType? AuthenticatorType { get; set; }
}