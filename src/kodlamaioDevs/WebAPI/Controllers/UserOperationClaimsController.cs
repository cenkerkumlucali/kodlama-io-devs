
using Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Features.UserOperationClaims.Queries;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace WebApi.Controllers
{
    public class UserOperationClaimsController:BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            CreatedUserOperationClaimDto createdUserOperationClaimDto = await Mediator.Send(createUserOperationClaimCommand);
            return Created("", createdUserOperationClaimDto);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
        {
            DeletedUserOperationClaimDto deletedUserOperationClaimDto = await Mediator.Send(deleteUserOperationClaimCommand);
            return Ok(deletedUserOperationClaimDto);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
        {
            UpdatedUserOperationClaimDto updatedUserOperationClaimDto = await Mediator.Send(updateUserOperationClaimCommand);
            return Ok(updatedUserOperationClaimDto);
        }
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] ListUserOperationClaimQuery getAllUserOperationClaimQuery)
        {
            UserOperationClaimListModel userOperationClaimListModel = await Mediator.Send(getAllUserOperationClaimQuery);
            return Ok(userOperationClaimListModel);
        }
    }
}