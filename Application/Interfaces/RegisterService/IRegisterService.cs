using Application.DTOs;

namespace Application.Interfaces.RegisterService
{
    public interface IRegisterService
    {
        Task<bool> RegisterOwner(RegisterRequest dto);
        Task<bool> RegisterEmployee(RegisterRequest dto, string invitationToken);
        Task<bool> RegisterRestaurant(Guid ownerId, RestaurantRegisterRequest dto);
    }
}
