using Application.DTOs;

namespace Application.Interfaces.RegisterService
{
    public interface IRegisterService
    {
        Task<bool> RegisterOwner(RegisterRequestDTO dto);
        Task<bool> RegisterEmployee(RegisterRequestDTO dto, Guid restaurantId);
    }
}
