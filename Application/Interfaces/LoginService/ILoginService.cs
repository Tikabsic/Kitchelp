
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces.LoginService
{
    public interface ILoginService
    {
        Task<bool> VerifyRequest(UserLoginRequest request);
        Task<string> GenerateToken(UserLoginRequest request);
    }
}
