using Core.Security.Enums;

namespace Application.Features.Auths.Dtos;

public class LoggedDto:RefreshedTokenDto
{
    public AuthenticatorType? AuthenticatorType { get; set; }
}