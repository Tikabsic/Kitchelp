using Application.DTOs;
using Application.Interfaces.InvitationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kitchelp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvitationController : ControllerBase
    {
        private readonly IInvitationService _invitationService;
        public InvitationController(IInvitationService invitationService)
        {
            _invitationService = invitationService;
        }

        [Authorize(policy: "RequireOwnerRole")]
        [HttpPost("/InviteEmployee/{restaurantId}")]
        public async Task<ActionResult> InviteNewEmployee([FromRoute]Guid restaurantId, [FromHeader]Guid ownerId, [FromBody]InvitationRequest invitationRequest)
        {
            var request = await _invitationService.InviteNewEmployee(invitationRequest.EmployeeEmail, invitationRequest.EmployeeName, restaurantId, ownerId);

            if (!request)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
