namespace Application.Features.Auths.Dtos;

public class LoginedDto
{
    public int UserId { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
}