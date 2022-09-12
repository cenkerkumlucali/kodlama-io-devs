using Application.Features.SocialPlatforms.Dtos;

namespace Application.Features.SocialPlatforms.Models;

public class SocialPlatformModel
{
    public IList<SocialPlatformListDto> Items { get; set; }
}