using Application.DTOs;

namespace Application.Interfaces.RegisterService
{
    public interface IRegisterServiceHelper
    {
        Task<bool> ValidateUserRequest(RegisterRequest dto);
        Task<bool> ValidateRestaurantRequest(RestaurantRegisterRequest dto);
        Task<bool> ValidateOwner(Guid ownerId);
        Task RegisterOwner(RegisterRequest dto);
        Task RegisterEmployee(RegisterRequest dto, Guid restaurantId);
        Task RegisterRestaurant(Guid ownerId, RestaurantRegisterRequest dto);
    }
}
