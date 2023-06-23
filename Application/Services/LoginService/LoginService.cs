using Application.DTOs;
using Application.Interfaces;
using Application.Interfaces.LoginService;
using Application.Interfaces.Repository;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly ILoginServiceHelper _loginServiceHelper;

        public LoginService(ILoginServiceHelper loginServiceHelper)

        {
            _loginServiceHelper = loginServiceHelper;
        }

        public async Task<bool> VerifyRequest(UserLoginRequest request)
        {
            var result = await _loginServiceHelper.VerifyPassword(request);

            if (!result)
            {
                return false;
            }

            return true;
        }

        public async Task<string> GenerateToken(UserLoginRequest request)
        {
            return await _loginServiceHelper.GenerateToken(request);
        }
    }
}
