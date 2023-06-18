
using Application.DTOs;

namespace Application.Interfaces.LoginService
{
    public interface ILoginServiceHelper
    {
        Task<bool> VerifyPassword(UserLoginRequest request);
        Task<string> GenerateToken(UserLoginRequest request);
    }
}
