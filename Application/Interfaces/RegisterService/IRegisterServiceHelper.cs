using Application.DTOs;

namespace Application.Interfaces.RegisterService
{
    public interface IRegisterServiceHelper
    {
        Task<bool> ValidateRequest(RegisterRequestDTO dto);
        Task RegisterOwner(RegisterRequestDTO dto);
        Task RegisterEmployee(RegisterRequestDTO dto, Guid restaurantId);
    }
}
