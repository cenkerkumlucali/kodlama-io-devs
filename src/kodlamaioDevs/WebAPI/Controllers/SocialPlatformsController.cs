using Application.Features.SocialPlatforms.Command.CreateSocialPlatform;
using Application.Features.SocialPlatforms.Command.DeleteSocialPlatform;
using Application.Features.SocialPlatforms.Command.UpdateSocialPlatform;
using Application.Features.SocialPlatforms.Dtos;
using Application.Features.SocialPlatforms.Models;
using Application.Features.SocialPlatforms.Queries.GetByIdSocialPlatform;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialPlatformsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add(
            [FromBody] CreateSocialPlatformCommand createUserGithubEntityCommand)
        {
            CreatedSocialPlatformDto result = await Mediator.Send(createUserGithubEntityCommand);
            return Created("", result);
        }   

        [HttpPost("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateSocialPlatformCommand updateUserGithubCommand)
        {
            UpdatedSocialPlatformDto result = await Mediator.Send(updateUserGithubCommand);
            return Created("", result);
        }
        
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(
            [FromRoute] DeleteSocialPlatformCommand deleteUserGithubCommand)
        {
            DeletedSocialPlatformDto result = await Mediator.Send(deleteUserGithubCommand);
            return Created("", result);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetList(
            [FromQuery] GetListSocialPlatformQuery getByIdSocialPlatformQuery)
        {
            SocialPlatformModel result = await Mediator.Send(getByIdSocialPlatformQuery);
            return Ok(result);
        }
    }
}
