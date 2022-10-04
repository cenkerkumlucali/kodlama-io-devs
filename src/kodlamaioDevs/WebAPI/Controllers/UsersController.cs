using Application.Features.Users.Models;
using Application.Features.Users.Queries.GetListUser;
using Core.Application.Requests;
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