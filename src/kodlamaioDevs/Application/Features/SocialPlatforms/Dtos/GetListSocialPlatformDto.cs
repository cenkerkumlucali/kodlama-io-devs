using Domain.Entities;

namespace Application.Features.SocialPlatforms.Dtos;

public class GetListSocialPlatformDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Text { get; set; }
}