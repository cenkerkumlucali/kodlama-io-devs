using Application.Features.Technology.Commands.CreateTechnology;
using Application.Features.Technology.Commands.DeleteTechnology;
using Application.Features.Technology.Commands.UpdateTechnology;
using Application.Features.Technology.Dtos;
using Application.Features.Technology.Models;
using Application.Features.Technology.Queries.GetListTechnology;
using Application.Features.UserGithub.Command.CreateUserGithub;
using Application.Features.UserGithub.Dtos;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGithubsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add(
            [FromBody] CreateUserGithubCommand createUserGithubEntityCommand)
        {
            CreatedUserGithubDto result = await Mediator.Send(createUserGithubEntityCommand);
            return Created("", result);
        }   

        [HttpPost("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateUserGithubCommand updateUserGithubCommand)
        {
            UpdatedUserGithubDto result = await Mediator.Send(updateUserGithubCommand);
            return Created("", result);
        }
        
        [HttpPost("delete/{Id}")]
        public async Task<IActionResult> Delete(
            [FromRoute] DeleteUserGithubCommand deleteUserGithubCommand)
        {
            DeletedUserGithubDto result = await Mediator.Send(deleteUserGithubCommand);
            return Created("", result);
        }
    
    }
}
