using Application.Features.Auth.Commands;
using Application.Features.Auths.Dtos;
using Application.Features.Technology.Commands.CreateTechnology;
using Application.Features.Technology.Commands.DeleteTechnology;
using Application.Features.Technology.Commands.UpdateTechnology;
using Application.Features.Technology.Dtos;
using Application.Features.Technology.Models;
using Application.Features.Technology.Queries.GetListTechnology;
using Application.Features.User;
using Application.Features.UserOperationClaims.Queries;
using Application.Features.Users.Queries;
using Core.Application.Requests;
using Core.Security.JWT;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        ITokenHelper _tokenHelper;

        public AuthController(ITokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            RegisteredDto result = await Mediator.Send(registerCommand);
            return Created("", result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Register([FromBody] LoginCommand loginCommand)
        {
            LoginedDto result = await Mediator.Send(loginCommand);
            if (result == null)
            {
                return BadRequest("error");
            }
            return Created("", result.Token);
        }
    }
}


/*
{
    "userForRegisterDto": {
        "email": "cenker@cenker.com",
        "password": "cenker123",
        "firstName": "Cenker",
        "lastName": "Kumlucalı"
    }
}*/



/*{
    "userForLoginDto": {
        "email": "cenker1@cenker.com",
        "password": "cenker123"
    }
}*/