using Application.DTOs;

namespace Application.Interfaces.RegisterService
{
    public interface IRegisterServiceHelper
    {
        Task<bool> ValidateRequest(RegisterRequestDTO dto);
        Task<bool> RegisterOwner(RegisterRequestDTO dto);
        Task<bool> RegisterEmployee(RegisterRequestDTO dto, Guid restaurantId);
    }
}
