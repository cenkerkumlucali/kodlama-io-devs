using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Commands.Register;
using Application.Features.Auths.Dtos;
using Application.Features.Technology.Commands.CreateTechnology;
using Application.Features.Technology.Commands.DeleteTechnology;
using Application.Features.Technology.Commands.UpdateTechnology;
using Application.Features.Technology.Dtos;
using Application.Features.Technology.Models;
using Application.Features.Technology.Queries.GetListTechnology;
using Application.Features.UserOperationClaims.Queries;
using Application.Features.Users.Queries;
using Core.Application.Requests;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new()
            {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = GetIpAddress()
            };

            RegisteredDto result = await Mediator.Send(registerCommand);
            SetRefreshTokenToCookie(result.RefreshToken);
            return Created("",result.AccessToken);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new()
            {
                UserForLoginDto = userForLoginDto,
                IPAddress = GetIpAddress()
            };
            
            LoggedDto result = await Mediator.Send(loginCommand);

            SetRefreshTokenToCookie(result.RefreshToken);

            return Ok(result.AccessToken);
        }
        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true ,Expires = DateTime.Now.AddDays(7)};
            Response.Cookies.Append("refreshToken",refreshToken.Token, cookieOptions);
        }
    }
}


/* REGISTER
{
    "email": "cenker@cenker.com",
    "password": "cenker123",
    "firstName": "Cenker",
    "lastName": "Kumlucalı"
}
*/



/* LOGIN
 {
    "email": "cenker@cenker.com",
    "password": "cenker123",
    "authenticatorCode": "0"
}
*/