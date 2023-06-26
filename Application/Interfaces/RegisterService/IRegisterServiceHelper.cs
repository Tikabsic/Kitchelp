using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces.RegisterService
{
    public interface IRegisterServiceHelper
    {
        Task<bool> ValidateUserRequest(RegisterRequest dto);
        Task<bool> ValidateRestaurantRequest(RestaurantRegisterRequest dto);
        Task<bool> ValidateOwner(Guid ownerId);
        Task<InvitationToken> ValidateInvitationToken(string token);
        Task RegisterOwner(RegisterRequest dto);
        Task RegisterEmployee(RegisterRequest dto, InvitationToken invitationToken);
        Task RegisterRestaurant(Guid ownerId, RestaurantRegisterRequest dto);
    }
}
