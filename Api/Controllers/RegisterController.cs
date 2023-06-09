﻿using Application.DTOs;
using Application.Interfaces.RegisterService;
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
        public async Task<ActionResult> RegisterOwner(RegisterRequestDTO request)
        {
            var result = await _registerService.RegisterOwner(request);

            if (!result)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}