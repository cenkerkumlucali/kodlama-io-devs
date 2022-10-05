
using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Application.Features.OperationClaims.Commands.UpdateUserOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using Application.Features.OperationClaims.Queries;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace WebApi.Controllers
{
    public class OperationClaimsController:BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            CreatedOperationClaimDto createdOperationClaimDto = await Mediator.Send(createOperationClaimCommand);
            return Created("", createdOperationClaimDto);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommand deleteOperationClaimCommand)
        {
            DeletedOperationClaimDto deletedOperationClaimDto = await Mediator.Send(deleteOperationClaimCommand);
            return Ok(deletedOperationClaimDto);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
        {
            UpdatedOperationClaimDto updatedOperationClaimDto = await Mediator.Send(updateOperationClaimCommand);
            return Ok(updatedOperationClaimDto);
        }
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] ListOperationClaimQuery getAllOperationClaimQuery)
        {
            OperationClaimListModel operationClaimListModel = await Mediator.Send(getAllOperationClaimQuery);
            return Ok(operationClaimListModel);
        }
    }
}