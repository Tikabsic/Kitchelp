using Application.DTOs;
using Application.Interfaces.RegisterService;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kitchelp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost("/RegisterOwner")]
        public async Task<ActionResult> RegisterOwner(RegisterRequest request)
        {
            var result = await _registerService.RegisterOwner(request);

            if (!result)
            {
                return BadRequest();
            }

            return Ok($"Welcome, {request.FirstName}!");
        }

        [HttpPost("/RegisterEmployee/{restaurantId}")]
        public async Task<ActionResult> RegisterEmployee([FromRoute] Guid restaurantId, RegisterRequest request)
        {
            var result = await _registerService.RegisterEmployee(request, restaurantId);

            if (!result)
            {
                return BadRequest();
            }

            return Ok($"Welcome, {request.FirstName}!");
        }

        [HttpPost("/RegisterRestaurant/{ownerId}")]
        [Authorize(policy: "RequireOwnerRole")]
        public async Task<ActionResult> RegisterRestaurant([FromRoute] Guid ownerId, RestaurantRegisterRequest request)
        {
            var result = await _registerService.RegisterRestaurant(ownerId, request);

            if (!result)
            {
                return BadRequest();
            }

            return Ok($"Restaurant {request.RestaurantName} has been added.");
        }
    }
}
