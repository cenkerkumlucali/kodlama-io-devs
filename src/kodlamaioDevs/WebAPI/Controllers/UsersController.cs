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
using Application.Features.Users.Models;
using Application.Features.Users.Queries;
using Application.Features.Users.Queries.GetListUser;
using Core.Application.Requests;
using Core.Security.JWT;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Register([FromQuery] PageRequest pageRequest)
        {
            GetListUserQuery getListUserQuery = new() { PageRequest = pageRequest };
            UserListModel result = await Mediator.Send(getListUserQuery);
            return Ok(result);
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