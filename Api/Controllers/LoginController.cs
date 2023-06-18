using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces.LoginService;
using Application.DTOs;

namespace Kitchelp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet("/login")]
        public async Task<ActionResult> LoginUser(UserLoginRequest dto)
        {
            var request = await _loginService.VerifyRequest(dto);

            if (!request)
            {
                return BadRequest();
            }

            var token = await _loginService.GenerateToken(dto);

            return Ok(token);
        }
    }
}
