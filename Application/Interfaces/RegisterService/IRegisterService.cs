using Application.DTOs;

namespace Application.Interfaces.RegisterService
{
    public interface IRegisterService
    {
        Task<bool> RegisterOwner(RegisterRequestDTO dto);
    }
}
