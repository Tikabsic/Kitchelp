using Application.DTOs;

namespace Application.Interfaces.RegisterService
{
    public interface IRegisterServiceHelper
    {
        Task<bool> ValidateRequest(RegisterRequest dto);
        Task<bool> RegisterOwner(RegisterRequest dto);
        Task<bool> RegisterEmployee(RegisterRequest dto, Guid restaurantId);
        Task<bool> RegisterRestaurant(Guid ownerId, RestaurantRegisterRequest dto);
    }
}
